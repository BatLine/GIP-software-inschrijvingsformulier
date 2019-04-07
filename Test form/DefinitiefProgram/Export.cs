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
        //item.Selected = true; toevoegen bij alles dat wordt toegevoegd in de listview
        //size klein 341; 140
        //size med 341; 275
        //size large 341, 574
        #endregion

        #region controls
        #region form
        public Export()
        { InitializeComponent(); }
        private void Export_Load(object sender, EventArgs e)
        { hideAlles(); }
        #endregion
        private void rdbIedereen_CheckedChanged(object sender, EventArgs e)
        { rdbChanged(); }
        private void rdbSpecifiek_CheckedChanged(object sender, EventArgs e)
        { rdbChanged(); }
        private void chkSpecifiker_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSpecifiker.Checked)
            { showSpecifieker(); this.Size = new Size(341, 574); }
            else { hideSpecifieker(); }
            setLocationButtons();
        }
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
            else { leerlingenOmteExporteren = b.getAlleLeerlingen(); }

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
                    runExport(prop.Default.lastSaveFolder, "Leerlingen.xlsx");
                }
            }
            else { MessageBox.Show("Leerlingen exporteren mislukt." + Environment.NewLine + "Gelieve minstens 1 leerling te selecteren.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
        #endregion

        #region functions
        void hideAlles()
        {
            this.Size = new Size(341, 140);
            gpSpecifiek.Hide();
            gpSpecifieker.Hide();
            setLocationButtons();
        }
        void showSpecifiek()
        {
            chkSpecifiker.Checked = false;
            gpSpecifiek.Show();
            this.Size = new Size(341, 275);
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
            this.Size = new Size(341, 275);
            setLocationButtons();
        }
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

            Tuple<int, List<Leerling>> tuple = b.getAantalLLN(van, tot, this);
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
            { hideAlles(); }
            else
            {
                refreshSpecifieker();
                showSpecifiek();
            }
        }
        void setLocationButtons()
        {
            int xCancel = 15;
            int xExport = 255;
            if (this.Size == new Size(341, 574))
            {
                int y = 505;
                btnCancel.Location = new Point(xCancel, y);
                btnExport.Location = new Point(xExport, y);
                btnCancel.BringToFront();
                btnExport.BringToFront();
            }
            else if (this.Size == new Size(341, 275))
            {
                int y = gpSpecifiek.Location.Y + gpSpecifiek.Size.Height + 4;
                btnCancel.Location = new Point(xCancel, y);
                btnExport.Location = new Point(xExport, y);
                btnCancel.BringToFront();
                btnExport.BringToFront();
                this.Size = new Size(341, 242);
            }
            else if (this.Size == new Size(341, 140))
            {
                int y = this.Height - btnCancel.Height - 45;
                btnCancel.Location = new Point(xCancel, y);
                btnExport.Location = new Point(xExport, y);
                btnCancel.BringToFront();
                btnExport.BringToFront();
            }
            CenterToParent();
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

            this.Visible = true;
            this.Text = text;
            Controls.Remove(pnl);
            lo.Close();
        }
        void export(string locatie, string naam)
        {
            this.Invoke(new Action(() => {
                try
                {
                    int intTeller = 1;
                    xlexcel = new Excel.Application();
                    xlexcel.Visible = false;

                    if (File.Exists(locatie + naam))
                        File.Delete(locatie + naam);
                    if (File.Exists(tempPath + @"\tempLeerlingen.xlsx"))
                    { File.Delete(tempPath + @"\tempLeerlingen.xlsx"); }

                    var app = new Excel.Application();
                    var wb = app.Workbooks.Add();
                    wb.SaveAs(tempPath + @"tempLeerlingen.xlsx");
                    wb.Close();

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
                        xlWorkSheet.Cells[intTeller, 18] = l.O.StrGSMMoeder;
                        xlWorkSheet.Cells[intTeller, 19] = l.O.StrGSMVader;
                        xlWorkSheet.Cells[intTeller, 20] = l.StrE_Mail;
                        xlWorkSheet.Cells[intTeller, 21] = l.O.StrEmailMoeder;
                        xlWorkSheet.Cells[intTeller, 22] = l.O.StrEmailVader;

                        xlWorkSheet.Cells[intTeller, 23] = l.StrGebruikersnaamNetwerk;
                        xlWorkSheet.Cells[intTeller, 24] = l.StrWachtwoordNetwerk;

                        xlWorkSheet.Cells[intTeller, 25] = l.O.StrNaamMoeder;
                        xlWorkSheet.Cells[intTeller, 26] = l.O.StrVoornaamMoeder;
                        xlWorkSheet.Cells[intTeller, 29] = l.O.StrBeroepMoeder;
                        xlWorkSheet.Cells[intTeller, 30] = l.O.StrGSMMoeder;
                        xlWorkSheet.Cells[intTeller, 31] = l.O.StrTelefoonWerkMoeder;
                        xlWorkSheet.Cells[intTeller, 32] = l.O.StrEmailMoeder;

                        xlWorkSheet.Cells[intTeller, 33] = l.O.StrNaamVader;
                        xlWorkSheet.Cells[intTeller, 34] = l.O.StrVoornaamVader;
                        xlWorkSheet.Cells[intTeller, 37] = l.O.StrBeroepVader;
                        xlWorkSheet.Cells[intTeller, 38] = l.O.StrGSMVader;
                        xlWorkSheet.Cells[intTeller, 39] = l.O.StrTelefoonWerkVader;
                        xlWorkSheet.Cells[intTeller, 40] = l.O.StrEmailVader;

                        intTeller++;
                    }

                    xlWorkBook.Close(true, locatie + naam, misValue);
                    xlexcel.Quit();

                    releaseObject(xlWorkSheet);
                    releaseObject(xlWorkBook);
                    releaseObject(xlexcel);
                    MessageBox.Show("Leerlingen ge-exporteerd.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                { MessageBox.Show("Leerlingen exporteren mislukt.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                this.Close();
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
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            { GC.Collect(); }
        }
        #endregion
    }
}
