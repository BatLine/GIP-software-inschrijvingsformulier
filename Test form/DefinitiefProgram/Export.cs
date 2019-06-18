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
using prop = DefinitiefProgram.Properties.Settings;
using System.IO;
using System.Diagnostics;
#endregion

namespace DefinitiefProgram
{
    public partial class Export : Form
    {
        #region vars
        Business b = new Business();
        Excel.Application xlexcel;
        Excel.Workbook xlWorkBook;
        Excel.Worksheet xlWorkSheet;
        object misValue = System.Reflection.Missing.Value;
        string tempPath = Path.GetTempPath();
        List<Leerling> lijstSpecifieker;
        List<Leerling> leerlingenOmteExporteren = new List<Leerling>();
        bool busy = false;
        #endregion

        #region controls
        #region form
        public Export()
        { InitializeComponent(); }
        private void Export_Load(object sender, EventArgs e)
        {
            this.Size = new Size(341, 163);
            gpSpecifiek.Hide();
            gpSpecifieker.Hide();
            gpLeerling.Hide();
            int y = this.Height - btnCancel.Height - 45;
            btnCancel.Location = new Point(15, y);
            btnExport.Location = new Point(255, y);
            btnCancel.BringToFront();
            btnExport.BringToFront();
            CenterToParent();
        }
        #endregion
        private void rdbIedereen_CheckedChanged(object sender, EventArgs e)
        { rdbChanged(); }
        private void rdbSpecifiek_CheckedChanged(object sender, EventArgs e)
        { gpSpecifieker.Visible = false; rdbChanged(); }
        private void chkSpecifiker_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSpecifiker.Checked)
            {
                this.Size = new Size(341, 597);
                gpSpecifieker.Show();
                btnCancel.Location = new Point(15, 529);
                btnExport.Location = new Point(255, 529);
                btnCancel.BringToFront();
                btnExport.BringToFront();
                CenterToParent();
            }
            else
            {
                gpSpecifieker.Hide();
                this.Size = new Size(341, 300);
                int y = gpSpecifiek.Location.Y + gpSpecifiek.Size.Height + 4;
                btnCancel.Location = new Point(15, y);
                btnExport.Location = new Point(255, y);
                btnCancel.BringToFront();
                btnExport.BringToFront();
                CenterToParent();
            }
        }
        private void rdbLeerling_CheckedChanged(object sender, EventArgs e)
        { rdbChanged(); }
        private void dtpVan_ValueChanged(object sender, EventArgs e)
        { refreshSpecifieker(); }
        private void dtpTot_ValueChanged(object sender, EventArgs e)
        { refreshSpecifieker(); }
        private void btnCancel_Click(object sender, EventArgs e)
        { this.Close(); }
        private void btnExport_Click(object sender, EventArgs e)
        {
            bool cancel = false;
            if (rdbSpecifiek.Checked)
            {
                if (chkSpecifiker.Checked)
                {
                    ListView.CheckedListViewItemCollection geselecteerdeLLN = this.lvSpecifieker.CheckedItems;
                    if (geselecteerdeLLN.Count > 0)
                    {
                        foreach (ListViewItem item in geselecteerdeLLN)
                        {
                            foreach (Leerling l in lijstSpecifieker)
                            {
                                if ((l.StrNaam + " " + l.StrVoornaam == item.Text) && (l.StrPostcode == item.SubItems[1].Text))
                                { leerlingenOmteExporteren.Add(l); }
                            }
                        }
                    }
                    else { cancel = true; }
                }
                else { leerlingenOmteExporteren = lijstSpecifieker; }
            }
            else if (rdbIedereen.Checked) { leerlingenOmteExporteren = b.getAlleLeerlingen(); }
            else if (rdbLeerling.Checked)
            {
                ListView.CheckedListViewItemCollection geselecteerdeLLN = this.lvSpecifieker.CheckedItems;
                if (geselecteerdeLLN.Count > 0)
                {
                    foreach (ListViewItem item in geselecteerdeLLN)
                    {
                        foreach (Leerling l in lijstSpecifieker)
                        {
                            if ((l.StrNaam + " " + l.StrVoornaam == item.Text) && (l.StrPostcode == item.SubItems[1].Text))
                            { leerlingenOmteExporteren.Add(l); }
                        }
                    }
                }
                else { cancel = true; }
            }

            if (leerlingenOmteExporteren.Count == 0)
            { cancel = true; }

            if (!cancel)
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.SelectedPath = prop.Default.lastSaveFolder;
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    prop.Default.lastSaveFolder = fbd.SelectedPath + @"\"; prop.Default.Save();
                    runExport(prop.Default.lastSaveFolder, "Leerlingen " + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + ".xlsx");
                }
            }
            else { MessageBox.Show("Leerlingen exporteren mislukt." + Environment.NewLine + "Gelieve minstens 1 leerling te selecteren.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
        private void btnZoek_Click(object sender, EventArgs e)
        { vulSpeciefiekerOpNaam(txtVNaam.Text, txtANaam.Text); }
        #endregion

        #region functions
        async void refreshSpecifieker()
        {
            if (!busy)
            {
                if (Convert.ToDateTime(DateTime.ParseExact(dtpVan.Value.ToString("dd/MM/yyyy"), "dd/MM/yyyy", null)) > Convert.ToDateTime(DateTime.ParseExact(dtpTot.Value.ToString("dd/MM/yyyy"), "dd/MM/yyyy", null)))
                { busy = true; MessageBox.Show("De einddatum kan niet lager zijn dan de begindatum."); dtpVan.Value = DateTime.Now; busy = false; refreshSpecifieker(); }
                else if (Convert.ToDateTime(DateTime.ParseExact(dtpVan.Value.ToString("dd/MM/yyyy"), "dd/MM/yyyy", null)) > DateTime.Now)
                { busy = true; MessageBox.Show("Je kan niet in de toekomst beignnen zoeken."); dtpVan.Value = DateTime.Now; busy = false; refreshSpecifieker(); }
                else if (Convert.ToDateTime(DateTime.ParseExact(dtpTot.Value.ToString("dd/MM/yyyy"), "dd/MM/yyyy", null)) > DateTime.Now)
                { busy = true; MessageBox.Show("Je kan niet tot in de toekomst zoeken."); dtpTot.Value = DateTime.Now; busy = false; refreshSpecifieker(); }
                else
                {
                    LoadingCircle lo = new LoadingCircle();
                    lo.Show();
                    lo.BringToFront();
                    lo.TopMost = true;
                    Panel pnl = new Panel();
                    this.Controls.Add(pnl);
                    pnl.BackColor = this.BackColor;
                    pnl.Size = this.Size;
                    pnl.Location = new Point(0, 0);
                    pnl.BringToFront();
                    string text = this.Text;
                    this.Text = "";
                    this.Visible = false;

                    await Task.Run(() => refrSpecifieker());

                    this.Visible = true;
                    this.Text = text;
                    Controls.Remove(pnl);
                    lo.Close();
                }
            }
        }
        void refrSpecifieker()
        {
            string van, tot;
            van = dtpVan.Value.ToString("dd MM yyyy");
            tot = dtpTot.Value.ToString("dd MM yyyy");

            Tuple<int, List<Leerling>> tuple = b.getAantalLLN(van, tot);
            this.Invoke(new Action(() => {
                lblAantalLLN.Text = tuple.Item1 + " Leerlingen in deze periode.";
                lijstSpecifieker = tuple.Item2;
                vulSpeciefieker(tuple.Item2);
            }));
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
        void rdbChanged()
        {
            if (rdbIedereen.Checked)
            {
                this.Size = new Size(341, 163);
                gpSpecifiek.Hide();
                gpSpecifieker.Hide();
                gpLeerling.Hide();
                int y = this.Height - btnCancel.Height - 45;
                btnCancel.Location = new Point(15, y);
                btnExport.Location = new Point(255, y);
                btnCancel.BringToFront();
                btnExport.BringToFront();
                CenterToParent();
            }
            else if (rdbSpecifiek.Checked)
            {
                refreshSpecifieker();
                chkSpecifiker.Checked = false;
                gpLeerling.Hide();
                gpSpecifiek.Show();
                this.Size = new Size(341, 300);
                int y = gpSpecifiek.Location.Y + gpSpecifiek.Size.Height + 4;
                btnCancel.Location = new Point(15, y);
                btnExport.Location = new Point(255, y);
                btnCancel.BringToFront();
                btnExport.BringToFront();
                this.Size = new Size(341, 268);
                CenterToParent();
            } else if (rdbLeerling.Checked)
            {
                gpSpecifieker.Hide();
                gpSpecifiek.Hide();
                gpLeerling.Show();
                this.Size = new Size(341, 300);
                int y = gpSpecifiek.Location.Y + gpSpecifiek.Size.Height + 4;
                btnCancel.Location = new Point(15, y);
                btnExport.Location = new Point(255, y);
                btnCancel.BringToFront();
                btnExport.BringToFront();
                CenterToParent();
            }
        }
        async void vulSpeciefiekerOpNaam(string Vnaam, string Anaam)
        {
            if (string.IsNullOrWhiteSpace(txtVNaam.Text))
            { MessageBox.Show("Geef een geldige voornaam in."); }
            else if (string.IsNullOrWhiteSpace(txtANaam.Text))
            { MessageBox.Show("Geef een geldige achternaam in."); }
            else
            {
                LoadingCircle lo = new LoadingCircle();
                lo.Show();
                lo.BringToFront();
                lo.TopMost = true;
                Panel pnl = new Panel();
                this.Controls.Add(pnl);
                pnl.BackColor = this.BackColor;
                pnl.Size = this.Size;
                pnl.Location = new Point(0, 0);
                pnl.BringToFront();
                string text = this.Text;
                this.Text = "";
                this.Visible = false;

                await Task.Run(() => _vulSpeciefiekerOpNaam(Vnaam, Anaam));

                this.Visible = true;
                this.Text = text;
                Controls.Remove(pnl);
                lo.Close();
            }
        }
        void _vulSpeciefiekerOpNaam(string Vnaam, string Anaam)
        {
            Tuple<int, List<Leerling>> tuple = b.getAantalLLNOpNaam(Vnaam, Anaam);
            this.Invoke(new Action(() => {
                this.Size = new Size(341, 557);
                gpSpecifieker.Show();
                btnCancel.Location = new Point(15, 525);
                btnExport.Location = new Point(258, 525);
                btnCancel.BringToFront();
                btnExport.BringToFront();
                CenterToParent();
                if (tuple.Item1 == 1)
                { lblAantalLLNOpNaam.Text = tuple.Item1 + " Leerling gevonden."; }
                else
                { lblAantalLLNOpNaam.Text = tuple.Item1 + " Leerlingen gevonden."; }
                lijstSpecifieker = tuple.Item2;
                vulSpeciefieker(tuple.Item2);
            }));
        }
        async void runExport(string l, string n)
        {
            LoadingCircle lo = new LoadingCircle();
            lo.Show();
            lo.BringToFront();
            lo.TopMost = true;
            Panel pnl = new Panel();
            this.Controls.Add(pnl);
            pnl.BackColor = this.BackColor;
            pnl.Size = this.Size;
            pnl.Location = new Point(0, 0);
            pnl.BringToFront();
            string text = this.Text;
            this.Text = "";
            this.Visible = false;

            await Task.Run(() => export(l, n));

            try {
                this.Visible = true;
                this.Text = text;
                Controls.Remove(pnl);
                lo.Close();
            } catch (Exception) { try { lo.Close(); } catch (Exception) { } }
        }
        void export(string locatie, string naam)
        {
            bool crashed = false;
            try
            {
                xlexcel = new Excel.Application();
                xlexcel.Visible = false;

                try
                {
                    if (File.Exists(locatie + naam))
                    { File.Delete(locatie + naam); }
                    if (File.Exists(tempPath + @"\tempLeerlingen.xlsx"))
                    { File.Delete(tempPath + @"\tempLeerlingen.xlsx"); }
                }
                catch (Exception)
                { MessageBox.Show("Fout bij het maken van het bestand.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning); this.Close(); }

                var app = new Excel.Application();
                var wb = app.Workbooks.Add();
                wb.SaveAs(tempPath + @"tempLeerlingen.xlsx");
                wb.Close();

                xlWorkBook = xlexcel.Workbooks.Open(tempPath + @"\tempLeerlingen.xlsx", 0, true, 5, "", "", true,
                Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            }
            catch (Exception) { MessageBox.Show("Leerlingen exporteren mislukt.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning); this.Close(); }
            this.Invoke(new Action(() => {
                try
                {
                    int intTeller = 1;
                    xlWorkSheet.Columns.ColumnWidth = 20;
                    xlWorkSheet.Range["A1"].EntireRow.Font.Bold = true;
                    xlWorkSheet.Range["A1"].EntireRow.Font.Size = 12;
                    xlWorkSheet.Cells[intTeller, 1] = "Achternaam Leerling";
                    xlWorkSheet.Cells[intTeller, 2] = "Voornaam Leerling";
                    xlWorkSheet.Cells[intTeller, 3] = "Bijkomende Voornaam Leerlign";
                    xlWorkSheet.Cells[intTeller, 4] = "Geslacht Leerling";
                    xlWorkSheet.Cells[intTeller, 5] = "Geboortedatum Leerling";
                    xlWorkSheet.Cells[intTeller, 6] = "Geboorteplaats Leerling";
                    xlWorkSheet.Cells[intTeller, 7] = "Rijksregister Leerling";
                    xlWorkSheet.Cells[intTeller, 8] = "Straatnaam Leerling";
                    xlWorkSheet.Cells[intTeller, 9] = "Huisnummer Leerling";
                    xlWorkSheet.Cells[intTeller, 10] = "Bus Leerling";
                    xlWorkSheet.Cells[intTeller, 11] = "Postcode Leerling";
                    xlWorkSheet.Cells[intTeller, 12] = "Gemeente Leerling";
                    xlWorkSheet.Cells[intTeller, 13] = "Land Leerling";
                    xlWorkSheet.Cells[intTeller, 14] = "Nationaliteit Leerling";
                    xlWorkSheet.Cells[intTeller, 15] = "Gezinshoofd";
                    xlWorkSheet.Cells[intTeller, 16] = "Gezinssituatie";
                    xlWorkSheet.Cells[intTeller, 17] = "GSM Nr Leerling";
                    xlWorkSheet.Cells[intTeller, 18] = "E-mail Leerling";
                    xlWorkSheet.Cells[intTeller, 19] = "Studiejaar Leerling";
                    xlWorkSheet.Cells[intTeller, 20] = "Schoolstatuut Leerling";
                    xlWorkSheet.Cells[intTeller, 21] = "Richting Leerling";
                    xlWorkSheet.Cells[intTeller, 22] = "Correspondentie";

                    xlWorkSheet.Cells[intTeller, 23] = "Gebruikersnaam Leerling";
                    xlWorkSheet.Cells[intTeller, 24] = "Standaardwachtwoord Leerling";

                    xlWorkSheet.Cells[intTeller, 25] = "Achternaam Moeder";
                    xlWorkSheet.Cells[intTeller, 26] = "Voornaam Moeder";
                    xlWorkSheet.Cells[intTeller, 27] = "Beroep Moeder";
                    xlWorkSheet.Cells[intTeller, 28] = "GSM Nr Moeder";
                    xlWorkSheet.Cells[intTeller, 29] = "Telefoon Werk Moeder";
                    xlWorkSheet.Cells[intTeller, 30] = "E-mail Moeder";
                    xlWorkSheet.Cells[intTeller, 31] = "Straat Moeder";
                    xlWorkSheet.Cells[intTeller, 32] = "Huisnummer + Bus Moeder";
                    xlWorkSheet.Cells[intTeller, 33] = "Postcode Moeder";
                    xlWorkSheet.Cells[intTeller, 34] = "Gemeente Moeder";

                    xlWorkSheet.Cells[intTeller, 35] = "Achternaam Vader";
                    xlWorkSheet.Cells[intTeller, 36] = "Voornaam Vader";
                    xlWorkSheet.Cells[intTeller, 37] = "Beroep Vader";
                    xlWorkSheet.Cells[intTeller, 38] = "GSM NR Vader";
                    xlWorkSheet.Cells[intTeller, 39] = "Telefoon Werk Vader";
                    xlWorkSheet.Cells[intTeller, 40] = "E-mail Vader";
                    xlWorkSheet.Cells[intTeller, 41] = "Straat Vader";
                    xlWorkSheet.Cells[intTeller, 42] = "Huisnummer + Bus Vader";
                    xlWorkSheet.Cells[intTeller, 43] = "Postcode Vader";
                    xlWorkSheet.Cells[intTeller, 44] = "Gemeente Vader";

                    intTeller++;
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
                        xlWorkSheet.Cells[intTeller, 15] = l.O.StrGezinshoofd;
                        xlWorkSheet.Cells[intTeller, 16] = l.O.StrGezinssituatie;
                        xlWorkSheet.Cells[intTeller, 17] = l.StrGSM_Nummer;
                        xlWorkSheet.Cells[intTeller, 18] = l.StrE_Mail;
                        xlWorkSheet.Cells[intTeller, 19] = l.IntMiddelbaar;
                        string text = string.Empty;
                        switch (l.IntSchoolstatuutID)
                        {
                            case 1: text = "Intern"; break;
                            case 2: text = "Extern"; break;
                            case 3: text = "Half-Intern"; break;
                        }
                        xlWorkSheet.Cells[intTeller, 20] = text;
                        xlWorkSheet.Cells[intTeller, 21] = l.StrRichtingNaam;
                        xlWorkSheet.Cells[intTeller, 22] = l.StrCorrespondentie;

                        xlWorkSheet.Cells[intTeller, 23] = l.StrGebruikersnaamNetwerk;
                        xlWorkSheet.Cells[intTeller, 24] = l.StrWachtwoordNetwerk;

                        xlWorkSheet.Cells[intTeller, 25] = l.O.StrNaamMoeder;
                        xlWorkSheet.Cells[intTeller, 26] = l.O.StrVoornaamMoeder;
                        xlWorkSheet.Cells[intTeller, 27] = l.O.StrBeroepMoeder;
                        xlWorkSheet.Cells[intTeller, 28] = l.O.StrGSMMoeder;
                        xlWorkSheet.Cells[intTeller, 29] = l.O.StrTelefoonWerkMoeder;
                        xlWorkSheet.Cells[intTeller, 30] = l.O.StrEmailMoeder;
                        xlWorkSheet.Cells[intTeller, 31] = l.O.StrStraatMoeder;
                        xlWorkSheet.Cells[intTeller, 32] = l.O.StrHuisnrMoeder; //bus zit hier in
                        xlWorkSheet.Cells[intTeller, 33] = l.O.StrPostcodeMoeder;
                        xlWorkSheet.Cells[intTeller, 34] = l.O.StrGemeenteMoeder;

                        xlWorkSheet.Cells[intTeller, 35] = l.O.StrNaamVader;
                        xlWorkSheet.Cells[intTeller, 36] = l.O.StrVoornaamVader;
                        xlWorkSheet.Cells[intTeller, 37] = l.O.StrBeroepVader;
                        xlWorkSheet.Cells[intTeller, 38] = l.O.StrGSMVader;
                        xlWorkSheet.Cells[intTeller, 39] = l.O.StrTelefoonWerkVader;
                        xlWorkSheet.Cells[intTeller, 40] = l.O.StrEmailVader;
                        xlWorkSheet.Cells[intTeller, 41] = l.O.StrStraatVader;
                        xlWorkSheet.Cells[intTeller, 42] = l.O.StrHuisnrVader; //bus zit hier in
                        xlWorkSheet.Cells[intTeller, 43] = l.O.StrPostcodeVader;
                        xlWorkSheet.Cells[intTeller, 44] = l.O.StrGemeenteVader;

                        intTeller++;
                    }
                    xlWorkSheet.Columns.AutoFit();
                    xlWorkSheet.Rows.AutoFit();
                }
                catch (Exception)
                { MessageBox.Show("Leerlingen exporteren mislukt.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning); crashed = true; }

                try
                {
                    xlWorkBook.Close(true, locatie + naam, misValue);
                    xlexcel.Quit();

                    releaseObject(xlWorkSheet);
                    releaseObject(xlWorkBook);
                    releaseObject(xlexcel);
                    try
                    {
                        System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlWorkSheet);
                        System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlWorkBook);
                        System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlexcel);
                        Process[] excelProcesses = Process.GetProcessesByName("excel");
                        foreach (Process p in excelProcesses)
                        {
                            if (string.IsNullOrEmpty(p.MainWindowTitle))
                            { p.Kill(); }
                        }
                        xlWorkSheet = null;
                        xlWorkBook = null;
                        xlexcel = null;
                    }
                    catch (Exception) { }
                    if (!crashed)
                    { MessageBox.Show("Leerlingen ge-exporteerd.", "", MessageBoxButtons.OK, MessageBoxIcon.Information); }

                    this.Close();
                }
                catch (Exception) { MessageBox.Show("Leerlingen exporteren mislukt.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning); this.Close(); }
            }));
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
                Console.WriteLine("Unable to release the Object " + ex.ToString());
            }
            finally
            { GC.Collect(); }
        }
        #endregion
    }
}