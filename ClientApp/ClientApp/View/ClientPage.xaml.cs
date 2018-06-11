using ClientApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClientApp.ViewModel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientPage : ContentPage
    {
        public ClientPage(Client client = null)
        {
            InitializeComponent();
            if (client == null)
            {
                this.BindingContext = new ClientViewModel(Navigation);
            }
            else
            {
                this.BindingContext = new ClientViewModel(Navigation, client);
            }
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }
    }
}