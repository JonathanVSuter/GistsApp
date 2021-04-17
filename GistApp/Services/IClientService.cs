using GistApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GistApp.Services
{
    public interface IClientService<T> where T : class
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<List<T>> GetItemsAsync();
        Task<bool> AddItemAsync(T item,string url);
        Task<bool> UpdateItemAsync(T item, string url);
        Task<bool> DeleteItemAsync(string id,string url);
        Task<T> GetItemAsync(string id, string url);
        Task<List<T>> GetItemsAsync(string url);
        Task<List<T>> RefreshDataAsync();
    }
}
