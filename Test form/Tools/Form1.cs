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

namespace Tools
{
    public partial class Form1 : Form
    {
        MySqlConnection conn = new MySqlConnection("server = ID191774_6itngip9.db.webhosting.be; user id = ID191774_6itngip9; database = ID191774_6itngip9;password=ILiWO2dm");
        public Form1()
        { InitializeComponent(); }

        private void Form1_Load(object sender, EventArgs e)
        { conn.Open(); }

        private void button1_Click(object sender, EventArgs e)
        { new MySqlCommand("TRUNCATE TABLE leerling", conn).ExecuteNonQuery(); }

        private void button2_Click(object sender, EventArgs e)
        { new MySqlCommand("TRUNCATE TABLE ouder", conn).ExecuteNonQuery(); }
    }
}
