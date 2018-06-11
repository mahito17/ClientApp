using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Model
{
    public class ClientRepository
    {
        public IList<Client> Clients { get; set; }

        public ClientRepository()
        {
            Task.Run(async () =>
                Clients = await App.Database.GetClientAsync()).Wait();
        }
        public IList<Client> GetAll()
        {
            return Clients;
        }
    }
}
