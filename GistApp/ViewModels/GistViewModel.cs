using GistApp.ExtractModels;
using GistApp.Models;
using GistApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GistApp.ViewModels
{
    public class GistViewModel : BaseViewModel<PostGistItem>
    {
        public string Title 
        {
            get 
            {
                return "Gists";
            }
        }
        private readonly GistService Service;
        private string Url = "https://api.github.com/";
        private int _ItensPerPage;
        public int ItensPerPage 
        {
            get 
            {
                return _ItensPerPage;
            }
            set 
            {
                Set(ref _ItensPerPage, value);
            }
        }
        private int _Page;
        public int Page
        {
            get 
            {
                return _Page;
            }
            set 
            {
                Set(ref _Page, value);
            }
        }
        public GistViewModel() 
        {
            Service = new GistService(Url);            
        }
        public GistViewModel(int itensperpage, int pagenumber, string url)
        {
            if(!string.IsNullOrEmpty(url) && itensperpage>0 && pagenumber>0)
            {
                ItensPerPage = itensperpage;
                Page = pagenumber;
                Url = url;
            }
            else
            {
                Service = new GistService(Url);
            }
        }
        public async Task GetGists(int itensperpage, int initialpagenumber) 
        {
            if(itensperpage>0 && initialpagenumber>0)
            {
                if (_ItensPerPage == 0 && Page == 0)
                {
                    ItensPerPage = itensperpage;
                    Page = initialpagenumber;
                }
                LoadItens(await Service.GetItemsAsync($"gists?per_page={ItensPerPage}&page={Page}").ConfigureAwait(true));
            }
        }
        public async Task GetMoreGists()
        {
            Page++;
            LoadItens(await Service.GetItemsAsync($"gists?per_page={ItensPerPage}&page={Page}").ConfigureAwait(true));
        }
        public async Task GetAllGists()
        {
            LoadItens(await Service.GetItemsAsync("gists").ConfigureAwait(true));
        }

    }
}
