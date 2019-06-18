namespace addLeerlingen
{
    partial class frmAddLeerlingen
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtAantalLLN = new System.Windows.Forms.TextBox();
            this.btnVoegToe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Aantal lln:";
            // 
            // txtAantalLLN
            // 
            this.txtAantalLLN.Location = new System.Drawing.Point(71, 6);
            this.txtAantalLLN.Name = "txtAantalLLN";
            this.txtAantalLLN.Size = new System.Drawing.Size(100, 20);
            this.txtAantalLLN.TabIndex = 1;
            this.txtAantalLLN.Text = "5";
            // 
            // btnVoegToe
            // 
            this.btnVoegToe.Location = new System.Drawing.Point(12, 32);
            this.btnVoegToe.Name = "btnVoegToe";
            this.btnVoegToe.Size = new System.Drawing.Size(159, 30);
            this.btnVoegToe.TabIndex = 2;
            this.btnVoegToe.Text = "Toevoegen";
            this.btnVoegToe.UseVisualStyleBackColor = true;
            this.btnVoegToe.Click += new System.EventHandler(this.BtnVoegToe_Click);
            // 
            // frmAddLeerlingen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(190, 79);
            this.Controls.Add(this.btnVoegToe);
            this.Controls.Add(this.txtAantalLLN);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddLeerlingen";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Leerlingen toeveogen";
            this.Load += new System.EventHandler(this.FrmAddLeerlingen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAantalLLN;
        private System.Windows.Forms.Button btnVoegToe;
    }
}

