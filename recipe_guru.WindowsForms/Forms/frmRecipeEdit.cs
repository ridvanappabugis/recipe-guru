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

namespace recipe_guru.WindowsFormsUI.Forms
{
    public partial class frmRecipeEdit : Form
    {
        APIService _serviceRecipes = new APIService("Recept");

        private Model.Recept _recept;
        public frmRecipeEdit(Model.Recept recept = null)
        {
            InitializeComponent();
            _recept = recept;
        }

        private void frmRecipeEdit_Load(object sender, EventArgs e)
        {
            naziv.Text = _recept.Naziv;
            description.Text = _recept.Deskripcija;
            effort.Value = _recept.DuzinaPripreme;
            publicRecipe.Checked = _recept.Public;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                var recept = await _serviceRecipes.GetById<Model.Recept>(_recept.Id);
                await _serviceRecipes.Update<Model.Recept>(_recept.Id, new ReceptUpsertRequest
                {
                    Deskripcija = description.Text,
                    Naziv = naziv.Text,
                    DuzinaPripreme = (int)effort.Value,
                    Public = publicRecipe.Checked,
                    ImageResourceId = recept.ImageResourceId,
                    ReceptPregledId = recept.ReceptPregledId,
                    KategorijaId = recept.KategorijaId,
                    KnjigaRecepataId = recept.KnjigaRecepataId
                });

                MessageBox.Show("Operation successfully completed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void naziv_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(naziv.Text))
            {
                errorProvider1.SetError(naziv, "Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(naziv, null);
            }
        }

        private void description_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(description.Text))
            {
                errorProvider1.SetError(description, "Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(description, null);
            }
        }

        private void effort_Validating(object sender, CancelEventArgs e)
        {
            if (effort.Value <= 0)
            {
                errorProvider1.SetError(effort, "Required Positive");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(effort, null);
            }
        }
    }
}
