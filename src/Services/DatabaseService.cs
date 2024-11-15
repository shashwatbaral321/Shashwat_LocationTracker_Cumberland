using LocationTracker.Models;
using SQLite;
using System.IO;

namespace LocationTracker.Services
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection _database;

        public DatabaseService()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "locations.db3");
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<LocationModel>().Wait();
        }

        public Task<int> SaveLocationAsync(LocationModel location) => _database.InsertAsync(location);

        public Task<List<LocationModel>> GetLocationsAsync() => _database.Table<LocationModel>().ToListAsync();
    }
}
