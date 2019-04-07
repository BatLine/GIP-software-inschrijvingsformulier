namespace DefinitiefProgram.Layout
{
    partial class circle_progressbar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(circle_progressbar));
            this.circle = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.stretch = new System.Windows.Forms.Timer(this.components);
            this.fader = new System.Windows.Forms.Timer(this.components);
            this.ColorTransition = new Bunifu.Framework.UI.BunifuColorTransition(this.components);
            this.SuspendLayout();
            // 
            // circle
            // 
            this.circle.animated = true;
            this.circle.animationIterval = 2;
            this.circle.animationSpeed = 1;
            this.circle.BackColor = System.Drawing.Color.White;
            this.circle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("circle.BackgroundImage")));
            this.circle.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.circle.ForeColor = System.Drawing.Color.Black;
            this.circle.LabelVisible = false;
            this.circle.LineProgressThickness = 8;
            this.circle.LineThickness = 5;
            this.circle.Location = new System.Drawing.Point(10, 10);
            this.circle.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.circle.MaxValue = 200;
            this.circle.Name = "circle";
            this.circle.ProgressBackColor = System.Drawing.Color.White;
            this.circle.ProgressColor = System.Drawing.Color.SeaGreen;
            this.circle.Size = new System.Drawing.Size(212, 212);
            this.circle.TabIndex = 1;
            this.circle.Value = 30;
            // 
            // stretch
            // 
            this.stretch.Enabled = true;
            this.stretch.Interval = 1;
            this.stretch.Tick += new System.EventHandler(this.stretch_Tick);
            // 
            // fader
            // 
            this.fader.Enabled = true;
            this.fader.Interval = 1;
            this.fader.Tick += new System.EventHandler(this.fader_Tick);
            // 
            // ColorTransition
            // 
            this.ColorTransition.Color1 = System.Drawing.Color.White;
            this.ColorTransition.Color2 = System.Drawing.Color.White;
            this.ColorTransition.ProgessValue = 0;
            // 
            // circle_progressbar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.circle);
            this.Name = "circle_progressbar";
            this.Size = new System.Drawing.Size(232, 232);
            this.ResumeLayout(false);

        }

        #endregion

        public Bunifu.Framework.UI.BunifuCircleProgressbar circle;
        private System.Windows.Forms.Timer stretch;
        private System.Windows.Forms.Timer fader;
        private Bunifu.Framework.UI.BunifuColorTransition ColorTransition;
    }
}
