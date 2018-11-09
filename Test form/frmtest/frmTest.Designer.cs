namespace frmtest
{
    partial class frmTest
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtText = new System.Windows.Forms.TextBox();
            this.txtGetal = new System.Windows.Forms.TextBox();
            this.txtVeelText = new System.Windows.Forms.RichTextBox();
            this.txtMaskedText = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOpslaan1 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Text";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Getal";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Veel text";
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(72, 41);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(100, 20);
            this.txtText.TabIndex = 3;
            this.txtText.Text = "Test";
            // 
            // txtGetal
            // 
            this.txtGetal.Location = new System.Drawing.Point(72, 68);
            this.txtGetal.Name = "txtGetal";
            this.txtGetal.Size = new System.Drawing.Size(100, 20);
            this.txtGetal.TabIndex = 4;
            // 
            // txtVeelText
            // 
            this.txtVeelText.Location = new System.Drawing.Point(72, 95);
            this.txtVeelText.Name = "txtVeelText";
            this.txtVeelText.Size = new System.Drawing.Size(100, 54);
            this.txtVeelText.TabIndex = 5;
            this.txtVeelText.Text = "";
            // 
            // txtMaskedText
            // 
            this.txtMaskedText.Location = new System.Drawing.Point(72, 155);
            this.txtMaskedText.Mask = "00/00/0000";
            this.txtMaskedText.Name = "txtMaskedText";
            this.txtMaskedText.Size = new System.Drawing.Size(100, 20);
            this.txtMaskedText.TabIndex = 6;
            this.txtMaskedText.ValidatingType = typeof(System.DateTime);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Masked text";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOpslaan1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMaskedText);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtVeelText);
            this.groupBox1.Controls.Add(this.txtText);
            this.groupBox1.Controls.Add(this.txtGetal);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 238);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnOpslaan1
            // 
            this.btnOpslaan1.Location = new System.Drawing.Point(12, 198);
            this.btnOpslaan1.Name = "btnOpslaan1";
            this.btnOpslaan1.Size = new System.Drawing.Size(140, 23);
            this.btnOpslaan1.TabIndex = 8;
            this.btnOpslaan1.Text = "Opslaan in Excel";
            this.btnOpslaan1.UseVisualStyleBackColor = true;
            this.btnOpslaan1.Click += new System.EventHandler(this.btnOpslaan1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(377, 76);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 59);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTest";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test form.";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.TextBox txtGetal;
        private System.Windows.Forms.RichTextBox txtVeelText;
        private System.Windows.Forms.MaskedTextBox txtMaskedText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOpslaan1;
        private System.Windows.Forms.Button button1;
    }
}

