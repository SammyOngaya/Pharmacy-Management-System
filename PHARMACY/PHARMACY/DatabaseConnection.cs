using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace PHARMACY
{
    class DatabaseConnection
    {

        public DatabaseConnection() {
            connection();
        }
        public static void connection() { 
         string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
        MySqlConnection con = new MySqlConnection(db);
       
        }

    }
}
