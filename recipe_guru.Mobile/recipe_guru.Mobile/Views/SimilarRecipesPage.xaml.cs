using System;
using System.Collections.Generic;
using recipe_guru.Mobile.Models;
using recipe_guru.Mobile.ViewModels;
using Xamarin.Forms;

namespace recipe_guru.Mobile.Views
{
    public partial class SimilarRecipesPage : ContentPage
    {

        public SimilarRecipesViewModel model = null;

        public SimilarRecipesPage(int KnjigaId, int KategorijaId, string naziv)
        {
            InitializeComponent();
            BindingContext = model = new SimilarRecipesViewModel(KnjigaId, KategorijaId, naziv);
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
