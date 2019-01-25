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
            Leerling l = new Leerling();
            int IDMoeder = 0;
            int IDVader = 0;
            
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("select * from leerling where idLeerling=" + pintID, conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                l.StrNaam = dr["Naam"].ToString();
                l.StrVoornaam = dr["Voornaam"].ToString();
                l.StrBijkNaam = dr["BijkVoornaam"].ToString();
                l.StrGeslacht = dr["Geslacht"].ToString();
                l.StrGeboorteplaats = dr["Geboorteplaats"].ToString();
                l.StrGeboortedatum = dr["Rijksregisternummer"].ToString();
                l.StrNationaliteit = dr["Nationaliteit"].ToString();
                l.StrGSM_Nummer = dr["GSMnummer"].ToString();
                l.StrE_Mail = dr["Email"].ToString();
                l.StrStraat = dr["Huisnummer"].ToString();
                l.StrBus = dr["Bus"].ToString();
                l.StrGemeente = dr["Gemeente"].ToString();
                l.StrPostcode = dr["Postcode"].ToString();
                l.StrLand = dr["Land"].ToString();
                l.IntMiddelbaar = Convert.ToInt32(dr["Middelbaar"]);
                l.IntStudieKeuzeID = Convert.ToInt32(dr["StudiekeuzeID"]);
                l.IntSchoolstatuutID = Convert.ToInt32(dr["SchoolstatuutID"]);
                l.IntKlasID = Convert.ToInt32(dr["KlasID"]);
                l.StrGebruikersnaamNetwerk = dr["GebruikernaamNetwerk"].ToString();
                l.StrWachtwoordNetwerk = dr["WachtwoordNetwerk"].ToString();

                IDMoeder = Convert.ToInt32(dr["IDMoeder"]);
                IDVader = Convert.ToInt32(dr["IDVader"]);
            }
            conn.Close();
            

            Ouders o = new Ouders();
            
            MySqlCommand cmd2 = new MySqlCommand("select * from Ouder where OuderID =" + IDMoeder, conn);
            MySqlDataReader d = cmd.ExecuteReader();
            conn.Open();

            while (d.Read())
            {
                o.StrNaamMoeder = d["Naam"].ToString();
                o.StrEmailMoeder = d["Mailadres"].ToString();
                o.StrGSMMoeder = d["GSM"].ToString();
                o.StrTelefoonWerkMoeder = d["Tel"].ToString();
                o.StrStraatMoeder = d["Straat"].ToString();
                o.StrPostcodeMoeder = d["Postcode"].ToString();
                o.StrHuisnrMoeder = d["HuisNR"].ToString();
                o.StrGemeenteMoeder = d["Gemeente"].ToString();
                o.StrGezinshoofdMoeder = d["Gezinshoofd"].ToString();
                o.StrGezinssituatie = d["GezinsSituatie"].ToString();
                
                //RelatieID ???????????????????????????????????????????
            }

            MySqlCommand cmd3 = new MySqlCommand("select * from Ouder where OuderID =" + IDVader, conn);
            MySqlDataReader dV = cmd.ExecuteReader();
            conn.Open();

            while (d.Read())
            {
                o.StrNaamVader = dV["Naam"].ToString();
                o.StrEmailVader = dV["Mailadres"].ToString();
                o.StrGSMVader = dV["GSM"].ToString();
                o.StrTelefoonWerkVader = dV["Tel"].ToString();
                o.StrStraatVader = dV["Straat"].ToString();
                o.StrPostcodeVader = dV["Postcode"].ToString();
                o.StrHuisnrVader = dV["HuisNR"].ToString();
                o.StrGemeenteVader = dV["Gemeente"].ToString();
                o.StrGezinshoofdVader = dV["Gezinshoofd"].ToString();
                o.StrGezinssituatie = dV["GezinsSituatie"].ToString();

                //RelatieID ???????????????????????????????????????????
            }


            conn.Close();
            return l;
        }

        public List<Leerling> getAlleLeerlingenFromDB()
        {
            List<Leerling> lln = new List<Leerling>();
            List<int> ids = getAlleIDs();

            foreach (int i in ids) //voor elke leerling
            {
                conn.Open();
                Leerling l = new Leerling();
                MySqlCommand cmd = new MySqlCommand("select * from leerling where idLeerling=" + i, conn);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    l.DatabaseID = i;
                    l.StrNaam = dr["Naam"].ToString();
                    l.StrVoornaam = dr["Voornaam"].ToString();
                    l.StrPostcode = dr["Postcode"].ToString();
                }
                lln.Add(l);
                conn.Close();
            }
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






        public List<Leerling> GetLeerlingenFromDB() //herdoen
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
