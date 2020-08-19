using recipe_guru.WindowsFormsUI;
using recipe_guru.Model;
using recipe_guru.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace recipe_guru.WindowsFormsUI.Forms
{
    public partial class frmUserAdd : Form
    {
        APIService _serviceUser = new APIService("Korisnici");
        APIService _serviceUserType = new APIService("Uloge");

        private Korisnik _user;

        private List<Korisnik> Users = null;

        public frmUserAdd(Korisnik user = null)
        {
            InitializeComponent();
            _user = user;
        }

        private async void frmUserAdd_Load(object sender, EventArgs e)
        {
            await LoadTypes();
            await LoadUsers();
            if(_user != null)
            {
                txtUsername.Text = _user.KorisnickoIme;
                txtEmail.Text = _user.Email;
                txtFirstName.Text = _user.Ime;
                txtLastName.Text = _user.Prezime;
                txtPhone.Text = _user.Telefon;
                cmbType.SelectedValue = _user.UlogaId;
                btnSave.Visible = false;
                txtPassword.ReadOnly = true;
                txtPassword.Enabled = false;
                txtPasswordConfirm.ReadOnly = true;
                txtPasswordConfirm.Enabled = false;
                chkShow.Visible = false;
                chkGenerate.Visible = false;
            }
        }

        private async Task LoadTypes()
        {
            var list = await _serviceUserType.GetAll<List<Uloga>>();
            list.Insert(0, new Uloga());
            cmbType.ValueMember = "Id";
            cmbType.DisplayMember = "Type";
            cmbType.DataSource = list;
        }

        private async Task LoadUsers()
        {
            Users = await _serviceUser.GetAll<List<Korisnik>>();
        }


        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                KorisniciInsertRequest request = new KorisniciInsertRequest
                {
                    KorisnickoIme = txtUsername.Text,
                    Email = txtEmail.Text,
                    Ime = txtFirstName.Text,
                    Prezime = txtLastName.Text,
                    Password = txtPassword.Text,
                    PasswordPotvrda = txtPasswordConfirm.Text,
                    Telefon = txtPhone.Text,
                };

                var idType = cmbType.SelectedValue;

                if (int.TryParse(idType.ToString(), out int typeId))
                {
                    request.UlogaId = typeId;
                }

                if (_user == null)
                {
                    var mtvs = await _serviceUser.Insert<Korisnik>(request);

                    if (mtvs == default(Korisnik))
                        return;
                }

                MessageBox.Show("Operation successfully completed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void chkGenerate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGenerate.Checked)
            {
                var guid = Guid.NewGuid().ToString().Substring(0, 8);
                txtPassword.Text = guid;
                txtPasswordConfirm.Text = guid;
            }
            else
            {
                txtPassword.Text = "";
                txtPasswordConfirm.Text = "";
            }
        }

        private void chkShow_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShow.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtPasswordConfirm.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
                txtPasswordConfirm.PasswordChar = '*';
            }
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                errorProvider.SetError(txtFirstName, "Required");
            }
            else
            {
                errorProvider.SetError(txtFirstName, null);
            }
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                errorProvider.SetError(txtLastName, "Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtLastName, null);
            }
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            bool flag = false;
            foreach (var item in Users)
            {
                if (item.KorisnickoIme == txtUsername.Text)
                {
                    flag = true;
                    break;
                }
            }
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                errorProvider.SetError(txtUsername, "Required");
                e.Cancel = true;
            }
            else if (flag)
            {
                errorProvider.SetError(txtUsername, "Username already exists");
                e.Cancel = true;
            }
            else if (txtUsername.Text.Length < 4)
            {
                errorProvider.SetError(txtUsername, "You must have minimum 4 characters.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtUsername, null);
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider.SetError(txtPassword, "Required");
                e.Cancel = true;
            }
            else if(txtPassword.Text.Length < 4)
            {
                errorProvider.SetError(txtPassword, "You must have minimum 4 characters.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtPassword, null);
            }
        }

        private void txtPasswordConfirm_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPasswordConfirm.Text))
            {
                errorProvider.SetError(txtPasswordConfirm, "Required");
                e.Cancel = true;
            }
            else if(txtPassword.Text != txtPasswordConfirm.Text)
            {
                errorProvider.SetError(txtPasswordConfirm, "Passwords not matched.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtPasswordConfirm, null);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, "Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtEmail, null);
            }
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                errorProvider.SetError(txtPhone, "Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtPhone, null);
            }
        }

        private void cmbType_Validating(object sender, CancelEventArgs e)
        {
            if (cmbType.SelectedIndex == 0)
            {
                errorProvider.SetError(cmbType, "Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cmbType, null);
            }
        }
    }
}
