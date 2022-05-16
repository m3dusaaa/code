using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfApp1.Add;

namespace WpfApp1.Tools
{
    public class CurrentPageControl
    {
        Stack<Page> pages = new Stack<Page>();

        public Page Page { get; internal set; }
        public event EventHandler PageChanged;

        internal void SetPage(Page optionPage)
        {
            if (Page != null)
                pages.Push(Page);
            Page = optionPage;
            PageChanged?.Invoke(this, new EventArgs());
        }

        internal void Back()
        {
            if (pages.Count > 0)
                Page = pages.Pop();
            else
                Page = null;
            PageChanged?.Invoke(this, new EventArgs());
        }

        internal void SetPage(ViewTour viewTour)
        {
            throw new NotImplementedException();
        }

        internal void SetPage(AddTour addTour)
        {
            throw new NotImplementedException();
        }

        internal void SetPage(ViewOplata viewOplata)
        {
            throw new NotImplementedException();
        }

        internal void SetPage(AddClient addClient)
        {
            throw new NotImplementedException();
        }

        internal void SetPage(ViewClient viewClient)
        {
            throw new NotImplementedException();
        }

        internal void SetPage(ViewOperator viewOperator)
        {
            throw new NotImplementedException();
        }

        internal void SetPage(AddOperator addOperator)
        {
            throw new NotImplementedException();
        }
    }
}
