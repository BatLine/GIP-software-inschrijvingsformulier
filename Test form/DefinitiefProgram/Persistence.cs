﻿#region usings
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
#endregion

namespace DefinitiefProgram
{
    class Persistence
    {
        #region vars
        MySqlConnection conn = new MySqlConnection(new Connection().getStrConnectionString());
        public Persistence()
        { }
        #endregion

        #region add
        public void addToDB(Leerling lln)
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
        public void addLand(string land)
        {
            conn.Open();

            MySqlCommand cmd = new MySqlCommand("INSERT INTO `landen` (`land`) VALUES ('" + land + "');", conn);
            cmd.ExecuteNonQuery();

            conn.Close();
        }
        public void addNationaliteit(string nationaliteit)
        {
            conn.Open();

            MySqlCommand cmd = new MySqlCommand("INSERT INTO `nationaliteiten` (`nationaliteit`) VALUES ('" + nationaliteit + "');", conn);
            cmd.ExecuteNonQuery();

            conn.Close();
        }
        #endregion

        #region delete
        public void removeByID(int id)
        {
            int IDmoeder = 0;
            int IDvader = 0;
            conn.Open();

            MySqlCommand getOuderIDS = new MySqlCommand("select IDmoeder, IDvader from leerling where idLeerling=" + id, conn);
            MySqlDataReader dr = getOuderIDS.ExecuteReader();
            while (dr.Read())
            {
                IDmoeder = Convert.ToInt16(dr["IDmoeder"]);
                IDvader = Convert.ToInt16(dr["IDvader"]);
            }

            conn.Close();
            conn.Open();
            MySqlCommand deleteMoeder = new MySqlCommand("delete from ouder where (OuderID = " + IDmoeder + ");", conn);
            deleteMoeder.ExecuteNonQuery();

            conn.Close();
            conn.Open();
            MySqlCommand deleteVader = new MySqlCommand("delete from ouder where (OuderID = " + IDvader + ");", conn);
            deleteVader.ExecuteNonQuery();

            conn.Close();
            conn.Open();
            MySqlCommand deleteLeerling = new MySqlCommand("delete from leerling where (idLeerling = " + id + ");", conn);
            deleteLeerling.ExecuteNonQuery();

            conn.Close();
        }
        public void wisAlles()
        {
            conn.Open();

            new MySqlCommand("TRUNCATE TABLE ouder", conn).ExecuteNonQuery();
            new MySqlCommand("TRUNCATE TABLE leerling", conn).ExecuteNonQuery();
            new MySqlCommand("TRUNCATE TABLE landen", conn).ExecuteNonQuery();
            new MySqlCommand("INSERT INTO landen (`idlanden`, `land`) VALUES ('1', 'België');", conn).ExecuteNonQuery();
            new MySqlCommand("TRUNCATE TABLE nationaliteiten", conn).ExecuteNonQuery();
            new MySqlCommand("INSERT INTO nationaliteiten (`idnationaliteiten`, `nationaliteit`) VALUES ('1', 'Belg');", conn).ExecuteNonQuery();

            conn.Close();
        }
        public void wisLeerling(string naam, string achternaam, string postcode)
        {
            conn.Open();

            MySqlCommand getIDLeerling = new MySqlCommand("select idLeerling from leerling where Voornaam='" + naam + "' AND Naam='" + achternaam + "' AND Postcode='" + postcode + "'", conn);
            var idLeerling = getIDLeerling.ExecuteScalar();

            conn.Close();
            if (idLeerling == null) { throw new Exception("Geen leerling gevonden."); }
            removeByID(Convert.ToInt16(idLeerling));
        }
        #endregion

