using recipe_guru.Mobile.Converters;
using recipe_guru.Mobile.Models;
using recipe_guru.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace recipe_guru.Mobile.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly APIService _KnjigeRecepataService = new APIService("KnjigaRecepata");
        private readonly APIService _ImageResourceService = new APIService("ImageResource");

        public ObservableCollection<KnjigaRecepataListViewItem> Knjige { get; set; } = new ObservableCollection<KnjigaRecepataListViewItem>();

        public HomeViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            Knjige.Clear();

            var lista = await _KnjigeRecepataService.Get<List<KnjigaRecepata>>(new Model.Requests.KnjigaRecepataSearchRequest
            {
                KorisnikId = APIService.UserId
            });

            foreach (var knjiga in lista)
            {
                Model.ImageResource imageResource = await _ImageResourceService.GetById<Model.ImageResource>(knjiga.ImageResourceId);

                Knjige.Add(new KnjigaRecepataListViewItem {
                    Id = knjiga.Id,
                    Naziv = knjiga.Naziv,
                    Deskripcija = knjiga.Deskripcija,
                    Image = imageResource != null ? new ImageConverter().Convert(imageResource.ImageByteValue) : "notfound.png"
                });
            }
        }
    }
}
