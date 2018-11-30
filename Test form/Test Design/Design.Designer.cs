namespace Test_Design
{
    partial class Design
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
            this.xylosTabControl1 = new XylosTabControl();
            this.lln = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.xylosTabControl1.SuspendLayout();
            this.lln.SuspendLayout();
            this.SuspendLayout();
            // 
            // xylosTabControl1
            // 
            this.xylosTabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.xylosTabControl1.Controls.Add(this.lln);
            this.xylosTabControl1.Controls.Add(this.tabPage2);
            this.xylosTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xylosTabControl1.FirstHeaderBorder = false;
            this.xylosTabControl1.ItemSize = new System.Drawing.Size(40, 180);
            this.xylosTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xylosTabControl1.Multiline = true;
            this.xylosTabControl1.Name = "xylosTabControl1";
            this.xylosTabControl1.SelectedIndex = 0;
            this.xylosTabControl1.Size = new System.Drawing.Size(800, 450);
            this.xylosTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.xylosTabControl1.TabIndex = 0;
            // 
            // lln
            // 
            this.lln.BackColor = System.Drawing.Color.White;
            this.lln.Controls.Add(this.button1);
            this.lln.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lln.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(133)))), ((int)(((byte)(142)))));
            this.lln.Location = new System.Drawing.Point(184, 4);
            this.lln.Name = "lln";
            this.lln.Padding = new System.Windows.Forms.Padding(3);
            this.lln.Size = new System.Drawing.Size(612, 442);
            this.lln.TabIndex = 0;
            this.lln.Text = "Leerling";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tabPage2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(133)))), ((int)(((byte)(142)))));
            this.tabPage2.Location = new System.Drawing.Point(184, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(612, 442);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Ouder";
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(96, 236);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Open loading";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Design
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.xylosTabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Design";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inschrijving";
            this.xylosTabControl1.ResumeLayout(false);
            this.lln.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private XylosTabControl xylosTabControl1;
        private System.Windows.Forms.TabPage lln;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
    }
}

