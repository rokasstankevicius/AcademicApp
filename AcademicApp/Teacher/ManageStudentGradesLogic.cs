using System.Data;
using MySql.Data.MySqlClient;

namespace AcademicApp.Teacher
{
    public class ManageStudentGradesLogic : Connection
    {
        public static DataTable LoadListOfTeachersModules(int iD)
        {
            string query1 =
                string.Format("SELECT `teaching subject`.TeachingSubjectID, subject.SubjectName, `group`.GroupName FROM `teaching subject` INNER JOIN subject ON `teaching subject`.SubjectID = subject.SubjectID INNER JOIN `group` ON `teaching subject`.GroupID = `group`.GroupID WHERE `teaching subject`.TeacherID = '{0}'",iD);
            var cmd1 = new MySqlCommand(query1, Conn());
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cmd1.Connection.Close();
            return dt;
        }
    }
}

