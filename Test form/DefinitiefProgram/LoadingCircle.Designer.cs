namespace DefinitiefProgram
{
    partial class LoadingCircle
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
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.circle_progressbar1 = new DefinitiefProgram.Layout.circle_progressbar();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // circle_progressbar1
            // 
            this.circle_progressbar1.BackColor = System.Drawing.Color.White;
            this.circle_progressbar1.Location = new System.Drawing.Point(12, 12);
            this.circle_progressbar1.Name = "circle_progressbar1";
            this.circle_progressbar1.Size = new System.Drawing.Size(232, 232);
            this.circle_progressbar1.TabIndex = 0;
            // 
            // LoadingCircle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(256, 256);
            this.Controls.Add(this.circle_progressbar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoadingCircle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoadingCircle";
            this.Load += new System.EventHandler(this.LoadingCircle_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Layout.circle_progressbar circle_progressbar1;
    }
}