using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AcademicApp.Admin.AdminSubMenus
{
    public class ManageTeachersLogic : Connection
    {
        public static DataTable LoadListOfTeachers()
        {
            string query1 = "select * from `teacher`";
            var cmd1 = new MySqlCommand(query1, Conn());
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cmd1.Connection.Close();
            return dt;
        }

        public static void CreateTeacher(string fName, string lName)
        {
            bool found = false;
            //------------------------------------------------------------------------------------------------------
            string query1 = "select * from teacher";
            var cmd1 = new MySqlCommand(query1, Conn());
            var reader1 = cmd1.ExecuteReader();

            while (reader1.Read() && found == false)
            {
                if (fName == (string)reader1["FirstName"] && lName == (string)reader1["LastName"])
                {
                    found = true;
                }
            }
            cmd1.Connection.Close();
            if (found == false)
            {

                string query4 = string.Format("insert into login(Username, Password) VALUE ('{0}','{1}')", fName, lName);
                var cmd4 = new MySqlCommand(query4, Conn());
                cmd4.ExecuteNonQuery();
                int newStudentId = (int)cmd4.LastInsertedId;
                cmd4.Connection.Close();
                //-------------------------------------------------------------------------------------------
                string query5 = string.Format("insert into teacher(TeacherID, FirstName, LastName) VALUE ('{0}','{1}','{2}')", newStudentId, fName, lName);
                var cmd5 = new MySqlCommand(query5, Conn());
                cmd5.ExecuteNonQuery();
                cmd5.Connection.Close();
                //-------------------------------------------------------------------------------------------
                MessageBox.Show("Teacher created.");
            }
            else
            {
                MessageBox.Show("A teacher with the same first and last name already exists.");
            }
        }

        public static void DeleteTeacher(int iD)
        {
            bool teacherHasModules = false;
            string queryLook = "select * from `teaching subject`";
            var cmdLook = new MySqlCommand(queryLook, Conn());
            var readerLook = cmdLook.ExecuteReader();
            while (readerLook.Read())
            {
                if (iD == (int)readerLook["TeacherID"])
                {
                    teacherHasModules = true;
                }
            }
            cmdLook.Connection.Close();

            if (teacherHasModules == false)
            {
                
                string query3 = string.Format("delete from `teacher` where TeacherID ='{0}'",
                    iD);
                var cmd3 = new MySqlCommand(query3, Conn());
                cmd3.ExecuteNonQuery();
                cmd3.Connection.Close();
                string query4 = string.Format("delete from `login` where LoginID ='{0}'", iD);
                var cmd4 = new MySqlCommand(query4, Conn());
                cmd4.ExecuteNonQuery();
                cmd4.Connection.Close();
                MessageBox.Show("Teacher deleted.");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Deleting this teacher will delete everything connected to them. Are you sure?", "Delete", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    string querryForMassDeletionFind = string.Format("Select * from `teaching subject` where TeacherID ='{0}'",
                        iD);
                    var cmdForMassDeletionFind = new MySqlCommand(querryForMassDeletionFind, Conn());
                    var readerForMassDeletionFind = cmdForMassDeletionFind.ExecuteReader();
                    while (readerForMassDeletionFind.Read())
                    {
                        string querryForMassDeletion1 = string.Format("delete from `subject evaluation` where TeachingSubjectID='{0}'", (int)readerForMassDeletionFind["TeachingSubjectID"]);
                        var cmdForMassDeletion1 = new MySqlCommand(querryForMassDeletion1, Conn());
                        cmdForMassDeletion1.ExecuteNonQuery();
                        cmdForMassDeletion1.Connection.Close();
                    }

                    string querryForMassDeletion3 = string.Format("delete from `teaching subject` where TeacherID ='{0}'", iD);
                    var cmdForMassDeletion3 = new MySqlCommand(querryForMassDeletion3, Conn());
                    cmdForMassDeletion3.ExecuteNonQuery();
                    
                    string querryForMassDeletion4 = string.Format("delete from `teacher` where TeacherID ='{0}'",
                        iD);
                    var cmdForMassDeletion4 = new MySqlCommand(querryForMassDeletion4, Conn());
                    cmdForMassDeletion4.ExecuteNonQuery();
                    
                    string queryForMassDeletion5 = string.Format("delete from `login` where LoginID ='{0}'", iD);
                    var cmdForMassDeletion5 = new MySqlCommand(queryForMassDeletion5, Conn());
                    cmdForMassDeletion5.ExecuteNonQuery();
                    
                    
                    cmdForMassDeletionFind.Connection.Close();
                    cmdForMassDeletion3.Connection.Close();
                    cmdForMassDeletion4.Connection.Close();
                    cmdForMassDeletion5.Connection.Close();
                    MessageBox.Show("Teacher deleted.");
                }
            }
        }
    }
}
