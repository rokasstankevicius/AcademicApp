﻿using MySql.Data.MySqlClient;

namespace AcademicApp
{
    public class Connection
    {
        static string server = "localhost";
        static string database = "academic system";
        static string username = "Academic system";
        static string password = "";
        static string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" +
                                  "UID=" + username + ";" + "PASSWORD=" + password + ";";
        protected static MySqlConnection Conn()
        {
            var conn = new MySqlConnection(constring);
            conn.Open();
            return conn;
        }
        protected void ConnClose()
        {
            var conn = new MySqlConnection(constring);
            conn.Close();
        }
    }
}