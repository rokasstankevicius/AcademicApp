using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AcademicApp.Admin.AdminSubMenus
{
    public class PopUpCreateModulesLogic : Connection
    {
        public static List<string> LoadListOfSubjectNames()
        {
            string query1 = "SELECT * FROM `subject`";
            var cmd1 = new MySqlCommand(query1, Conn());
            var reader1 = cmd1.ExecuteReader();
            //MySqlDataAdapter sda = new MySqlDataAdapter(cmd1);
            List<string> subjectNames = new List<string>();
            while (reader1.Read())
            {
                subjectNames.Add((string)reader1["SubjectName"]);
            }

            cmd1.Connection.Close();
            return subjectNames;
        }
        public static List<string> LoadListOfTeacherNames()
        {
            string query1 = "SELECT * FROM `teacher`";
            var cmd1 = new MySqlCommand(query1, Conn());
            var reader1 = cmd1.ExecuteReader();
            //MySqlDataAdapter sda = new MySqlDataAdapter(cmd1);
            List<string> teacherNames = new List<string>();
            while (reader1.Read())
            {
                teacherNames.Add((string)reader1["FirstName"] + " " + (string)reader1["LastName"]);
            }

            cmd1.Connection.Close();
            return teacherNames;
        }
        public static List<string> LoadListOfGroupNames()
        {
            string query1 = "SELECT * FROM `group`";
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
        public static int FindSubjectId(string sName)
        {
            int iD = 0;
            string query1 = "SELECT * FROM `subject`";
            var cmd1 = new MySqlCommand(query1, Conn());
            var reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                if (sName == (string)reader1["SubjectName"])
                {
                    iD = (int)reader1["SubjectID"];
                }
            }

            cmd1.Connection.Close();
            return iD;
        }
        public static int FindTeacherId(string tName)
        {
            int iD = 0;
            string query1 = "SELECT * FROM `teacher`";
            var cmd1 = new MySqlCommand(query1, Conn());
            var reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                if (tName == (string)reader1["FirstName"] + " " + (string)reader1["LastName"])
                {
                    iD = (int)reader1["TeacherID"];
                }
            }

            cmd1.Connection.Close();
            return iD;
        }
        public static int FindGroupId(string gName)
        {
            int iD = 0;
            string query1 = "SELECT * FROM `group`";
            var cmd1 = new MySqlCommand(query1, Conn());
            var reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                if (gName == (string)reader1["GroupName"])
                {
                    iD = (int)reader1["GroupID"];
                }
            }

            cmd1.Connection.Close();
            return iD;
        }
    }
}