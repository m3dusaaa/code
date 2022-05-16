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
using WpfApp1.Tools;
using WpfApp1.Add;
using WpfApp1.VM;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для AddOperator.xaml
    /// </summary>
    public partial class AddOperator : Window
    {
        private CurrentPageControl currentPageControl;

        public AddOperator(AddOperatorsVM vm)
        {
            InitializeComponent();
            DataContext = vm;
        }

        public AddOperator(CurrentPageControl currentPageControl)
        {
            InitializeComponent();
            this.currentPageControl = currentPageControl;
        }
    }
}
