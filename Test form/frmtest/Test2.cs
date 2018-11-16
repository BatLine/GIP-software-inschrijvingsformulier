using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;



namespace frmtest
{
    public partial class Test2 : Form
    {

        Microsoft.Office.Interop.Excel.Application xlexcel;
        Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
        Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
        object misValue = System.Reflection.Missing.Value;
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        Leerling lln;
        Ouders Ouder;

        public Test2()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Voornaam_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void cmbRichting_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

        private void rdb1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void rdb2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void rdb3_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void rdb4_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void rdb5_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void rdb6_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void Test2_Load(object sender, EventArgs e)
        {
            lln = leerling2;
            Ouder = ouders1;
        }

       

        private void leerling2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
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

            //wijzigingen
            xlWorkSheet.Cells[1, 1] = "Familienaam";
            xlWorkSheet.Cells[2, 1] = lln.txtFamilienaam.Text;
            xlWorkSheet.Cells[1, 2] = "Voornaam";
            xlWorkSheet.Cells[2, 2] = lln.txtVoornaam.Text;
            xlWorkSheet.Cells[1, 3] = "Bijk voornaam";
            xlWorkSheet.Cells[2, 3] = lln.txtBijkVoornaam.Text;
            xlWorkSheet.Cells[1, 4] = "Geslacht";
            xlWorkSheet.Cells[2, 4] = lln.cmbGeslacht.Text;
            xlWorkSheet.Cells[1, 5] = "Geboortedatum";
            xlWorkSheet.Cells[2, 5] = lln.txtGeboorteDatum.Text;
            xlWorkSheet.Cells[1, 6] = "Geboorteplaats";
            xlWorkSheet.Cells[2, 6] = lln.txtGeboortePlaats.Text;
            xlWorkSheet.Cells[1, 7] = "Rijksregisternummer";
            xlWorkSheet.Cells[2, 7] = lln.mskRijksregisterNummer.Text;
            xlWorkSheet.Cells[1, 8] = "Straat";
            xlWorkSheet.Cells[2, 8] = lln.txtStraat.Text;
            xlWorkSheet.Cells[1, 9] = "Bus";
            xlWorkSheet.Cells[2, 9] = lln.txtBus.Text;
            xlWorkSheet.Cells[1, 10] = "Huisnummer";
            xlWorkSheet.Cells[2, 10] = lln.txtHuisnummer.Text;
            xlWorkSheet.Cells[1, 11] = "Gemeente";
            xlWorkSheet.Cells[2, 11] = lln.txtGemeente.Text;
            xlWorkSheet.Cells[1, 12] = "Land";
            xlWorkSheet.Cells[2, 12] = lln.txtLand.Text;
            xlWorkSheet.Cells[1, 13] = "Nationaliteit";
            xlWorkSheet.Cells[2, 13] = lln.txtNationaliteit.Text;
            xlWorkSheet.Cells[1, 14] = "Telefoon Domicile";
            //xlWorkSheet.Cells[2, 14] = .Text;
            xlWorkSheet.Cells[1, 15] = "GSM Domicile";
            //xlWorkSheet.Cells[2, 15] = ;
            xlWorkSheet.Cells[1, 16] = "Gsm-Nummer Leerling";
            xlWorkSheet.Cells[2, 16] = lln.mskGsmNummer.Text;
            xlWorkSheet.Cells[1, 17] = "Gsm Ouder";
            //xlWorkSheet.Cells[2, 17] = mskGsmOuder.Text;
            xlWorkSheet.Cells[1, 18] = "E-Mail Leerling";
            xlWorkSheet.Cells[2, 18] = lln.txtMail.Text;
            xlWorkSheet.Cells[1, 19] = "E-Mail Ouder";
            
            xlWorkSheet.Cells[1, 20] = "Aanmeldings tijdstip";

            xlWorkSheet.Cells[1, 21] = "Klascode";

            xlWorkSheet.Cells[1, 22] = "Klasnummer";

            xlWorkSheet.Cells[1, 23] = "Gebruikersnaam netwerk";

            xlWorkSheet.Cells[1, 24] = "Wachtwoord netwerk";

            //Moeder

            xlWorkSheet.Cells[1, 25] = "Naam Moeder";
            xlWorkSheet.Cells[2, 25] = Ouder.txtFamilieNaamMoeder.Text;
            xlWorkSheet.Cells[1, 26] = "Voornaam Moeder";
            xlWorkSheet.Cells[2, 26] = Ouder.txtVoornaamMoeder.Text;
            xlWorkSheet.Cells[1, 27] = "Geboortedatum Moeder";
            xlWorkSheet.Cells[2, 27] = Ouder.mskGeboortedatumMoeder.Text;
            xlWorkSheet.Cells[1, 28] = "Rijksregisternummer Moeder";
            xlWorkSheet.Cells[2, 28] = Ouder.mskRijksregisterNrMoeder.Text;
            xlWorkSheet.Cells[1, 29] = "Beroep Moeder";
            xlWorkSheet.Cells[2, 29] = Ouder.txtBeroepMoeder.Text;
            xlWorkSheet.Cells[1, 30] = "GSM Moeder";
            xlWorkSheet.Cells[2, 30] = Ouder.mskGsmMoeder.Text;
            xlWorkSheet.Cells[1, 31] = "Telefoon werk Moeder";
            xlWorkSheet.Cells[2, 31] = Ouder.mskTelefoonWerkMoeder.Text;
            xlWorkSheet.Cells[1, 32] = "E-Mail Moeder";
            xlWorkSheet.Cells[2, 32] = Ouder.txtEMailMoeder.Text;
            //Vader
            xlWorkSheet.Cells[1, 33] = "Naam Vader";
            xlWorkSheet.Cells[2, 33] = Ouder.txtNaamVader.Text;
            xlWorkSheet.Cells[1, 34] = "Voornaam Vader";
            xlWorkSheet.Cells[2, 24] = Ouder.txtVoornaamVader.Text;
            xlWorkSheet.Cells[1, 35] = "Geboortedatum Vader";
            xlWorkSheet.Cells[2, 35] = Ouder.mskGeboortedatumVader.Text;
            xlWorkSheet.Cells[1, 36] = "Rijksregisternummer Vader";
            xlWorkSheet.Cells[2, 37] = Ouder.mskRijksregisterNrVader.Text;
            xlWorkSheet.Cells[1, 37] = "Beroep Vader";
            xlWorkSheet.Cells[2, 37] = Ouder.txtBeroepVader.Text;
            xlWorkSheet.Cells[1, 38] = "GSM Vader";
            xlWorkSheet.Cells[2, 38] = Ouder.mskGsmVader.Text;
            xlWorkSheet.Cells[1, 39] = "Telefoon werk Vader";
            xlWorkSheet.Cells[2, 39] = Ouder.mskTelefoonWerkVader.Text;
            xlWorkSheet.Cells[1, 40] = "E-Mail Vader";
            xlWorkSheet.Cells[2, 40] = Ouder.txtEMailVader.Text;

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
            MessageBox.Show("Voltooid.", "Voltooid", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            {
                GC.Collect();
            }
        }

        private void btnBevestigen_Click(object sender, EventArgs e)
        {
            btnUploaden.Visible = true;
        }
    }
}
