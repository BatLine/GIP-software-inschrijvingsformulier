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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadingCircle));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.circle = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // circle
            // 
            this.circle.animated = true;
            this.circle.animationIterval = 5;
            this.circle.animationSpeed = 30;
            this.circle.BackColor = System.Drawing.Color.White;
            this.circle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("circle.BackgroundImage")));
            this.circle.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.circle.ForeColor = System.Drawing.Color.Black;
            this.circle.LabelVisible = false;
            this.circle.LineProgressThickness = 8;
            this.circle.LineThickness = 5;
            this.circle.Location = new System.Drawing.Point(18, 18);
            this.circle.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.circle.MaxValue = 100;
            this.circle.Name = "circle";
            this.circle.ProgressBackColor = System.Drawing.Color.DarkSlateGray;
            this.circle.ProgressColor = System.Drawing.Color.Cyan;
            this.circle.Size = new System.Drawing.Size(212, 212);
            this.circle.TabIndex = 0;
            this.circle.Value = 20;
            // 
            // LoadingCircle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(248, 248);
            this.Controls.Add(this.circle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoadingCircle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoadingCircle";
            this.Load += new System.EventHandler(this.LoadingCircle_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        public Bunifu.Framework.UI.BunifuCircleProgressbar circle;
    }
}