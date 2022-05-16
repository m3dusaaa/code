using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfApp1.Add;
using WpfApp1.Tools;


namespace WpfApp1.VM
{
    class MainVM : BaseVM
    {
        CurrentPageControl currentPageControl;

        public Page CurrentPage
        {
            get => currentPageControl.Page;
        }

        public CommandVM CreateClient { get; set; }
        public CommandVM ViewClients { get; set; }
        public CommandVM CreateOperator { get; set; }
        public CommandVM ViewOperators { get; set; }

        public CommandVM CreateOplata { get; set; }
        public CommandVM ViewOplata { get; set; }
        public CommandVM CreateTour { get; set; }
        public CommandVM ViewTour { get; set; }

        public MainVM()
        {
            currentPageControl = new CurrentPageControl();
            currentPageControl.PageChanged += CurrentPageControl_PageChanged;

            CreateClient = new WpfApp1.Tools.CommandVM(() => {
                new AddClient(new AddClientVM(currentPageControl)).Show();
            });

            ViewClients = new CommandVM(() => {
                currentPageControl.SetPage(new ViewClient());
            });
            CreateOperator = new CommandVM(() => {
                new AddOperator(new AddOperatorsVM(currentPageControl)).Show();
            });

            ViewOperators = new CommandVM(() =>
            {
                currentPageControl.SetPage(new ViewOperator());
            });
            CreateOplata = new CommandVM(() => {
                new AddOplata(new AddOplataVM(currentPageControl)).Show();
            });

            ViewOplata = new CommandVM(() =>
            {
                currentPageControl.SetPage(new ViewOplata());
            });
            CreateTour = new CommandVM(() => {
                new AddTour(new AddToursVM(currentPageControl)).Show();
            });

            ViewTour = new CommandVM(() =>
            {
                currentPageControl.SetPage(new ViewTour());
            });
        }

        private void CurrentPageControl_PageChanged(object sender, EventArgs e)
        {
            Signal(nameof(CurrentPage));
        }
    }
}