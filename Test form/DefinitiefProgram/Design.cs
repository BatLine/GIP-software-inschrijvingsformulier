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
        /// 
        /// </TODO>
        #region vars
        Business b;// = new Business();
        int Studiejaar = 0;
        string Schoolstatuut = "Extern";
        bool blnShowPassword = false;
        bool starting = false;
        LoadingCircle lo;
        int updateID = 0;
        #endregion

        #region controls
        #region Form
        public Design()
        { InitializeComponent(); }
        private void Design_Load(object sender, EventArgs e)
        { start(); }
        private void Design_FormClosing(object sender, FormClosingEventArgs e)
        { }
        #endregion
        private void BtnCloseNotification_Click(object sender, EventArgs e)
        { notification.Hide(); }
        private void btnAddLand_Click(object sender, EventArgs e)
        {
            string strLand = Microsoft.VisualBasic.Interaction.InputBox("Naam land:", "Land toevoegen");
            if (!string.IsNullOrWhiteSpace(strLand))
            {
                if (b.addLand(strLand))
                {
                    MessageBox.Show(strLand + " is toegevoegd.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getAlleLanden();
                    setSelectedLand(strLand);
                }
                else { MessageBox.Show(strLand + " bestaat al.", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
        private void btnAddNationaliteit_Click(object sender, EventArgs e)
        {
            string strNationaliteit = Microsoft.VisualBasic.Interaction.InputBox("Nationaliteit:", "Nationaliteit toevoegen");
            if (!string.IsNullOrWhiteSpace(strNationaliteit))
            {
                if (b.addNationaliteit(strNationaliteit))
                {
                    MessageBox.Show(strNationaliteit + " is toegevoegd.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getAlleNationaliteiten();
                    setSelectedNationaliteit(strNationaliteit);
                }
                else { MessageBox.Show(strNationaliteit + " bestaat al.", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            notification.Visible = false;
            if (check())
            {
                Leerling lln = new Leerling();
                //leerling
                lln.StrCorrespondentie = cmbCorrespondentie.SelectedItem.ToString();
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
                lln.StrRichtingNaam = cmbRichting.SelectedItem.ToString();

                //Ouders
                Ouders o = new Ouders();
                o.StrGezinssituatie = cmbGezinssituatie.SelectedItem.ToString();
                //Moeder
                o.StrNaamMoeder = txtFamilienaamMoeder.Text;
                o.StrVoornaamMoeder = txtVoornaamMoeder.Text;
                o.StrGSMMoeder = mtxtGSMMoeder.Text;
                o.StrTelefoonWerkMoeder = mtxtTelfoonWerkMoeder.Text;
                o.StrEmailMoeder = txtEmailMoeder.Text;
                o.StrStraatMoeder = txtStraatMoeder.Text;
                o.StrHuisnrMoeder = txtHuisNRMoeder.Text;
                o.StrGemeenteMoeder = txtGemeenteMoeder.Text;
                o.StrPostcodeMoeder = mtxtPostcodeMoeder.Text;
                o.StrBeroepMoeder = txtBeroepMoeder.Text;

                //Vader
                o.StrNaamVader = txtFamilienaamMoeder.Text;
                o.StrVoornaamVader = txtVoornaamVader.Text;
                o.StrGSMVader = mtxtGSMVader.Text;
                o.StrTelefoonWerkVader = mtxtTelfoonWerkVader.Text;
                o.StrEmailVader = txtEmailVader.Text;
                o.StrStraatVader = txtStraatVader.Text;
                o.StrHuisnrVader = txtHuisNRVader.Text;
                o.StrGemeenteVader = txtGemeenteVader.Text;
                o.StrPostcodeVader = mtxtPostcodeVader.Text;
                o.StrBeroepVader = txtBeroepVader.Text;

                string strGezinshoofd;
                if (rdbGezinshoofdMoeder.Checked) { strGezinshoofd = "Moeder"; } else { strGezinshoofd = "Vader"; }
                o.StrGezinshoofd = strGezinshoofd;
                lln.O = o;

                if (this.Text == "Leerling Toevoegen")
                { voegToe(lln); }
                else { updateLLN(lln, updateID); }
            }
        }
        private void pbToonWachtwoord_Click(object sender, EventArgs e)
        {
            if (blnShowPassword) { pbToonWachtwoord.Image = il.Images[0]; blnShowPassword = false; txtWachtwoordNetwerk.UseSystemPasswordChar = true; }
            else { pbToonWachtwoord.Image = il.Images[1]; blnShowPassword = true; txtWachtwoordNetwerk.UseSystemPasswordChar = false; }
        }
        private void txtGeboortedatum_Leave(object sender, EventArgs e)
        {
            try
            {
                string dag = txtGeboortedatum.Text.Substring(0, 2);
                string maand = txtGeboortedatum.Text.Substring(3, 2);
                string jaar = txtGeboortedatum.Text.Substring(8, 2);
                mskRijksregisterNummer.Text = jaar + "." + maand + "." + dag + "-";
            }
            catch (Exception) { }
        }
        private void RdbGezinshoofdMoeder_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbGezinssituatie.SelectedItem.ToString() == "Éenoudergezin")
            {
                if (rdbGezinshoofdMoeder.Checked)
                {
                    label21.Text = "Moeder";
                    pnlVader.Visible = false;
                    pnlMoeder.Visible = true;
                }
                else
                {
                    label23.Text = "Vader";
                    pnlVader.Visible = true;
                    pnlMoeder.Visible = false;
                }
                centerOuderNames();
            }
        }
        private void RdbGezinshoofdVader_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbGezinssituatie.SelectedItem.ToString() == "Éenoudergezin")
            {
                if (rdbGezinshoofdMoeder.Checked)
                {
                    label21.Text = "Moeder";
                    pnlVader.Visible = false;
                    pnlMoeder.Visible = true;
                }
                else
                {
                    label23.Text = "Vader";
                    pnlVader.Visible = true;
                    pnlMoeder.Visible = false;
                }
                centerOuderNames();
            }
        }
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
        public async void start()
        {
            lo = new LoadingCircle();
            lo.Show();
            lo.Focus();
            lo.TopMost = true;
            lo.BringToFront();

            await Task.Run(() => _start());

            lo.Close();
        }
        void _start()
        {
            starting = true;
            this.Invoke(new Action(() =>
            {
                b = new Business();
                getAlleLanden();
                getAlleNationaliteiten();
                pbToonWachtwoord.Image = il.Images[0];
                cmbGeslacht.SelectedItem = cmbGeslacht.Items[0];
                cmbGezinssituatie.SelectedItem = cmbGezinssituatie.Items[0];
                rdbJaar1.Checked = true;
                checkStudieJaar();
                txtWachtwoordNetwerk.Text = "Netwerk" + DateTime.Now.Year;
                txtVoornaam.Focus();
                //checkdebug();
            }));
            starting = false;
        }
        void toevoegen(Leerling l)
        {
            try
            {
                var richting = (string)cmbRichting.Invoke(new Func<string>(() => cmbRichting.Text));
                b.addToDatabase(l, richting, Schoolstatuut);
            }
            catch (Exception)
            { MessageBox.Show("Toevoegen mislukt.", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            this.Invoke(new Action(() => this.Close()));
        }
        async void voegToe(Leerling l)
        {
            LoadingCircle lo = new LoadingCircle();
            lo.Show();
            lo.Focus();

            await Task.Run(() => toevoegen(l));

            lo.Close();
        }
        async void updateLLN(Leerling l, int id)
        {
            LoadingCircle lo = new LoadingCircle();
            lo.Show();
            lo.Focus();

            await Task.Run(() => updaten(l, id));

            lo.Close();
        }
        void updaten(Leerling l, int id)
        {
            try
            {
                b.removeByID(id);
                var richting = (string)cmbRichting.Invoke(new Func<string>(() => cmbRichting.Text));
                b.addToDatabase(l, richting, Schoolstatuut);
            }
            catch (Exception)
            { MessageBox.Show("Updaten mislukt.", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            this.Invoke(new Action(() => this.Close()));
        }
        void setSelectedLand(string nieuwLand)
        { cmbLand.SelectedItem = nieuwLand; }
        void getAlleLanden()
        {
            string strHuidigland = string.Empty;
            if (!starting)
            { cmbLand.Items.Clear(); } else { if (cmbLand.Items.Count > 0) { strHuidigland = cmbLand.Items[0].ToString(); }}
            foreach (string s in b.getAlleLanden())
            { if (strHuidigland != s) { cmbLand.Items.Add(s); } }
        }
        void setSelectedNationaliteit(string nieuweNationaliteit)
        { txtNationaliteit.SelectedItem = nieuweNationaliteit; }
        void getAlleNationaliteiten()
        {
            string strHuidigeNationaliteit = string.Empty;
            if (!starting)
            { txtNationaliteit.Items.Clear(); } else { if (txtNationaliteit.Items.Count > 0) { strHuidigeNationaliteit = txtNationaliteit.Items[0].ToString(); }}
            foreach (string s in b.getAlleNationaliteiten())
            { if (strHuidigeNationaliteit != s) { txtNationaliteit.Items.Add(s); } }
        }
        public void veldenvullen(int pintID)
        {
            b = new Business();
            getAlleLanden();
            getAlleNationaliteiten();
            pbToonWachtwoord.Image = il.Images[0];
            cmbGeslacht.SelectedItem = cmbGeslacht.Items[0];
            cmbGezinssituatie.SelectedItem = cmbGezinssituatie.Items[0];
            rdbJaar1.Checked = true;
            checkStudieJaar();
            txtWachtwoordNetwerk.Text = "Netwerk" + DateTime.Now.Year;
            txtVoornaam.Focus();

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
            if (!cmbLand.Items.Contains(l.StrLand))
            { cmbLand.Items.Add(l.StrLand); }
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
            txtVoornaamMoeder.Text = l.O.StrVoornaamMoeder;
            txtFamilienaamMoeder.Text = l.O.StrNaamMoeder;
            txtEmailMoeder.Text = l.O.StrEmailMoeder;
            mtxtGSMMoeder.Text = l.O.StrGSMMoeder;
            mtxtTelfoonWerkMoeder.Text = l.O.StrTelefoonWerkMoeder;
            txtStraatMoeder.Text = l.O.StrStraatMoeder;
            mtxtPostcodeMoeder.Text = l.O.StrPostcodeMoeder;
            txtHuisNRMoeder.Text = l.O.StrHuisnrMoeder;
            txtGemeenteMoeder.Text = l.O.StrGemeenteMoeder;
            txtBeroepMoeder.Text = l.O.StrBeroepMoeder;

            txtVoornaamVader.Text = l.O.StrVoornaamVader;
            txtFamilienaamVader.Text = l.O.StrNaamVader;
            txtEmailVader.Text = l.O.StrEmailVader;
            mtxtGSMVader.Text = l.O.StrGSMVader;
            mtxtTelfoonWerkVader.Text = l.O.StrTelefoonWerkVader;
            txtStraatVader.Text = l.O.StrStraatVader;
            mtxtPostcodeVader.Text = l.O.StrPostcodeVader;
            txtHuisNRVader.Text = l.O.StrHuisnrVader;
            txtGemeenteVader.Text = l.O.StrGemeenteVader;
            txtBeroepVader.Text = l.O.StrBeroepVader;

            if (l.O.StrGezinshoofd.ToLower().Contains("moeder")) { rdbGezinshoofdMoeder.Checked = true; rdbGezinshoofdVader.Checked = false; } else { rdbGezinshoofdVader.Checked = true; rdbGezinshoofdMoeder.Checked = false; }
            if (l.O.StrGezinshoofd.ToLower().Contains("pleeg")) { rdbGezinshoofdMoeder.Text = "Pleeg moeder"; rdbGezinshoofdVader.Text = "Pleeg vader"; }
            cmbGezinssituatie.SelectedItem = l.O.StrGezinssituatie;

            cmbCorrespondentie.SelectedItem = l.StrCorrespondentie;
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
            if ((System.Diagnostics.Debugger.IsAttached) && (this.Text != "Leerling wijzigen"))
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
                cmbLand.SelectedIndex = 0;

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
        void error(string Titel, string Message)
        {
            lblText.Text = Message;
            lblTitel.Text = Titel;
            notification.Visible = true;
            notification.Location = new Point((tpBevestigen.Width / 2) - (notification.Width / 2), notification.Location.Y);
        }
        bool check()
        {
            if (string.IsNullOrWhiteSpace(txtVoornaam.Text)) { error("Ongeldige voornaam leerling.", ""); return false; }
            if (string.IsNullOrWhiteSpace(txtFamilieNaam.Text)) { error("Ongeldige familienaam leerling.", ""); return false; }
            if (string.IsNullOrWhiteSpace(txtGeboorteplaats.Text)) { error("Ongeldige geboorteplaats leerling.", ""); return false; }
            if (string.IsNullOrWhiteSpace(txtGeboortedatum.Text)) { error("Ongeldige geboortedatum leerling.", "(dd/mm/jjjj)"); return false; }
            try { DateTime.ParseExact(txtGeboortedatum.Text, "dd/MM/yyyy", null); }
            catch (Exception) { error("Ongeldige geboortedatum leerling.", "(dd/mm/jjjj)"); return false;  }
            if (DateTime.ParseExact(txtGeboortedatum.Text, "dd/MM/yyyy", null) > DateTime.Now) { error("Ongeldige geboortedatum leerling.", "Leerling geboren in toekomstige tijd."); return false; }
            if (string.IsNullOrWhiteSpace(mskRijksregisterNummer.Text)) { error("Ongeldig rijksregisternummer leerling.", ""); return false; }
            if (mskRijksregisterNummer.Text.Substring(0,2) != txtGeboortedatum.Text.Substring(8,2)) { error("Ongeldig rijksregisternummer leerling", "Eerste 2 cijfers komen niet overeen met het geboortejaar."); return false; }
            if (mskRijksregisterNummer.Text.Substring(3,2) != txtGeboortedatum.Text.Substring(3,2)) { error("Ongeldig rijksregisternummer leerling", "3e en 4e cijfer komt niet overeen met de geboortemaand."); return false; }
            if (mskRijksregisterNummer.Text.Substring(6,2) != txtGeboortedatum.Text.Substring(0,2)) { error("Ongeldig rijksregisternummer leerling", "5e en 6e cijfer komt niet overeen met de geboortedag."); return false; }
            if (cmbGeslacht.SelectedItem.ToString() == "Vrouw")
            {
                if ((Convert.ToInt16(mskRijksregisterNummer.Text.Substring(9, 3)) % 2) != 0)
                { error("Ongeldig rijksregisternummer leerling", "Check de cijfergroep van 3 cijfers."); return false; }
            } else if (cmbGeslacht.SelectedItem.ToString() == "Man")
            {
                if ((Convert.ToInt16(mskRijksregisterNummer.Text.Substring(9, 3)) % 2) == 0)
                { error("Ongeldig rijksregisternummer leerling", "Check de cijfergroep van 3 cijfers."); return false; }
            }
            string getal = string.Empty;
            if (txtGeboortedatum.Text.Substring(6,1) == "2") { getal = "2"; }
            getal += mskRijksregisterNummer.Text.Substring(0, 2) + mskRijksregisterNummer.Text.Substring(3, 2) + mskRijksregisterNummer.Text.Substring(6, 2) + mskRijksregisterNummer.Text.Substring(9, 3);
            int intGetal = 97 - (Convert.ToInt32(getal) % 97);
            int intControleGetal = Convert.ToInt16(mskRijksregisterNummer.Text.Substring(13, 2));
            if (intControleGetal != intGetal)
            { error("Ongeldig rijksregisternummer leerling", "Controlenummer klopt niet."); return false; }
            //if (string.IsNullOrWhiteSpace(mskGsmNummer.Text)) { error("Ongeldig GSM nummer leerling.", ""); return false; ; }
            if (string.IsNullOrWhiteSpace(txtEmail.Text)) { error("Ongeldig mailadres leerling.", ""); return false; ; }
            if (!txtEmail.Text.Contains('@')) { error("Ongeldig mailadres leerling.", "Geen @ gevonden."); return false; }
            if (!txtEmail.Text.Contains('.')) { error("Ongeldig mailadres leerling.", "Geen . gevonden."); return false; }
            if (txtEmail.Text.Length < 5) { error("Ongeldig mailadres leerling.", "Email niet lang genoeg."); return false; }
            if (string.IsNullOrWhiteSpace(txtStraat.Text)) { error("Ongeldige straatnaam leerling.", ""); return false; }
            if (string.IsNullOrWhiteSpace(txtHuisnr.Text)) { error("Ongeldig huisnummer leerling.", ""); return false; }
            //bool isNumeric = int.TryParse(txtHuisnr.Text, out int n);
            //if (!isNumeric) { error("Ongeldig huisnummer leerling.", "Geef een getal in."); return false; }
            if (string.IsNullOrWhiteSpace(txtGemeente.Text)) { error("Ongeldige gemeente leerling.", ""); return false; }
            if (string.IsNullOrWhiteSpace(mskPostcode.Text)) { error("Ongeldige postcode leerling.", ""); return false; }

            //ouders
            if ((cmbGezinssituatie.SelectedItem.ToString() == "Éenoudergezin") || (cmbGezinssituatie.SelectedItem.ToString() == "Vader overleden") || (cmbGezinssituatie.SelectedItem.ToString() == "Moeder overleden"))
            {
                if (rdbGezinshoofdMoeder.Checked)
                {
                    if (string.IsNullOrWhiteSpace(txtVoornaamMoeder.Text)) { error("Ongeldige voornaam moeder.", ""); return false; }
                    if (string.IsNullOrWhiteSpace(txtFamilienaamMoeder.Text)) { error("Ongeldige familienaam moeder.", ""); return false; }
                    if (string.IsNullOrWhiteSpace(mtxtGSMMoeder.Text)) { error("Ongeldig GSM nummer moeder.", ""); return false; }
                    if (string.IsNullOrWhiteSpace(txtEmailMoeder.Text)) { error("Ongeldig mailadres moeder.", ""); return false; }
                    if (!txtEmailMoeder.Text.Contains('@')) { error("Ongeldig mailadres moeder.", "Geen @ gevonden."); return false; }
                    if (!txtEmailMoeder.Text.Contains('.')) { error("Ongeldig mailadres moeder.", "Geen . gevonden."); return false; }
                    if (txtEmailMoeder.Text.Length < 5) { error("Ongeldig mailadres moeder.", "Email niet lang genoeg."); return false; }
                    if (string.IsNullOrWhiteSpace(txtStraatMoeder.Text)) { error("Ongeldige straatnaam moeder.", ""); return false; }
                    if (string.IsNullOrWhiteSpace(txtHuisNRMoeder.Text)) { error("Ongeldig huisnummer moeder.", ""); return false; }
                    if (string.IsNullOrWhiteSpace(mtxtPostcodeMoeder.Text)) { error("Ongeldige postcode moeder.", ""); return false; }
                    //if (double.TryParse(mtxtPostcodeMoeder.Text, out double nr)) { error("Ongeldige postcode moeder.", "Gebruik alleen cijfers."); return false; }
                    if (string.IsNullOrWhiteSpace(txtGemeenteMoeder.Text)) { error("Ongeldige gemeente moeder.", ""); return false; }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(txtVoornaamVader.Text)) { error("Ongeldige voornaam vader.", ""); return false; }
                    if (string.IsNullOrWhiteSpace(txtFamilienaamVader.Text)) { error("Ongeldige familienaam vader.", ""); return false; }
                    if (string.IsNullOrWhiteSpace(mtxtGSMVader.Text)) { error("Ongeldig GSM nummer vader.", ""); return false; }
                    if (string.IsNullOrWhiteSpace(txtEmailVader.Text)) { error("Ongeldig mailadres vader.", ""); return false; }
                    if (!txtEmailVader.Text.Contains('@')) { error("Ongeldig mailadres vader.", "Geen @ gevonden."); return false; }
                    if (!txtEmailVader.Text.Contains('.')) { error("Ongeldig mailadres vader.", "Geen . gevonden."); return false; }
                    if (txtEmailVader.Text.Length < 5) { error("Ongeldig mailadres vader.", "Email niet lang genoeg."); return false; }
                    if (string.IsNullOrWhiteSpace(txtStraatVader.Text)) { error("Ongeldige straatnaam vader.", ""); return false; }
                    if (string.IsNullOrWhiteSpace(txtHuisNRVader.Text)) { error("Ongeldig huisnummer vader.", ""); return false; }
                    if (string.IsNullOrWhiteSpace(mtxtPostcodeVader.Text)) { error("Ongeldige postcode vader.", ""); return false; }
                    //if (double.TryParse(mtxtPostcodeVader.Text, out double nr)) { error("Ongeldige postcode vader.", "Gebruik alleen cijfers."); return false; }
                    if (string.IsNullOrWhiteSpace(txtGemeenteVader.Text)) { error("Ongeldige gemeente vader.", ""); return false; }
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtVoornaamMoeder.Text)) { error("Ongeldige voornaam moeder.", ""); return false; }
                if (string.IsNullOrWhiteSpace(txtFamilienaamMoeder.Text)) { error("Ongeldige familienaam moeder.", ""); return false; }
                if (string.IsNullOrWhiteSpace(mtxtGSMMoeder.Text)) { error("Ongeldig GSM nummer moeder.", ""); return false; }
                if (string.IsNullOrWhiteSpace(txtEmailMoeder.Text)) { error("Ongeldig mailadres moeder.", ""); return false; }
                if (!txtEmailMoeder.Text.Contains('@')) { error("Ongeldig mailadres moeder.", "Geen @ gevonden."); return false; }
                if (!txtEmailMoeder.Text.Contains('.')) { error("Ongeldig mailadres moeder.", "Geen . gevonden."); return false; }
                if (txtEmailMoeder.Text.Length < 5) { error("Ongeldig mailadres moeder.", "Email niet lang genoeg."); return false; }
                if (string.IsNullOrWhiteSpace(txtStraatMoeder.Text)) { error("Ongeldige straatnaam moeder.", ""); return false; }
                if (string.IsNullOrWhiteSpace(txtHuisNRMoeder.Text)) { error("Ongeldig huisnummer moeder.", ""); return false; }
                if (string.IsNullOrWhiteSpace(mtxtPostcodeMoeder.Text)) { error("Ongeldige postcode moeder.", ""); return false; }
                //if (double.TryParse(mtxtPostcodeMoeder.Text, out double nr)) { error("Ongeldige postcode moeder.", "Gebruik alleen cijfers."); return false; }
                if (string.IsNullOrWhiteSpace(txtGemeenteMoeder.Text)) { error("Ongeldige gemeente moeder.", ""); return false; }

                if (string.IsNullOrWhiteSpace(txtVoornaamVader.Text)) { error("Ongeldige voornaam vader.", ""); return false; }
                if (string.IsNullOrWhiteSpace(txtFamilienaamVader.Text)) { error("Ongeldige familienaam vader.", ""); return false; }
                if (string.IsNullOrWhiteSpace(mtxtGSMVader.Text)) { error("Ongeldig GSM nummer vader.", ""); return false; }
                if (string.IsNullOrWhiteSpace(txtEmailVader.Text)) { error("Ongeldig mailadres vader.", ""); return false; }
                if (!txtEmailVader.Text.Contains('@')) { error("Ongeldig mailadres vader.", "Geen @ gevonden."); return false; }
                if (!txtEmailVader.Text.Contains('.')) { error("Ongeldig mailadres vader.", "Geen . gevonden."); return false; }
                if (txtEmailVader.Text.Length < 5) { error("Ongeldig mailadres vader.", "Email niet lang genoeg."); return false; }
                if (string.IsNullOrWhiteSpace(txtStraatVader.Text)) { error("Ongeldige straatnaam vader.", ""); return false; }
                if (string.IsNullOrWhiteSpace(txtHuisNRVader.Text)) { error("Ongeldig huisnummer vader.", ""); return false; }
                if (string.IsNullOrWhiteSpace(mtxtPostcodeVader.Text)) { error("Ongeldige postcode vader.", ""); return false; }
                //if (double.TryParse(mtxtPostcodeVader.Text, out double nr2)) { error("Ongeldige postcode vader.", "Gebruik alleen cijfers."); return false; }
                if (string.IsNullOrWhiteSpace(txtGemeenteVader.Text)) { error("Ongeldige gemeente vader.", ""); return false; }
            }

            if (string.IsNullOrWhiteSpace(txtGebruikersnaamNetwerk.Text)) { error("Ongeldige gebruikersnaam.", ""); return false; }
            if (string.IsNullOrWhiteSpace(txtWachtwoordNetwerk.Text)) { error("Ongeldig wachtwoord leerling.", ""); return false; }

            return true;
        }
        private void cmbGezinssituatie_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGezinssituatie.SelectedItem.ToString() != "Pleeggezin")
            {
                rdbGezinshoofdMoeder.Text = "Moeder";
                rdbGezinshoofdVader.Text = "Vader";
            }

            if (cmbGezinssituatie.SelectedItem.ToString() == "Gehuwd")
            {
                rdbGezinshoofdMoeder.Enabled = true;
                rdbGezinshoofdVader.Enabled = true;
                label21.Text = "Moeder";
                label23.Text = "Vader";
                pnlVader.Visible = true;
                pnlMoeder.Visible = true;
            }
            else if (cmbGezinssituatie.SelectedItem.ToString() == "Co-Ouderschap")
            {
                rdbGezinshoofdMoeder.Enabled = true;
                rdbGezinshoofdVader.Enabled = true;
                label21.Text = "Moeder";
                label21.Text = "Vader";
                pnlVader.Visible = true;
                pnlMoeder.Visible = true;
            }
            else if (cmbGezinssituatie.SelectedItem.ToString() == "Pleeggezin")
            {
                label21.Text = "Pleeg moeder";
                label23.Text = "Pleeg vader";

                rdbGezinshoofdMoeder.Text = "Pleeg moeder";
                rdbGezinshoofdVader.Text = "Pleeg vader";

                rdbGezinshoofdMoeder.Enabled = true;
                rdbGezinshoofdVader.Enabled = true;

                pnlVader.Visible = true;
                pnlMoeder.Visible = true;
            }
            else if (cmbGezinssituatie.SelectedItem.ToString() == "Éenoudergezin")
            {
                rdbGezinshoofdMoeder.Enabled = true;
                rdbGezinshoofdVader.Enabled = true;
                if (rdbGezinshoofdMoeder.Checked)
                {
                    label21.Text = "Moeder";
                    pnlVader.Visible = false;
                    pnlMoeder.Visible = true;
                }
                else
                {
                    label23.Text = "Vader";
                    pnlVader.Visible = true;
                    pnlMoeder.Visible = false;
                }
            }
            else if (cmbGezinssituatie.SelectedItem.ToString() == "Vader overleden")
            {
                label21.Text = "Moeder";
                pnlVader.Visible = false;
                pnlMoeder.Visible = true;
                rdbGezinshoofdMoeder.Checked = true;
                rdbGezinshoofdVader.Checked = false;
                rdbGezinshoofdMoeder.Enabled = true;
                rdbGezinshoofdVader.Enabled = false;
            }
            else if (cmbGezinssituatie.SelectedItem.ToString() == "Moeder overleden")
            {
                label21.Text = "Moeder";
                pnlVader.Visible = true;
                pnlMoeder.Visible = false;
                rdbGezinshoofdMoeder.Checked = false;
                rdbGezinshoofdVader.Checked = true;
                rdbGezinshoofdMoeder.Enabled = false;
                rdbGezinshoofdVader.Enabled = true;
            }

            centerOuderNames();
        }
        void centerOuderNames()
        {
            int x = label21.Location.X;
            int y = label21.Location.Y;
            x = (pnlMoeder.Size.Width / 2) - (label21.Width / 2);
            label21.Location = new Point(x, y);

            x = label23.Location.X;
            y = label23.Location.Y;
            x = (pnlVader.Size.Width / 2) - (label23.Width / 2);
            label23.Location = new Point(x, y);
        }
        #endregion
    }
}