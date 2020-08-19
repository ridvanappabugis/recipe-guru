using System;
using System.Collections.Generic;
using recipe_guru.Mobile.Models;
using recipe_guru.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace recipe_guru.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KnjigaRecepataPage : ContentPage
    {
        public KnjigaRecepataViewModel model = null;

        public KnjigaRecepataPage(int KnjigaId, string naziv)
        {
            InitializeComponent();
            BindingContext = model = new KnjigaRecepataViewModel(KnjigaId, naziv);
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

        public async void OnButtonClicked(object sender, EventArgs e)
        {
        }
    }
}
