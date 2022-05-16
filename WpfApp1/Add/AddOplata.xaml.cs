using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Add;
using WpfApp1.Tools;
using WpfApp1.VM;

namespace WpfApp1.Add
{
    /// <summary>
    /// Логика взаимодействия для AddOplata.xaml
    /// </summary>
    public partial class AddOplata : Window
    {
        private CurrentPageControl currentPageControl;

        public AddOplata(AddOplataVM vm)
        {
            InitializeComponent();
            DataContext = vm;
        }

        public AddOplata(CurrentPageControl currentPageControl)
        {
            InitializeComponent();
            this.currentPageControl = currentPageControl;
        }
    }
}
