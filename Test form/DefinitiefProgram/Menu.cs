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
        public Menu()
        { InitializeComponent(); }

        private void btnToevoegen_Click(object sender, EventArgs e)
        {
            new Design().Show();
            this.Close();
        }

        private void btnWijzigen_Click(object sender, EventArgs e)
        {
            Design d = new Design(); d.Show();

            this.Close();
        }
    }
}
