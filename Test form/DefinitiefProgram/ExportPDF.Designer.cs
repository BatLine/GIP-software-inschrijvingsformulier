namespace DefinitiefProgram
{
    partial class ExportPDF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportPDF));
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkPrinten = new XylosCheckBox();
            this.btnBrowse = new XylosButton();
            this.txtVoornaam = new XylosTextBox();
            this.loadingcircle = new DefinitiefProgram.Layout.circle_progressbar();
            this.btnCreatePDF = new XylosButton();
            this.txtAchternaam = new XylosTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(3, 9);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(98, 13);
            this.bunifuCustomLabel1.TabIndex = 6;
            this.bunifuCustomLabel1.Text = "Voornaam Leerling:";
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(3, 41);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(107, 13);
            this.bunifuCustomLabel2.TabIndex = 6;
            this.bunifuCustomLabel2.Text = "Achternaam Leerling:";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(377, 9);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(384, 20);
            this.txtPath.TabIndex = 5;
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(311, 9);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(60, 13);
            this.bunifuCustomLabel3.TabIndex = 6;
            this.bunifuCustomLabel3.Text = "Opslaan in:";
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(295, 9);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(10, 94);
            this.bunifuSeparator1.TabIndex = 9;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkPrinten);
            this.panel1.Controls.Add(this.bunifuCustomLabel1);
            this.panel1.Controls.Add(this.btnBrowse);
            this.panel1.Controls.Add(this.txtVoornaam);
            this.panel1.Controls.Add(this.loadingcircle);
            this.panel1.Controls.Add(this.btnCreatePDF);
            this.panel1.Controls.Add(this.bunifuSeparator1);
            this.panel1.Controls.Add(this.bunifuCustomLabel2);
            this.panel1.Controls.Add(this.bunifuCustomLabel3);
            this.panel1.Controls.Add(this.txtAchternaam);
            this.panel1.Controls.Add(this.txtPath);
            this.panel1.Location = new System.Drawing.Point(5, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(797, 108);
            this.panel1.TabIndex = 12;
            // 
            // chkPrinten
            // 
            this.chkPrinten.Checked = false;
            this.chkPrinten.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkPrinten.EnabledCalc = true;
            this.chkPrinten.Location = new System.Drawing.Point(377, 34);
            this.chkPrinten.Name = "chkPrinten";
            this.chkPrinten.Size = new System.Drawing.Size(156, 18);
            this.chkPrinten.TabIndex = 10;
            this.chkPrinten.Text = "Alleen printen";
            this.chkPrinten.CheckedChanged += new XylosCheckBox.CheckedChangedEventHandler(this.ChkPrinten_CheckedChanged);
            // 
            // btnBrowse
            // 
            this.btnBrowse.EnabledCalc = true;
            this.btnBrowse.Location = new System.Drawing.Point(767, 9);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(23, 20);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "...";
            this.btnBrowse.Click += new XylosButton.ClickEventHandler(this.BtnBrowse_Click);
            // 
            // txtVoornaam
            // 
            this.txtVoornaam.EnabledCalc = true;
            this.txtVoornaam.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtVoornaam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(133)))), ((int)(((byte)(142)))));
            this.txtVoornaam.Location = new System.Drawing.Point(116, 9);
            this.txtVoornaam.MaxLength = 32767;
            this.txtVoornaam.MultiLine = false;
            this.txtVoornaam.Name = "txtVoornaam";
            this.txtVoornaam.ReadOnly = false;
            this.txtVoornaam.Size = new System.Drawing.Size(173, 29);
            this.txtVoornaam.TabIndex = 1;
            this.txtVoornaam.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtVoornaam.UseSystemPasswordChar = false;
            this.txtVoornaam.TextChanged += new System.EventHandler(this.TxtVoornaam_TextChanged);
            // 
            // loadingcircle
            // 
            this.loadingcircle.BackColor = System.Drawing.Color.White;
            this.loadingcircle.Location = new System.Drawing.Point(301, 34);
            this.loadingcircle.Name = "loadingcircle";
            this.loadingcircle.Size = new System.Drawing.Size(71, 68);
            this.loadingcircle.TabIndex = 6;
            this.loadingcircle.Visible = false;
            // 
            // btnCreatePDF
            // 
            this.btnCreatePDF.EnabledCalc = true;
            this.btnCreatePDF.Location = new System.Drawing.Point(116, 79);
            this.btnCreatePDF.Name = "btnCreatePDF";
            this.btnCreatePDF.Size = new System.Drawing.Size(173, 23);
            this.btnCreatePDF.TabIndex = 3;
            this.btnCreatePDF.Text = "Maak PDF";
            this.btnCreatePDF.Click += new XylosButton.ClickEventHandler(this.BtnCreatePDF_Click);
            // 
            // txtAchternaam
            // 
            this.txtAchternaam.EnabledCalc = true;
            this.txtAchternaam.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAchternaam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(133)))), ((int)(((byte)(142)))));
            this.txtAchternaam.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtAchternaam.Location = new System.Drawing.Point(116, 44);
            this.txtAchternaam.MaxLength = 32767;
            this.txtAchternaam.MultiLine = false;
            this.txtAchternaam.Name = "txtAchternaam";
            this.txtAchternaam.ReadOnly = false;
            this.txtAchternaam.Size = new System.Drawing.Size(173, 29);
            this.txtAchternaam.TabIndex = 2;
            this.txtAchternaam.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtAchternaam.UseSystemPasswordChar = false;
            this.txtAchternaam.TextChanged += new System.EventHandler(this.TxtAchternaam_TextChanged);
            // 
            // ExportPDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(811, 119);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportPDF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exporteren naar PDF";
            this.Load += new System.EventHandler(this.ExportPDF_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private XylosTextBox txtVoornaam;
        private XylosButton btnCreatePDF;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private XylosTextBox txtAchternaam;
        private System.Windows.Forms.TextBox txtPath;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private Layout.circle_progressbar loadingcircle;
        private XylosButton btnBrowse;
        private System.Windows.Forms.Panel panel1;
        private XylosCheckBox chkPrinten;
    }
}