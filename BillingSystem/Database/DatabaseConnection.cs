using BillingSystem.Database;
using MySql.Data.MySqlClient;
using System;

namespace BillingSystem.Database
{
    public class DatabaseConnection
    {
        private const string SERVER = "localhost";
        private const string DATABASE = "BillingDB";
        private const string UID = "root";
        private const string PASSWORD = "Dhus_tine#123"; //MySQL password 

        private static string ConnectionString =>
            $"server={SERVER};database={DATABASE};uid={UID};pwd={PASSWORD};";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public static bool TestConnection()
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

