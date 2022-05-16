using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.DTO;
using WpfApp1.Model;
using WpfApp1.Tools;

namespace WpfApp1
{

   public class ViewClientVM : BaseVM
    {
        private List<Client> clients;
        private List<int> pageIndexes;
        private int selectedIndex;
        private int viewRowsCount;

        public List<Client> Clients
        {
            get => clients;
            set
            {
                clients = value;
                Signal();
            }
        }
        public CommandVM ViewBack { get; set; }
        public CommandVM ViewForward { get; set; }
        public List<int> PageIndexes
        {
            get => pageIndexes;
            set
            {
                pageIndexes = value;
                Signal();
            }
        }
        public int SelectedIndex
        {
            get => selectedIndex;
            set
            {
                selectedIndex = value;
                Clients = SqlModel.GetInstance().SelectAllClients();
                Signal();
            }
        }
        public int[] RowsCountVariants { get; set; }
        public int ViewRowsCount
        {
            get => viewRowsCount;
            set
            {
                viewRowsCount = value;
                InitPages();
                Signal();
            }
        }

        public ViewClientVM()
        {
            RowsCountVariants = new int[] { 2, 5, 10 };
            ViewRowsCount = 5;

            ViewBack = new CommandVM(() =>
            {
                if (SelectedIndex > 1)
                    SelectedIndex--;
            });

            ViewForward = new CommandVM(() =>
            {
                if (SelectedIndex < PageIndexes.Last())
                    SelectedIndex++;
            });
        }

        private void InitPages()
        {
            var sqlModel = SqlModel.GetInstance();
            int pageCount = (sqlModel.GetNumRows(typeof(Client)) / ViewRowsCount) + 1;
            PageIndexes = new List<int>(Enumerable.Range(1, pageCount));
            SelectedIndex = 1;
        }
    }
}   

