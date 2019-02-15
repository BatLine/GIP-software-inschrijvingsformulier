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
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Naam");
            this.label1 = new System.Windows.Forms.Label();
            this.rdbIedereen = new XylosRadioButton();
            this.rdbSpecifiek = new XylosRadioButton();
            this.gpSpecifiek = new System.Windows.Forms.GroupBox();
            this.chkSpecifiker = new XylosCheckBox();
            this.lblAantalLLN = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTot = new System.Windows.Forms.DateTimePicker();
            this.dtpVan = new System.Windows.Forms.DateTimePicker();
            this.gpSpecifieker = new System.Windows.Forms.GroupBox();
            this.lvSpecifieker = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnExport = new XylosButton();
            this.btnCancel = new XylosButton();
            this.gpSpecifiek.SuspendLayout();
            this.gpSpecifieker.SuspendLayout();
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
            // gpSpecifiek
            // 
            this.gpSpecifiek.Controls.Add(this.chkSpecifiker);
            this.gpSpecifiek.Controls.Add(this.lblAantalLLN);
            this.gpSpecifiek.Controls.Add(this.label3);
            this.gpSpecifiek.Controls.Add(this.label2);
            this.gpSpecifiek.Controls.Add(this.dtpTot);
            this.gpSpecifiek.Controls.Add(this.dtpVan);
            this.gpSpecifiek.Location = new System.Drawing.Point(14, 73);
            this.gpSpecifiek.Name = "gpSpecifiek";
            this.gpSpecifiek.Size = new System.Drawing.Size(277, 125);
            this.gpSpecifiek.TabIndex = 3;
            this.gpSpecifiek.TabStop = false;
            this.gpSpecifiek.Text = "Op datum";
            // 
            // chkSpecifiker
            // 
            this.chkSpecifiker.Checked = false;
            this.chkSpecifiker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkSpecifiker.EnabledCalc = true;
            this.chkSpecifiker.Location = new System.Drawing.Point(9, 101);
            this.chkSpecifiker.Name = "chkSpecifiker";
            this.chkSpecifiker.Size = new System.Drawing.Size(262, 18);
            this.chkSpecifiker.TabIndex = 5;
            this.chkSpecifiker.Text = "Bekijk deze leerlingen / selecteer specifieker";
            this.chkSpecifiker.CheckedChanged += new XylosCheckBox.CheckedChangedEventHandler(this.chkSpecifiker_CheckedChanged);
            // 
            // lblAantalLLN
            // 
            this.lblAantalLLN.AutoSize = true;
            this.lblAantalLLN.Location = new System.Drawing.Point(6, 85);
            this.lblAantalLLN.Name = "lblAantalLLN";
            this.lblAantalLLN.Size = new System.Drawing.Size(140, 13);
            this.lblAantalLLN.TabIndex = 4;
            this.lblAantalLLN.Text = "0 Leerlingen in deze periode";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tot:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Van:";
            // 
            // dtpTot
            // 
            this.dtpTot.Location = new System.Drawing.Point(41, 55);
            this.dtpTot.Name = "dtpTot";
            this.dtpTot.Size = new System.Drawing.Size(230, 20);
            this.dtpTot.TabIndex = 1;
            // 
            // dtpVan
            // 
            this.dtpVan.Location = new System.Drawing.Point(41, 19);
            this.dtpVan.Name = "dtpVan";
            this.dtpVan.Size = new System.Drawing.Size(230, 20);
            this.dtpVan.TabIndex = 0;
            // 
            // gpSpecifieker
            // 
            this.gpSpecifieker.Controls.Add(this.lvSpecifieker);
            this.gpSpecifieker.Location = new System.Drawing.Point(14, 204);
            this.gpSpecifieker.Name = "gpSpecifieker";
            this.gpSpecifieker.Size = new System.Drawing.Size(277, 288);
            this.gpSpecifieker.TabIndex = 4;
            this.gpSpecifieker.TabStop = false;
            this.gpSpecifieker.Text = "Op naam";
            // 
            // lvSpecifieker
            // 
            this.lvSpecifieker.CheckBoxes = true;
            this.lvSpecifieker.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvSpecifieker.FullRowSelect = true;
            listViewItem4.Checked = true;
            listViewItem4.StateImageIndex = 1;
            this.lvSpecifieker.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem4});
            this.lvSpecifieker.Location = new System.Drawing.Point(6, 19);
            this.lvSpecifieker.Name = "lvSpecifieker";
            this.lvSpecifieker.Size = new System.Drawing.Size(265, 263);
            this.lvSpecifieker.TabIndex = 0;
            this.lvSpecifieker.UseCompatibleStateImageBehavior = false;
            this.lvSpecifieker.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Naam";
            this.columnHeader1.Width = 251;
            // 
            // btnExport
            // 
            this.btnExport.EnabledCalc = true;
            this.btnExport.Location = new System.Drawing.Point(265, 73);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(26, 23);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "=>";
            // 
            // btnCancel
            // 
            this.btnCancel.EnabledCalc = true;
            this.btnCancel.Location = new System.Drawing.Point(233, 73);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(26, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "<=";
            // 
            // Export
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(302, 499);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.gpSpecifieker);
            this.Controls.Add(this.gpSpecifiek);
            this.Controls.Add(this.rdbSpecifiek);
            this.Controls.Add(this.rdbIedereen);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Export";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export";
            this.gpSpecifiek.ResumeLayout(false);
            this.gpSpecifiek.PerformLayout();
            this.gpSpecifieker.ResumeLayout(false);
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
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private XylosButton btnExport;
        private XylosButton btnCancel;
    }
}