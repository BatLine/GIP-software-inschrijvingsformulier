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
    public partial class Menu : Form
    {
        Business b = new Business();
        public int selectedLeerlingID=-1;
        public Menu()
        { InitializeComponent(); }

        private void btnToevoegen_Click(object sender, EventArgs e)
        {
            new Design().Show();
            this.Close();
        }

        private void btnWijzigen_Click(object sender, EventArgs e)
        {
            Lijstleerlingen lijstleerlingen = new Lijstleerlingen();
            lijstleerlingen.m = this;
            lijstleerlingen.ShowDialog();
            if ((lijstleerlingen.DialogResult == DialogResult.OK) && (selectedLeerlingID != -1))
            {
                Design d = new Design(); d.Text = "Leerling wijzigen"; d.Show();
                d.veldenvullen(selectedLeerlingID);
                this.Close();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            foreach (Leerling l in b.getAlleLeerlingen())
            {

            }
            MessageBox.Show("Done");
        }
    }
}
