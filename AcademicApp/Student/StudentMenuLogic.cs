using System;
using System.Data;
using Microsoft.SqlServer.Server;
using MySql.Data.MySqlClient;

namespace AcademicApp.Student
{
    public class StudentMenuLogic : Connection
    {
        public string GiveStudentMenuName(int iD)
        {
            string query = String.Format("select * from student where StudentID = '{0}'", iD);
            var cmd = new MySqlCommand(query, Conn());
            var reader = cmd.ExecuteReader();
            reader.Read();
            string query1 = String.Format("SELECT * FROM `group` WHERE `group`.GroupID = '{0}'", reader["GroupID"]);
            var cmd1 = new MySqlCommand(query1, Conn());
            var reader1 = cmd1.ExecuteReader();
            reader1.Read();
            string fullName = (string)reader["FirstName"] + " " + (string)reader["LastName"] + " " + (string)reader1["GroupName"];
            
            cmd.Connection.Close();
            cmd1.Connection.Close();
            return fullName;
        }
        
        public static DataTable ListOfGrades(int iD)
        {
            string query1 = string.Format("SELECT subject.SubjectName, `subject evaluation`.Grade FROM `teaching subject` INNER JOIN subject ON `teaching subject`.SubjectID = subject.SubjectID INNER JOIN `subject evaluation` ON `subject evaluation`.TeachingSubjectID = `teaching subject`.TeachingSubjectID WHERE `subject evaluation`.StudentID = '{0}'", iD);
            var cmd1 = new MySqlCommand(query1, Conn());
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cmd1.Connection.Close();
            return dt;
        }
    }
}