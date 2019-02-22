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

        void rdbChanged()
        {
            if (rdbIedereen.Checked)
            { hideAlles(); }
            else
            {
                showSpecifiek();
                b.
                //laad antal
            }
        }
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
            refreshSpecifieker();
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
            //laad alle mensen in die datum 
            setLocationButtons();
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

        private void Export_Load(object sender, EventArgs e)
        {
            hideAlles();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
