using recipe_guru.Model;
using recipe_guru.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace recipe_guru.WindowsFormsUI.Forms
{
    public partial class frmLoginUser : Form
    {
        APIService _service = new APIService("Kategorije");
        APIService _serviceUser = new APIService("Korisnici");

        public frmLoginUser()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                APIService.username = username.Text;
                APIService.password = password.Text;
                await _service.GetAll<dynamic>(null);

                Korisnik korisnik = (await _serviceUser.GetAll<List<Model.Korisnik>>(new KorisniciSearchRequest { KorisnickoIme = APIService.username }))[0];

                if (korisnik.UlogaId == 1)
                {
                    frmIndex frm = new frmIndex();
                    frm.Show();

                }
                else
                {
                    frmUserProfile frm = new frmUserProfile();
                    frm.Show();

                }
                this.Hide();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
