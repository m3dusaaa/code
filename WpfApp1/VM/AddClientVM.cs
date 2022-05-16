using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.DTO;
using WpfApp1.Add;
using WpfApp1.Tools;
using WpfApp1.Model;

namespace WpfApp1
{
        public class AddClientVM
        {
            public Client AddClient { get; set; }
            public CommandVM SaveClient { get; set; }

            private CurrentPageControl currentPageControl;
            public AddClientVM(CurrentPageControl currentPageControl)
            {
                this.currentPageControl = currentPageControl;
                AddClient = new Client();
                InitCommand();
            }
            public AddClientVM(Client AddClient, CurrentPageControl currentPageControl)
            {
                this.currentPageControl = currentPageControl;
                AddClient = AddClient;
                InitCommand();
            }


        private void InitCommand()
            {
                SaveClient = new CommandVM(() =>
                {
                    var model = SqlModel.GetInstance();
                    if (AddClient.ID == 0)
                        model.Insert(AddClient);
                    else
                        model.Update(AddClient);
                    currentPageControl.Back();
                });
            }



        }
    }
