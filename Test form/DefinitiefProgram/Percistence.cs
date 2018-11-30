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
        string strConnectionString;

        public Percistence()
        {
            strConnectionString = "server = ID191774_6itngip9.db.webhosting.be; user id = ID191774_6itngip9; database = ID191774_6itngip9;password=";
        }

        public List<Leerling> GetLeerlingenFromDB()
        {
            MySqlConnection conn = new MySqlConnection(strConnectionString);
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
                l.IntRijkregisternummer = Convert.ToInt32(dataReader["Rijksregisternummer"]);
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
    }
}
