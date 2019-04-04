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
    public partial class Design : Form
    {
        /// <TODO>
        /// TODO
        /// textbox geboortedatum bij ouders en lln naar masked?
        /// postcode automatisch laten invullen? => of omgekeerd
        /// cmb land opvullen met alle landen
        /// cmbNationaliteit invullen met alle nationaliteiten
        /// eerst checken op oudernaam om dan alles automatisch te laten invullen als ouder al bestaat
        /// als er zo aangeduid wordt dat die persoon maar 1 ouder heeft, ervoor zorgen dat de rest niet moet ingevuld worden
        /// wachtwoorden misschien versleuteld opslaan?
        /// gezinssituatie moeder/vader overleven nieuwe vraag met de vraag welke dood is en  die disabele. ook bij geen contact meer met
        /// </TODO>
        #region vars
        Business b = new Business();
        int Studiejaar = 0;
        string Schoolstatuut = "Extern";
        bool blnShowPassword = false;
        #endregion

        #region controls
        #region Form
        public Design()
        { InitializeComponent(); }
        private void Design_Load(object sender, EventArgs e)
        { checkdebug(); pbToonWachtwoord.Image = ilPassword.Images[0]; }
        private void Design_FormClosing(object sender, FormClosingEventArgs e)
        { }
        #endregion
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Loading loadingscreen = new Loading();
            //loadingscreen.Show();
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
            lln.StrGebruikersnaamNetwerk = txtGebruikersnaamNetwerk.Text;
            lln.StrWachtwoordNetwerk = txtWachtwoordNetwerk.Text;

            //Ouders
            Ouders o = new Ouders();
            o.StrGezinssituatie = cmbGezinssituatie.SelectedItem.ToString();
            //Moeder
            o.StrNaamMoeder = txtVoornaamMoeder.Text;
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
            o.StrNaamVader = txtVoornaamVader.Text;
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

            string strGezinshoofd;
            if (rdbGezinshoofdMoeder.Checked) { strGezinshoofd = "Moeder"; } else { strGezinshoofd = "Vader"; }
            o.StrGezinshoofd = strGezinshoofd;
            lln.O = o;

            b.addToDatabase(lln, cmbRichting.Text, Schoolstatuut);
            loadingscreen.Close();
            this.Close();
        }
        private void tpLLN_Click(object sender, EventArgs e)
        { }
        private void pbToonWachtwoord_Click(object sender, EventArgs e)
        {
            if (blnShowPassword) { pbToonWachtwoord.Image = ilPassword.Images[0]; blnShowPassword = false; txtWachtwoordNetwerk.UseSystemPasswordChar = true; }
            else { pbToonWachtwoord.Image = ilPassword.Images[1]; blnShowPassword = true; txtWachtwoordNetwerk.UseSystemPasswordChar = false; }
        }
        private void tpOuder_Click(object sender, EventArgs e)
        { }
        private void rdbGezinshoofdMoeder_CheckedChanged(object sender, EventArgs e)
        { }
        private void rdbGezinshoofdVader_CheckedChanged(object sender, EventArgs e)
        { }
        #region updatenetwerknaam
        private void txtVoornaam_TextChanged(object sender, EventArgs e)
        { updateNetwerkNaam(); }
        private void txtFamilieNaam_TextChanged(object sender, EventArgs e)
        { updateNetwerkNaam(); }
        void updateNetwerkNaam()
        { txtGebruikersnaamNetwerk.Text = txtVoornaam.Text + "." + txtFamilieNaam.Text.Replace(" ", "").ToLower(); }
        #endregion
        #region checkstudiejaar
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
        #endregion
        #region checkschoolstatuut
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
        #endregion
        #endregion

        #region functions
        public void veldenvullen(int pintID)
        {
            Leerling l = b.GetLeerling(pintID);
            txtVoornaam.Text = l.StrVoornaam;
            txtFamilieNaam.Text = l.StrNaam;
            txtBijkvoornaam.Text = l.StrBijkNaam;
            cmbGeslacht.SelectedItem = l.StrGeslacht;
            txtGeboortedatum.Text = l.StrGeboortedatum;
            txtGeboorteplaats.Text = l.StrGeboorteplaats;
            mskRijksregisterNummer.Text = l.StrRijkregisternummer;
            txtNationaliteit.Text = l.StrNationaliteit;
            mskGsmNummer.Text = l.StrGSM_Nummer;
            txtEmail.Text = l.StrE_Mail;
            txtStraat.Text = l.StrStraat;
            txtHuisnr.Text = l.StrHuisnummer;
            txtBus.Text = l.StrBus;
            txtGemeente.Text = l.StrGemeente;
            mskPostcode.Text = l.StrPostcode;
            cmbLand.SelectedItem = l.StrLand;
            switch (l.IntMiddelbaar)
            {
                case 1:
                    unselectAllrdbJaar(); rdbJaar1.Checked = true; break;
                case 2:
                    unselectAllrdbJaar(); rdbJaar2.Checked = true; break;
                case 3:
                    unselectAllrdbJaar(); rdbJaar3.Checked = true; break;
                case 4:
                    unselectAllrdbJaar(); rdbJaar4.Checked = true; break;
                case 5:
                    unselectAllrdbJaar(); rdbJaar5.Checked = true; break;
                case 6:
                    unselectAllrdbJaar(); rdbJaar6.Checked = true; break;
            }
            checkStudieJaar();
            cmbRichting.SelectedItem = l.StrRichtingNaam;
            txtGebruikersnaamNetwerk.Text = l.StrGebruikersnaamNetwerk;
            txtWachtwoordNetwerk.Text = l.StrWachtwoordNetwerk;
            switch (l.IntSchoolstatuutID)
            {
                case 1:
                    rdbIntern.Checked = true; rdbExtern.Checked = false; rdbHalfIntern.Checked = false; break;
                case 2:
                    rdbIntern.Checked = false; rdbExtern.Checked = true; rdbHalfIntern.Checked = false; break;
                case 3:
                    rdbIntern.Checked = false; rdbExtern.Checked = false; rdbHalfIntern.Checked = true; break;
            }
            txtVoornaamMoeder.Text = l.O.StrNaamMoeder;
            txtEmailMoeder.Text = l.O.StrEmailMoeder;
            mtxtGSMMoeder.Text = l.O.StrGSMMoeder;
            mtxtTelfoonWerkMoeder.Text = l.O.StrTelefoonWerkMoeder;
            txtStraatMoeder.Text = l.O.StrStraatMoeder;
            mtxtPostcodeMoeder.Text = l.O.StrPostcodeMoeder;
            txtHuisNRMoeder.Text = l.O.StrHuisnrMoeder;
            txtGemeenteMoeder.Text = l.O.StrGemeenteMoeder;

            txtVoornaamVader.Text = l.O.StrNaamVader;
            txtEmailVader.Text = l.O.StrEmailVader;
            mtxtGSMVader.Text = l.O.StrGSMVader;
            mtxtTelfoonWerkVader.Text = l.O.StrTelefoonWerkVader;
            txtStraatVader.Text = l.O.StrStraatVader;
            mtxtPostcodeVader.Text = l.O.StrPostcodeVader;
            txtHuisNRVader.Text = l.O.StrHuisnrVader;
            txtGemeenteVader.Text = l.O.StrGemeenteVader;

            if (l.O.StrGezinshoofd == "Moeder") { rdbGezinshoofdMoeder.Checked = true; rdbGezinshoofdVader.Checked = false; } else { rdbGezinshoofdVader.Checked = true; rdbGezinshoofdMoeder.Checked = false; }
            cmbGezinssituatie.SelectedItem = l.O.StrGezinssituatie;

            //bij bevestigen de origenele updaten/eerst verwijderen en dan toevoegen
        }
        void unselectAllrdbJaar()
        {
            rdbJaar1.Checked = false;
            rdbJaar2.Checked = false;
            rdbJaar3.Checked = false;
            rdbJaar4.Checked = false;
            rdbJaar5.Checked = false;
            rdbJaar6.Checked = false;
        }

        
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

                txtVoornaamMoeder.Text = "naam";
                txtHuisNRMoeder.Text = "1";
                txtGemeenteMoeder.Text = "Gemeente";
                txtEmailMoeder.Text = "email@mail.com";
                mtxtPostcodeMoeder.Text = "9000";
                txtStraatMoeder.Text = "straat";
                mtxtTelfoonWerkMoeder.Text = "04711";
                mtxtGSMMoeder.Text = "04711";
                txtVoornaamVader.Text = "naam";
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

                txtGebruikersnaamNetwerk.Text = "gebruikersnaam";
                txtWachtwoordNetwerk.Text = "wachtwoord";
                cmbCorrespondentie.SelectedIndex = 1;

                checkSchoolstatuut();
            }
        }
        
        #endregion

        private void mtxtPostcodeMoeder_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {}

        private void cmbGezinssituatie_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGezinssituatie.SelectedItem.ToString() == "Gehuwd")
            {
                label21.Text = "Moeder";
                pnlVader.Visible = true;
                pnlMoeder.Visible = true;
            }
            else if (cmbGezinssituatie.SelectedItem.ToString() == "Co-Ouderschap")
            {
                label21.Text = "Moeder";
                pnlVader.Visible = true;
                pnlMoeder.Visible = true;
            }
            else if (cmbGezinssituatie.SelectedItem.ToString() == "Pleeggezin")
            {
                label21.Text = "Pleeg moeder";
                label23.Text = "Pleeg vader";
                pnlVader.Visible = true;
                pnlMoeder.Visible = true;
            }
            else if (cmbGezinssituatie.SelectedItem.ToString() == "Éenoudergezin")
            {
                label21.Text = "Ouder";
                pnlVader.Visible = false;
                pnlMoeder.Visible = true;
            }
            else if (cmbGezinssituatie.SelectedItem.ToString() == "Gescheiden")
            {
                label21.Text = "Moeder";
                pnlVader.Visible = true;
                pnlMoeder.Visible = true;
            }
            else if (cmbGezinssituatie.SelectedItem.ToString() == "Vader overleden")
            {
                label21.Text = "Moeder";
                pnlVader.Visible = false;
                pnlMoeder.Visible = true;
            }
            else if (cmbGezinssituatie.SelectedItem.ToString() == "Moeder overleden")
            {
                label21.Text = "Moeder";
                pnlVader.Visible = true;
                pnlMoeder.Visible = false;
            }


        }

        private void label21_Click(object sender, EventArgs e)
        {

        }
    }
}