        #region get
        public Tuple<int, List<Leerling>> getAantalLLN(string strVan, string strTot)
        {
            int intAantal = 0;
            List<Leerling> alleLeerlingenInDB = getAlleLeerlingenFromDB();
            List<Leerling> specifiekeLLN = new List<Leerling>();

            DateTime dteVan = DateTime.ParseExact(strVan, "dd MM yyyy", null);
            DateTime dteTot = DateTime.ParseExact(strTot, "dd MM yyyy", null);
            foreach (Leerling l in alleLeerlingenInDB)
            {
                DateTime dte = DateTime.ParseExact(l.AanmaakDatum, "dd/MM/yyyy", null);
                if ((dte >= dteVan) && (dte <= dteTot))
                {
                    intAantal++;
                    specifiekeLLN.Add(l);
                }
            }
            return new Tuple<int, List<Leerling>>(intAantal, specifiekeLLN);
        }
        public Tuple<int, List<Leerling>> getAantalLLNOpNaam(string VNaam, string ANaam)
        {
            int intAantal = 0;
            List<Leerling> alleLeerlingenInDB = getAlleLeerlingenFromDB();
            List<Leerling> specifiekeLLN = new List<Leerling>();

            foreach (Leerling l in alleLeerlingenInDB)
            {
                if ((l.StrVoornaam.ToLower() == VNaam.ToLower()) && (l.StrNaam.ToLower() == ANaam.ToLower()))
                {
                    intAantal++;
                    specifiekeLLN.Add(l);
                }
            }
            return new Tuple<int, List<Leerling>>(intAantal, specifiekeLLN);
        }
        public Leerling getLeerling(int pintID)
        {
            int moederID = 0;
            int vaderID = 0;
            Leerling l = new Leerling();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("select * from leerling where idLeerling=" + pintID, conn);
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
                l.AanmaakDatum = dr["Aanmaakdatum"].ToString();
                l.StrCorrespondentie = dr["Correspondentie"].ToString();
                l.ExtraInfo = dr["ExtraInfo"].ToString();
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
                l.O.StrVoornaamMoeder = dr["Voornaam"].ToString();
                l.O.StrNaamMoeder = dr["Naam"].ToString();
                l.O.StrEmailMoeder = dr["Mailadres"].ToString();
                l.O.StrGSMMoeder = dr["GSM"].ToString();
                l.O.StrTelefoonWerkMoeder = dr["Tel"].ToString();
                l.O.StrStraatMoeder = dr["Straat"].ToString();
                l.O.StrPostcodeMoeder = dr["Postcode"].ToString();
                l.O.StrHuisnrMoeder = dr["HuisNR"].ToString();
                l.O.StrGemeenteMoeder = dr["Gemeente"].ToString();
                l.O.StrBeroepMoeder = dr["Beroep"].ToString();

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
                l.O.StrVoornaamVader = dr["Voornaam"].ToString();
                l.O.StrNaamVader = dr["Naam"].ToString();
                l.O.StrEmailVader = dr["Mailadres"].ToString();
                l.O.StrGSMVader = dr["GSM"].ToString();
                l.O.StrTelefoonWerkVader = dr["Tel"].ToString();
                l.O.StrStraatVader = dr["Straat"].ToString();
                l.O.StrPostcodeVader = dr["Postcode"].ToString();
                l.O.StrHuisnrVader = dr["HuisNR"].ToString();
                l.O.StrGemeenteVader = dr["Gemeente"].ToString();
                l.O.StrBeroepVader = dr["Beroep"].ToString();
            }
            conn.Close();

            return l;
        }
        public Leerling getLeerling(string Voornaam, string Achternaam)
        {
            int moederID = 0;
            int vaderID = 0;
            Leerling l = new Leerling();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("select * from leerling where Naam = '" + Achternaam + "' and Voornaam = '" + Voornaam + "';", conn);
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
                l.AanmaakDatum = dr["Aanmaakdatum"].ToString();
                l.StrCorrespondentie = dr["Correspondentie"].ToString();
                l.ExtraInfo = dr["ExtraInfo"].ToString();
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
                l.O.StrVoornaamMoeder = dr["Voornaam"].ToString();
                l.O.StrNaamMoeder = dr["Naam"].ToString();
                l.O.StrEmailMoeder = dr["Mailadres"].ToString();
                l.O.StrGSMMoeder = dr["GSM"].ToString();
                l.O.StrTelefoonWerkMoeder = dr["Tel"].ToString();
                l.O.StrStraatMoeder = dr["Straat"].ToString();
                l.O.StrPostcodeMoeder = dr["Postcode"].ToString();
                l.O.StrHuisnrMoeder = dr["HuisNR"].ToString();
                l.O.StrGemeenteMoeder = dr["Gemeente"].ToString();
                l.O.StrBeroepMoeder = dr["Beroep"].ToString();

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
                l.O.StrVoornaamVader = dr["Voornaam"].ToString();
                l.O.StrNaamVader = dr["Naam"].ToString();
                l.O.StrEmailVader = dr["Mailadres"].ToString();
                l.O.StrGSMVader = dr["GSM"].ToString();
                l.O.StrTelefoonWerkVader = dr["Tel"].ToString();
                l.O.StrStraatVader = dr["Straat"].ToString();
                l.O.StrPostcodeVader = dr["Postcode"].ToString();
                l.O.StrHuisnrVader = dr["HuisNR"].ToString();
                l.O.StrGemeenteVader = dr["Gemeente"].ToString();
                l.O.StrBeroepVader = dr["Beroep"].ToString();
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
        public List<string> getAlleLanden()
        {
            List<string> alleLanden = new List<string>();

            conn.Open();
            MySqlCommand cmd = new MySqlCommand("select * from landen", conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            { alleLanden.Add(dr["land"].ToString()); }

            conn.Close();
            return alleLanden;
        }
        public List<string> getAlleNationaliteiten()
        {
            List<string> alleNationaliteiten = new List<string>();

            conn.Open();
            MySqlCommand cmd = new MySqlCommand("select * from nationaliteiten", conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            { alleNationaliteiten.Add(dr["nationaliteit"].ToString()); }

            conn.Close();
            return alleNationaliteiten;
        }
        #endregion
    }
}