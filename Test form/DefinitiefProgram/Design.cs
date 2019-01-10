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
        //textbox geboortedatum bij ouders en lln naar masked?
        //gemeente checken met elke gemeente in belgie
        //postcode automatisch laten invullen?
        //cmb land opvullen met alle landen
        //cmbNationaliteit invullen met alle nationaliteiten
        //sommige velden verifieren als ze mogen gebruikt worden
        //comboboxen laten opvullen met dingen
        Business b = new Business();
        int Studiejaar = 0;
        string Schoolstatuut = "Extern";
        public Design()
        { InitializeComponent(); }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Leerling lln = new Leerling();

            //leerling
            //correspondentie, gezinssituatie, gezinshoofd
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
            lln.StrPostcode = mtxtPostcode.Text;
            lln.StrLand = cmbLand.Text;
            lln.IntMiddelbaar = Studiejaar;
            lln.IntKlasNR = Convert.ToInt16(lblKlasNR.Text);
            lln.StrKlas = cmbKlas.SelectedItem.ToString();
            lln.StrGebruikersnaamNetwerk = txtGebruikersnaamNetwerk.Text;
            lln.StrWachtwoordNetwerk = txtWachtwoordNetwerk.Text;

            //Ouders
            Ouders o = new Ouders();
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

            b.addToDatabase(lln, cmbRichting.Text, Schoolstatuut);
        }

        private void Design_Load(object sender, EventArgs e)
        { }

        private void tpLLN_Click(object sender, EventArgs e)
        { }

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
        { btnToonWachtwoord.Text = "Verbergen"; }

        private void rdbGezinshoofdMoeder_CheckedChanged(object sender, EventArgs e)
        { }
    }
}
