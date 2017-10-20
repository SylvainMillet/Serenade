using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Serenade
{
    class connectSQL
    {
        public MySqlConnection con = new MySqlConnection();

        public connectSQL()
        {
            //string strConnect = "server='80.15.195.96/22'; user id='pi'; password='Un1S0ft*'; database='serenade_db'";
            string strConnect = "server='localhost'; user id='root'; password=''; database='serenade_db'";
            con = new MySqlConnection(strConnect);
        }
    }
}
