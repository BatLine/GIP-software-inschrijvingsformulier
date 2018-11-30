namespace frmtest
{
    partial class Gegevens_uit_database_halen
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
            this.txtNaam = new System.Windows.Forms.TextBox();
            this.lbNamen = new System.Windows.Forms.ListBox();
            this.btnVernieuwen = new System.Windows.Forms.Button();
            this.btnToevoegen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNaam
            // 
            this.txtNaam.Location = new System.Drawing.Point(12, 12);
            this.txtNaam.Name = "txtNaam";
            this.txtNaam.Size = new System.Drawing.Size(177, 20);
            this.txtNaam.TabIndex = 0;
            // 
            // lbNamen
            // 
            this.lbNamen.FormattingEnabled = true;
            this.lbNamen.Location = new System.Drawing.Point(12, 70);
            this.lbNamen.Name = "lbNamen";
            this.lbNamen.Size = new System.Drawing.Size(258, 368);
            this.lbNamen.TabIndex = 1;
            // 
            // btnVernieuwen
            // 
            this.btnVernieuwen.Location = new System.Drawing.Point(12, 38);
            this.btnVernieuwen.Name = "btnVernieuwen";
            this.btnVernieuwen.Size = new System.Drawing.Size(258, 23);
            this.btnVernieuwen.TabIndex = 2;
            this.btnVernieuwen.Text = "Vernieuw";
            this.btnVernieuwen.UseVisualStyleBackColor = true;
            this.btnVernieuwen.Click += new System.EventHandler(this.btnVernieuwen_Click);
            // 
            // btnToevoegen
            // 
            this.btnToevoegen.Location = new System.Drawing.Point(195, 12);
            this.btnToevoegen.Name = "btnToevoegen";
            this.btnToevoegen.Size = new System.Drawing.Size(75, 20);
            this.btnToevoegen.TabIndex = 3;
            this.btnToevoegen.Text = "Toevoegen";
            this.btnToevoegen.UseVisualStyleBackColor = true;
            this.btnToevoegen.Click += new System.EventHandler(this.btnToevoegen_Click);
            // 
            // Gegevens_uit_database_halen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 450);
            this.Controls.Add(this.btnToevoegen);
            this.Controls.Add(this.btnVernieuwen);
            this.Controls.Add(this.lbNamen);
            this.Controls.Add(this.txtNaam);
            this.Name = "Gegevens_uit_database_halen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Datatbase";
            this.Load += new System.EventHandler(this.Gegevens_uit_database_halen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNaam;
        private System.Windows.Forms.ListBox lbNamen;
        private System.Windows.Forms.Button btnVernieuwen;
        private System.Windows.Forms.Button btnToevoegen;
    }
}