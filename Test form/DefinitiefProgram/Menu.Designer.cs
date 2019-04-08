namespace DefinitiefProgram
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnExport = new XylosButton();
            this.btnToevoegen = new XylosButton();
            this.btnClose = new XylosButton();
            this.btnWijzigen = new XylosButton();
            this.lblTime = new System.Windows.Forms.Label();
            this.pbLogo = new Bunifu.Framework.UI.BunifuImageButton();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(54, 2);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(87, 33);
            this.bunifuCustomLabel1.TabIndex = 7;
            this.bunifuCustomLabel1.Text = "Menu";
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.btnExport);
            this.pnlMenu.Controls.Add(this.bunifuCustomLabel1);
            this.pnlMenu.Controls.Add(this.btnToevoegen);
            this.pnlMenu.Controls.Add(this.btnClose);
            this.pnlMenu.Controls.Add(this.btnWijzigen);
            this.pnlMenu.Location = new System.Drawing.Point(113, 28);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(198, 373);
            this.pnlMenu.TabIndex = 8;
            // 
            // btnExport
            // 
            this.btnExport.EnabledCalc = true;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(4, 174);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(191, 60);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Leerlingen exporteren";
            this.btnExport.Click += new XylosButton.ClickEventHandler(this.btnExport_Click);
            // 
            // btnToevoegen
            // 
            this.btnToevoegen.EnabledCalc = true;
            this.btnToevoegen.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToevoegen.Location = new System.Drawing.Point(4, 42);
            this.btnToevoegen.Name = "btnToevoegen";
            this.btnToevoegen.Size = new System.Drawing.Size(191, 60);
            this.btnToevoegen.TabIndex = 3;
            this.btnToevoegen.Text = "Nieuwe leerling toevoegen";
            this.btnToevoegen.Click += new XylosButton.ClickEventHandler(this.btnToevoegen_Click);
            // 
            // btnClose
            // 
            this.btnClose.EnabledCalc = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(4, 306);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(191, 60);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Sluiten";
            this.btnClose.Click += new XylosButton.ClickEventHandler(this.btnClose_Click);
            // 
            // btnWijzigen
            // 
            this.btnWijzigen.EnabledCalc = true;
            this.btnWijzigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWijzigen.Location = new System.Drawing.Point(4, 108);
            this.btnWijzigen.Name = "btnWijzigen";
            this.btnWijzigen.Size = new System.Drawing.Size(191, 60);
            this.btnWijzigen.TabIndex = 4;
            this.btnWijzigen.Text = "Bestaande leerling aanpassen";
            this.btnWijzigen.Click += new XylosButton.ClickEventHandler(this.btnWijzigen_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(22, 418);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(46, 18);
            this.lblTime.TabIndex = 10;
            this.lblTime.Text = "label1";
            this.lblTime.Paint += new System.Windows.Forms.PaintEventHandler(this.lblTime_Paint);
            // 
            // pbLogo
            // 
            this.pbLogo.BackColor = System.Drawing.Color.SeaGreen;
            this.pbLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.ImageActive = null;
            this.pbLogo.Location = new System.Drawing.Point(351, 202);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(71, 71);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 11;
            this.pbLogo.TabStop = false;
            this.pbLogo.WaitOnLoad = true;
            this.pbLogo.Zoom = 10;
            this.pbLogo.Click += new System.EventHandler(this.pbLogo_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(546, 460);
            this.ControlBox = false;
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.pnlMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Menu_FormClosing);
            this.Load += new System.EventHandler(this.Menu_Load);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private XylosButton btnExport;
        private XylosButton btnWijzigen;
        private XylosButton btnToevoegen;
        private XylosButton btnClose;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Label lblTime;
        private Bunifu.Framework.UI.BunifuImageButton pbLogo;
    }
}