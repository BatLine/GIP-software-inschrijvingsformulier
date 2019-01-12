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
    public partial class Design : Form
    {

        /// <TODO>
        /// TODO
        /// textbox geboortedatum bij ouders en lln naar masked?
        /// postcode automatisch laten invullen? => of omgekeerd en bovenstaand puntje skippen
        /// cmb land opvullen met alle landen
        /// cmbNationaliteit invullen met alle nationaliteiten
        /// eerst checken op oudernaam om dan alles automatisch te laten invullen als ouder al bestaat
        /// als er zo aangeduid wordt dat die persoon maar 1 ouder heeft, ervoor zorgen dat de rest niet moet ingevuld worden
        /// wachtwoorden misschien versleuteld opslaan?
        /// </TODO>
        Business b = new Business();
        int Studiejaar = 0;
        string Schoolstatuut = "Extern";
        string Gezinshoofd = "Moeder";
        public Design()
        { InitializeComponent(); }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Leerling lln = new Leerling();

            //leerling
            //correspondentie
            lln.StrVoornaam = txtVoornaam.Text;
            lln.StrNaam = txtFamilieNaam.Text;
            lln.StrBijkNaam = txtBijkvoornaam.Text;
            lln.StrGeslacht = cmbGeslacht.SelectedItem.ToString();
            lln.StrGeboorteplaats = txtGeboorteplaats.Text;
            lln.StrGeboortedatum = txtGeboortedatum.Text;
            lln.StrRijkregisternummer = mskRijksregisterNummer.Text;
            lln.StrNationaliteit = txtNationaliteit.Text;
            lln.StrGSM_Nummer = mskGsmNummer.Text;
            lln.StrE_Mail = txtEmail.Text;
            lln.StrStraat = txtStraat.Text;
            lln.StrHuisnummer = txtHuisnr.Text;
            lln.StrBus = txtBus.Text;
            lln.StrGemeente = txtGemeente.Text;
            lln.StrPostcode = mskPostcode.Text;
            lln.StrLand = cmbLand.Text;
            lln.IntMiddelbaar = Studiejaar;
            lln.IntKlasNR = Convert.ToInt16(lblKlasNR.Text);
            lln.StrKlas = cmbKlas.SelectedItem.ToString();
            lln.StrGebruikersnaamNetwerk = txtGebruikersnaamNetwerk.Text;
            lln.StrWachtwoordNetwerk = txtWachtwoordNetwerk.Text;

            //Ouders
            Ouders o = new Ouders();
            o.StrGezinssituatie = cmbGezinssituatie.SelectedItem.ToString();
            //Moeder
            o.StrNaamMoeder = txtNaamMoeder.Text;
            //o.StrGeboorteDatumMoeder = txtGeboortedatumMoeder.Text;
            //o.StrRijksregisterNRMoeder = mtxtRijkregNRMoeder.Text;
            //o.StrBeroepMoeder = txtBeroepMoeder.Text;
            o.StrGSMMoeder = mtxtGSMMoeder.Text;
            o.StrTelefoonWerkMoeder = mtxtTelfoonWerkMoeder.Text;
            o.StrEmailMoeder = txtEmailMoeder.Text;
            o.StrStraatMoeder = txtStraatMoeder.Text;
            o.StrHuisnrMoeder = txtHuisNRMoeder.Text;
            o.StrGemeenteMoeder = txtGemeenteMoeder.Text;
            o.StrPostcodeMoeder = mtxtPostcodeMoeder.Text;

            //Vader
            o.StrNaamVader = txtNaamVader.Text;
            //o.StrGeboorteDatumVader = txtGeboortedatumVader.Text;
            //o.StrRijksregisterNRVader = mtxtRijksregisterNRVader.Text;
            //o.StrBeroepVader = txtBeroepVader.Text;
            o.StrGSMVader = mtxtGSMVader.Text;
            o.StrTelefoonWerkVader = mtxtTelfoonWerkVader.Text;
            o.StrEmailVader = txtEmailVader.Text;
            o.StrStraatVader = txtStraatVader.Text;
            o.StrHuisnrVader = txtHuisNRVader.Text;
            o.StrGemeenteVader = txtGemeenteVader.Text;
            o.StrPostcodeVader = mtxtPostcodeVader.Text;

            lln.O = o;

            b.addToDatabase(lln, cmbRichting.Text, Schoolstatuut, Gezinshoofd);
            this.Close();
        }

        private void Design_Load(object sender, EventArgs e)
        { refreshAlleKlassen(); checkdebug(); }

        private void tpLLN_Click(object sender, EventArgs e)
        { }

        void refreshAlleKlassen()
        {
            foreach (string s in b.getAlleKlassen())
            { cmbKlas.Items.Add(s); }
        }

        //Check studiejaar
        void checkStudieJaar()
        {
            if (rdbJaar1.Checked) { Studiejaar = 1; }
            else if (rdbJaar2.Checked) { Studiejaar = 2; }
            else if (rdbJaar3.Checked) { Studiejaar = 3; }
            else if (rdbJaar4.Checked) { Studiejaar = 4; }
            else if (rdbJaar5.Checked) { Studiejaar = 5; }
            else if (rdbJaar6.Checked) { Studiejaar = 6; }
            cmbRichting.Enabled = true;
            if (rdbJaar1.Checked || rdbJaar2.Checked)
            {
                cmbRichting.Items.Clear();
                cmbRichting.Items.Add("Ondernemen");
            }
            else if (rdbJaar3.Checked || rdbJaar4.Checked)
            {
                cmbRichting.Items.Clear();
                cmbRichting.Items.Add("Ondernemen & IT");
                cmbRichting.Items.Add("Ondernemen & Communicatie");
            }
            else if (rdbJaar5.Checked || rdbJaar6.Checked)
            {
                cmbRichting.Items.Clear();
                cmbRichting.Items.Add("Marketing & Ondernemen");
                cmbRichting.Items.Add("Accountancy & IT");
                cmbRichting.Items.Add("IT & Netwerken");
                cmbRichting.Items.Add("Office management & communicatie");
            }
        }
        private void rdbJaar1_CheckedChanged(object sender, EventArgs e)
        { checkStudieJaar(); }
        private void rdbJaar2_CheckedChanged(object sender, EventArgs e)
        { checkStudieJaar(); }
        private void rdbJaar3_CheckedChanged(object sender, EventArgs e)
        { checkStudieJaar(); }
        private void rdbJaar4_CheckedChanged(object sender, EventArgs e)
        { checkStudieJaar(); }
        private void rdbJaar5_CheckedChanged(object sender, EventArgs e)
        { checkStudieJaar(); }
        private void rdbJaar6_CheckedChanged(object sender, EventArgs e)
        { checkStudieJaar(); }

        //Check schoolstatuut
        void checkSchoolstatuut()
        {
            if (rdbExtern.Checked) { Schoolstatuut = "Extern"; }
            else if (rdbIntern.Checked) { Schoolstatuut = "Intern"; }
            else if (rdbHalfIntern.Checked) { Schoolstatuut = "Half-Intern"; }
        }
        private void rdbIntern_CheckedChanged(object sender, EventArgs e)
        { checkSchoolstatuut(); }
        private void rdbExtern_CheckedChanged(object sender, EventArgs e)
        { checkSchoolstatuut(); }
        private void rdbHalfIntern_CheckedChanged(object sender, EventArgs e)
        { checkSchoolstatuut(); }

        private void tpOuder_Click(object sender, EventArgs e)
        { }

        private void btnToonWachtwoord_Click(object sender, EventArgs e)
        { if (btnToonWachtwoord.Text == "Tonen") { btnToonWachtwoord.Text = "Verbergen"; } else { btnToonWachtwoord.Text = "Tonen"; } }

        private void rdbGezinshoofdMoeder_CheckedChanged(object sender, EventArgs e)
        { if (rdbGezinshoofdMoeder.Checked) { Gezinshoofd = "Moeder"; } }
        private void rdbGezinshoofdVader_CheckedChanged(object sender, EventArgs e)
        { if (rdbGezinshoofdVader.Checked) { Gezinshoofd = "Vader"; } }

        void checkdebug()
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                //alle velden vullen om te testen
                txtVoornaam.Text = "Voornaam";
                txtFamilieNaam.Text = "Familienaam";
                txtBijkvoornaam.Text = "bijk. vnaam";
                cmbGeslacht.SelectedIndex = 1;
                txtGeboorteplaats.Text = "geboorteplaats";
                txtGeboortedatum.Text = "01/01/0001";
                mskRijksregisterNummer.Text = "1";
                txtNationaliteit.Text = "Nationaliteit";
                mskGsmNummer.Text = "04711";
                txtStraat.Text = "Straat";
                txtEmail.Text = "email@email.com";
                txtHuisnr.Text = "1";
                txtBus.Text = "a";
                txtGemeente.Text = "Gemeente";
                mskPostcode.Text = "9000";
                cmbLand.SelectedIndex = 1;

                txtNaamMoeder.Text = "naam";
                txtHuisNRMoeder.Text = "1";
                txtGemeenteMoeder.Text = "Gemeente";
                txtEmailMoeder.Text = "email@mail.com";
                mtxtPostcodeMoeder.Text = "9000";
                txtStraatMoeder.Text = "straat";
                mtxtTelfoonWerkMoeder.Text = "04711";
                mtxtGSMMoeder.Text = "04711";
                txtNaamVader.Text = "naam";
                txtHuisNRVader.Text = "1";
                txtGemeenteVader.Text = "Gemeente";
                txtEmailVader.Text = "email@mail.com";
                mtxtPostcodeVader.Text = "9000";
                txtStraatVader.Text = "straat";
                mtxtTelfoonWerkVader.Text = "04711";
                mtxtGSMVader.Text = "04711";
                rdbGezinshoofdMoeder.Checked = true;
                cmbGezinssituatie.SelectedIndex = 1;

                rdbJaar6.Checked = true;
                checkStudieJaar();
                cmbRichting.SelectedIndex = 0;
                rdbExtern.Checked = true;

                lblKlasNR.Text = "1";
                cmbKlas.SelectedIndex = 1;
                txtGebruikersnaamNetwerk.Text = "gebruikersnaam";
                txtWachtwoordNetwerk.Text = "wachtwoord";
                cmbCorrespondentie.SelectedIndex = 1;

                checkSchoolstatuut();
            }
        }

        private void Design_FormClosing(object sender, FormClosingEventArgs e)
        {
            new Menu().Show();
        }
    }
}
