using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AcademicApp.Teacher
{
    public class PopUpGradeStudentLogic : Connection
    {
        public static List<string> ListOfStudentNames(int iD)
        {
            string query1 = string.Format("SELECT student.FirstName, student.LastName FROM student WHERE student.GroupID = '{0}'", iD);
            var cmd1 = new MySqlCommand(query1, Conn());
            var reader1 = cmd1.ExecuteReader();
            //MySqlDataAdapter sda = new MySqlDataAdapter(cmd1);
            List<string> studentNames = new List<string>();
            while (reader1.Read())
            {
                studentNames.Add((string)reader1["FirstName"] + " " + (string)reader1["LastName"]);
            }

            cmd1.Connection.Close();
            return studentNames;
        }

        public static int GetStudentsId(string fullName)
        {
            int iD = 0;
            string query1 = "SELECT student.* FROM student";
            var cmd1 = new MySqlCommand(query1, Conn());
            var reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                if (fullName == (string)reader1["FirstName"] + " " + (string)reader1["LastName"])
                {
                    iD = (int)reader1["StudentID"];
                }
            }

            cmd1.Connection.Close();
            return iD;
        }
    }
}