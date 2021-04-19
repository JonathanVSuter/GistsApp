using GistApp.ExtractModels;
using GistApp.LocalDataContext;
using GistApp.Models;
using GistApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GistApp.ViewModels
{
    public class GistViewModel : GenericViewModel<PostGistItem>
    {
        private readonly GistService Service;
        private readonly GistLocalDB GistLocalDB;
        private readonly string Url = "https://api.github.com/";

        private string _NameSearch;
        public string NameSearch 
        {
            get 
            {
                return _NameSearch;
            }
            set 
            {
                _NameSearch = value;
            }
        }
        public int CountFiles 
        {
            get 
            {
                return Item.Files.Count();
            }  
        }
        public string Title 
        {
            get 
            {
                return "Gists";
            }
        }
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
            GistLocalDB = new GistLocalDB();
        }
        public GistViewModel(bool activateService = true, bool activateGistLocal=true)
        {
            if(activateService)
            {
                Service = new GistService(Url);
            }
            if(activateGistLocal)
            {
                GistLocalDB = new GistLocalDB();
            }
        }
        public GistViewModel(int itensperpage, int pagenumber, string url)
        {
            if(!string.IsNullOrEmpty(url) && itensperpage>0 && pagenumber>0)
            {
                ItensPerPage = itensperpage;
                Page = pagenumber;
                Url = url;
                Service = new GistService(Url);
                GistLocalDB = new GistLocalDB();                
            }
            else
            {
                Service = new GistService(Url);
                GistLocalDB = new GistLocalDB();                
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
        public void SaveGistLocal(PostGistItem item)
        {
            if(item!=null)
            {
                GistLocalDB.Add(item);
            }
        }
        public void LoadGistsFromLocal() 
        {
            LoadItens(GistLocalDB.GetAll());
        }
        public void LoadGistsByName() 
        {
            //this is not the best way, cleaning Item's list, but i not found another way.
            if(!string.IsNullOrEmpty(NameSearch))
            {
                Items.Clear();
                LoadItens(GistLocalDB.GetBy(x => x.Owner.Login.Contains(NameSearch)));
            }
            else
            {
                if(Items.Any())
                {
                    Items.Clear();
                }
                LoadGistsFromLocal();
            }
        }

    }
}
