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
    public partial class FavoriteListPage : ContentPage
    {
        private readonly GistViewModel Context;
        public FavoriteListPage()
        {
            InitializeComponent();
            BindingContext = Context = new GistViewModel(false);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (!Context.Items.Any())
            {
                Context.LoadGistsFromLocal();
            }
        }
        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            Context.LoadGistsByName();
        }
        private async void CustomCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((!string.IsNullOrEmpty(Context.Item.Id)))
            {
                FavoriteDetailPage gistDetailPage = new FavoriteDetailPage(Context);
                await Navigation.PushAsync(gistDetailPage).ConfigureAwait(true);
            }
        }
    }
}