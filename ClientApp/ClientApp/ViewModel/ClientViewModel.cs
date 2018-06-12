using ClientApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ClientApp.ViewModel
{
    public class ClientViewModel
    {
        public Command SaveClientCommand { get; set; }

        public Client ClientModel { get; set; }

        private INavigation Navigation;

        public ClientViewModel(INavigation navigation)
        {
            ClientModel = new Client();
            SaveClientCommand = new Command(async () => await SaveClient());
            Navigation = navigation;
        }
        public ClientViewModel(INavigation navigation, Client client)
        {
            ClientModel = client;
            SaveClientCommand = new Command(async () => await SaveClient());
            Navigation = navigation;
        }

        public async Task SaveClient()
        {
            await App.Database.SaveItemAsync(ClientModel);
            await Navigation.PopToRootAsync();
        }
    }
}