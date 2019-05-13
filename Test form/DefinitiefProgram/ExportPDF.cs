#region usings
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
using System.Diagnostics;
using RawPrint;
using System.Drawing.Printing;
#endregion
namespace DefinitiefProgram
{
    public partial class ExportPDF : Form
    {
        #region vars
        string Path = Properties.Settings.Default.lastSaveFolder;
        Business b = new Business();
        string tempPath = System.IO.Path.GetTempPath();
        #endregion

        #region controls
        private void BtnCreatePDF_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtVoornaam.Text)) { MessageBox.Show("Geef een geldige voornaam in.", "Exporteren", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            else if (string.IsNullOrWhiteSpace(txtAchternaam.Text)) { MessageBox.Show("Geef een geldige achternaam in.", "Exporteren", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            maakPDF(Path);
        }
        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = Properties.Settings.Default.lastSaveFolder;
            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                Properties.Settings.Default.lastSaveFolder = fbd.SelectedPath + @"\"; Properties.Settings.Default.Save();
                Path = Properties.Settings.Default.lastSaveFolder;
                refreshPath();
            }
        }
        private void ExportPDF_Load(object sender, EventArgs e)
        { txtPath.Text = Path; }
        private void TxtVoornaam_TextChanged(object sender, EventArgs e)
        { refreshPath(); }
        private void TxtAchternaam_TextChanged(object sender, EventArgs e)
        { refreshPath(); }
        private void ChkPrinten_CheckedChanged(object sender, EventArgs e)
        {
            refreshPath();
            if (chkPrinten.Checked)
            { btnCreatePDF.Text = "Print"; btnBrowse.Enabled = false; }
            else { btnCreatePDF.Text = "Maak PDF"; btnBrowse.Enabled = true; }
        }
        #region form
        public ExportPDF()
        { InitializeComponent(); }
        #endregion
        #endregion

        #region functions
        void refreshPath()
        {
            if (!chkPrinten.Checked)
            { txtPath.Text = Path + txtAchternaam.Text.Replace(" ", "") + txtVoornaam.Text.Replace(" ", "") + ".pdf"; }
            else { txtPath.Text = tempPath + "leerling.pdf"; }
        }
        async void maakPDF(string path)
        {
            loadingcircle.Visible = true;
            btnCreatePDF.Enabled = false;
            btnBrowse.Enabled = false;

            await Task.Run(() => PDFMaken(path));

            loadingcircle.Visible = false;
            btnCreatePDF.Enabled = true;
            if (!chkPrinten.Checked)
            { btnBrowse.Enabled = true; }
        }
        void PDFMaken(string path)
        {
            try
            {
                Leerling l = b.GetLeerling(txtVoornaam.Text.ToLower(), txtAchternaam.Text.ToLower());
                if (l != null)
                {
                    try
                    {
                        if (File.Exists(txtPath.Text))
                        { File.Delete(txtPath.Text); }
                        if (File.Exists(tempPath + @"\tempLeerling.xlsx"))
                        { File.Delete(tempPath + @"\tempLeerling.xlsx"); }
                        if (File.Exists(tempPath + @"\tempLeerling2.xlsx"))
                        { File.Delete(tempPath + @"\tempLeerling2.xlsx"); }
                    }
                    catch (Exception)
                    { MessageBox.Show("Fout bij het maken van het bestand.", "", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                    Excel.Application excel = new Excel.Application();
                    excel.Visible = false;
                    Excel.Workbook sheet = excel.Workbooks.Add();
                    sheet.SaveAs(tempPath + @"tempLeerling.xlsx");
                    sheet.Close();
                    sheet = excel.Workbooks.Open(tempPath + @"tempLeerling.xlsx");
                    Excel.Worksheet x = excel.ActiveSheet as Excel.Worksheet;

                    x.Cells[1, 1] = "Leerling:";
                    x.Cells[2, 1] = "Achternaam Leerling:";
                    x.Cells[3, 1] = "Voornaam Leerling:";
                    x.Cells[4, 1] = "Bijkomende Voornaam Leerlign:";
                    x.Cells[5, 1] = "Geslacht Leerling:";
                    x.Cells[6, 1] = "Geboortedatum Leerling:";
                    x.Cells[7, 1] = "Geboorteplaats Leerling:";
                    x.Cells[8, 1] = "Rijksregister Leerling:";
                    x.Cells[9, 1] = "Straatnaam Leerling:";
                    x.Cells[10, 1] = "Huisnummer Leerling:";
                    x.Cells[11, 1] = "Bus Leerling:";
                    x.Cells[12, 1] = "Postcode Leerling:";
                    x.Cells[13, 1] = "Gemeente Leerling:";
                    x.Cells[14, 1] = "Land Leerling:";
                    x.Cells[15, 1] = "Nationaliteit Leerling:";
                    x.Cells[16, 1] = "Gezinshoofd:";
                    x.Cells[17, 1] = "Gezinssituatie:";
                    x.Cells[18, 1] = "GSM Nr Leerling:";
                    x.Cells[19, 1] = "E-mail Leerling:";
                    x.Cells[20, 1] = "Studiejaar Leerling:";
                    x.Cells[21, 1] = "Schoolstatuut Leerling:";
                    x.Cells[22, 1] = "Richting Leerling:";
                    x.Cells[23, 1] = "Correspondentie:";
                    x.Cells[24, 1] = "Gebruikersnaam Leerling:";
                    x.Cells[25, 1] = "Standaardwachtwoord Leerling:";

                    x.Cells[27, 1] = "Moeder:";
                    x.Cells[28, 1] = "Achternaam Moeder:";
                    x.Cells[29, 1] = "Voornaam Moeder:";
                    x.Cells[30, 1] = "Beroep Moeder:";
                    x.Cells[31, 1] = "GSM Nr Moeder:";
                    x.Cells[32, 1] = "Telefoon Werk Moeder:";
                    x.Cells[33, 1] = "E-mail Moeder:";
                    x.Cells[34, 1] = "Straat Moeder:";
                    x.Cells[35, 1] = "Huisnummer + Bus Moeder:";
                    x.Cells[36, 1] = "Postcode Moeder:";
                    x.Cells[37, 1] = "Gemeente Moeder:";

                    x.Cells[39, 1] = "Vader:";
                    x.Cells[40, 1] = "Achternaam Vader:";
                    x.Cells[41, 1] = "Voornaam Vader:";
                    x.Cells[42, 1] = "Beroep Vader:";
                    x.Cells[43, 1] = "GSM NR Vader:";
                    x.Cells[44, 1] = "Telefoon Werk Vader:";
                    x.Cells[45, 1] = "E-mail Vader:";
                    x.Cells[46, 1] = "Straat Vader:";
                    x.Cells[47, 1] = "Huisnummer + Bus Vader:";
                    x.Cells[48, 1] = "Postcode Vader:";
                    x.Cells[49, 1] = "Gemeente Vader:";

                    x.Cells[1, 1].Font.Bold = true;
                    x.Cells[27, 1].Font.Bold = true;
                    x.Cells[39, 1].Font.Bold = true;
                    x.Cells[51, 1].Font.Bold = true;
                    x.Cells[1, 1].Font.Size = 11;
                    x.Cells[27, 1].Font.Size = 11;
                    x.Cells[39, 1].Font.Size = 11;
                    x.Cells[51, 1].Font.Size = 11;
                    x.Rows.RowHeight = x.Rows.RowHeight + 0.5;
                    x.Cells[26, 1].RowHeight = 30;
                    x.Cells[38, 1].RowHeight = 30;
                    x.Cells[50, 1].RowHeight = 30;

                    x.Cells[2, 2] = l.StrNaam;
                    x.Cells[3, 2] = l.StrVoornaam;
                    x.Cells[4, 2] = l.StrBijkNaam;
                    x.Cells[5, 2] = l.StrGeslacht;
                    x.Cells[6, 2] = l.StrGeboortedatum;
                    x.Cells[7, 2] = l.StrGeboorteplaats;
                    x.Cells[8, 2] = "'" + l.StrRijkregisternummer;
                    x.Cells[9, 2] = l.StrStraat;
                    x.Cells[10, 2] = "'" + l.StrHuisnummer;
                    x.Cells[11, 2] = l.StrBus;
                    x.Cells[12, 2] = "'" + l.StrPostcode;
                    x.Cells[13, 2] = l.StrGemeente;
                    x.Cells[14, 2] = l.StrLand;
                    x.Cells[15, 2] = l.StrNationaliteit;
                    x.Cells[16, 2] = l.O.StrGezinshoofd;
                    x.Cells[17, 2] = l.O.StrGezinssituatie;
                    x.Cells[18, 2] = "'" + l.StrGSM_Nummer;
                    x.Cells[19, 2] = l.StrE_Mail;
                    x.Cells[20, 2] = "'" + l.IntMiddelbaar;
                    string text = string.Empty;
                    switch (l.IntSchoolstatuutID)
                    {
                        case 1: text = "Intern"; break;
                        case 2: text = "Extern"; break;
                        case 3: text = "Half-Intern"; break;
                    }
                    x.Cells[21, 2] = text;
                    x.Cells[22, 2] = l.StrRichtingNaam;
                    x.Cells[23, 2] = l.StrCorrespondentie;

                    x.Cells[24, 2] = l.StrGebruikersnaamNetwerk;
                    x.Cells[25, 2] = "/";

                    x.Cells[28, 2] = l.O.StrNaamMoeder;
                    x.Cells[29, 2] = l.O.StrVoornaamMoeder;
                    x.Cells[30, 2] = l.O.StrBeroepMoeder;
                    x.Cells[31, 2] = "'" + l.O.StrGSMMoeder;
                    x.Cells[32, 2] = "'" + l.O.StrTelefoonWerkMoeder;
                    x.Cells[32, 2] = l.O.StrEmailMoeder;
                    x.Cells[33, 2] = l.O.StrStraatMoeder;
                    x.Cells[34, 2] = "'" + l.O.StrHuisnrMoeder;
                    x.Cells[35, 2] = "'" + l.O.StrPostcodeMoeder;
                    x.Cells[36, 2] = l.O.StrGemeenteMoeder;

                    x.Cells[40, 2] = l.O.StrNaamVader;
                    x.Cells[41, 2] = l.O.StrVoornaamVader;
                    x.Cells[42, 2] = l.O.StrBeroepMoeder;
                    x.Cells[43, 2] = "'" + l.O.StrGSMVader;
                    x.Cells[44, 2] = "'" + l.O.StrTelefoonWerkVader;
                    x.Cells[45, 2] = l.O.StrEmailVader;
                    x.Cells[46, 2] = l.O.StrStraatVader;
                    x.Cells[47, 2] = "'" + l.O.StrHuisnrVader;
                    x.Cells[48, 2] = "'" + l.O.StrPostcodeVader;
                    x.Cells[49, 2] = l.O.StrGemeenteVader;

                    x.Columns.AutoFit();

                    x.PageSetup.TopMargin = 0.3;
                    x.PageSetup.BottomMargin = 1;
                    x.PageSetup.LeftMargin = 0.2;
                    x.PageSetup.RightMargin = 1;
                    x.PageSetup.HeaderMargin = 0.1;
                    x.PageSetup.FooterMargin = 0.5;

                    sheet.Close(true, tempPath + "tempLeerling2.xlsx", Type.Missing);
                    excel.Quit();
                    x = null;
                    sheet = null;
                    if (File.Exists(txtPath.Text)) { File.Delete(txtPath.Text); }
                    if (!chkPrinten.Checked)
                    { ExportWorkbookToPdf(tempPath + "tempLeerling2.xlsx", txtPath.Text); }
                    else { ExportWorkbookToPdf(tempPath + "tempLeerling2.xlsx", tempPath + "leerling.pdf"); }
                }
                else { MessageBox.Show("Geen leerling gevonden", "Exporteren", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            }
            catch (Exception)
            { MessageBox.Show("Fout bij het exporteren", "Exporteren", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
        }
        public bool ExportWorkbookToPdf(string workbookPath, string outputPath)
        {
            if (File.Exists("leerling.pdf")) { File.Delete("leerling.pdf"); }
            if (string.IsNullOrEmpty(workbookPath) || string.IsNullOrEmpty(outputPath))
            { return false; }

            Excel.Application excelApplication;
            Excel.Workbook excelWorkbook;

            excelApplication = new Microsoft.Office.Interop.Excel.Application();
            excelApplication.ScreenUpdating = false;
            excelApplication.DisplayAlerts = false;
            excelWorkbook = excelApplication.Workbooks.Open(workbookPath);
            if (excelWorkbook == null)
            {
                excelApplication.Quit();

                excelApplication = null;
                excelWorkbook = null;

                return false;
            }

            var exportSuccessful = true;
            try
            { excelWorkbook.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, outputPath); }
            catch (Exception) { exportSuccessful = false; }
            finally
            {
                excelWorkbook.Close();
                excelApplication.Quit();

                excelApplication = null;
                excelWorkbook = null;
            }

            if (!chkPrinten.Checked)
            {
                if (File.Exists(outputPath))
                { Process.Start(outputPath); }
            }
            else
            {
                PrinterSettings settings = new PrinterSettings();
                IPrinter printer = new Printer();
                printer.PrintRawFile(settings.PrinterName, outputPath, outputPath);
            }

            return exportSuccessful;
        }
        #endregion
    }
}
