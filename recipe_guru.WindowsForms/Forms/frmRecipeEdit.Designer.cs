namespace recipe_guru.WindowsFormsUI.Forms
{
    partial class frmRecipeEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.naziv = new System.Windows.Forms.TextBox();
            this.description = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.effort = new System.Windows.Forms.NumericUpDown();
            this.publicRecipe = new System.Windows.Forms.RadioButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.effort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Naziv";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Effort";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Public";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Description";
            // 
            // naziv
            // 
            this.naziv.Location = new System.Drawing.Point(112, 12);
            this.naziv.Name = "naziv";
            this.naziv.Size = new System.Drawing.Size(120, 26);
            this.naziv.TabIndex = 4;
            this.naziv.Validating += new System.ComponentModel.CancelEventHandler(this.naziv_Validating);
            // 
            // description
            // 
            this.description.Location = new System.Drawing.Point(112, 41);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(120, 26);
            this.description.TabIndex = 5;
            this.description.Validating += new System.ComponentModel.CancelEventHandler(this.description_Validating);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 172);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(216, 40);
            this.button1.TabIndex = 8;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // effort
            // 
            this.effort.Location = new System.Drawing.Point(112, 82);
            this.effort.Name = "effort";
            this.effort.Size = new System.Drawing.Size(120, 26);
            this.effort.TabIndex = 9;
            this.effort.Validating += new System.ComponentModel.CancelEventHandler(this.effort_Validating);
            // 
            // publicRecipe
            // 
            this.publicRecipe.AutoSize = true;
            this.publicRecipe.Location = new System.Drawing.Point(157, 129);
            this.publicRecipe.Name = "publicRecipe";
            this.publicRecipe.Size = new System.Drawing.Size(21, 20);
            this.publicRecipe.TabIndex = 10;
            this.publicRecipe.TabStop = true;
            this.publicRecipe.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmRecipeEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 249);
            this.Controls.Add(this.publicRecipe);
            this.Controls.Add(this.effort);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.description);
            this.Controls.Add(this.naziv);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmRecipeEdit";
            this.Text = "frmRecipeEdit";
            this.Load += new System.EventHandler(this.frmRecipeEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.effort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox naziv;
        private System.Windows.Forms.TextBox description;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown effort;
        private System.Windows.Forms.RadioButton publicRecipe;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}