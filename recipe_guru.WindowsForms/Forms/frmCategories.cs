using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using recipe_guru.Model.ReportModels;
using recipe_guru.Model.Requests;

namespace recipe_guru.WindowsFormsUI.Forms
{
    public partial class frmCategories : Form
    {
        APIService _serviceKategorije = new APIService("Kategorije");
        APIService _serviceRecept = new APIService("Recept");
        APIService _serviceRating = new APIService("Rating");
        APIService _serviceBrojPregleda = new APIService("ReceptPregled");

        public frmCategories()
        {
            InitializeComponent();
        }

        private async Task LoadCategories()
        {
            var list = await _serviceKategorije.GetAll<List<Model.Kategorija>>(null);
            List<frmCategoriesVM> vm = new List<frmCategoriesVM>();
            foreach (var item in list)
            {
                var recepti = await _serviceRecept.GetAll<List<Model.Recept>>(new ReceptSearchRequest { 
                    KategorijaId = item.Id
                });

                List<int> avg = new List<int>();
                int brojPregleda = 0;
                foreach (var recept in recepti)
                {
                    var ratings = await _serviceRating.GetAll<List<Model.Rating>>(new RatingSearchRequest { ReceptId = recept.Id });
                    var pregled = await _serviceBrojPregleda.GetById<Model.ReceptPregled>(recept.ReceptPregledId);

                    avg.Add((int)ratings.Average(x => (int)x.Mark));
                    brojPregleda = pregled.BrojPregleda + brojPregleda;

                }

                frmCategoriesVM categoryStatistics = new frmCategoriesVM
                {
                    Id = item.Id,
                    Naziv = item.Naziv,
                    AvgRating = (int) avg.Average(x => x),
                    BrojPregleda = brojPregleda,
                    BrojRecepata = recepti.Count()
                }; 

                vm.Add(categoryStatistics);
            }
            dgvCategory.DataSource = vm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmRptCategory frm = new frmRptCategory(dgvCategory.DataSource as List<frmCategoriesVM>);
            frm.Show();
        }

        private async void frmCategories_Load(object sender, EventArgs e)
        {
            dgvCategory.AutoGenerateColumns = false;
            await LoadCategories();
        }
    }
}
