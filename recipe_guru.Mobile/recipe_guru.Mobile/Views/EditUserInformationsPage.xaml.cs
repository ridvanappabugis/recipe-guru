using recipe_guru.Model;
using recipe_guru.Model.Requests;
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
    public partial class EditUserInformationsPage : ContentPage
    {
        private readonly APIService _serviceUser = new APIService("Korisnik");

        public EditUserInformationsPage()
        {
            InitializeComponent();
            FirstName.Text = APIService.User.Ime;
            LastName.Text = APIService.User.Prezime;
            Email.Text = APIService.User.Email;
            Phone.Text = APIService.User.Telefon;
            Username.Text = APIService.User.KorisnickoIme;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(FirstName.Text) || string.IsNullOrWhiteSpace(LastName.Text) ||
                   string.IsNullOrWhiteSpace(Email.Text) || string.IsNullOrWhiteSpace(Phone.Text)
                   || string.IsNullOrWhiteSpace(Username.Text))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "All fields are required.", "Try again");
                    return;
                }

                if (Username.Text.Length < 4)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Username must have minimum 4 characthers.", "Try again");
                    return;
                }

                var listUsers = await _serviceUser.Get<List<Model.Korisnik>>(null);
                foreach (var item in listUsers)
                {
                    if (Username.Text == item.KorisnickoIme && APIService.Username != item.KorisnickoIme)
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "Username already exist.", "Try again");
                        return;
                    }
                }

                var newUser = await _serviceUser.Update<Korisnik>(APIService.UserId, new KorisniciInsertRequest
                {
                    KorisnickoIme = Username.Text,
                    Ime = FirstName.Text,
                    Prezime = LastName.Text,
                    Email = Email.Text,
                    Telefon = Phone.Text,
                    UlogaId = 2
                });


                if(newUser == default(Korisnik))
                    return;

                APIService.Password = Username.Text;
                await Application.Current.MainPage.DisplayAlert("Succesfull", "Succesfully changed, please log in to confirm changes.", "OK");
                await Navigation.PushAsync(new LoginPage());
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Something went wrong.", "Try again");
            }
        }
    }
}