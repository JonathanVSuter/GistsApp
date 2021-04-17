using GistApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GistApp.Services
{
    public class BaseClientService<T> : IClientService<T> where T : class
    {
        private readonly HttpClient _HttpClient;
        private readonly string _remoteServiceBaseUrl;
        private readonly JsonSerializerOptions serializerOptions;        
        public BaseClientService(string uri)
        {   
            if(!string.IsNullOrEmpty(uri))
            {
                _remoteServiceBaseUrl = uri;
                _HttpClient = new HttpClient
                {
                    BaseAddress = new Uri(_remoteServiceBaseUrl)
                };
                _HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/Json"));
                //just for gist use
                _HttpClient.DefaultRequestHeaders.Add("User-Agent", "request");
            }                      
            serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }
        public Task<bool> AddItemAsync(T item)
        {
            throw new NotImplementedException();
        }
        public Task<bool> AddItemAsync(T item, string url)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }        public Task<bool> DeleteItemAsync(string id, string url)
        {
            throw new NotImplementedException();
        }
        public Task<T> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }
        public Task<T> GetItemAsync(string id, string url)
        {
            throw new NotImplementedException();
        }
        public async Task<List<T>> GetItemsAsync(string url)
        {
            List<T> baseModels;
            try
            {
                if(!string.IsNullOrEmpty(url))
                {
                    HttpResponseMessage response = await _HttpClient.GetAsync(url).ConfigureAwait(true);
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync().ConfigureAwait(true);
                        baseModels = JsonSerializer.Deserialize<List<T>>(content, serializerOptions);
                        return baseModels;
                    }
                    else if(response.StatusCode==System.Net.HttpStatusCode.Forbidden)
                    {
                        throw new HttpRequestException("Request limit reached");
                    }
                    else
                    {
                        throw new HttpRequestException("Request not made. See details");
                    }
                }
                else
                {
                    throw new ArgumentException("Url is empty, please pass an valid Url.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                throw ex;
            }            
        }

        public Task<List<T>> GetItemsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> RefreshDataAsync()
        {
            throw new NotImplementedException();
        }
        public Task<bool> UpdateItemAsync(T item)
        {
            throw new NotImplementedException();
        }
        public Task<bool> UpdateItemAsync(T item, string url)
        {
            throw new NotImplementedException();
        }
    }
}
