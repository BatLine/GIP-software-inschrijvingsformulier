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
        //item.Selected = true; toevoegen bij alles dat wordt toegevoegd in de listview
        //size klein 318; 114
        //size med 318; 244
        //size large 318; 538
        public Export()
        { InitializeComponent(); }

        void rdbChanged()
        {
            if (rdbIedereen.Checked)
            { hideAlles(); }
            else
            { showSpecifiek(); }
        }
        void hideAlles()
        {
            this.Size = new Size(318, 114);
            gpSpecifiek.Hide();
            gpSpecifieker.Hide();
        }
        void showSpecifiek()
        {
            chkSpecifiker.Checked = false;
            gpSpecifiek.Show();
            this.Size = new Size(318, 244);
        }
        void showSpecifieker()
        {
            gpSpecifieker.Show();
            refreshSpecifieker();
        }
        void hideSpecifieker()
        {
            gpSpecifieker.Hide();
            this.Size = new Size(318, 538);
        }
        void refreshSpecifieker()
        {
            lvSpecifieker.Clear();
        }

        private void rdbIedereen_CheckedChanged(object sender, EventArgs e)
        { rdbChanged(); }
        private void rdbSpecifiek_CheckedChanged(object sender, EventArgs e)
        { rdbChanged(); }

        private void chkSpecifiker_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSpecifiker.Checked)
            { showSpecifieker(); this.Size = new Size(318, 538); } else { hideSpecifieker(); }
        }
    }
}
