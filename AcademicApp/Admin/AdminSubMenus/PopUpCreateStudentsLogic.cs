using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AcademicApp.Admin.AdminSubMenus

{
    public class PopUpCreateStudentsLogic : Connection
    {
        public static List<string> LoadListOfGroupNames()
        {
            string query1 = "SELECT student.StudentID,student.FirstName,student.LastName, `group`.GroupName FROM student INNER JOIN `group` ON student.GroupID = `group`.GroupID";
            var cmd1 = new MySqlCommand(query1, Conn());
            var reader1 = cmd1.ExecuteReader();
            //MySqlDataAdapter sda = new MySqlDataAdapter(cmd1);
            List<string> groupNames = new List<string>();
            while (reader1.Read())
            {
                groupNames.Add((string)reader1["GroupName"]);
            }

            cmd1.Connection.Close();
            return groupNames;
        }
    }
}