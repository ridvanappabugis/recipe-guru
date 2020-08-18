using System;
using System.Collections.Generic;
using recipe_guru.Mobile.Models;
using recipe_guru.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace recipe_guru.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReceptiPretragaPage : ContentPage
    {
        public ReceptPretragaViewModel model = null;

        public ReceptiPretragaPage()
        {
            InitializeComponent();
            BindingContext = model = new ReceptPretragaViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        public async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ReceptListViewItem item = (ReceptListViewItem)e.SelectedItem;

            await Navigation.PushModalAsync(new RecipePage(item.Id));
        }
    }
}
