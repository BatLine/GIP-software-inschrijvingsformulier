namespace frmtest
{
    partial class Leerling
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mskRijksregisterNummer = new System.Windows.Forms.MaskedTextBox();
            this.cmbGeslacht = new System.Windows.Forms.ComboBox();
            this.Bevestigen = new System.Windows.Forms.Button();
            this.rdb6 = new System.Windows.Forms.RadioButton();
            this.rdb5 = new System.Windows.Forms.RadioButton();
            this.rdb4 = new System.Windows.Forms.RadioButton();
            this.rdb3 = new System.Windows.Forms.RadioButton();
            this.rdb2 = new System.Windows.Forms.RadioButton();
            this.rdb1 = new System.Windows.Forms.RadioButton();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.mskPostcode = new System.Windows.Forms.MaskedTextBox();
            this.txtLand = new System.Windows.Forms.TextBox();
            this.txtGemeente = new System.Windows.Forms.TextBox();
            this.txtBus = new System.Windows.Forms.TextBox();
            this.txtHuisnummer = new System.Windows.Forms.TextBox();
            this.txtStraat = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.mskGsmNummer = new System.Windows.Forms.MaskedTextBox();
            this.cmbRichting = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNationaliteit = new System.Windows.Forms.TextBox();
            this.txtGeboorteDatum = new System.Windows.Forms.TextBox();
            this.txtGeboortePlaats = new System.Windows.Forms.TextBox();
            this.txtFamilienaam = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Voornaam = new System.Windows.Forms.Label();
            this.txtVoornaam = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // mskRijksregisterNummer
            // 
            this.mskRijksregisterNummer.Location = new System.Drawing.Point(184, 210);
            this.mskRijksregisterNummer.Mask = "00.00.00-000.00";
            this.mskRijksregisterNummer.Name = "mskRijksregisterNummer";
            this.mskRijksregisterNummer.Size = new System.Drawing.Size(100, 20);
            this.mskRijksregisterNummer.TabIndex = 83;
            // 
            // cmbGeslacht
            // 
            this.cmbGeslacht.FormattingEnabled = true;
            this.cmbGeslacht.Items.AddRange(new object[] {
            "Man",
            "Vrouw"});
            this.cmbGeslacht.Location = new System.Drawing.Point(184, 98);
            this.cmbGeslacht.Name = "cmbGeslacht";
            this.cmbGeslacht.Size = new System.Drawing.Size(100, 21);
            this.cmbGeslacht.TabIndex = 82;
            // 
            // Bevestigen
            // 
            this.Bevestigen.Location = new System.Drawing.Point(657, 349);
            this.Bevestigen.Name = "Bevestigen";
            this.Bevestigen.Size = new System.Drawing.Size(75, 23);
            this.Bevestigen.TabIndex = 81;
            this.Bevestigen.Text = "button1";
            this.Bevestigen.UseVisualStyleBackColor = true;
            this.Bevestigen.Click += new System.EventHandler(this.Bevestigen_Click);
            // 
            // rdb6
            // 
            this.rdb6.AutoSize = true;
            this.rdb6.Location = new System.Drawing.Point(573, 277);
            this.rdb6.Name = "rdb6";
            this.rdb6.Size = new System.Drawing.Size(60, 17);
            this.rdb6.TabIndex = 80;
            this.rdb6.TabStop = true;
            this.rdb6.Text = "6e Jaar";
            this.rdb6.UseVisualStyleBackColor = true;
            this.rdb6.CheckedChanged += new System.EventHandler(this.rdb6_CheckedChanged);
            // 
            // rdb5
            // 
            this.rdb5.AutoSize = true;
            this.rdb5.Location = new System.Drawing.Point(573, 254);
            this.rdb5.Name = "rdb5";
            this.rdb5.Size = new System.Drawing.Size(60, 17);
            this.rdb5.TabIndex = 79;
            this.rdb5.TabStop = true;
            this.rdb5.Text = "5e Jaar";
            this.rdb5.UseVisualStyleBackColor = true;
            this.rdb5.CheckedChanged += new System.EventHandler(this.rdb5_CheckedChanged);
            // 
            // rdb4
            // 
            this.rdb4.AutoSize = true;
            this.rdb4.Location = new System.Drawing.Point(469, 324);
            this.rdb4.Name = "rdb4";
            this.rdb4.Size = new System.Drawing.Size(60, 17);
            this.rdb4.TabIndex = 78;
            this.rdb4.TabStop = true;
            this.rdb4.Text = "4e Jaar";
            this.rdb4.UseVisualStyleBackColor = true;
            this.rdb4.CheckedChanged += new System.EventHandler(this.rdb4_CheckedChanged);
            // 
            // rdb3
            // 
            this.rdb3.AutoSize = true;
            this.rdb3.Location = new System.Drawing.Point(469, 300);
            this.rdb3.Name = "rdb3";
            this.rdb3.Size = new System.Drawing.Size(60, 17);
            this.rdb3.TabIndex = 77;
            this.rdb3.TabStop = true;
            this.rdb3.Text = "3e Jaar";
            this.rdb3.UseVisualStyleBackColor = true;
            this.rdb3.CheckedChanged += new System.EventHandler(this.rdb3_CheckedChanged);
            // 
            // rdb2
            // 
            this.rdb2.AutoSize = true;
            this.rdb2.Location = new System.Drawing.Point(469, 277);
            this.rdb2.Name = "rdb2";
            this.rdb2.Size = new System.Drawing.Size(60, 17);
            this.rdb2.TabIndex = 76;
            this.rdb2.TabStop = true;
            this.rdb2.Text = "2e Jaar";
            this.rdb2.UseVisualStyleBackColor = true;
            this.rdb2.CheckedChanged += new System.EventHandler(this.rdb2_CheckedChanged);
            // 
            // rdb1
            // 
            this.rdb1.AutoSize = true;
            this.rdb1.Location = new System.Drawing.Point(469, 254);
            this.rdb1.Name = "rdb1";
            this.rdb1.Size = new System.Drawing.Size(68, 17);
            this.rdb1.TabIndex = 75;
            this.rdb1.TabStop = true;
            this.rdb1.Text = "1ste Jaar";
            this.rdb1.UseVisualStyleBackColor = true;
            this.rdb1.CheckedChanged += new System.EventHandler(this.rdb1_CheckedChanged_1);
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(184, 323);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(100, 20);
            this.txtMail.TabIndex = 74;
            // 
            // mskPostcode
            // 
            this.mskPostcode.Location = new System.Drawing.Point(469, 179);
            this.mskPostcode.Mask = "0000";
            this.mskPostcode.Name = "mskPostcode";
            this.mskPostcode.Size = new System.Drawing.Size(40, 20);
            this.mskPostcode.TabIndex = 73;
            // 
            // txtLand
            // 
            this.txtLand.Location = new System.Drawing.Point(469, 215);
            this.txtLand.Name = "txtLand";
            this.txtLand.Size = new System.Drawing.Size(100, 20);
            this.txtLand.TabIndex = 72;
            // 
            // txtGemeente
            // 
            this.txtGemeente.Location = new System.Drawing.Point(469, 140);
            this.txtGemeente.Name = "txtGemeente";
            this.txtGemeente.Size = new System.Drawing.Size(100, 20);
            this.txtGemeente.TabIndex = 71;
            // 
            // txtBus
            // 
            this.txtBus.Location = new System.Drawing.Point(469, 101);
            this.txtBus.Name = "txtBus";
            this.txtBus.Size = new System.Drawing.Size(100, 20);
            this.txtBus.TabIndex = 70;
            // 
            // txtHuisnummer
            // 
            this.txtHuisnummer.Location = new System.Drawing.Point(469, 62);
            this.txtHuisnummer.Name = "txtHuisnummer";
            this.txtHuisnummer.Size = new System.Drawing.Size(100, 20);
            this.txtHuisnummer.TabIndex = 69;
            // 
            // txtStraat
            // 
            this.txtStraat.Location = new System.Drawing.Point(469, 19);
            this.txtStraat.Name = "txtStraat";
            this.txtStraat.Size = new System.Drawing.Size(100, 20);
            this.txtStraat.TabIndex = 68;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(359, 257);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(54, 13);
            this.label16.TabIndex = 67;
            this.label16.Text = "Studiejaar";
            // 
            // mskGsmNummer
            // 
            this.mskGsmNummer.Location = new System.Drawing.Point(184, 289);
            this.mskGsmNummer.Mask = "0000 00 00 00";
            this.mskGsmNummer.Name = "mskGsmNummer";
            this.mskGsmNummer.Size = new System.Drawing.Size(100, 20);
            this.mskGsmNummer.TabIndex = 66;
            this.mskGsmNummer.ValidatingType = typeof(int);
            // 
            // cmbRichting
            // 
            this.cmbRichting.Enabled = false;
            this.cmbRichting.FormattingEnabled = true;
            this.cmbRichting.Location = new System.Drawing.Point(469, 354);
            this.cmbRichting.Name = "cmbRichting";
            this.cmbRichting.Size = new System.Drawing.Size(121, 21);
            this.cmbRichting.TabIndex = 65;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(359, 359);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(46, 13);
            this.label15.TabIndex = 64;
            this.label15.Text = "Richting";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(359, 218);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 13);
            this.label14.TabIndex = 63;
            this.label14.Text = "Land";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(359, 179);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 13);
            this.label13.TabIndex = 62;
            this.label13.Text = "Postcode";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(359, 140);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 13);
            this.label12.TabIndex = 61;
            this.label12.Text = "Gemeente";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(359, 101);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 13);
            this.label11.TabIndex = 60;
            this.label11.Text = "Bus";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(359, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 59;
            this.label10.Text = "Huisnummer";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(359, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 58;
            this.label9.Text = "Straat";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(42, 323);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 57;
            this.label8.Text = "E-Mail";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 291);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 56;
            this.label4.Text = "GSM-Nummer";
            // 
            // txtNationaliteit
            // 
            this.txtNationaliteit.Location = new System.Drawing.Point(184, 254);
            this.txtNationaliteit.Name = "txtNationaliteit";
            this.txtNationaliteit.Size = new System.Drawing.Size(100, 20);
            this.txtNationaliteit.TabIndex = 55;
            // 
            // txtGeboorteDatum
            // 
            this.txtGeboorteDatum.Location = new System.Drawing.Point(184, 176);
            this.txtGeboorteDatum.Name = "txtGeboorteDatum";
            this.txtGeboorteDatum.Size = new System.Drawing.Size(100, 20);
            this.txtGeboorteDatum.TabIndex = 54;
            // 
            // txtGeboortePlaats
            // 
            this.txtGeboortePlaats.Location = new System.Drawing.Point(184, 137);
            this.txtGeboortePlaats.Name = "txtGeboortePlaats";
            this.txtGeboortePlaats.Size = new System.Drawing.Size(100, 20);
            this.txtGeboortePlaats.TabIndex = 53;
            // 
            // txtFamilienaam
            // 
            this.txtFamilienaam.Location = new System.Drawing.Point(184, 59);
            this.txtFamilienaam.Name = "txtFamilienaam";
            this.txtFamilienaam.Size = new System.Drawing.Size(100, 20);
            this.txtFamilienaam.TabIndex = 52;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 257);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 51;
            this.label7.Text = "Nationaliteit";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 13);
            this.label6.TabIndex = 50;
            this.label6.Text = "Rijksregisternummer";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 49;
            this.label5.Text = "Geboortedatum";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "Geboorteplaats";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Geslacht";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "Familienaam";
            // 
            // Voornaam
            // 
            this.Voornaam.AutoSize = true;
            this.Voornaam.Location = new System.Drawing.Point(39, 23);
            this.Voornaam.Name = "Voornaam";
            this.Voornaam.Size = new System.Drawing.Size(55, 13);
            this.Voornaam.TabIndex = 45;
            this.Voornaam.Text = "Voornaam";
            // 
            // txtVoornaam
            // 
            this.txtVoornaam.Location = new System.Drawing.Point(184, 20);
            this.txtVoornaam.Name = "txtVoornaam";
            this.txtVoornaam.Size = new System.Drawing.Size(100, 20);
            this.txtVoornaam.TabIndex = 44;
            // 
            // Leerling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mskRijksregisterNummer);
            this.Controls.Add(this.cmbGeslacht);
            this.Controls.Add(this.Bevestigen);
            this.Controls.Add(this.rdb6);
            this.Controls.Add(this.rdb5);
            this.Controls.Add(this.rdb4);
            this.Controls.Add(this.rdb3);
            this.Controls.Add(this.rdb2);
            this.Controls.Add(this.rdb1);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.mskPostcode);
            this.Controls.Add(this.txtLand);
            this.Controls.Add(this.txtGemeente);
            this.Controls.Add(this.txtBus);
            this.Controls.Add(this.txtHuisnummer);
            this.Controls.Add(this.txtStraat);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.mskGsmNummer);
            this.Controls.Add(this.cmbRichting);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNationaliteit);
            this.Controls.Add(this.txtGeboorteDatum);
            this.Controls.Add(this.txtGeboortePlaats);
            this.Controls.Add(this.txtFamilienaam);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Voornaam);
            this.Controls.Add(this.txtVoornaam);
            this.Name = "Leerling";
            this.Size = new System.Drawing.Size(771, 394);
            this.Load += new System.EventHandler(this.Leerling_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox mskRijksregisterNummer;
        private System.Windows.Forms.ComboBox cmbGeslacht;
        private System.Windows.Forms.Button Bevestigen;
        private System.Windows.Forms.RadioButton rdb6;
        private System.Windows.Forms.RadioButton rdb5;
        private System.Windows.Forms.RadioButton rdb4;
        private System.Windows.Forms.RadioButton rdb3;
        private System.Windows.Forms.RadioButton rdb2;
        protected System.Windows.Forms.RadioButton rdb1;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.MaskedTextBox mskPostcode;
        private System.Windows.Forms.TextBox txtLand;
        private System.Windows.Forms.TextBox txtGemeente;
        private System.Windows.Forms.TextBox txtBus;
        private System.Windows.Forms.TextBox txtHuisnummer;
        private System.Windows.Forms.TextBox txtStraat;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.MaskedTextBox mskGsmNummer;
        private System.Windows.Forms.ComboBox cmbRichting;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNationaliteit;
        private System.Windows.Forms.TextBox txtGeboorteDatum;
        private System.Windows.Forms.TextBox txtGeboortePlaats;
        private System.Windows.Forms.TextBox txtFamilienaam;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Voornaam;
        private System.Windows.Forms.TextBox txtVoornaam;
    }
}
