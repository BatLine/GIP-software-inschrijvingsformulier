using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefinitiefProgram
{
    class Connection
    {
        private string strConnectionString = "server = ID191774_6itngip9.db.webhosting.be; user id = ID191774_6itngip9; database = ID191774_6itngip9;password=ILiWO2dm"; 

        public Connection()
        {

        }

        public String getStrConnectionString()
        {
            return strConnectionString;
        }
    }
}
