using System;
using System.Collections.Generic;
using SQLite;
using ClientApp.Model;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ClientApp.Helpers;

namespace ClientApp.Data
{
    public class ClientDatabase
    {
        private readonly SQLiteAsyncConnection database;
        public ClientDatabase(string dbPatch)
        {
            database = new SQLiteAsyncConnection(dbPatch);
            database.CreateTableAsync<Client>().Wait();
        }

        internal Task<IList<Client>> GetClientAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Client>> GetClientsAsnyc()
        {
            return await database.Table<Client>().ToListAsync();
        }

        public Task<Client> GetClientAsync(int id)
        {
            return database.Table<Client>().Where(f => f.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveClientAsync(Client client)
        {
            if (client.ID != 0)
            {
                return database.UpdateAsync(client);
            }
            else
            {
                return database.InsertAsync(client);
            }
        }

        internal Task SaveFriendAsync(Client clientModel)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteClientAsync(Client client)
        {
            return database.DeleteAsync(client);
        }

        public
        ObservableCollection
        <Grouping<string, Client>>
        GetAllGrouped()
        {
            IEnumerable<Grouping<string, Client>> sorted = new Grouping<string, Client>[0];

            if (Clients != null)
            {
                sorted =
                from f in Clients
                orderby f.FirstName
                group f by f.FirstName[0].ToString()
                into theGroup
                select
                new Grouping<string, Client>
                (theGroup.Key, theGroup);
            }
            return new
                ObservableCollection
                <Grouping<string, Client>>(sorted);


        }
    }

}