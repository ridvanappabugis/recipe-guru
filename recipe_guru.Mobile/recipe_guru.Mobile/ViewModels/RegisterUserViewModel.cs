using recipe_guru.Model;
using recipe_guru.Model.Requests;
using recipe_guru.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace recipe_guru.Mobile.ViewModels
{
    public class RegisterUserViewModel : BaseViewModel
    {
        private readonly APIService _serviceUser = new APIService("Korisnici");

        public RegisterUserViewModel()
        {
            RegisterCommand = new Command(async () => await Register());
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public ICommand RegisterCommand { get; set; }

        async Task Register()
        {
            try
            {
                if (Password != PasswordConfirm)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Passwords are not matched.", "Try again");
                    return;
                }
                var listUsers = await _serviceUser.Get<List<Model.Korisnik>>(null);
                foreach (var item in listUsers)
                {
                    if (Username == item.KorisnickoIme)
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "Username already exist.", "Try again");
                        return;
                    }
                }
                var newUser = await _serviceUser.Insert<Model.Korisnik>(new KorisniciInsertRequest
                {
                    Ime = FirstName,
                    Prezime = LastName,
                    Email = Email,
                    Telefon = Phone,
                    Password = Password,
                    PasswordPotvrda = PasswordConfirm,
                    KorisnickoIme = Username,
                    UlogaId = 2
                });

                if (newUser == default(Korisnik))
                    return;

                await Application.Current.MainPage.DisplayAlert("Registred succesfully.", "Now just log in.", "OK");
                await Application.Current.MainPage.Navigation.PushModalAsync(new LoginPage());
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Try again");
            }
        }
    }
}
