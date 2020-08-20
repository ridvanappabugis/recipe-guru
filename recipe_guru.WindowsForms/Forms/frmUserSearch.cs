using recipe_guru.WindowsFormsUI;
using recipe_guru.Model;
using recipe_guru.Model.Requests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using recipe_guru.Model.ReportModels;

namespace recipe_guru.WindowsFormsUI.Forms
{
    public partial class frmUserSearch : Form
    {
        APIService _serviceUser = new APIService("Korisnici");
        APIService _serviceUserType = new APIService("Uloge");

        public frmUserSearch()
        {
            InitializeComponent();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await LoadUsers();
        }

        private async Task LoadTypes()
        {
            var list = await _serviceUserType.GetAll<List<Uloga>>();
            list.Insert(0, new Uloga());
            cmbType.ValueMember = "Id";
            cmbType.DisplayMember = "Naziv";
            cmbType.DataSource = list;
        }

        private async Task LoadUsers()
        {
            KorisniciInsertRequest request = new KorisniciInsertRequest
            {
                KorisnickoIme = txtSearch.Text
            };

            var id = cmbType.SelectedValue;

            if (int.TryParse(id.ToString(), out int ID))
            {
                request.UlogaId = ID;
            }

            var list = await _serviceUser.GetAll<List<Korisnik>>(request);
            List<frmUserSearchVM> vm = new List<frmUserSearchVM>();
            foreach (var item in list)
            {
                var uloga = await _serviceUserType.GetById<Model.Uloga>(item.UlogaId);
                frmUserSearchVM userSearch = new frmUserSearchVM
                {
                    Email = item.Email,
                    FirstName = item.Ime,
                    LastName = item.Prezime,
                    Id = item.Id,
                    Phone = item.Telefon,
                    Username = item.KorisnickoIme,
                    UserType = uloga.Naziv.ToString()
                };
                vm.Add(userSearch);
            }
            dgvUser.DataSource = vm;
        }

        private async void frmUserSearch_Load(object sender, EventArgs e)
        {
            dgvUser.AutoGenerateColumns = false;
            await LoadTypes();
            await LoadUsers();
        }

        private async void dgvUser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = dgvUser.SelectedRows[0].DataBoundItem;
            var MTVS = await _serviceUser.GetById<Korisnik>((item as frmUserSearchVM).Id);
            frmUserAdd frm = new frmUserAdd(MTVS);
            frm.WindowState = FormWindowState.Normal;
            frm.Show();
        }

        private async void cmbType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            await LoadUsers();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmRptUser frm = new frmRptUser(dgvUser.DataSource as List<frmUserSearchVM>);
            frm.Show();
        }
    }
}
