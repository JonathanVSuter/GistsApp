using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GistApp.LocalDataContext
{
    interface IDataBaseOperations<T>
    {
        Task<List<T>> GetItemsAsync();
        Task<T> GetItemAsync(int id);
        Task<int> SaveItemAsync(T item);
        Task<int> DeleteItemAsync(T item);
    }
}
