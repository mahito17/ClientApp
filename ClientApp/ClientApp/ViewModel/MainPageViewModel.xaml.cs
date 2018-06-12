using ClientApp.Helpers;
using ClientApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ClientApp.ViewModel
{
    public class MainPageViewModel : Notificable
    {
        private ClientRepository clientRepository;

        public ObservableCollection<Grouping<string, Client>> Clients { get; }
        public ObservableCollection<Grouping<string, Client>> Friends { get; set; }
        public Command AddClientCommand
        {
            get;
            set;
        }
        public Command SearchCommand
        {
            get;
            set;
        }
        private string filter;
        private string Filter
        {
            get
            {
                return filter;
            }
            set
            {
                SetValue(ref filter, value);
            }
        }

        private void SetValue(ref string filter, string value)
        {
            throw new NotImplementedException();
        }

        public Command ItemTappedCommand
        {
            get;
            set;
        }
        private Client currentClient;
        public Client CurrentClient
        {
            get
            {
                return currentClient;
            }
            set
            {
                SetValue(ref currentClient, value);
            }
        }

        private void SetValue(ref Client currentClient, Client value)
        {
            throw new NotImplementedException();
        }

        private INavigation Navigation;

        public MainPageViewModel(INavigation navigation)
        {
            clientRepository = new ClientRepository();
            Clients = clientRepository.GetAllGrouped();
            Navigation = navigation;
            AddClientCommand = new Command(async () => await AddClient());
            SearchCommand = new Command(async () => await Search());
            ItemTappedCommand = new Command(async () => await NavigateToEditClientView());

        }

        private Task Search()
        {
            throw new NotImplementedException();
        }

        public async Task AddClient()
        {
            await Navigation.PushAsync(new ClientPage());

        }
        public async Task NavigateToEditClientView()
        {
            await Navigation.PushAsync(new ClientPage(CurrentClient));
        }
    }
}