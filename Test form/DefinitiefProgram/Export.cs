using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DefinitiefProgram
{
    public partial class Export : Form
    {
        Business b = new Business();
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
            vulSpeciefieker(tuple.Item2);
        }
        void vulSpeciefieker(List<Leerling> lln)
        {
            lvSpecifieker.Clear();
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
        }
    }
}
