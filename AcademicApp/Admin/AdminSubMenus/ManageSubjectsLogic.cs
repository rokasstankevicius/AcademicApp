using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AcademicApp.Admin.AdminSubMenus
{
    public class ManageSubjectsLogic : Connection
    {
        public static DataTable ListOfSubjects()
        {
            string query1 = "select * from `subject`";
            var cmd1 = new MySqlCommand(query1, Conn());
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cmd1.Connection.Close();
            return dt;
        }
        
        public static void CreateSubject(string name)
        {
            if (name != String.Empty)
            {
                bool alreadyExists = false;
                string query1 = "select * from `subject`";
                var cmd1 = new MySqlCommand(query1, Conn());
                var reader = cmd1.ExecuteReader();
                while (reader.Read())
                {
                    if (name == (string)reader["SubjectName"]) alreadyExists = true;
                }
                cmd1.Connection.Close();
                if (alreadyExists == false)
                {
                    string query2 = string.Format("insert into `subject` (`SubjectName`) VALUE ('{0}')", name);
                    var cmd2 = new MySqlCommand(query2, Conn());
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("A subject with this name (" + name + ") has been created");
                    cmd2.Connection.Close();
                }
                else
                {
                    MessageBox.Show("A subject with this name already exists.");
                }
            }
            else
            {
                MessageBox.Show("No input given.");
            }
        }

        public static void DeleteSubject(int iD)
        {
            bool groupHasTeachers = false;
            string query3 = "select * from `teaching subject`";
            var cmd3 = new MySqlCommand(query3, Conn());
            var reader3 = cmd3.ExecuteReader();
            while (reader3.Read())
            {
                if (iD == (int)reader3["SubjectID"])
                {
                    groupHasTeachers = true;
                }
            }
            cmd3.Connection.Close();

            //----------------------------------------------------------------------------------------------------------
            if (groupHasTeachers == false)
            {
                string query4 = string.Format("delete from `subject` where SubjectID ='{0}'", iD);
                var cmd4 = new MySqlCommand(query4, Conn());
                cmd4.ExecuteNonQuery();
                cmd4.Connection.Close();
                MessageBox.Show("Subject deleted."); ;
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Deleting this subject will delete everything connected to it. Are you sure?", "Delete", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    string querryForMassDeletionFind = string.Format("Select * from `teaching subject` where SubjectID ='{0}'", iD);
                    var cmdForMassDeletionFind = new MySqlCommand(querryForMassDeletionFind, Conn());
                    var readerForMassDeletionFind = cmdForMassDeletionFind.ExecuteReader();
                    while (readerForMassDeletionFind.Read())
                    {
                        string querryForMassDeletion1 = string.Format("delete from `subject evaluation` where TeachingSubjectID='{0}'", (int)readerForMassDeletionFind["TeachingSubjectID"]);
                        var cmdForMassDeletion1 = new MySqlCommand(querryForMassDeletion1, Conn());
                        cmdForMassDeletion1.ExecuteNonQuery();
                        cmdForMassDeletion1.Connection.Close();
                    }

                    string querryForMassDeletion3 = string.Format("delete from `teaching subject` where SubjectID ='{0}'", iD);
                    var cmdForMassDeletion3 = new MySqlCommand(querryForMassDeletion3, Conn());
                    cmdForMassDeletion3.ExecuteNonQuery();
                    
                    string querryForMassDeletion4 = string.Format("delete from `subject` where SubjectID ='{0}'", iD);
                    var cmdForMassDeletion4 = new MySqlCommand(querryForMassDeletion4, Conn());
                    cmdForMassDeletion4.ExecuteNonQuery();
                    cmdForMassDeletionFind.Connection.Close();
                    cmdForMassDeletion3.Connection.Close();
                    cmdForMassDeletion4.Connection.Close();
                    MessageBox.Show("Subject deleted.");
                }
            }
        }
    }
}