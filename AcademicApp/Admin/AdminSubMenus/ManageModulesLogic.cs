using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AcademicApp.Admin.AdminSubMenus
{
    public class ManageModulesLogic : Connection
    {
        public static DataTable LoadListOfModules()
        {
            string query1 =
                "SELECT `teaching subject`.TeachingSubjectID, teacher.FirstName, teacher.LastName, subject.SubjectName, group.GroupName FROM `teaching subject` INNER JOIN teacher ON `teaching subject`.TeacherID = teacher.TeacherID INNER JOIN subject ON `teaching subject`.SubjectID = subject.SubjectID INNER JOIN `group` ON `teaching subject`.GroupID = `group`.GroupID";
            var cmd1 = new MySqlCommand(query1, Conn());
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cmd1.Connection.Close();
            return dt;
        }
        public static void CreateModule(int sId, int tId, int gId)
        {
            bool moduleFound = false;
            string query = "select * from `teaching subject`";
            var cmd = new MySqlCommand(query, Conn());
            var reader = cmd.ExecuteReader();

            while (reader.Read() && moduleFound == false)
            {
                if (sId == (int)reader["SubjectID"] &&
                    tId == (int)reader["TeacherID"] &&
                    gId == (int)reader["GroupID"])
                {
                    moduleFound = true;
                }

            }

            cmd.Connection.Close();
            if (moduleFound == false)
            {
                string queryModule = string.Format(
                    "insert into `teaching subject`(SubjectID, TeacherID, GroupID) VALUE ('{0}','{1}','{2}')",
                    sId, tId, gId);
                var cmdModule = new MySqlCommand(queryModule, Conn());
                cmdModule.ExecuteNonQuery();
                MessageBox.Show("Module created.");
            }
            else
            {
                MessageBox.Show("A module with the same parameters already exists.");
            }
        }
        public static void DeleteModule(int iD)
        {
            bool moduleHasEvaluation = false;
            string query3 = "select * from `subject evaluation`";
            var cmd3 = new MySqlCommand(query3, Conn());
            var reader3 = cmd3.ExecuteReader();
            while (reader3.Read())
            {
                if (iD == (int)reader3["TeachingSubjectID"])
                {
                    moduleHasEvaluation = true;
                }
            }

            cmd3.Connection.Close();
            //----------------------------------------------------------------------------------------------------------
            if (moduleHasEvaluation == false)
            {
                string query4 = string.Format("delete from `teaching subject` where TeachingSubjectID ='{0}'",
                    iD);
                var cmd4 = new MySqlCommand(query4, Conn());
                cmd4.ExecuteNonQuery();
                MessageBox.Show("Module deleted.");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Deleting this module will delete everything connected to it. Are you sure?", "Delete", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    string selectionForMassDeletion = Console.ReadLine() ?? string.Empty;
                    if (selectionForMassDeletion == "1")
                    {
                        string querryForMassDeletion3 =
                            string.Format("delete from `subject evaluation` where TeachingSubjectID ='{0}'",
                                iD);
                        var cmdForMassDeletion3 = new MySqlCommand(querryForMassDeletion3, Conn());
                        cmdForMassDeletion3.ExecuteNonQuery();
                        cmdForMassDeletion3.Connection.Close();
                        string querryForMassDeletion4 = string.Format(
                            "delete from `teaching subject` where TeachingSubjectID ='{0}'",
                            iD);
                        var cmdForMassDeletion4 = new MySqlCommand(querryForMassDeletion4, Conn());
                        cmdForMassDeletion4.ExecuteNonQuery();
                        cmdForMassDeletion4.Connection.Close();
                        MessageBox.Show("Module deleted.");
                    }
                }
            }
        }
    }
}


