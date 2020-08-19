using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using recipe_guru.Mobile.Models;

namespace recipe_guru.Mobile.ViewModels
{
    public class AddReceptViewModel : BaseViewModel
    {
        public ObservableCollection<Model.Kategorija> Kategorije { get; set; } = new ObservableCollection<Model.Kategorija>();
        public ObservableCollection<ReceptSastojakListViewItem> Sastojci { get; set; } = new ObservableCollection<ReceptSastojakListViewItem>();

        private readonly APIService _KategorijeService = new APIService("Kategorije");

        public AddReceptViewModel(int KnjigaRecepataId)
        {
        }

        public async Task Init()
        {
            var kategorijeList = await _KategorijeService.Get<List<Model.Kategorija>>(null);

            foreach (var kat in kategorijeList)
            {
                Kategorije.Add(kat);
            }
        }
    }
}
