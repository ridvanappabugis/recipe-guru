using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace recipe_guru.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class YourProfilePage : ContentPage
    {
        private readonly APIService _serviceUser = new APIService("Korisnik");

        public YourProfilePage()
        {
            InitializeComponent();
            Username.Text = APIService.User.KorisnickoIme;
            FirstName.Text = APIService.User.Ime;
            LastName.Text = APIService.User.Prezime;
            Email.Text = APIService.User.Email;
            Phone.Text = APIService.User.Telefon;
            Description.Text = APIService.User.Deskripcija;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditUserInformationsPage());
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewPasswordPage());
        }
    }
}
