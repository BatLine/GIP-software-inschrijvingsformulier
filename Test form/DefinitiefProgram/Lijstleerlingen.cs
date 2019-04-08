#region usings
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion

namespace DefinitiefProgram
{
    public partial class Lijstleerlingen : Form
    {
        #region vars
        Business b = new Business();
        public Menu m = new Menu();
        bool loading = true;
        #endregion

        #region controls
        #region form
        public Lijstleerlingen()
        { InitializeComponent(); }
        private void Lijstleerlingen_Load(object sender, EventArgs e)
        { refreshLLN(); loading = false; }
        private void Lijstleerlingen_FormClosing(object sender, FormClosingEventArgs e)
        { this.Dispose(); }
        #endregion
        private void btnKies_Click(object sender, EventArgs e)
        {
            if (lvLeerlingen.SelectedItems[0].Text.Length > 0)
            {
                m.wijzigLLN(Convert.ToInt16(lvLeerlingen.SelectedItems[0].Tag));
                this.Close();
            }
            else { MessageBox.Show("Selecteer eerst een leerling."); }
        }
        private void lvLeerlingen_DoubleClick(object sender, EventArgs e)
        {
            if (lvLeerlingen.SelectedItems.Count > 0)
            { btnKies_Click(sender, e); }
        }
        private void lvLeerlingen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { btnKies_Click(sender, e); }
        }
        private void tmrCheckIfLoaded_Tick(object sender, EventArgs e)
        {
            if (!loading)
            {
                lo.Focus();
                tmrCheckIfLoaded.Stop();
            }
        }
        #endregion

        #region functions
        LoadingCircle lo;
        public async void refreshLLN()
        {
            lo = new LoadingCircle();
            lo.Show();
            lo.BringToFront();
            Panel pnl = new Panel();
            this.Controls.Add(pnl);
            pnl.BackColor = this.BackColor;
            pnl.Size = this.Size;
            pnl.Location = new Point(0, 0);
            pnl.BringToFront();
            string text = this.Text;
            this.Text = "";
            this.Visible = false;
            lo.Focus();

            await Task.Run(() => getAlleLLN());

            this.Focus();
            this.Visible = true;
            this.Text = text;
            Controls.Remove(pnl);
            lo.Close();
            lo.Dispose();
        }
        void getAlleLLN()
        {
            List<Leerling> lln = b.getAlleLeerlingen();
            foreach (Leerling l in lln)
            {
                int databaseID = l.DatabaseID;
                string[] info = new string[3];
                info[0] = l.StrVoornaam;
                info[1] = l.StrNaam;
                info[2] = l.StrPostcode;
                ListViewItem lv = new ListViewItem(info);
                lv.Tag = databaseID;
                try
                { this.Invoke(new Action(() => lvLeerlingen.Items.Add(lv) )); }
                catch (Exception)
                { Thread.Sleep(2000); }
            }
        }
        #endregion
    }
}
