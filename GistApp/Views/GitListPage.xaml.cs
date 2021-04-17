using GistApp.Models;
using GistApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GistApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GitListPage : ContentPage
    {
        private readonly GistViewModel Context;
        public GitListPage()
        {
            InitializeComponent();
            BindingContext = Context = new GistViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            if(!Context.Items.Any())
            {
                await Context.GetGists(6, 1).ConfigureAwait(true);
            }
        }
        private async void CustomCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((!string.IsNullOrEmpty(Context.Item.Id)))
            {
                GitDetailPage gistDetailPage = new GitDetailPage(Context);
                await Navigation.PushAsync(gistDetailPage).ConfigureAwait(true);
            }
            /*
            PostGistItem item = (PostGistItem)e.CurrentSelection.FirstOrDefault();
            if (item!=null && (!string.IsNullOrEmpty(item.Id)))
            {
                Context.Item = item;
                GitDetailPage gistDetailPage = new GitDetailPage(Context);
                await Navigation.PushAsync(gistDetailPage).ConfigureAwait(true);
            }*/
        }
        private async void CustomCollectionView_RemainingItemsThresholdReached(object sender, EventArgs e)
        {
            await Context.GetMoreGists().ConfigureAwait(true);
        }
    }
}