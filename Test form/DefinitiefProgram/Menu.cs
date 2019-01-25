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

namespace DefinitiefProgram
{
    public partial class Menu : Form
    {
        //naam en voornaam bij export nog aanpassen & mama en papa appart tablad bij design
        //beroep en rijk reg nog toevoegen
        //path aanpassen met folderbrowser
        //bestandsnaam ook kieze
        //met tempfile werken in temp folder
        Excel.Application xlexcel;
        Excel.Workbook xlWorkBook;
        Excel.Worksheet xlWorkSheet;
        object misValue = System.Reflection.Missing.Value;
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        Business b = new Business();
        public int selectedLeerlingID=-1;
        bool blnVolledigSluiten = false;
        public Menu()
        { InitializeComponent(); }

        private void btnToevoegen_Click(object sender, EventArgs e)
        {
            Design d = new Design();
            this.Hide();
            d.Show();
        }

        private void btnWijzigen_Click(object sender, EventArgs e)
        {
            Lijstleerlingen lijstleerlingen = new Lijstleerlingen();
            lijstleerlingen.m = this;
            lijstleerlingen.ShowDialog();
            if ((lijstleerlingen.DialogResult == DialogResult.OK) && (selectedLeerlingID != -1))
            {
                Design d = new Design(); d.Text = "Leerling wijzigen"; d.Show();
                d.veldenvullen(selectedLeerlingID);
                this.Hide();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            int intTeller = 1;
            //alles in excel zetten
            //exel openen
            xlexcel = new Excel.Application();
            xlexcel.Visible = false;

            //vorige resulaten verwijderen
            if (File.Exists(path + @"\Resultaat.xlsx"))
                File.Delete(path + @"\Resultaat.xlsx");
            if (File.Exists(path + @"\TempFile.xlsx"))
            {
                File.Delete(path + @"\TempFile.xlsx");
            }
            //leeg excel document aanmaken.
            var app = new Microsoft.Office.Interop.Excel.Application();
            var wb = app.Workbooks.Add();
            wb.SaveAs(path + @"\TempFile.xlsx");
            wb.Close();

            //Bestand openen en wijzigen.
            xlWorkBook = xlexcel.Workbooks.Open(path + @"\TempFile.xlsx", 0, true, 5, "", "", true,
            Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
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
                xlWorkSheet.Cells[intTeller, 18] = l.O.StrGSMMoeder; //gsm ouders
                xlWorkSheet.Cells[intTeller, 19] = l.O.StrGSMVader; //gsm ouders
                xlWorkSheet.Cells[intTeller, 20] = l.StrE_Mail;
                xlWorkSheet.Cells[intTeller, 21] = l.O.StrEmailMoeder; //email ouders
                xlWorkSheet.Cells[intTeller, 22] = l.O.StrEmailVader; //email ouders

                //aanmeldingstijdstip
                //klascode
                //klasnr

                xlWorkSheet.Cells[intTeller, 23] = l.StrGebruikersnaamNetwerk;
                xlWorkSheet.Cells[intTeller, 24] = l.StrWachtwoordNetwerk;

                xlWorkSheet.Cells[intTeller, 25] = l.O.StrNaamMoeder; //naam
                xlWorkSheet.Cells[intTeller, 26] = l.O.StrNaamMoeder; //voornaam
                xlWorkSheet.Cells[intTeller, 27] = l.O.StrGeboorteDatumMoeder; //nog invullen
                xlWorkSheet.Cells[intTeller, 28] = l.O.StrRijksregisterNRMoeder; //nog invullen
                xlWorkSheet.Cells[intTeller, 29] = l.O.StrBeroepMoeder; //nog invullen
                xlWorkSheet.Cells[intTeller, 30] = l.O.StrGSMMoeder;
                xlWorkSheet.Cells[intTeller, 31] = l.O.StrTelefoonWerkMoeder;
                xlWorkSheet.Cells[intTeller, 32] = l.O.StrEmailMoeder;

                xlWorkSheet.Cells[intTeller, 33] = l.O.StrNaamVader; //naam
                xlWorkSheet.Cells[intTeller, 34] = l.O.StrNaamVader; //voornaam
                xlWorkSheet.Cells[intTeller, 35] = l.O.StrGeboorteDatumVader; //nog invullen
                xlWorkSheet.Cells[intTeller, 36] = l.O.StrRijksregisterNRVader; //nog invullen
                xlWorkSheet.Cells[intTeller, 37] = l.O.StrBeroepVader; //nog invullen
                xlWorkSheet.Cells[intTeller, 38] = l.O.StrGSMVader;
                xlWorkSheet.Cells[intTeller, 39] = l.O.StrTelefoonWerkVader;
                xlWorkSheet.Cells[intTeller, 40] = l.O.StrEmailVader;
                
                //stiefmoeder
                //stiefvader

                intTeller++;
            }

            //opslaan als..
            xlWorkBook.Close(true, path + @"\Resultaat.xlsx", misValue);
            xlexcel.Quit();

            //document terug sluiten
            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlexcel);

            //verwijder temp file
            if (File.Exists(path + @"\TempFile.xlsx"))
                File.Delete(path + @"\TempFile.xlsx");
            MessageBox.Show("Done");
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            blnVolledigSluiten = true;
            Application.Exit();
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!blnVolledigSluiten)
            { e.Cancel = true; } else { this.Hide(); }
        }
    }
}
