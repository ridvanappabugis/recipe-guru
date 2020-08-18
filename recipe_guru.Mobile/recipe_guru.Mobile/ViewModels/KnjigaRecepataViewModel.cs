using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using recipe_guru.Mobile.Converters;
using recipe_guru.Mobile.Models;
using recipe_guru.Model;
using Xamarin.Forms;

namespace recipe_guru.Mobile.ViewModels
{
    public class KnjigaRecepataViewModel : BaseViewModel
    {
        private readonly APIService _ReceptService = new APIService("Recept");
        private readonly APIService _ImageResourceService = new APIService("ImageResource");

        public ObservableCollection<ReceptListViewItem> Recepti { get; set; } = new ObservableCollection<ReceptListViewItem>();

        private int KnjigaId { get; set; }
        public string NazivKnjige { get; set; }

        public KnjigaRecepataViewModel(int KnjigaRecepataId, string naziv)
        {
            KnjigaId = KnjigaRecepataId;
            NazivKnjige = naziv;
        }

        internal async Task Init()
        {
            try
            {
                Recepti.Clear();

                var lista = await _ReceptService.Get<List<Model.Recept>>(new Model.Requests.ReceptSearchRequest
                {
                    KnjigaRecepataId = KnjigaId
                });

                foreach (var recept in lista)
                {
                    Model.ImageResource imageResource = await _ImageResourceService.GetById<Model.ImageResource>(recept.ImageResouceId);

                    Recepti.Add(new ReceptListViewItem
                    {
                        Id = recept.Id,
                        Naziv = recept.Naziv,
                        Image = imageResource != null ? new ImageConverter().Convert(imageResource.ImageByteValue) : "notfound.png"
                    });
                }
            } catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }

        }
    }
}
