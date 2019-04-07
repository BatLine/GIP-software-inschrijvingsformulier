namespace DefinitiefProgram
{
    partial class Lijstleerlingen
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
            this.lvLeerlingen = new System.Windows.Forms.ListView();
            this.cVoornaam = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cNaam = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cPostcode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnKies = new XylosButton();
            this.tmrCheckIfLoaded = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lvLeerlingen
            // 
            this.lvLeerlingen.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.lvLeerlingen.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cVoornaam,
            this.cNaam,
            this.cPostcode});
            this.lvLeerlingen.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvLeerlingen.FullRowSelect = true;
            this.lvLeerlingen.HideSelection = false;
            this.lvLeerlingen.Location = new System.Drawing.Point(0, 0);
            this.lvLeerlingen.MultiSelect = false;
            this.lvLeerlingen.Name = "lvLeerlingen";
            this.lvLeerlingen.Size = new System.Drawing.Size(266, 366);
            this.lvLeerlingen.TabIndex = 0;
            this.lvLeerlingen.UseCompatibleStateImageBehavior = false;
            this.lvLeerlingen.View = System.Windows.Forms.View.Details;
            this.lvLeerlingen.DoubleClick += new System.EventHandler(this.lvLeerlingen_DoubleClick);
            this.lvLeerlingen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvLeerlingen_KeyDown);
            // 
            // cVoornaam
            // 
            this.cVoornaam.Text = "Voornaam";
            this.cVoornaam.Width = 100;
            // 
            // cNaam
            // 
            this.cNaam.Text = "Naam";
            this.cNaam.Width = 100;
            // 
            // cPostcode
            // 
            this.cPostcode.Text = "Postcode";
            // 
            // btnKies
            // 
            this.btnKies.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnKies.EnabledCalc = true;
            this.btnKies.Location = new System.Drawing.Point(0, 363);
            this.btnKies.Name = "btnKies";
            this.btnKies.Size = new System.Drawing.Size(266, 31);
            this.btnKies.TabIndex = 1;
            this.btnKies.Text = "Selecteer";
            this.btnKies.Click += new XylosButton.ClickEventHandler(this.btnKies_Click);
            // 
            // tmrCheckIfLoaded
            // 
            this.tmrCheckIfLoaded.Enabled = true;
            this.tmrCheckIfLoaded.Tick += new System.EventHandler(this.tmrCheckIfLoaded_Tick);
            // 
            // Lijstleerlingen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(266, 394);
            this.Controls.Add(this.btnKies);
            this.Controls.Add(this.lvLeerlingen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Lijstleerlingen";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kies een leerling";
            this.Load += new System.EventHandler(this.Lijstleerlingen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvLeerlingen;
        private System.Windows.Forms.ColumnHeader cVoornaam;
        private System.Windows.Forms.ColumnHeader cNaam;
        private System.Windows.Forms.ColumnHeader cPostcode;
        private XylosButton btnKies;
        private System.Windows.Forms.Timer tmrCheckIfLoaded;
    }
}