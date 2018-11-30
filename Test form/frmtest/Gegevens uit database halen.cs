using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace frmtest
{
    public partial class Gegevens_uit_database_halen : Form
    {
        public Gegevens_uit_database_halen()
        {
            InitializeComponent();
        }

        private void Gegevens_uit_database_halen_Load(object sender, EventArgs e)
        {
            strConnectionstring = "user id=ID191774_6itngip9;server=ID191774_6itngip9.db.webhosting.be;database=ID191774_6itngip9;password=ILiWO2dm";
            vernieuw();
        }

        private void btnToevoegen_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(strConnectionstring);
            MySqlCommand cmd = new MySqlCommand("INSERT INTO `ID191774_6itngip9`.`leerling` (`Naam`, `Voornaam`, `Bijk Voornaam`, `Geslacht`, `Geboorteplaats`, `Geboortedatum`, `Rijksregisternummer`, `Nationaliteit`, `GSM-nummer`, `E-mail`, `Straat`, `Huisnummer`, `Bus`, `Gemeente`, `Postcode`, `Land`, `StudiekeuzeID`, `Middelbaar`, `SchoolstatuutID`) VALUES ('"+ txtNaam.Text +"', '4', '4', '4', '4', '4', '4', '4', '4', '4', '4', '4', '4', '4', '4', '4', '4', '4', '4');", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            vernieuw();
        }

        string strConnectionstring;

        private void vernieuw()
        {
            lbNamen.Items.Clear();
            MySqlConnection conn = new MySqlConnection(strConnectionstring);
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM ID191774_6itngip9.leerling;", conn);
            conn.Open();
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                lbNamen.Items.Add(dataReader["Naam"]);
            }
            conn.Close();
        }

        private void btnVernieuwen_Click(object sender, EventArgs e)
        {
            vernieuw();
        }
    }
}
