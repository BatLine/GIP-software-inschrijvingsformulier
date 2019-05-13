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
    public partial class CheckPassword : Form
    {
        public CheckPassword()
        { InitializeComponent(); }

        private void BtnForward_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == Properties.Settings.Default.Wachtwoord) { this.DialogResult = DialogResult.OK; } else { this.DialogResult = DialogResult.No; }
            this.Close();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            this.Close();
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { BtnForward_Click(sender, e); }
        }
    }
}
