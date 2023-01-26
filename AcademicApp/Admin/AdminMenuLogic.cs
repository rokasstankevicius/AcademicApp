using System;
using MySql.Data.MySqlClient;

namespace AcademicApp.Admin
{
    public class AdminMenuLogic : Connection
    {
        public string GiveAdminMenuName(int iD)
        {
            string query = String.Format("select * from admin where AdminID = '{0}'", iD);
            var cmd = new MySqlCommand(query, Conn());
            var reader = cmd.ExecuteReader();
            reader.Read();
            string fullName = (string)reader["FirstName"] + " " + (string)reader["LastName"];;
            
            cmd.Connection.Close();
            return fullName;
        }
    }
}