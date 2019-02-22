using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefinitiefProgram
{
    class Business
    {
        Persistence p;
        List<Leerling> Leerlingen = new List<Leerling>();

        public Business()
        { p = new Persistence(); }

        public string getAantalLLN(DateTime dteVan, DateTime dteTot)
        {
            string van, tot;
            van = dteVan.ToString("dd mm yyyy");
            tot = dteTot.ToString("dd mm yyyy");
            return p.getAantalLLN(van, tot) + " Leerlingen in deze periode";
        }
        public void addToDatabase(Leerling lln, string pRichting, string pStatuut)
        {
            int intKeuzeID=0, intStatuut=0;
            switch (pStatuut)
            {
                case "Intern":
                    intStatuut = 1; break;
                case "Extern":
                    intStatuut = 2; break;
                case "Half-Intern":
                    intStatuut = 3; break;
            }
            switch (pRichting)
            {
                case "Ondernemen":
                    if (lln.IntMiddelbaar == 1)
                    { intKeuzeID = 1; } else if (lln.IntMiddelbaar == 2) { intKeuzeID = 2; }
                    break;
                case "Ondernemen & IT":
                    if (lln.IntMiddelbaar == 3)
                    { intKeuzeID = 3; }
                    else if (lln.IntMiddelbaar == 4) { intKeuzeID = 4; }
                    break;
                case "Ondernemen & Communicatie":
                    if (lln.IntMiddelbaar == 3)
                    { intKeuzeID = 5; }
                    else if (lln.IntMiddelbaar == 4) { intKeuzeID = 6; }
                    break;
                case "Marketing & Ondernemen":
                    if (lln.IntMiddelbaar == 5)
                    { intKeuzeID = 7; }
                    else if (lln.IntMiddelbaar == 6) { intKeuzeID = 8; }
                    break;
                case "Accountancy & IT":
                    if (lln.IntMiddelbaar == 5)
                    { intKeuzeID = 9; }
                    else if (lln.IntMiddelbaar == 6) { intKeuzeID = 10; }
                    break;
                case "IT & Netwerken":
                    if (lln.IntMiddelbaar == 5)
                    { intKeuzeID = 11; }
                    else if (lln.IntMiddelbaar == 6) { intKeuzeID = 12; }
                    break;
                case "Office management & communicatie":
                    if (lln.IntMiddelbaar == 5)
                    { intKeuzeID = 13; }
                    else if (lln.IntMiddelbaar == 6) { intKeuzeID = 14; }
                    break;
            }
            lln.IntStudieKeuzeID = intKeuzeID;
            lln.IntSchoolstatuutID = intStatuut;
            p.addToDB(lln);
        }

        public List<Leerling> getAlleLeerlingen()
        {
            List<Leerling> l = new List<Leerling>();
            l = p.getAlleLeerlingenFromDB();
            return l;
        }
        public Leerling GetLeerling(int pintID)
        {
            Leerling l = p.getLeerling(pintID);
            return l;
        }
    }
}
