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
    public partial class GitDetailPage : ContentPage
    {
        private readonly GistViewModel Context;
        public GitDetailPage(GistViewModel gistViewModel) 
        {
            InitializeComponent();
            if(gistViewModel!=null)
            {
                BindingContext= Context = gistViewModel;
            }
        }
        public GitDetailPage()
        {
            InitializeComponent();
        }
    }
}