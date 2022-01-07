using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using Proiect_Medii_Masaj.Models;

namespace Proiect_Medii_Masaj.Data
{
    public class AppointmentListDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public AppointmentListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<AppointmentList>().Wait();
            _database.CreateTableAsync<Client>().Wait();
            _database.CreateTableAsync<ListClient>().Wait();
        }

        public Task<int> SaveClientAsync(Client client)
        {
            if (client.ID != 0)
            {
                return _database.UpdateAsync(client);
            }
            else
            {
                return _database.InsertAsync(client);
            }
        }
        public Task<int> DeleteClientAsync(Client client)
        {
            return _database.DeleteAsync(client);
        }
        public Task<List<Client>> GetClientsAsync()
        {
            return _database.Table<Client>().ToListAsync();
        }

        public Task<List<AppointmentList>> GetAppointmentListsAsync()
        {
            return _database.Table<AppointmentList>().ToListAsync();
        }
        public Task<AppointmentList> GetAppointmentListAsync(int id)
        {
            return _database.Table<AppointmentList>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveAppointmentListAsync(AppointmentList alist)
        {
            if (alist.ID != 0)
            {
                return _database.UpdateAsync(alist);
            }
            else
            {
                return _database.InsertAsync(alist);
            }
        }
        public Task<int> DeleteAppointmentListAsync(AppointmentList alist)
        {
            return _database.DeleteAsync(alist);
        }

        public Task<int> SaveListClientAsync(ListClient listc)
        {
            if (listc.ID != 0)
            {
                return _database.UpdateAsync(listc);
            }
            else
            {
                return _database.InsertAsync(listc);
            }
        }
        public Task<List<Client>> GetListClientsAsync(int appointmentlistid)
        {
            return _database.QueryAsync<Client>(
            "select C.ID, C.Description from Client C"
            + " inner join ListClient LC"
            + " on C.ID = LC.ClientID where LC.AppointmentListID = ?",
            appointmentlistid);
        }

    }
}
