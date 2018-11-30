using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using MySql.Data.MySqlClient;

namespace frmtest
{
    public partial class Leerling : UserControl
    {

        Microsoft.Office.Interop.Excel.Application xlexcel;
        Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
        Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
        object misValue = System.Reflection.Missing.Value;
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string strConnectionstring;

        public Leerling()
        {
            InitializeComponent();
        }

        private void Leerling_Load(object sender, EventArgs e)
        {

        }
       

        public void checkJaar()
        {
            cmbRichting.Enabled = true;
            if (rdb1.Checked || rdb2.Checked)
            {
                cmbRichting.Items.Clear();
                cmbRichting.Items.Add("Ondernemen");
            }

            else if (rdb3.Checked || rdb4.Checked)
            {
                cmbRichting.Items.Clear();
                cmbRichting.Items.Add("Ondernemen & IT");
                cmbRichting.Items.Add("Ondernemen & Communicatie");
            }
            else if (rdb5.Checked || rdb6.Checked)
            {
                cmbRichting.Items.Clear();
                cmbRichting.Items.Add("Marketing & Ondernemen");
                cmbRichting.Items.Add("Accountancy & IT");
                cmbRichting.Items.Add("IT & Netwerken");
                cmbRichting.Items.Add("Office management & communicatie");
            }
        }

        private void rdb1_CheckedChanged_1(object sender, EventArgs e)
        {
            checkJaar();
        }

        private void rdb2_CheckedChanged(object sender, EventArgs e)
        {
            checkJaar();
        }

        private void rdb3_CheckedChanged(object sender, EventArgs e)
        {
            checkJaar();
        }

        private void rdb4_CheckedChanged(object sender, EventArgs e)
        {
            checkJaar();
        }

        private void rdb5_CheckedChanged(object sender, EventArgs e)
        {
            checkJaar();
        }

        private void rdb6_CheckedChanged(object sender, EventArgs e)
        {
            checkJaar();
        }

