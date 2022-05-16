using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Add;
using WpfApp1.DTO;
using WpfApp1.Model;
using WpfApp1.Tools;

namespace WpfApp1.VM
{
    public class AddOplataVM
    {
        public Oplata AddOplata { get; set; }
        public CommandVM SaveOplata { get; set; }

        private CurrentPageControl currentPageControl;
        public AddOplataVM(CurrentPageControl currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            AddOplata = new Oplata();
            InitCommand();
        }
        public AddOplataVM(AddOplata AddOplata, CurrentPageControl currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            AddOplata = AddOplata;
            InitCommand();
        }

        public AddOplataVM()
        {
        }

        private void InitCommand()
        {
            SaveOplata = new CommandVM(() =>
            {
                var model = SqlModel.GetInstance();
                if (AddOplata.ID == 0)
                    model.Insert(AddOplata);
                else
                    model.Update(AddOplata);
                currentPageControl.Back();
            });
        }



    }
}