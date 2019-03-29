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
using prop = DefinitiefProgram.Properties.Settings;
using System.IO;

namespace DefinitiefProgram
{
    public partial class Export : Form
    {
        Business b = new Business();
        Excel.Application xlexcel;
        Excel.Workbook xlWorkBook;
        Excel.Worksheet xlWorkSheet;
        object misValue = System.Reflection.Missing.Value;
        string tempPath = Path.GetTempPath();
        List<Leerling> lijstSpecifieker;
        List<Leerling> leerlingenOmteExporteren = new List<Leerling>();
        //item.Selected = true; toevoegen bij alles dat wordt toegevoegd in de listview
        //size klein 318; 140
        //size med 318; 270
        //size large 318; 538

        public Export()
        { InitializeComponent(); }
        private void Export_Load(object sender, EventArgs e)
        { hideAlles(); }
        
        void hideAlles()
        {
            this.Size = new Size(318, 140);
            gpSpecifiek.Hide();
            gpSpecifieker.Hide();
            setLocationButtons();
        }
        void showSpecifiek()
        {
            chkSpecifiker.Checked = false;
            gpSpecifiek.Show();
            this.Size = new Size(318, 270);
            setLocationButtons();
        }
        void showSpecifieker()
        {
            gpSpecifieker.Show();
            setLocationButtons();
        }
        void hideSpecifieker()
        {
            gpSpecifieker.Hide();
            this.Size = new Size(318, 270);
            setLocationButtons();
        }

        void refreshSpecifieker()
        {
            string van, tot;
            van = dtpVan.Value.ToString("dd MM yyyy");
            tot = dtpTot.Value.ToString("dd MM yyyy");

            //new thread & loading dinges?
            Tuple<int, List<Leerling>> tuple = b.getAantalLLN(van, tot);
            lblAantalLLN.Text = tuple.Item1 + " Leerlingen in deze periode.";
            lijstSpecifieker = tuple.Item2;
            vulSpeciefieker(tuple.Item2);
        }
        void vulSpeciefieker(List<Leerling> lln)
        {
            lvSpecifieker.Items.Clear();
            foreach (Leerling l in lln)
            {
                ListViewItem lvi = new ListViewItem(l.StrNaam + " " + l.StrVoornaam);
                lvi.Checked = false;
                lvi.Focused = false;
                lvi.Selected = false;
                lvi.SubItems.Add(l.StrPostcode);
                lvi.SubItems.Add(l.AanmaakDatum);
                lvSpecifieker.Items.Add(lvi);
            }
        }

        private void rdbIedereen_CheckedChanged(object sender, EventArgs e)
        { rdbChanged(); }
        private void rdbSpecifiek_CheckedChanged(object sender, EventArgs e)
        { rdbChanged(); }
        private void chkSpecifiker_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSpecifiker.Checked)
            { showSpecifieker(); this.Size = new Size(318, 538); } else { hideSpecifieker(); }
            setLocationButtons();
        }
        private void dtpVan_ValueChanged(object sender, EventArgs e)
        { refreshSpecifieker(); }
        private void dtpTot_ValueChanged(object sender, EventArgs e)
        { refreshSpecifieker(); }
        void rdbChanged()
        {
            if (rdbIedereen.Checked)
            { hideAlles(); }
            else
            {
                showSpecifiek();
                refreshSpecifieker();
            }
        }
        void setLocationButtons()
        {
            if (this.Size == new Size(318, 538))
            {
                int y = this.Height - btnCancel.Height - 60;
                btnCancel.Location = new Point(btnCancel.Width, y);
                btnExport.Location = new Point(this.Width - btnExport.Width - 40, y);
                btnCancel.BringToFront();
                btnExport.BringToFront();
            }
            else if (this.Size == new Size(318, 270))
            {
                int y = this.Height - btnCancel.Height - 45;
                btnCancel.Location = new Point(gpSpecifiek.Location.X, y);
                btnExport.Location = new Point(gpSpecifiek.Location.X + gpSpecifiek.Size.Width - btnExport.Width, y);
                btnCancel.BringToFront();
                btnExport.BringToFront();
            }
            else if (this.Size == new Size(318, 140))
            {
                int y = this.Height - btnCancel.Height - 45;
                btnCancel.Location = new Point(rdbIedereen.Location.X, y);
                btnExport.Location = new Point(rdbIedereen.Location.X + rdbIedereen.Size.Width - btnExport.Width, y);
                btnCancel.BringToFront();
                btnExport.BringToFront();
            }
            CenterToScreen();
        }

        
        private void btnCancel_Click(object sender, EventArgs e)
        { this.Close(); }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //laad scherm tonen tot einde adhv async method
            //alles uit menu naar hier halen om te exporten

            if (chkSpecifiker.Checked)
            {
                ListView.CheckedListViewItemCollection geselecteerdeLLN = this.lvSpecifieker.CheckedItems;
                foreach (ListViewItem item in geselecteerdeLLN)
                {
                    foreach (Leerling l in lijstSpecifieker)
                    {
                        if ((l.StrNaam + " " + l.StrVoornaam == item.Text) && (l.StrPostcode == item.SubItems[1].Text))
                        { leerlingenOmteExporteren.Add(l); }
                    }
                }
            } else { leerlingenOmteExporteren = lijstSpecifieker; }

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = prop.Default.lastSaveFolder;
            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                prop.Default.lastSaveFolder = fbd.SelectedPath + @"\"; prop.Default.Save();
                if (export(prop.Default.lastSaveFolder, "Leerlingen.xlsx"))
                { MessageBox.Show("Leerlingen ge-exporteerd.", "", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else { MessageBox.Show("Leerlingen exporteren mislukt.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
        }
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

            foreach (Leerling l in leerlingenOmteExporteren)
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
    }
}
