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
        
        public void addToDB(Leerling lln)
        {
            conn.Open();
            MySqlCommand cmdLLN = new MySqlCommand("INSERT INTO leerling (Naam, Voornaam, BijkVoornaam, Geslacht, Geboorteplaats, Geboortedatum, Rijksregisternummer, Nationaliteit, GSMnummer, Email, Straat, Huisnummer, Bus, Gemeente, Postcode, Land, StudiekeuzeID, Middelbaar, SchoolstatuutID) VALUES (" +
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
                lln.IntSchoolstatuutID +"')"
                , conn);
            MySqlCommand cmdMoeder = new MySqlCommand("INSERT INTO leerling (VNaam, Naam, Mailadres, GSM, Straat, Postcode, Tel, Gemeente, RelatieID) VALUES (" +
                //"'" + lln.O.StrVNaamMoeder + "','" +
                lln.O.StrNaamMoeder + "','" +
                lln.O.StrEmailMoeder + "','" +
                lln.O.StrGSMMoeder + "','" +
                //lln.O. + "','" + //straat
                lln.StrGeboorteplaats + "','" + //postcode
                lln.O.StrTelefoonWerkMoeder + "','" +
                //lln.O. + "','" + //gemeebte
                2 + "')" //relateID
                , conn);
            cmdLLN.ExecuteNonQuery();
            conn.Close();
        }
    }
}
