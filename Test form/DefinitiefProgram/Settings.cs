using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace DefinitiefProgram
{
    public partial class Settings : Form
    {
        Business b = new Business();
        public Settings()
        { InitializeComponent(); }

        private void BtnWisAlles_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            DialogResult result = MessageBox.Show("Ben je zeker dat je alles wilt verwijderen?" + Environment.NewLine + "Dit kan niet ongedaan gemaakt worden.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            { wisAlles(); }
            else { this.TopMost = true; return; }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        { this.Close(); }

        private void BtnVerwijderLeerling_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            string voornaam = Interaction.InputBox("Voornaam leerling:", "Info Leerling");
            string achternaam = Interaction.InputBox("(Tussenvoegsel +) Achternaam leerling:", "Info Leerling");
            string postcode = Interaction.InputBox("Postcode leerling:", "Info Leerling");
            DialogResult result = MessageBox.Show("Ben je zeker dat je " + voornaam + " " + achternaam + " wilt verwijderen?" + Environment.NewLine + "Dit kan niet ongedaan gemaakt worden.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            { wisLLN(voornaam, achternaam, postcode); }
            else { this.TopMost = true; return; }
        }
        async void wisLLN(string voornaam, string achternaam, string postcode)
        {
            LoadingCircle lo = new LoadingCircle();
            lo.Show();
            lo.Focus();

            await Task.Run(() => wissen(voornaam, achternaam, postcode));

            lo.Close();
            this.TopMost = true;
        }
        void wissen(string voornaam, string achternaam, string postcode)
        { MessageBox.Show(b.wisLeerling(voornaam, achternaam, postcode), "Leerling wissen", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        async void wisAlles()
        {
            LoadingCircle lo = new LoadingCircle();
            lo.Show();
            lo.Focus();

            await Task.Run(() => alleswissen());

            lo.Close();
            this.TopMost = true;
        }
        void alleswissen()
        { MessageBox.Show(b.wisAlles(), "Database wissen", MessageBoxButtons.OK, MessageBoxIcon.Information); }
    }
}