        private void Bevestigen_Click(object sender, EventArgs e)
        {
            if (chkExcel.Checked)
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
                xlWorkSheet.Cells[2, 1] = txtFamilienaam.Text;
                xlWorkSheet.Cells[1, 2] = "Voornaam";
                xlWorkSheet.Cells[2, 2] = txtVoornaam.Text;
                xlWorkSheet.Cells[1, 3] = "Bijk voornaam";
                xlWorkSheet.Cells[2, 3] = txtBijkVoornaam.Text;
                xlWorkSheet.Cells[1, 4] = "Geslacht";
                xlWorkSheet.Cells[2, 4] = cmbGeslacht.Text;
                xlWorkSheet.Cells[1, 5] = "Geboortedatum";
                xlWorkSheet.Cells[2, 5] = txtGeboorteDatum.Text;
                xlWorkSheet.Cells[1, 6] = "Geboorteplaats";
                xlWorkSheet.Cells[2, 6] = txtGeboortePlaats.Text;
                xlWorkSheet.Cells[1, 7] = "Rijksregisternummer";
                xlWorkSheet.Cells[2, 7] = mskRijksregisterNummer.Text;
                xlWorkSheet.Cells[1, 8] = "Straat";
                xlWorkSheet.Cells[2, 8] = txtStraat.Text;
                xlWorkSheet.Cells[1, 9] = "Bus";
                xlWorkSheet.Cells[2, 9] = txtBus.Text;
                xlWorkSheet.Cells[1, 10] = "Huisnummer";
                xlWorkSheet.Cells[2, 10] = txtHuisnummer.Text;
                xlWorkSheet.Cells[1, 11] = "Gemeente";
                xlWorkSheet.Cells[2, 11] = txtGemeente.Text;
                xlWorkSheet.Cells[1, 12] = "Land";
                xlWorkSheet.Cells[2, 12] = txtLand.Text;
                xlWorkSheet.Cells[1, 13] = "Nationaliteit";
                xlWorkSheet.Cells[2, 13] = txtNationaliteit.Text;
                xlWorkSheet.Cells[1, 14] = "Telefoon Domicile";
                //xlWorkSheet.Cells[2, 14] = .Text;
                xlWorkSheet.Cells[1, 15] = "GSM Domicile";
                //xlWorkSheet.Cells[2, 15] = ;
                xlWorkSheet.Cells[1, 16] = "Gsm-Nummer Leerling";
                xlWorkSheet.Cells[2, 16] = mskGsmNummer.Text;
                xlWorkSheet.Cells[1, 17] = "Gsm Ouder";
                //xlWorkSheet.Cells[2, 17] = mskGsmOuder.Text;
                xlWorkSheet.Cells[1, 18] = "E-Mail Leerling";
                xlWorkSheet.Cells[2, 18] = txtMail.Text;
                xlWorkSheet.Cells[1, 19] = "E-Mail Ouder";

                xlWorkSheet.Cells[1, 20] = "Aanmeldings tijdstip";

                xlWorkSheet.Cells[1, 21] = "Klascode";

                xlWorkSheet.Cells[1, 22] = "Klasnummer";

                xlWorkSheet.Cells[1, 23] = "Gebruikersnaam netwerk";

                xlWorkSheet.Cells[1, 24] = "Wachtwoord netwerk";

                //Moeder

                xlWorkSheet.Cells[1, 25] = "Naam Moeder";

                xlWorkSheet.Cells[1, 26] = "Voornaam Moeder";

                xlWorkSheet.Cells[1, 27] = "Geboortedatum Moeder";

                xlWorkSheet.Cells[1, 28] = "Rijksregisternummer Moeder";

                xlWorkSheet.Cells[1, 29] = "Beroep Moeder";

                xlWorkSheet.Cells[1, 30] = "GSM Moeder";

                xlWorkSheet.Cells[1, 31] = "Telefoon werk Moeder";

                xlWorkSheet.Cells[2, 32] = "E-Mail Moeder";

                //Vader
                xlWorkSheet.Cells[1, 33] = "Naam Vader";

                xlWorkSheet.Cells[1, 34] = "Voornaam Vader";

                xlWorkSheet.Cells[1, 35] = "Geboortedatum Vader";

                xlWorkSheet.Cells[1, 36] = "Rijksregisternummer Vader";

                xlWorkSheet.Cells[1, 37] = "Beroep Vader";

                xlWorkSheet.Cells[1, 38] = "GSM Vader";

                xlWorkSheet.Cells[1, 39] = "Telefoon werk Vader";

                xlWorkSheet.Cells[2, 40] = "E-Mail Vader";


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
            else
            {
                int intMiddelbaar = 0; //berekenen adhv de rdb's
                int intStudiekeuzeID=0; //berekenen adhv cmbRichting
                //
                //

                strConnectionstring = "user id=ID191774_6itngip9;server=ID191774_6itngip9.db.webhosting.be;database=ID191774_6itngip9;password=ILiWO2dm";
                MySqlConnection conn = new MySqlConnection(strConnectionstring);
                MySqlCommand cmd = new MySqlCommand("INSERT INTO `ID191774_6itngip9`.`leerling` (`Naam`, `Voornaam`, `Bijk Voornaam`, `Geslacht`, `Geboorteplaats`, `Geboortedatum`, `Rijksregisternummer`, `Nationaliteit`, `GSM-nummer`, `E-mail`, `Straat`, `Huisnummer`, `Bus`, `Gemeente`, `Postcode`, `Land`, `StudiekeuzeID`, `Middelbaar`, `SchoolstatuutID`) VALUES ('" +
                    txtFamilienaam.Text + "', '" + //Naam
                    txtVoornaam.Text + "', '" + //Voornaam
                    txtBijkVoornaam.Text + "', '" + //Bijk voornaam
                    cmbGeslacht.Text + "', '" + //Geslacht
                    txtGeboortePlaats.Text + "', '" + //Geboorteplaats
                    txtGeboorteDatum.Text + "', '" + //geboortedatum (string)
                    mskRijksregisterNummer.Text + "', '" + //rijkregisternummer
                    txtNationaliteit.Text + "', '" + //Nationaliteit
                    mskGsmNummer.Text + "', '" + //GSM-nummer
                    txtMail.Text + "', '" + //E-mail
                    txtStraat.Text + "', '" + //Straat
                    txtHuisnummer.Text + "', '" + //Huisnummer
                    txtBus.Text + "', '" + //bus
                    txtGemeente.Text + "', '" + //Gemeente
                    mskPostcode.Text + "', '" + //Postcode
                    txtLand.Text + "', '" + //Land
                    intStudiekeuzeID + "', '" + //StudiekeuzeID
                    intMiddelbaar + "', '" + //Midelbaar
                    4 + "');", conn); //SchoolstatuutID
                conn.Open();
                cmd.ExecuteNonQuery();
            }
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
    }
}
