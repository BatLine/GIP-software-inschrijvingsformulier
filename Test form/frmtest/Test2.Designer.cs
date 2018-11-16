namespace frmtest
{
    partial class Test2
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
            this.TabLeerling = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.leerling2 = new frmtest.Leerling();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ouders1 = new frmtest.Ouders();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnBevestigen = new System.Windows.Forms.Button();
            this.btnUploaden = new System.Windows.Forms.Button();
            this.TabLeerling.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabLeerling
            // 
            this.TabLeerling.Controls.Add(this.tabPage1);
            this.TabLeerling.Controls.Add(this.tabPage2);
            this.TabLeerling.Controls.Add(this.tabPage3);
            this.TabLeerling.Location = new System.Drawing.Point(0, 0);
            this.TabLeerling.Name = "TabLeerling";
            this.TabLeerling.SelectedIndex = 0;
            this.TabLeerling.Size = new System.Drawing.Size(786, 446);
            this.TabLeerling.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.leerling2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(778, 420);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // leerling2
            // 
            this.leerling2.Location = new System.Drawing.Point(4, 6);
            this.leerling2.Name = "leerling2";
            this.leerling2.Size = new System.Drawing.Size(771, 379);
            this.leerling2.TabIndex = 0;
            this.leerling2.Load += new System.EventHandler(this.leerling2_Load);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ouders1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(778, 420);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ouders1
            // 
            this.ouders1.Location = new System.Drawing.Point(3, 3);
            this.ouders1.Name = "ouders1";
            this.ouders1.Size = new System.Drawing.Size(772, 418);
            this.ouders1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnBevestigen);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(778, 420);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnBevestigen
            // 
            this.btnBevestigen.Location = new System.Drawing.Point(669, 365);
            this.btnBevestigen.Name = "btnBevestigen";
            this.btnBevestigen.Size = new System.Drawing.Size(101, 51);
            this.btnBevestigen.TabIndex = 0;
            this.btnBevestigen.Text = "Bevestigen";
            this.btnBevestigen.UseVisualStyleBackColor = true;
            this.btnBevestigen.Click += new System.EventHandler(this.btnBevestigen_Click);
            // 
            // btnUploaden
            // 
            this.btnUploaden.Location = new System.Drawing.Point(673, 490);
            this.btnUploaden.Name = "btnUploaden";
            this.btnUploaden.Size = new System.Drawing.Size(101, 22);
            this.btnUploaden.TabIndex = 1;
            this.btnUploaden.Text = "Uploaden";
            this.btnUploaden.UseVisualStyleBackColor = true;
            this.btnUploaden.Visible = false;
            this.btnUploaden.Click += new System.EventHandler(this.button2_Click);
            // 
            // Test2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 524);
            this.Controls.Add(this.btnUploaden);
            this.Controls.Add(this.TabLeerling);
            this.Name = "Test2";
            this.Text = "Test2";
            this.Load += new System.EventHandler(this.Test2_Load);
            this.TabLeerling.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabLeerling;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Leerling leerling1;
        private Ouders ouders1;
        private Leerling leerling2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnBevestigen;
        private System.Windows.Forms.Button btnUploaden;
    }
}