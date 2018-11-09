using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmtest
{
    public partial class Test2 : Form
    {
        public Test2()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Voornaam_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void cmbRichting_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void checkJaar()
        {
            cmbRichting.Enabled = true;
            if (rdb1.Checked || rdb2.Checked)
            {
                cmbRichting.Items.Clear();
                cmbRichting.Items.Add("Ondernemen");
            }
            
            else if (rdb3.Checked || rdb4.Checked)
            {
                cmbRichting.Items.Clear();
                cmbRichting.Items.Add("Ondernemen & IT");
                cmbRichting.Items.Add("Ondernemen & Communicatie"); 
            }
            else if (rdb5.Checked || rdb6.Checked)
            {
                cmbRichting.Items.Clear();
                cmbRichting.Items.Add("Marketing & Ondernemen");
                cmbRichting.Items.Add("Accountancy & IT");
                cmbRichting.Items.Add("IT & Netwerken");
                cmbRichting.Items.Add("Office management & communicatie");
            }
        }

        private void rdb1_CheckedChanged(object sender, EventArgs e)
        {
            checkJaar();
        }

        private void rdb2_CheckedChanged(object sender, EventArgs e)
        {
            checkJaar();
        }

        private void rdb3_CheckedChanged(object sender, EventArgs e)
        {
            checkJaar();
        }

        private void rdb4_CheckedChanged(object sender, EventArgs e)
        {
            checkJaar();
        }

        private void rdb5_CheckedChanged(object sender, EventArgs e)
        {
            checkJaar();
        }

        private void rdb6_CheckedChanged(object sender, EventArgs e)
        {
            checkJaar();
        }
    }
}
