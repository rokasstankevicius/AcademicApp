using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AcademicApp.Teacher
{
    public class TeacherMenuLogic : Connection
    {
        public static string GiveTeacherMenuName(int iD)
        {
            string query = String.Format("select * from teacher where TeacherID = '{0}'", iD);
            var cmd = new MySqlCommand(query, Conn());
            var reader = cmd.ExecuteReader();
            reader.Read();
            string fullName = (string)reader["FirstName"] + " " + (string)reader["LastName"];;
            
            cmd.Connection.Close();
            return fullName;
        }
        
        public static bool CheckIfTeacherHasModules(int iD)
        {
            bool hasModule = false;
            string query = "select * from `teaching subject`";
            var cmd = new MySqlCommand(query, Conn());
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (iD == (int)reader["TeacherID"])
                {
                    hasModule = true;
                }
            }
            cmd.Connection.Close();
            return hasModule;
        }
        
        public static int GiveGroupId(string gName)
        {
            string query = String.Format("SELECT `group`.GroupID FROM `group` WHERE `group`.GroupName = '{0}'", gName);
            var cmd = new MySqlCommand(query, Conn());
            var reader = cmd.ExecuteReader();
            reader.Read();
            int gId = (int)reader["GroupID"];
            
            cmd.Connection.Close();
            return gId;
        }

        public static void GradeStudent(int mId, int sId, int grade)
        {
            bool studentsHasEvaluation = false;
            string queryStudentEvaluation = "select * from `subject evaluation`";
            var cmdStudentEvaluation = new MySqlCommand(queryStudentEvaluation, Conn());
            var readerStudentEvaluation = cmdStudentEvaluation.ExecuteReader();
            while (readerStudentEvaluation.Read())
            {
                if (sId == (int)readerStudentEvaluation["StudentID"] && mId == (int)readerStudentEvaluation["TeachingSubjectID"])
                {
                    studentsHasEvaluation = true;
                }
            }
            cmdStudentEvaluation.Connection.Close();

            if (studentsHasEvaluation == false)
            {
                string queryEvaluation = string.Format("insert into `subject evaluation` (`StudentID`, `TeachingSubjectID`, `Grade`) VALUE ('{0}','{1}','{2}')", sId,mId,grade);
                var cmdEvaluation = new MySqlCommand(queryEvaluation, Conn());
                cmdEvaluation.ExecuteNonQuery();

                MessageBox.Show("Student evaluated.");
                cmdEvaluation.Connection.Close();
            }
            else
            {
                MessageBox.Show("This student already was graded.");
            }
            
        }

        public static void UpdateStudentsGrade(int eId, int gradeInt)
        {
            if (gradeInt <= 10 && gradeInt > 0)
            {
                string queryEvaluation = string.Format("update `subject evaluation` set `Grade` = '{0}' where `SubjectEvaluationID` = '{1}'", gradeInt, eId);
                var cmdEvaluation = new MySqlCommand(queryEvaluation, Conn());
                cmdEvaluation.ExecuteNonQuery();
                MessageBox.Show("Evaluation updated.");
                cmdEvaluation.Connection.Close();
            }
        }
    }
}


