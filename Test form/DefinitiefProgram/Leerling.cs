﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefinitiefProgram
{
    class Leerling
    {
        private string strNaam;
        private string strVoornaam;
        private string strBijkNaam;
        private string strGeslacht;
        private string strGeboorteplaats;
        private string strGeboortedatum;
        private string strRijkregisternummer;
        private string strNationaliteit;
        private string strGSM_Nummer;
        private string strE_Mail;
        private string strStraat;
        private string strHuisnummer;
        private string strBus;
        private string strGemeente;
        private string strPostcode;
        private string strLand;
        private string strKlas;
        private string strGebruikersnaamNetwerk;
        private string strWachtwoordNetwerk;
        private int intStudieKeuzeID;
        private int intMiddelbaar;
        private int intSchoolstatuutID;
        private int intKlasNR;
        private Ouders o;

        public string StrNaam { get => strNaam; set => strNaam = value; }
        public string StrVoornaam { get => strVoornaam; set => strVoornaam = value; }
        public string StrBijkNaam { get => strBijkNaam; set => strBijkNaam = value; }
        public string StrGeslacht { get => strGeslacht; set => strGeslacht = value; }
        public string StrGeboorteplaats { get => strGeboorteplaats; set => strGeboorteplaats = value; }
        public string StrGeboortedatum { get => strGeboortedatum; set => strGeboortedatum = value; }
        public string StrRijkregisternummer { get => strRijkregisternummer; set => strRijkregisternummer = value; }
        public string StrNationaliteit { get => strNationaliteit; set => strNationaliteit = value; }
        public string StrGSM_Nummer { get => strGSM_Nummer; set => strGSM_Nummer = value; }
        public string StrE_Mail { get => strE_Mail; set => strE_Mail = value; }
        public string StrStraat { get => strStraat; set => strStraat = value; }
        public string StrHuisnummer { get => strHuisnummer; set => strHuisnummer = value; }
        public string StrBus { get => strBus; set => strBus = value; }
        public string StrGemeente { get => strGemeente; set => strGemeente = value; }
        public string StrPostcode { get => strPostcode; set => strPostcode = value; }
        public string StrLand { get => strLand; set => strLand = value; }
        public int IntStudieKeuzeID { get => intStudieKeuzeID; set => intStudieKeuzeID = value; }
        public int IntMiddelbaar { get => intMiddelbaar; set => intMiddelbaar = value; }
        public int IntSchoolstatuutID { get => intSchoolstatuutID; set => intSchoolstatuutID = value; }
        public string StrKlas { get => strKlas; set => strKlas = value; }
        public string StrGebruikersnaamNetwerk { get => strGebruikersnaamNetwerk; set => strGebruikersnaamNetwerk = value; }
        public string StrWachtwoordNetwerk { get => strWachtwoordNetwerk; set => strWachtwoordNetwerk = value; }
        public int IntKlasNR { get => intKlasNR; set => intKlasNR = value; }
        internal Ouders O { get => o; set => o = value; }
    }
}
