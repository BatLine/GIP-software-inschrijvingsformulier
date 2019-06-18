using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace addLeerlingen
{
    public partial class frmAddLeerlingen : Form
    {
        List<string> names = new List<string>();
        List<string> postcENGemeente = new List<string>();
        Random r = new Random();
        MySqlConnection conn = new MySqlConnection("server = ID191774_6itngip9.db.webhosting.be; user id = ID191774_6itngip9; database = ID191774_6itngip9;password=ILiWO2dm");

        public frmAddLeerlingen()
        { InitializeComponent(); }

        private void BtnVoegToe_Click(object sender, EventArgs e)
        {
            btnVoegToe.Enabled = false;
            startToevoegen(Convert.ToInt16(txtAantalLLN.Text));
        }
        async void startToevoegen(int aantal)
        {
            await Task.Run(() => voegToe(aantal));
            MessageBox.Show("Iedereen toegevoegd.");
            btnVoegToe.Enabled = true;
        }
        void voegToe(int aantal)
        {
            for (int i = 0; i < aantal; i++)
            {
                Leerling l = makeLLN();
                addToDB(l);
            }
        }

        private void FrmAddLeerlingen_Load(object sender, EventArgs e)
        {
            names.Add("Victor");
            names.Add("Louis");
            names.Add("Cedric");
            names.Add("Bruno");
            names.Add("Pol");
            names.Add("Bart");
            names.Add("Robbe");
            names.Add("Kurt");
            names.Add("Peter");
            names.Add("Pieter");
            names.Add("Geert");

            names.Add("Louise");
            names.Add("Anna");
            names.Add("Charlotte");
            names.Add("Emma");
            names.Add("Maura");
            names.Add("Sofie");
            names.Add("Sarah");
            names.Add("Ruth");
            names.Add("Amelie");
            names.Add("Anneline");
            names.Add("Eline");
            
            postcENGemeente.Add("9000;Gent");
            postcENGemeente.Add("9930;Zomergem");
            postcENGemeente.Add("9810;Eke");
            postcENGemeente.Add("9300;Aalst");
            postcENGemeente.Add("9920;Lovendegem");
            postcENGemeente.Add("9900;Eeklo");
            postcENGemeente.Add("9880;Aalter");
        }

        Leerling makeLLN()
        {
            Leerling l = new Leerling();
            l.StrWachtwoordNetwerk = "Netwerk2019";
            l.StrVoornaam = names[r.Next(names.Count)];
            l.StrNaam = "Achternaam";
            l.StrBijkNaam = "";
            l.StrGeslacht = "Man";
            l.StrGeboortedatum = "28/12/2001";
            string[] randomStadENPostc = postcENGemeente[r.Next(postcENGemeente.Count)].Split(';');
            l.StrGeboorteplaats = randomStadENPostc[1];
            l.StrRijkregisternummer = "01.12.28-351.10";
            l.StrNationaliteit = "Belg";
            l.StrGSM_Nummer = "+32 471 01 31 26";
            l.StrE_Mail = "email@gmail.com";
            l.StrStraat = "straat";
            l.StrHuisnummer = "1";
            l.StrBus = "";
            l.StrGemeente = randomStadENPostc[1];
            l.StrPostcode = randomStadENPostc[0];
            l.StrLand = "België";
            l.IntMiddelbaar = 6;
            l.IntStudieKeuzeID = 8;
            l.IntSchoolstatuutID = 2;
            l.StrRichtingNaam = "IT & Netwerken";
            l.StrGebruikersnaamNetwerk = l.StrVoornaam + "." + l.AanmaakDatum;
            l.StrWachtwoordNetwerk = "Netwerk2019";

            l.O.StrVoornaamMoeder = names[r.Next(names.Count)];
            l.O.StrNaamMoeder = "Achternaam";
            l.O.StrEmailMoeder = "mail@gmail.com";
            l.O.StrGSMMoeder = "+32 471 01 31 26";
            l.O.StrTelefoonWerkMoeder = "+32 491 73 20 24";
            l.O.StrStraatMoeder = "Straat";
            l.O.StrPostcodeMoeder = randomStadENPostc[0];
            l.O.StrHuisnrMoeder = "1";
            l.O.StrGemeenteMoeder = randomStadENPostc[1];
            l.O.StrBeroepMoeder = "Bediende";

            l.O.StrVoornaamVader = names[r.Next(names.Count)];
            l.O.StrNaamVader = "Achternaam";
            l.O.StrEmailVader = "mail@gmail.com";
            l.O.StrGSMVader = "+32 471 01 31 26";
            l.O.StrTelefoonWerkVader = "+32 491 73 20 24";
            l.O.StrStraatVader = "Straat";
            l.O.StrPostcodeVader = randomStadENPostc[0];
            l.O.StrHuisnrVader = "1";
            l.O.StrGemeenteVader = randomStadENPostc[1];
            l.O.StrBeroepVader = "Bediende";

            l.ExtraInfo = "";
            l.O.StrGezinshoofd = "Moeder";
            l.O.StrGezinssituatie = "Gehuwd";
            l.StrCorrespondentie = "Beide";
            l.AanmaakDatum = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;

            return l;
        }

        void addToDB(Leerling lln)
        {
            string LLNID, MoederID, VaderID;
            conn.Open();
            MySqlCommand cmdLLN = new MySqlCommand("INSERT INTO leerling (Naam, ExtraInfo, Correspondentie, Voornaam, BijkVoornaam, Geslacht, Geboorteplaats, Geboortedatum, Rijksregisternummer, Nationaliteit, GSMnummer, Email, Straat, Huisnummer, Bus, Gemeente, Postcode, Land, StudiekeuzeID, Middelbaar, SchoolstatuutID, GebruikersnaamNetwerk, WachtwoordNetwerk, Aanmaakdatum) VALUES (" +
                "'" + lln.StrNaam + "','" +
                lln.ExtraInfo + "','" +
                lln.StrCorrespondentie + "','" +
                lln.StrVoornaam + "','" +
                lln.StrBijkNaam + "','" +
                lln.StrGeslacht + "','" +
                lln.StrGeboorteplaats + "','" +
                lln.StrGeboortedatum + "','" +
                lln.StrRijkregisternummer + "','" +
                lln.StrNationaliteit + "','" +
                lln.StrGSM_Nummer + "','" +
                lln.StrE_Mail + "','" +
                lln.StrStraat + "','" +
                lln.StrHuisnummer + "','" +
                lln.StrBus + "','" +
                lln.StrGemeente + "','" +
                lln.StrPostcode + "','" +
                lln.StrLand + "','" +
                lln.IntStudieKeuzeID + "','" +
                lln.IntMiddelbaar + "','" +
                lln.IntSchoolstatuutID + "','" +
                lln.StrGebruikersnaamNetwerk + "','" +
                lln.StrWachtwoordNetwerk + "','" +
                lln.AanmaakDatum + "')"
                , conn);
            cmdLLN.ExecuteNonQuery();

            LLNID = new MySqlCommand("select last_insert_id()", conn).ExecuteScalar().ToString();
            MySqlCommand cmdMoeder = new MySqlCommand("INSERT INTO ouder (Naam, Beroep, Mailadres, GSM, Tel, Straat, Postcode, HuisNR, Gemeente, Gezinshoofd, GezinsSituatie, Voornaam, RelatieID) VALUES (" +
                "'" + lln.O.StrNaamMoeder + "','" +
                lln.O.StrBeroepMoeder + "','" +
                lln.O.StrEmailMoeder + "','" +
                lln.O.StrGSMMoeder + "','" +
                lln.O.StrTelefoonWerkMoeder + "','" +
                lln.O.StrStraatMoeder + "','" +
                lln.O.StrPostcodeMoeder + "','" +
                lln.O.StrHuisnrMoeder + "','" +
                lln.O.StrGemeenteMoeder + "','" +
                lln.O.StrGezinshoofd + "','" +
                lln.O.StrGezinssituatie + "','" +
                lln.O.StrVoornaamMoeder + "'," +
                2 + ")"
                , conn);
            cmdMoeder.ExecuteNonQuery();
            MoederID = new MySqlCommand("select last_insert_id()", conn).ExecuteScalar().ToString();

            MySqlCommand cmdVader = new MySqlCommand("INSERT INTO ouder (Naam, Beroep, Mailadres, GSM, Tel, Straat, Postcode, HuisNR, Gemeente, Gezinshoofd, GezinsSituatie, Voornaam, RelatieID) VALUES (" +
                "'" + lln.O.StrNaamVader + "','" +
                lln.O.StrBeroepVader + "','" +
                lln.O.StrEmailVader + "','" +
                lln.O.StrGSMVader + "','" +
                lln.O.StrTelefoonWerkVader + "','" +
                lln.O.StrStraatVader + "','" +
                lln.O.StrPostcodeVader + "','" +
                lln.O.StrHuisnrVader + "','" +
                lln.O.StrGemeenteVader + "','" +
                lln.O.StrGezinshoofd + "','" +
                lln.O.StrGezinssituatie + "','" +
                lln.O.StrVoornaamVader + "'," +
                1 + ")"
                , conn);
            cmdVader.ExecuteNonQuery();
            VaderID = new MySqlCommand("select last_insert_id()", conn).ExecuteScalar().ToString();
            new MySqlCommand("UPDATE leerling SET IDmoeder = '" + MoederID + "', IDvader = '" + VaderID + "' WHERE (idLeerling = '" + LLNID + "')", conn).ExecuteNonQuery();
            conn.Close();
        }
    }
}
