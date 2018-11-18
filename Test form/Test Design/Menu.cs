using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_Design
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }
        Design d = new Design();

        private void btnToevoegen_Click(object sender, EventArgs e)
        {
            d.Show();
            this.Close();
        }

        private void btnWijzigen_Click(object sender, EventArgs e)
        {
            d.Show();
            //alle velden vullen met shit
            this.Close();
        }
    }
}
