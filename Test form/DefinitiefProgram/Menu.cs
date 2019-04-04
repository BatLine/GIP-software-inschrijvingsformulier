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
using Excel = Microsoft.Office.Interop.Excel;
using prop = DefinitiefProgram.Properties.Settings;
#endregion
namespace DefinitiefProgram
{
    public partial class Menu : Form
    { 
        #region vars
        Excel.Application xlexcel;
        Excel.Workbook xlWorkBook;
        Excel.Worksheet xlWorkSheet;
        object misValue = System.Reflection.Missing.Value;
        string tempPath = Path.GetTempPath();
        Business b = new Business();
        public int selectedLeerlingID=-1;
        #endregion

        #region controls
        #region form
        public Menu()
        { InitializeComponent(); }
        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        { }
        private void Menu_Load(object sender, EventArgs e)
        {
            if ((prop.Default.lastSaveFolder == null) || (prop.Default.lastSaveFolder == ""))
            { prop.Default.lastSaveFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); prop.Default.Save(); }
        }
        #endregion
        private void btnToevoegen_Click(object sender, EventArgs e)
        { Design d = new Design(); d.ShowDialog(); }
        private void btnWijzigen_Click(object sender, EventArgs e)
        {
            Lijstleerlingen lijstleerlingen = new Lijstleerlingen();
            lijstleerlingen.m = this;
            lijstleerlingen.Show();
            lijstleerlingen.BringToFront();
            lijstleerlingen.refreshLLN();
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
                d.veldenvullen(selectedLeerlingID);
                d.ShowDialog();
            }
        }
        #endregion
    }
}
