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
            if (prop.Default.lastSaveFolder.Substring(prop.Default.lastSaveFolder.Length - 1) != "/" && prop.Default.lastSaveFolder.Substring(prop.Default.lastSaveFolder.Length - 1) != @"\")
            {
                if (prop.Default.lastSaveFolder.Substring(prop.Default.lastSaveFolder.Length - 1) != "/")
                { prop.Default.lastSaveFolder += @"\"; prop.Default.Save(); }
                else if (prop.Default.lastSaveFolder.Substring(prop.Default.lastSaveFolder.Length - 1) != @"\")
                { prop.Default.lastSaveFolder += @"\"; prop.Default.Save(); }
            }
            setLogo();
            setFooter();
            btnClose2.Location = new Point(this.Width - btnClose2.Width - 15, 15);
            btnSettings.Location = new Point(btnClose2.Location.X - 38, btnClose2.Location.Y);
        }
        #endregion
        private void BtnClose2_Click(object sender, EventArgs e)
        { Application.Exit(); }
        private void BtnSettings_Click(object sender, EventArgs e)
        {
            DialogResult result = new CheckPassword().ShowDialog();
            if (result == DialogResult.OK)
            { new Settings().ShowDialog(); } else if (result == DialogResult.No) { MessageBox.Show("Fout wachtwoord!", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void BtnExportToPDF_Click(object sender, EventArgs e)
        { new ExportPDF().ShowDialog(); }
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
                d.updatenn = true;
                d.updateID = id;
                d.ShowDialog();
                this.Focus();
            }
        }
        #region footer
        void setLogo()
        {
            pbLogo.Load("https://pbs.twimg.com/profile_images/427530649839210496/Xq-_xksG_400x400.jpeg");
            //pbLogo.Size = new Size(pbLogo.Image.Width, pbLogo.Image.Height);
            pbLogo.Size = new Size(150, 150);
            pbLogo.BackColor = this.BackColor;
            int x = this.Width - pbLogo.Width - 30;
            int y = this.Height - pbLogo.Height - 30;
            pbLogo.Location = new Point(x, y);
        }
        void setFooter() //async
        {
            lblTime.Location = new Point(5, this.Height - lblTime.Height - 5);
            //await Task.Run(() => _setFooter());
            //lblTime.Text = "GIP Software | Rune " + @"\&" + " Gilles"; wordt gedaan in lblTime_Paint
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