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
        public async Task<List<Client>> GetClientsAsnyc()
        {
            return await database.Table<Client>().ToListAsync();
        }

        public Task<Client> GetItemAsync(int id)
        {
            return database.Table<Client>()
                .Where(f => f.ID == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Client item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Client item)
        {
            return database.DeleteAsync(item);
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