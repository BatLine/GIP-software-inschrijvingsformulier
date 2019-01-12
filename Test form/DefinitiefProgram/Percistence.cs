using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DefinitiefProgram
{
    class Percistence
    {
        MySqlConnection conn = new MySqlConnection("server = ID191774_6itngip9.db.webhosting.be; user id = ID191774_6itngip9; database = ID191774_6itngip9;password=ILiWO2dm");
        public Percistence()
        { }
        
        public List<Leerling> GetLeerlingenFromDB()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM ID191774_6itngip9.leerling;", conn);
            conn.Open();
            
            List<Leerling> leerlingen = new List<Leerling>();

            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Leerling l = new Leerling();
                l.StrNaam = dataReader["Naam"].ToString();
                l.StrVoornaam = dataReader["Voornaam"].ToString();
                l.StrBijkNaam = dataReader["Bijk Voornaam"].ToString();
                l.StrGeslacht = dataReader["Geslacht"].ToString();
                l.StrGeboorteplaats = dataReader["Geboorteplaats"].ToString();
                l.StrGeboortedatum = dataReader["Geboortedatum"].ToString();
                l.StrRijkregisternummer = dataReader["Rijksregisternummer"].ToString();
                l.StrGSM_Nummer = dataReader["GSM-nummer"].ToString();
                l.StrE_Mail = dataReader["E-mail"].ToString();
                l.StrStraat = dataReader["Straat"].ToString();
                l.StrHuisnummer = dataReader["Huisnummer"].ToString();
                l.StrBus = dataReader["Bus"].ToString();
                l.StrGemeente = dataReader["Gemeente"].ToString();
                l.StrPostcode = dataReader["Postcode"].ToString();
                l.StrLand = dataReader["Land"].ToString();
                l.IntStudieKeuzeID = Convert.ToInt32(dataReader["StudiekeuzeID"]);
                l.IntMiddelbaar = Convert.ToInt32(dataReader["Middelbaar"]);
                l.IntSchoolstatuutID = Convert.ToInt32(dataReader["SchoolstatuutID"]);

            }
            conn.Close();
            return leerlingen;
        }
        public int getKlasID(string pstrKlasnaam)
        { conn.Open(); int intKlasID = Convert.ToInt16(new MySqlCommand("select klasID from klassen where naamKlas=" + pstrKlasnaam, conn).ExecuteScalar()); conn.Close(); return intKlasID; }

        public List<string> getAlleKlassen()
        {
            conn.Open();
            List<string> klassen = new List<string>();
            MySqlCommand cmd = new MySqlCommand("select * from klassen", conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            { klassen.Add(dr["naamKlas"].ToString()); }
            conn.Close();
            return klassen;
        }

        public void addToDB(Leerling lln)
        {
            string LLNID, MoederID, VaderID;
            conn.Open();
            MySqlCommand cmdLLN = new MySqlCommand("INSERT INTO leerling (Naam, Voornaam, BijkVoornaam, Geslacht, Geboorteplaats, Geboortedatum, Rijksregisternummer, Nationaliteit, GSMnummer, Email, Straat, Huisnummer, Bus, Gemeente, Postcode, Land, StudiekeuzeID, Middelbaar, SchoolstatuutID, KlasID, KlasNR, GebruikersnaamNetwerk, WachtwoordNetwerk) VALUES (" +
                "'" + lln.StrNaam + "','" +
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
                lln.StrKlas + "','" +
                lln.IntKlasNR + "','" +
                lln.StrGebruikersnaamNetwerk + "','" +
                lln.StrWachtwoordNetwerk +"')"
                , conn);
            cmdLLN.ExecuteNonQuery();
            LLNID = new MySqlCommand("select last_insert_id()", conn).ExecuteScalar().ToString();
            MySqlCommand cmdMoeder = new MySqlCommand("INSERT INTO ouder (Naam, Mailadres, GSM, Tel, Straat, Postcode, HuisNR, Gemeente, Gezinshoofd, GezinsSituatie, RelatieID) VALUES (" + //'naam', 'mail', 'gsm', 'tel', 'straat', 'postcode', 'huisnr', 'gemeente', 'gezinshoofdjafnee', 'gezinssituatie', 'relatieid'" +
                "'" + lln.O.StrNaamMoeder + "','" +
                lln.O.StrEmailMoeder + "','" +
                lln.O.StrGSMMoeder + "','" +
                lln.O.StrTelefoonWerkMoeder + "','" +
                lln.O.StrStraatMoeder + "','" +
                lln.O.StrPostcodeMoeder + "','" +
                lln.O.StrHuisnrMoeder + "','" +
                lln.O.StrGemeenteMoeder + "','" +
                lln.O.StrGezinshoofdMoeder + "','" +
                lln.O.StrGezinssituatie + "'," +
                2 + ")"
                , conn);
            cmdMoeder.ExecuteNonQuery();
            MoederID = new MySqlCommand("select last_insert_id()", conn).ExecuteScalar().ToString();
            MySqlCommand cmdVader = new MySqlCommand("INSERT INTO ouder (Naam, Mailadres, GSM, Tel, Straat, Postcode, HuisNR, Gemeente, Gezinshoofd, GezinsSituatie, RelatieID) VALUES (" + //'naam', 'mail', 'gsm', 'tel', 'straat', 'postcode', 'huisnr', 'gemeente', 'gezinshoofdjafnee', 'gezinssituatie', 'relatieid'" +
                "'" + lln.O.StrNaamMoeder + "','" +
                lln.O.StrEmailVader + "','" +
                lln.O.StrGSMVader + "','" +
                lln.O.StrTelefoonWerkVader + "','" +
                lln.O.StrStraatVader + "','" +
                lln.O.StrPostcodeVader + "','" +
                lln.O.StrHuisnrVader + "','" +
                lln.O.StrGemeenteVader + "','" +
                lln.O.StrGezinshoofdVader + "','" +
                lln.O.StrGezinssituatie + "'," +
                1 + ")"
                , conn);
            cmdVader.ExecuteNonQuery();
            VaderID = new MySqlCommand("select last_insert_id()", conn).ExecuteScalar().ToString();
            new MySqlCommand("UPDATE leerling SET IDmoeder = '" + MoederID + "', IDvader = '" + VaderID + "' WHERE (idLeerling = '" + LLNID + "')", conn).ExecuteNonQuery();
            conn.Close();
        }
    }
}
