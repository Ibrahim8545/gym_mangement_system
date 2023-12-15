using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym_management_system.Service
{
    public class SqlService
    {
        private static string server = "pulseupgym-mysql-pulseupgym.a.aivencloud.com";
        private static string database = "pulseup_gym_mangment_system";
        private static string uid = "avnadmin";
        private static string password = "AVNS_ZGEQYkVNAEWmL20ib5_";
        private static int port = 10361;
        private string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};PORT={port};";

        public MySqlDataReader SqlSelect(string query)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand slct = new MySqlCommand(query, connection);
            connection.Open();
            MySqlDataReader reader = slct.ExecuteReader();
            return reader;
        }
        public int sqlExecuteScalar(string query)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand(query, connection);
            object result = command.ExecuteScalar();
            return result != null ? Convert.ToInt32(result) : 0;
        }
        public int SqlNonQuery(string query)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand(query, connection);
            connection.Open();
            return command.ExecuteNonQuery();
        }
    }
}
