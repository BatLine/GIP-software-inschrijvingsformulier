using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DefinitiefProgram
{
    class Persistence
    {
        MySqlConnection conn = new MySqlConnection("server = ID191774_6itngip9.db.webhosting.be; user id = ID191774_6itngip9; database = ID191774_6itngip9;password=ILiWO2dm");
        public Persistence()
        { }
        
        public Leerling getLeerling(int pintID)
        {
            int moederID = 0;
            int vaderID = 0;
            Leerling l = new Leerling();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("select * from leerling where idLeerling=" + pintID, conn);
            MySqlCommand cmd4 = new MySqlCommand("select * from leerling where idLeerling=" + pintID, conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                l.DatabaseID = Convert.ToInt16(dr["idLeerling"]);
                l.StrNaam = dr["Naam"].ToString();
                l.StrVoornaam = dr["Voornaam"].ToString();
                l.StrBijkNaam = dr["BijkVoornaam"].ToString();
                l.StrGeslacht = dr["Geslacht"].ToString();
                l.StrGeboortedatum = dr["Geboortedatum"].ToString();
                l.StrGeboorteplaats = dr["Geboorteplaats"].ToString();
                l.StrRijkregisternummer = dr["Rijksregisternummer"].ToString();
                l.StrNationaliteit = dr["Nationaliteit"].ToString();
                l.StrGSM_Nummer = dr["GSMnummer"].ToString();
                l.StrE_Mail = dr["Email"].ToString();
                l.StrStraat = dr["Straat"].ToString();
                l.StrHuisnummer = dr["Huisnummer"].ToString();
                l.StrBus = dr["Bus"].ToString();
                l.StrGemeente = dr["Gemeente"].ToString();
                l.StrPostcode = dr["Postcode"].ToString();
                l.StrLand = dr["Land"].ToString();
                l.IntMiddelbaar = Convert.ToInt16(dr["Middelbaar"]);
                l.IntStudieKeuzeID = Convert.ToInt16(dr["StudiekeuzeID"]);
                l.IntSchoolstatuutID = Convert.ToInt16(dr["SchoolstatuutID"]);
                l.StrGebruikersnaamNetwerk = dr["GebruikersnaamNetwerk"].ToString();
                l.StrWachtwoordNetwerk = dr["WachtwoordNetwerk"].ToString();
                moederID = Convert.ToInt16(dr["IDmoeder"]);
                vaderID = Convert.ToInt16(dr["IDvader"]);
            }
            conn.Close();
            //richtingnaam
            cmd = new MySqlCommand("select Omschrijving,StudiekeuzeID from studiekeuze where StudiekeuzeID=" + l.IntStudieKeuzeID, conn);
            conn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            { l.StrRichtingNaam = dr["Omschrijving"].ToString(); }
            conn.Close();
            //moeder
            cmd = new MySqlCommand("select * from ouder where OuderID=" + moederID, conn);
            conn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                l.O.StrNaamMoeder = dr["Naam"].ToString();
                l.O.StrEmailMoeder = dr["Mailadres"].ToString();
                l.O.StrGSMMoeder = dr["GSM"].ToString();
                l.O.StrTelefoonWerkMoeder = dr["Tel"].ToString();
                l.O.StrStraatMoeder = dr["Straat"].ToString();
                l.O.StrPostcodeMoeder = dr["Postcode"].ToString();
                l.O.StrHuisnrMoeder = dr["HuisNR"].ToString();
                l.O.StrGemeenteMoeder = dr["Gemeente"].ToString();

                //algemeen
                l.O.StrGezinshoofd = dr["Gezinshoofd"].ToString();
                l.O.StrGezinssituatie = dr["GezinsSituatie"].ToString();
            }
            conn.Close();
            //vader
            cmd = new MySqlCommand("select * from ouder where OuderID=" + vaderID, conn);
            conn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                l.O.StrNaamVader = dr["Naam"].ToString();
                l.O.StrEmailVader = dr["Mailadres"].ToString();
                l.O.StrGSMVader = dr["GSM"].ToString();
                l.O.StrTelefoonWerkVader = dr["Tel"].ToString();
                l.O.StrStraatVader = dr["Straat"].ToString();
                l.O.StrPostcodeVader = dr["Postcode"].ToString();
                l.O.StrHuisnrVader = dr["HuisNR"].ToString();
                l.O.StrGemeenteVader = dr["Gemeente"].ToString();
            }
            conn.Close();

            return l;
        }

        public List<Leerling> getAlleLeerlingenFromDB()
        {
            List<Leerling> lln = new List<Leerling>();
            List<int> ids = getAlleIDs();

            foreach (int i in ids)
            { lln.Add(getLeerling(i)); }
            return lln;
        }

        public List<int> getAlleIDs()
        {
            conn.Open();
            List<int> ids = new List<int>();
            MySqlCommand cmd = new MySqlCommand("select idLeerling from leerling", conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            { ids.Add(Convert.ToInt16(dr["idLeerling"])); }
            conn.Close();
            return ids;
        }

        public void addToDB(Leerling lln)
        {
            string LLNID, MoederID, VaderID;
            conn.Open();
            MySqlCommand cmdLLN = new MySqlCommand("INSERT INTO leerling (Naam, Voornaam, BijkVoornaam, Geslacht, Geboorteplaats, Geboortedatum, Rijksregisternummer, Nationaliteit, GSMnummer, Email, Straat, Huisnummer, Bus, Gemeente, Postcode, Land, StudiekeuzeID, Middelbaar, SchoolstatuutID, GebruikersnaamNetwerk, WachtwoordNetwerk) VALUES (" +
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
                lln.O.StrGezinshoofd + "','" +
                lln.O.StrGezinssituatie + "'," +
                2 + ")"
                , conn);
            cmdMoeder.ExecuteNonQuery();
            MoederID = new MySqlCommand("select last_insert_id()", conn).ExecuteScalar().ToString();
            MySqlCommand cmdVader = new MySqlCommand("INSERT INTO ouder (Naam, Mailadres, GSM, Tel, Straat, Postcode, HuisNR, Gemeente, Gezinshoofd, GezinsSituatie, RelatieID) VALUES (" + //'naam', 'mail', 'gsm', 'tel', 'straat', 'postcode', 'huisnr', 'gemeente', 'gezinshoofdjafnee', 'gezinssituatie', 'relatieid'" +
                "'" + lln.O.StrNaamVader + "','" +
                lln.O.StrEmailVader + "','" +
                lln.O.StrGSMVader + "','" +
                lln.O.StrTelefoonWerkVader + "','" +
                lln.O.StrStraatVader + "','" +
                lln.O.StrPostcodeVader + "','" +
                lln.O.StrHuisnrVader + "','" +
                lln.O.StrGemeenteVader + "','" +
                lln.O.StrGezinshoofd + "','" +
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
