using GistApp.DBModels;
using GistApp.Helpers;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GistApp.LocalDataContext
{
    public class BaseDB<T> : IDataBaseOperations<T> where T : IBaseDBModel, new() 
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<T> Instance = new AsyncLazy<T>(async () =>
        {
            T instance = (T)Activator.CreateInstance(typeof(T), Array.Empty<object>());
            CreateTableResult result = await Database.CreateTableAsync<T>();
            return instance;
        });
        public BaseDB()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }
        public Task<List<T>> GetItemsAsync()
        {
            return Database.Table<T>().ToListAsync();
        }
        public Task<T> GetItemAsync(int id)
        {
            return Database.Table<T>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public Task<int> SaveItemAsync(T item)
        {
            if(item.Id!=0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }
        public Task<int> DeleteItemAsync(T item)
        {
            return Database.DeleteAsync(item);
        }
    }
}
