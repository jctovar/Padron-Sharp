using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Padron
{
    class MyDataBase
    {
        public MySqlConnection GetConnection()
        {
            MySqlConnection conn = new MySqlConnection();

            string host = Padron.Properties.Settings.Default.host;
            string database = Padron.Properties.Settings.Default.database;
            string username = Padron.Properties.Settings.Default.username;
            string password = Padron.Properties.Settings.Default.password;

            string myConnectionString = String.Format("server={0};uid={1};pwd={2};database={3};", host, username, password, database);

            try
            {
                 conn.ConnectionString = myConnectionString;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return conn;
        }
    }
}