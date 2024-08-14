using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiasCRUD5363922
{
    public class LocalDBService
    {
        private const string DB_NAME = "demo_local_db.db3";
        private readonly SQLiteAsyncConnection _connection;

        public LocalDBService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory,DB_NAME));

            _connection.CreateTableAsync<CalculoD>();
        }

        public async Task<List<CalculoD>> GetCalculoD()
        {
            return await _connection.Table<CalculoD>().ToListAsync();
        }

        public async Task<CalculoD> GetById(int id)
        {
            return await _connection.Table<CalculoD>().Where(x=>x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Create(CalculoD calculoD)
        {
            await _connection.InsertAsync(calculoD);
        }
        public async Task Update(CalculoD calculoD)
        {
            await _connection.UpdateAsync(calculoD);
        }
        public async Task Delete(CalculoD calculoD)
        {
            await _connection.DeleteAsync(calculoD);
        }
    }
}
