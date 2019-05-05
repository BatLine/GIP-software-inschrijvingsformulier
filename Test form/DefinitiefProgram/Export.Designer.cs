namespace DefinitiefProgram
{
    partial class Export
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Export));
            this.label1 = new System.Windows.Forms.Label();
            this.gpSpecifiek = new System.Windows.Forms.GroupBox();
            this.chkSpecifiker = new XylosCheckBox();
            this.lblAantalLLN = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTot = new System.Windows.Forms.DateTimePicker();
            this.dtpVan = new System.Windows.Forms.DateTimePicker();
            this.gpSpecifieker = new System.Windows.Forms.GroupBox();
            this.lvSpecifieker = new System.Windows.Forms.ListView();
            this.chNaam = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPostcode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDatum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gpLeerling = new System.Windows.Forms.GroupBox();
            this.btnZoek = new XylosButton();
            this.txtANaam = new XylosTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtVNaam = new XylosTextBox();
            this.lblAantalLLNOpNaam = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.rdbLeerling = new XylosRadioButton();
            this.btnExport = new XylosButton();
            this.btnCancel = new XylosButton();
            this.rdbSpecifiek = new XylosRadioButton();
            this.rdbIedereen = new XylosRadioButton();
            this.gpSpecifiek.SuspendLayout();
            this.gpSpecifieker.SuspendLayout();
            this.gpLeerling.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selecteer een optie:";
            // 
            // gpSpecifiek
            // 
            this.gpSpecifiek.Controls.Add(this.chkSpecifiker);
            this.gpSpecifiek.Controls.Add(this.lblAantalLLN);
            this.gpSpecifiek.Controls.Add(this.label3);
            this.gpSpecifiek.Controls.Add(this.label2);
            this.gpSpecifiek.Controls.Add(this.dtpTot);
            this.gpSpecifiek.Controls.Add(this.dtpVan);
            this.gpSpecifiek.Location = new System.Drawing.Point(15, 97);
            this.gpSpecifiek.Name = "gpSpecifiek";
            this.gpSpecifiek.Size = new System.Drawing.Size(299, 132);
            this.gpSpecifiek.TabIndex = 3;
            this.gpSpecifiek.TabStop = false;
            this.gpSpecifiek.Text = "Op aanmaakdatum";
            // 
            // chkSpecifiker
            // 
            this.chkSpecifiker.Checked = false;
            this.chkSpecifiker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkSpecifiker.EnabledCalc = true;
            this.chkSpecifiker.Location = new System.Drawing.Point(9, 106);
            this.chkSpecifiker.Name = "chkSpecifiker";
            this.chkSpecifiker.Size = new System.Drawing.Size(262, 18);
            this.chkSpecifiker.TabIndex = 5;
            this.chkSpecifiker.Text = "Bekijk deze leerlingen / selecteer specifieker";
            this.chkSpecifiker.CheckedChanged += new XylosCheckBox.CheckedChangedEventHandler(this.chkSpecifiker_CheckedChanged);
            // 
            // lblAantalLLN
            // 
            this.lblAantalLLN.AutoSize = true;
            this.lblAantalLLN.Location = new System.Drawing.Point(38, 78);
            this.lblAantalLLN.Name = "lblAantalLLN";
            this.lblAantalLLN.Size = new System.Drawing.Size(140, 13);
            this.lblAantalLLN.TabIndex = 4;
            this.lblAantalLLN.Text = "0 Leerlingen in deze periode";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tot:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Van:";
            // 
            // dtpTot
            // 
            this.dtpTot.Location = new System.Drawing.Point(41, 55);
            this.dtpTot.Name = "dtpTot";
            this.dtpTot.Size = new System.Drawing.Size(252, 20);
            this.dtpTot.TabIndex = 1;
            this.dtpTot.ValueChanged += new System.EventHandler(this.dtpTot_ValueChanged);
            // 
            // dtpVan
            // 
            this.dtpVan.Location = new System.Drawing.Point(41, 19);
            this.dtpVan.Name = "dtpVan";
            this.dtpVan.Size = new System.Drawing.Size(252, 20);
            this.dtpVan.TabIndex = 0;
            this.dtpVan.ValueChanged += new System.EventHandler(this.dtpVan_ValueChanged);
            // 
            // gpSpecifieker
            // 
            this.gpSpecifieker.Controls.Add(this.lvSpecifieker);
            this.gpSpecifieker.Location = new System.Drawing.Point(15, 235);
            this.gpSpecifieker.Name = "gpSpecifieker";
            this.gpSpecifieker.Size = new System.Drawing.Size(299, 288);
            this.gpSpecifieker.TabIndex = 4;
            this.gpSpecifieker.TabStop = false;
            this.gpSpecifieker.Text = "Selecteer specifieker";
            // 
            // lvSpecifieker
            // 
            this.lvSpecifieker.CheckBoxes = true;
            this.lvSpecifieker.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chNaam,
            this.chPostcode,
            this.chDatum});
            this.lvSpecifieker.FullRowSelect = true;
            this.lvSpecifieker.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvSpecifieker.HideSelection = false;
            this.lvSpecifieker.Location = new System.Drawing.Point(6, 19);
            this.lvSpecifieker.Name = "lvSpecifieker";
            this.lvSpecifieker.Size = new System.Drawing.Size(287, 263);
            this.lvSpecifieker.TabIndex = 0;
            this.lvSpecifieker.UseCompatibleStateImageBehavior = false;
            this.lvSpecifieker.View = System.Windows.Forms.View.Details;
            // 
            // chNaam
            // 
            this.chNaam.Text = "Naam";
            this.chNaam.Width = 140;
            // 
            // chPostcode
            // 
            this.chPostcode.Text = "Postcode";
            this.chPostcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chDatum
            // 
            this.chDatum.Text = "Gemaakt op";
            this.chDatum.Width = 80;
            // 
            // gpLeerling
            // 
            this.gpLeerling.Controls.Add(this.btnZoek);
            this.gpLeerling.Controls.Add(this.txtANaam);
            this.gpLeerling.Controls.Add(this.label5);
            this.gpLeerling.Controls.Add(this.txtVNaam);
            this.gpLeerling.Controls.Add(this.lblAantalLLNOpNaam);
            this.gpLeerling.Controls.Add(this.label6);
            this.gpLeerling.Location = new System.Drawing.Point(15, 97);
            this.gpLeerling.Name = "gpLeerling";
            this.gpLeerling.Size = new System.Drawing.Size(299, 132);
            this.gpLeerling.TabIndex = 6;
            this.gpLeerling.TabStop = false;
            this.gpLeerling.Text = "Op naam";
            this.gpLeerling.Visible = false;
            // 
            // btnZoek
            // 
            this.btnZoek.EnabledCalc = true;
            this.btnZoek.Location = new System.Drawing.Point(79, 85);
            this.btnZoek.Name = "btnZoek";
            this.btnZoek.Size = new System.Drawing.Size(206, 23);
            this.btnZoek.TabIndex = 8;
            this.btnZoek.Text = "Zoek";
            this.btnZoek.Click += new XylosButton.ClickEventHandler(this.btnZoek_Click);
            // 
            // txtANaam
            // 
            this.txtANaam.EnabledCalc = true;
            this.txtANaam.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtANaam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(133)))), ((int)(((byte)(142)))));
            this.txtANaam.Location = new System.Drawing.Point(79, 50);
            this.txtANaam.MaxLength = 32767;
            this.txtANaam.MultiLine = false;
            this.txtANaam.Name = "txtANaam";
            this.txtANaam.ReadOnly = false;
            this.txtANaam.Size = new System.Drawing.Size(206, 29);
            this.txtANaam.TabIndex = 7;
            this.txtANaam.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtANaam.UseSystemPasswordChar = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Achternaam:";
            // 
            // txtVNaam
            // 
            this.txtVNaam.EnabledCalc = true;
            this.txtVNaam.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtVNaam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(133)))), ((int)(((byte)(142)))));
            this.txtVNaam.Location = new System.Drawing.Point(79, 15);
            this.txtVNaam.MaxLength = 32767;
            this.txtVNaam.MultiLine = false;
            this.txtVNaam.Name = "txtVNaam";
            this.txtVNaam.ReadOnly = false;
            this.txtVNaam.Size = new System.Drawing.Size(206, 29);
            this.txtVNaam.TabIndex = 6;
            this.txtVNaam.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtVNaam.UseSystemPasswordChar = false;
            // 
            // lblAantalLLNOpNaam
            // 
            this.lblAantalLLNOpNaam.AutoSize = true;
            this.lblAantalLLNOpNaam.Location = new System.Drawing.Point(6, 111);
            this.lblAantalLLNOpNaam.Name = "lblAantalLLNOpNaam";
            this.lblAantalLLNOpNaam.Size = new System.Drawing.Size(116, 13);
            this.lblAantalLLNOpNaam.TabIndex = 4;
            this.lblAantalLLNOpNaam.Text = "0 Leerlingen gevonden";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Voornaam:";
            // 
            // rdbLeerling
            // 
            this.rdbLeerling.Checked = false;
            this.rdbLeerling.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdbLeerling.EnabledCalc = true;
            this.rdbLeerling.Location = new System.Drawing.Point(15, 73);
            this.rdbLeerling.Name = "rdbLeerling";
            this.rdbLeerling.Size = new System.Drawing.Size(283, 18);
            this.rdbLeerling.TabIndex = 7;
            this.rdbLeerling.Text = "1 Leerling op naam";
            this.rdbLeerling.CheckedChanged += new XylosRadioButton.CheckedChangedEventHandler(this.rdbLeerling_CheckedChanged);
            // 
            // btnExport
            // 
            this.btnExport.EnabledCalc = true;
            this.btnExport.Location = new System.Drawing.Point(256, 529);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(58, 23);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Exporteer";
            this.btnExport.Click += new XylosButton.ClickEventHandler(this.btnExport_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.EnabledCalc = true;
            this.btnCancel.Location = new System.Drawing.Point(16, 529);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(42, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Terug";
            this.btnCancel.Click += new XylosButton.ClickEventHandler(this.btnCancel_Click);
            // 
            // rdbSpecifiek
            // 
            this.rdbSpecifiek.Checked = false;
            this.rdbSpecifiek.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdbSpecifiek.EnabledCalc = true;
            this.rdbSpecifiek.Location = new System.Drawing.Point(15, 49);
            this.rdbSpecifiek.Name = "rdbSpecifiek";
            this.rdbSpecifiek.Size = new System.Drawing.Size(283, 18);
            this.rdbSpecifiek.TabIndex = 2;
            this.rdbSpecifiek.Text = "Een specifiek aantal leerlingen";
            this.rdbSpecifiek.CheckedChanged += new XylosRadioButton.CheckedChangedEventHandler(this.rdbSpecifiek_CheckedChanged);
            // 
            // rdbIedereen
            // 
            this.rdbIedereen.Checked = true;
            this.rdbIedereen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdbIedereen.EnabledCalc = true;
            this.rdbIedereen.Location = new System.Drawing.Point(15, 25);
            this.rdbIedereen.Name = "rdbIedereen";
            this.rdbIedereen.Size = new System.Drawing.Size(283, 18);
            this.rdbIedereen.TabIndex = 1;
            this.rdbIedereen.Text = "Alle leerlingen uit de database exporteren";
            this.rdbIedereen.CheckedChanged += new XylosRadioButton.CheckedChangedEventHandler(this.rdbIedereen_CheckedChanged);
            // 
            // Export
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(325, 558);
            this.ControlBox = false;
            this.Controls.Add(this.rdbLeerling);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gpSpecifieker);
            this.Controls.Add(this.rdbSpecifiek);
            this.Controls.Add(this.rdbIedereen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gpLeerling);
            this.Controls.Add(this.gpSpecifiek);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Export";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export";
            this.Load += new System.EventHandler(this.Export_Load);
            this.gpSpecifiek.ResumeLayout(false);
            this.gpSpecifiek.PerformLayout();
            this.gpSpecifieker.ResumeLayout(false);
            this.gpLeerling.ResumeLayout(false);
            this.gpLeerling.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private XylosRadioButton rdbIedereen;
        private XylosRadioButton rdbSpecifiek;
        private System.Windows.Forms.GroupBox gpSpecifiek;
        private System.Windows.Forms.DateTimePicker dtpTot;
        private System.Windows.Forms.DateTimePicker dtpVan;
        private XylosCheckBox chkSpecifiker;
        private System.Windows.Forms.Label lblAantalLLN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gpSpecifieker;
        private System.Windows.Forms.ListView lvSpecifieker;
        private System.Windows.Forms.ColumnHeader chNaam;
        private XylosButton btnExport;
        private XylosButton btnCancel;
        private System.Windows.Forms.ColumnHeader chPostcode;
        private System.Windows.Forms.ColumnHeader chDatum;
        private XylosRadioButton rdbLeerling;
        private System.Windows.Forms.GroupBox gpLeerling;
        private XylosTextBox txtANaam;
        private System.Windows.Forms.Label label5;
        private XylosTextBox txtVNaam;
        private System.Windows.Forms.Label lblAantalLLNOpNaam;
        private System.Windows.Forms.Label label6;
        private XylosButton btnZoek;
    }
}