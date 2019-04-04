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

namespace DefinitiefProgram
{
    public partial class Lijstleerlingen : Form
    {
        Business b = new Business();
        public Menu m = new Menu();

        public Lijstleerlingen()
        { InitializeComponent(); }

        private void Lijstleerlingen_Load(object sender, EventArgs e)
        { }

        public async void refreshLLN()
        {
            LoadingCircle lo = new LoadingCircle();
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

            await Task.Run(() => getAlleLLN());

            Controls.Remove(pnl);
            lo.Close();
        }

        private void btnKies_Click(object sender, EventArgs e)
        {
            if (lvLeerlingen.SelectedItems[0].Text.Length > 0)
            {
                m.wijzigLLN(Convert.ToInt16(lvLeerlingen.SelectedItems[0].Tag));
                this.Close();
            }
            else { MessageBox.Show("Selecteer eerst een leerling."); }
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
                this.Invoke(new Action(() => lvLeerlingen.Items.Add(lv))); 
            }
        }
    }
}
