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
            this.btnExport = new XylosButton();
            this.btnWijzigen = new XylosButton();
            this.btnToevoegen = new XylosButton();
            this.SuspendLayout();
            // 
            // btnExport
            // 
            this.btnExport.EnabledCalc = true;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(30, 104);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(140, 34);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Leerlingen exporteren";
            // 
            // btnWijzigen
            // 
            this.btnWijzigen.EnabledCalc = true;
            this.btnWijzigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWijzigen.Location = new System.Drawing.Point(30, 64);
            this.btnWijzigen.Name = "btnWijzigen";
            this.btnWijzigen.Size = new System.Drawing.Size(140, 34);
            this.btnWijzigen.TabIndex = 4;
            this.btnWijzigen.Text = "Leerling wijzigen";
            this.btnWijzigen.Click += new XylosButton.ClickEventHandler(this.btnWijzigen_Click);
            // 
            // btnToevoegen
            // 
            this.btnToevoegen.EnabledCalc = true;
            this.btnToevoegen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToevoegen.Location = new System.Drawing.Point(30, 24);
            this.btnToevoegen.Name = "btnToevoegen";
            this.btnToevoegen.Size = new System.Drawing.Size(140, 34);
            this.btnToevoegen.TabIndex = 3;
            this.btnToevoegen.Text = "Leerling toevoegen";
            this.btnToevoegen.Click += new XylosButton.ClickEventHandler(this.btnToevoegen_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(200, 162);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnWijzigen);
            this.Controls.Add(this.btnToevoegen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private XylosButton btnExport;
        private XylosButton btnWijzigen;
        private XylosButton btnToevoegen;
    }
}