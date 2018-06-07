using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using ClientApp.Model;
using System.Threading.Tasks;

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

        public Task<Client> GetClientAsync(int id)
        {
            return database.Table<Client>().Where(f =>f.ID == id). FirstOrDefaultAsync();
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
            public Task<int> DeleteClientAsync(Client client)
        {
            return database.DeleteAsync(client);
        }



    }
}
