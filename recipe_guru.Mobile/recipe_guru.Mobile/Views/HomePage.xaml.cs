using recipe_guru.Model.Requests;
using recipe_guru.Mobile.ViewModels;
using recipe_guru.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace recipe_guru.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public HomeViewModel model = null;

        public Home()
        {
            InitializeComponent();
            BindingContext = model = new HomeViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        public async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            KnjigaRecepataListViewItem item = (KnjigaRecepataListViewItem)e.SelectedItem;

            await Navigation.PushModalAsync(new KnjigaRecepataPage(item.Id, item.Naziv));
        }
    }


}