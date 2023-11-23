using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS
{
    internal class Database
    {
        protected static string server = "localhost";
        protected static string uid = "root";
        protected static string password = "root";
        protected static string database = "AMS_DB";
        protected static string connectionString = "server=" + server + ";uid=" + uid + ";pwd=" + password + ";database=" + database;
        public MySqlConnection connection = new MySqlConnection(connectionString);
    }
}
