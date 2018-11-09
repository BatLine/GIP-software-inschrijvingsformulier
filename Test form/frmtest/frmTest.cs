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
    public partial class frmTest : Form
    {
        Microsoft.Office.Interop.Excel.Application xlexcel;
        Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
        Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
        object misValue = System.Reflection.Missing.Value;
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public frmTest()
        {
            InitializeComponent();
        }

        private void btnOpslaan1_Click(object sender, EventArgs e)
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

                //leeg excel document aanmaken.
                var app = new Microsoft.Office.Interop.Excel.Application();
                var wb = app.Workbooks.Add();
                wb.SaveAs(path + @"\TempFile.xlsx");
                wb.Close();
            }
            else
            {
                //leeg excel document aanmaken.
                var app = new Microsoft.Office.Interop.Excel.Application();
                var wb = app.Workbooks.Add();
                wb.SaveAs(path + @"\TempFile.xlsx");
                wb.Close();
            }


            //Bestand openen en wijzigen.
            xlWorkBook = xlexcel.Workbooks.Open(path + @"\TempFile.xlsx", 0, true, 5, "", "", true,
            Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            //wijzigingen
            xlWorkSheet.Cells[1, 1] = "Kolom 1";
            xlWorkSheet.Cells[2, 1] = txtText.Text;
            xlWorkSheet.Cells[1, 2] = "Kolom 2";
            xlWorkSheet.Cells[1, 3] = "Kolom 3";
            xlWorkSheet.Cells[1, 4] = "Kolom 4";
            xlWorkSheet.Cells[2, 2] = txtGetal.Text;
            xlWorkSheet.Cells[2, 3] = txtVeelText.Text;
            xlWorkSheet.Cells[2, 4] = txtMaskedText.Text;

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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Test2 test2 = new Test2();
            test2.Show();
        }
    }
}
