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

namespace frmtest
{
    public partial class Leerling : UserControl
    {

        Microsoft.Office.Interop.Excel.Application xlexcel;
        Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
        Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
        object misValue = System.Reflection.Missing.Value;
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

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
            xlWorkSheet.Cells[1, 1] = "Voornaam";
            xlWorkSheet.Cells[2, 1] = txtVoornaam.Text;
            xlWorkSheet.Cells[1, 2] = "Familienaam";
            xlWorkSheet.Cells[2, 2] = txtFamilienaam.Text;
            xlWorkSheet.Cells[1, 3] = "Geslacht";
            xlWorkSheet.Cells[2, 3] = cmbGeslacht.Text;
            xlWorkSheet.Cells[1, 4] = "Geboorteplaats";
            xlWorkSheet.Cells[2, 4] = txtGeboortePlaats.Text;
            xlWorkSheet.Cells[1, 5] = "Geboortedatum";
            xlWorkSheet.Cells[2, 5] = txtGeboorteDatum.Text;
            xlWorkSheet.Cells[1, 6] = "Rijksregisternummer";
            xlWorkSheet.Cells[2, 6] = mskRijksregisterNummer.Text;
            xlWorkSheet.Cells[1, 7] = "Nationaliteit";
            xlWorkSheet.Cells[2, 7] = txtNationaliteit.Text;
            xlWorkSheet.Cells[1, 8] = "GSM-Nummer";
            xlWorkSheet.Cells[2, 8] = mskGsmNummer.Text;
            xlWorkSheet.Cells[1, 9] = "E-Mail";
            xlWorkSheet.Cells[2, 9] = txtMail.Text;
            xlWorkSheet.Cells[1, 10] = "Straat";
            xlWorkSheet.Cells[2, 10] = txtStraat.Text;
            xlWorkSheet.Cells[1, 11] = "Bus";
            xlWorkSheet.Cells[2, 11] = txtBus.Text;
            xlWorkSheet.Cells[1, 12] = "Gemeente";
            xlWorkSheet.Cells[2, 12] = txtGemeente.Text;
            xlWorkSheet.Cells[1, 13] = "Postcode";
            xlWorkSheet.Cells[2, 13] = mskPostcode.Text;
            xlWorkSheet.Cells[1, 14] = "Richting";
            xlWorkSheet.Cells[2, 14] = cmbRichting.Text;

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
    }
}
