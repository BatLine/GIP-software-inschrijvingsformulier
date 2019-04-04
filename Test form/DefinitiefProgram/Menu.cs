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
        public Menu()
        { InitializeComponent(); }
        private void btnToevoegen_Click(object sender, EventArgs e)
        {
            Design d = new Design();
            d.ShowDialog();
        }
        private void btnWijzigen_Click(object sender, EventArgs e)
        {
            Lijstleerlingen lijstleerlingen = new Lijstleerlingen();
            lijstleerlingen.m = this;
            lijstleerlingen.ShowDialog();
            if ((lijstleerlingen.DialogResult == DialogResult.OK) && (selectedLeerlingID != -1))
            {
                Design d = new Design(); d.Text = "Leerling wijzigen";
                d.veldenvullen(selectedLeerlingID);
                d.ShowDialog();
            }
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            //moet nog verplaatst worden naar export dinges
            //FolderBrowserDialog fbd = new FolderBrowserDialog();
            //fbd.SelectedPath = prop.Default.lastSaveFolder;
            //DialogResult result = fbd.ShowDialog();

            //if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            //{
            //    prop.Default.lastSaveFolder = fbd.SelectedPath +  @"\"; prop.Default.Save();
            //    if (export(prop.Default.lastSaveFolder, "Leerlingen.xlsx"))
            //    { MessageBox.Show("Leerlingen ge-exporteerd.", "", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            //    else { MessageBox.Show("Leerlingen exporteren mislukt.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            //}

            Export export = new Export();
            export.Show();
        }
        private void btnClose_Click(object sender, EventArgs e)
        { Application.Exit();}
        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        { }
        private void Menu_Load(object sender, EventArgs e)
        {
            if ((prop.Default.lastSaveFolder == null) || (prop.Default.lastSaveFolder == ""))
            { prop.Default.lastSaveFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); prop.Default.Save(); }
        }
        #endregion

        #region functions
        bool export(string locatie, string naam)
        {
            int intTeller = 1;
            //alles in excel zetten
            //exel openen
            xlexcel = new Excel.Application();
            xlexcel.Visible = false;

            //vorige resulaten verwijderen
            if (File.Exists(locatie + naam))
                File.Delete(locatie + naam);
            if (File.Exists(tempPath + @"\tempLeerlingen.xlsx"))
            { File.Delete(tempPath + @"\tempLeerlingen.xlsx"); }
            //leeg excel document aanmaken.
            var app = new Excel.Application();
            var wb = app.Workbooks.Add();
            wb.SaveAs(tempPath + @"tempLeerlingen.xlsx");
            wb.Close();

            //Bestand openen en wijzigen.
            xlWorkBook = xlexcel.Workbooks.Open(tempPath + @"\tempLeerlingen.xlsx", 0, true, 5, "", "", true,
            Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            

            foreach (Leerling l in b.getAlleLeerlingen())
            {

                xlWorkSheet.Cells[intTeller, 1] = l.StrNaam;
                xlWorkSheet.Cells[intTeller, 2] = l.StrVoornaam;
                xlWorkSheet.Cells[intTeller, 3] = l.StrBijkNaam;
                xlWorkSheet.Cells[intTeller, 4] = l.StrGeslacht;
                xlWorkSheet.Cells[intTeller, 5] = l.StrGeboortedatum;
                xlWorkSheet.Cells[intTeller, 6] = l.StrGeboorteplaats;
                xlWorkSheet.Cells[intTeller, 7] = l.StrRijkregisternummer;
                xlWorkSheet.Cells[intTeller, 8] = l.StrStraat;
                xlWorkSheet.Cells[intTeller, 9] = l.StrHuisnummer;
                xlWorkSheet.Cells[intTeller, 10] = l.StrBus;
                xlWorkSheet.Cells[intTeller, 11] = l.StrPostcode;
                xlWorkSheet.Cells[intTeller, 12] = l.StrGemeente;
                xlWorkSheet.Cells[intTeller, 13] = l.StrLand;
                xlWorkSheet.Cells[intTeller, 14] = l.StrNationaliteit;
                if (l.O.StrGezinshoofd == "Moeder")
                { xlWorkSheet.Cells[intTeller, 15] = l.O.StrTelefoonWerkMoeder; xlWorkSheet.Cells[intTeller, 16] = l.O.StrGSMMoeder; }
                else { xlWorkSheet.Cells[intTeller, 15] = l.O.StrTelefoonWerkVader; xlWorkSheet.Cells[intTeller, 16] = l.O.StrGSMVader; }
                xlWorkSheet.Cells[intTeller, 17] = l.StrGSM_Nummer;
                xlWorkSheet.Cells[intTeller, 18] = l.O.StrGSMMoeder;
                xlWorkSheet.Cells[intTeller, 19] = l.O.StrGSMVader;
                xlWorkSheet.Cells[intTeller, 20] = l.StrE_Mail;
                xlWorkSheet.Cells[intTeller, 21] = l.O.StrEmailMoeder;
                xlWorkSheet.Cells[intTeller, 22] = l.O.StrEmailVader;

                //aanmeldingstijdstip

                xlWorkSheet.Cells[intTeller, 23] = l.StrGebruikersnaamNetwerk;
                xlWorkSheet.Cells[intTeller, 24] = l.StrWachtwoordNetwerk;

                xlWorkSheet.Cells[intTeller, 25] = l.O.StrNaamMoeder; //naam
                xlWorkSheet.Cells[intTeller, 26] = l.O.StrNaamMoeder; //voornaam
                xlWorkSheet.Cells[intTeller, 29] = l.O.StrBeroepMoeder; 
                xlWorkSheet.Cells[intTeller, 30] = l.O.StrGSMMoeder;
                xlWorkSheet.Cells[intTeller, 31] = l.O.StrTelefoonWerkMoeder;
                xlWorkSheet.Cells[intTeller, 32] = l.O.StrEmailMoeder;

                xlWorkSheet.Cells[intTeller, 33] = l.O.StrNaamVader; //naam
                xlWorkSheet.Cells[intTeller, 34] = l.O.StrNaamVader; //voornaam
                xlWorkSheet.Cells[intTeller, 37] = l.O.StrBeroepVader; 
                xlWorkSheet.Cells[intTeller, 38] = l.O.StrGSMVader;
                xlWorkSheet.Cells[intTeller, 39] = l.O.StrTelefoonWerkVader;
                xlWorkSheet.Cells[intTeller, 40] = l.O.StrEmailVader;

                //stiefmoeder
                //stiefvader

                intTeller++;
            }

            //opslaan als..
            xlWorkBook.Close(true, locatie + naam, misValue);
            xlexcel.Quit();

            //document terug sluiten
            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlexcel);

            return true;
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            { GC.Collect(); }
        }
        #endregion
    }
}
