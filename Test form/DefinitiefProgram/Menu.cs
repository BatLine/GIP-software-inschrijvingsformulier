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
        void setLogo()
        {
            pbLogo.Load("http://www.vhsj.be/sint-joris/images/logo_handelsschool_sint_joris.jpg");
            int x = this.Width - pbLogo.Width - 20;
            int y = this.Height - pbLogo.Height - 20;
            pbLogo.Location = new Point(x, y);
        }
        #endregion
    }
}
