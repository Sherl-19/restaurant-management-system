using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace restaurantSystem
{
    public class DBConnect
    {
        MySqlConnection con = new MySqlConnection(
            "server=localhost;user=root;database=onlinefoodphp;password=;"
        );

        public MySqlConnection GetConnection()
        {
            return con;
        }

        public void OpenConnection()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public void CloseConnection()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
