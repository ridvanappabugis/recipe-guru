using recipe_guru.Model;
using recipe_guru.Model.ReportModels;

using recipe_guru.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace recipe_guru.WindowsFormsUI.Forms
{
    public partial class frmUserProfile : Form
    {

        APIService _serviceUser = new APIService("Korisnici");
        APIService _serviceKnjigaRecepata = new APIService("KnjigaRecepata");
        APIService _serviceRecipes = new APIService("Recept");
        APIService _serviceRating = new APIService("Rating");
        APIService _serviceBrojPregleda = new APIService("ReceptPregled");

        Korisnik korisnik;

        public frmUserProfile()
        {
            InitializeComponent();
        }

        private async void frmUserProfile_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private async void dgvRecipes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = dgvRecipes.SelectedRows[0].DataBoundItem;
            var recipe = await _serviceRecipes.GetById<Model.Recept>((item as frmRecipesUsersVM).Id);
            frmRecipeEdit frm = new frmRecipeEdit(recipe);
            frm.WindowState = FormWindowState.Normal;
            frm.Show();


        }

        private async void refresh()
        {
            korisnik = (await _serviceUser.GetAll<List<Model.Korisnik>>(new KorisniciSearchRequest { KorisnickoIme = APIService.username }))[0];

            userName.Text = korisnik.KorisnickoIme;
            fullName.Text = korisnik.Ime + " " + korisnik.Prezime;
            description.Text = korisnik.Deskripcija;

            var listKnjiga = await _serviceKnjigaRecepata.GetAll<List<Model.KnjigaRecepata>>(new KnjigaRecepataSearchRequest
            {
                KorisnikId = korisnik.Id
            });

            List<frmRecipesUsersVM> vm = new List<frmRecipesUsersVM>();

            foreach (var knjiga in listKnjiga)
            {
                var list = await _serviceRecipes.GetAll<List<Model.Recept>>(new ReceptSearchRequest
                {
                    KnjigaRecepataId = knjiga.Id
                });

                foreach (var recept in list)
                {
                    List<int> avg = new List<int>();
                    int brojPregleda = 0;
                    var ratings = await _serviceRating.GetAll<List<Model.Rating>>(new RatingSearchRequest { ReceptId = recept.Id });
                    var pregled = await _serviceBrojPregleda.GetById<Model.ReceptPregled>(recept.ReceptPregledId);

                    vm.Add(new frmRecipesUsersVM
                    {
                        Id = recept.Id,
                        Naziv = recept.Naziv,
                        Description = recept.Deskripcija,
                        RecipeBook = knjiga.Naziv,
                        AverageRating = (int)ratings.Average(x => (int)x.Mark) + 1,
                        NumberOfRatings = ratings.Count(),
                        NumberOfViews = pregled.BrojPregleda
                    });

                }
            }

            dgvRecipes.DataSource = vm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmLoginUser frm = new frmLoginUser();
            frm.Show();
            this.Hide();
        }
    }
}
