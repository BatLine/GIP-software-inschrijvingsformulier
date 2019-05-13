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
            if (string.IsNullOrWhiteSpace(voornaam)) { MessageBox.Show("Ongeldige voornaam ingegeven.", "", MessageBoxButtons.OK, MessageBoxIcon.Error); this.TopMost = true; return; }
            string achternaam = Interaction.InputBox("(Tussenvoegsel +) Achternaam leerling:", "Info Leerling");
            if (string.IsNullOrWhiteSpace(achternaam)) { MessageBox.Show("Ongeldige achternaam ingegeven.", "", MessageBoxButtons.OK, MessageBoxIcon.Error); this.TopMost = true; return; }
            string postcode = Interaction.InputBox("Postcode leerling:", "Info Leerling");
            if (string.IsNullOrWhiteSpace(postcode)) { MessageBox.Show("Ongeldige postcode ingegeven.", "", MessageBoxButtons.OK, MessageBoxIcon.Error); this.TopMost = true; return; }

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

        private void TxtWijzigWachtwoordInstellingen_Click(object sender, EventArgs e)
        {
            if (Interaction.InputBox("Geef het huidige wachtwoord in:", "Wachtwoord veranderen") == Properties.Settings.Default.Wachtwoord)
            {
                Properties.Settings.Default.Wachtwoord = Interaction.InputBox("Geef een nieuw wachtwoord in:", "Wachtwoord veranderen");
                Properties.Settings.Default.Save();
                MessageBox.Show("Wachtwoord gewijzigd.", "Wachtwoord veranderen", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else { MessageBox.Show("Fout wachtwoord!", "Wachtwoord veranderen", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void TxtWijzigStandaardWWLLN_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.StandaardWachtwoordLLN = Interaction.InputBox("Geef een nieuw wachtwoord in:", "Wachtwoord veranderen");
            try
            {
                Properties.Settings.Default.Save();
                MessageBox.Show("Wachtwoord gewijzigd.", "Wachtwoord veranderen", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception) { MessageBox.Show("Fout bij het wijzigen van het wachtwoord!", "Wachtwoord veranderen", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
