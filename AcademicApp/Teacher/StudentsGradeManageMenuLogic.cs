using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AcademicApp.Teacher
{
    public class StudentsGradeManageMenuLogic : Connection
    {
        public static DataTable LoadListOfStudentsAndTheirGrades(int iD)
        {
            string query1 = string.Format("SELECT `subject evaluation`.SubjectEvaluationID, student.FirstName, student.LastName, `subject evaluation`.Grade FROM `subject evaluation` INNER JOIN student ON `subject evaluation`.StudentID = student.StudentID WHERE `subject evaluation`.TeachingSubjectID = '{0}'", iD);
            var cmd1 = new MySqlCommand(query1, Conn());
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cmd1.Connection.Close();
            return dt;
        }
    }
}