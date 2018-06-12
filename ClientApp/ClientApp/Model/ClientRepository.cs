using ClientApp.Helpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ClientApp.Model
{

    public class ClientRepository
    {
        #region Propiedades
        public IList<Client> Clients { get; set; }
        #endregion
        public ClientRepository()
        {
            Task.Run(async () =>
            Clients = await App.Database.GetClientsAsnyc()).Wait();
        }

        public IList<Client> GetAll()
        {
            return Clients;
        }

        public ObservableCollection<Grouping<string, Client>> GetAllGrouped()
        {
            IEnumerable<Grouping<string, Client>> sorted = new Grouping<string, Client>[0];

            if (Clients != null)
            {

                sorted =
                from f in Clients
                orderby f.Nombre
                group f by f.Nombre[0].ToString()
                into theGroup
                select
                new Grouping<string, Client>
                (theGroup.Key, theGroup);
            }


            return new ObservableCollection<Grouping<string, Client>>(sorted);
        }
    }
}