#region usings
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using prop = DefinitiefProgram.Properties.Settings;
#endregion
namespace DefinitiefProgram
{
    public partial class Menu : Form
    {
        #region vars
        string tempPath = Path.GetTempPath();
        Business b = new Business();
        #endregion

        #region controls
        #region form
        public Menu()
        { InitializeComponent(); }
        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        { }
        private void Menu_Load(object sender, EventArgs e)
        {
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Left = Top = 0;
            Width = Screen.PrimaryScreen.WorkingArea.Width;
            Height = Screen.PrimaryScreen.WorkingArea.Height;
            pnlMenu.Location = new Point((this.Width / 2) - (pnlMenu.Width / 2), (this.Height / 2) - (pnlMenu.Height / 2));
            if ((prop.Default.lastSaveFolder == null) || (prop.Default.lastSaveFolder == ""))
            { prop.Default.lastSaveFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); prop.Default.Save(); }
            setLogo();
            setFooter();
        }
        #endregion
        private void btnToevoegen_Click(object sender, EventArgs e)
        { Design d = new Design(); d.ShowDialog(); d.Dispose(); this.Focus(); }
        private void btnWijzigen_Click(object sender, EventArgs e)
        {
            Lijstleerlingen lijstleerlingen = new Lijstleerlingen();
            lijstleerlingen.m = this;
            lijstleerlingen.ShowDialog();
        }
        private void btnExport_Click(object sender, EventArgs e)
        { Export export = new Export(); export.Show(); }
        private void btnClose_Click(object sender, EventArgs e)
        { Application.Exit();}
        #endregion

        #region functions
        public void wijzigLLN(int id)
        {
            if (id != -1)
            {
                Design d = new Design();
                d.Text = "Leerling wijzigen";
                d.veldenvullen(id);
                d.ShowDialog();
                this.Focus();
            }
        }
        #region footer
        void setLogo()
        {
            pbLogo.Load("http://www.vhsj.be/sint-joris/images/logo_handelsschool_sint_joris.jpg");
            pbLogo.Size = new Size(pbLogo.Image.Width, pbLogo.Image.Height);
            pbLogo.BackColor = this.BackColor;
            int x = this.Width - pbLogo.Width - 30;
            int y = this.Height - pbLogo.Height - 30;
            pbLogo.Location = new Point(x, y);
        }
        async void setFooter()
        {
            lblTime.Location = new Point(5, this.Height - lblTime.Height - 5);
            //await Task.Run(() => _setFooter()); voor bv tijd (dingen die veranderen)
            //lblTime.Text = "GIP Software | Rune " + @"\&" + " Gilles"; wordt gedaan in _Paint
        }
        void _setFooter()
        {
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 1000;
            aTimer.Enabled = true;
        }
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        { this.Invoke(new Action(() => lblTime.Text = DateTime.Now.ToString() )); }
        private void lblTime_Paint(object sender, PaintEventArgs e)
        {
            lblTime.Text = "                                                            ";
            string topLine = "GIP Software | Rune & Gilles";
            string capLine = topLine.ToUpper();
            Font font = new Font("Verdana", 10, FontStyle.Regular);

            Graphics g = e.Graphics;
            g.DrawString(capLine, font, Brushes.Black, 0, 0);
        }
        private void pbLogo_Click(object sender, EventArgs e)
        { System.Diagnostics.Process.Start("www.slcb.be"); }
        #endregion
        #endregion
    }
}