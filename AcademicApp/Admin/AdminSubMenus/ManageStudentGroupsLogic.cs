using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AcademicApp.Admin.AdminSubMenus
{
    public class ManageStudentGroupsLogic : Connection
    {
        public static DataTable LoadListOfGroups()
        {
            string query1 = "select * from `group`";
            var cmd1 = new MySqlCommand(query1, Conn());
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cmd1.Connection.Close();
            return dt;
        }

        public static void CreateStudentGroup(string name)
        {
            if (name != String.Empty)
            {
                bool alreadyExists = false;
                string query1 = "select * from `group`";
                var cmd1 = new MySqlCommand(query1, Conn());
                var reader = cmd1.ExecuteReader();
                while (reader.Read())
                {
                    if (name == (string)reader["GroupName"]) alreadyExists = true;
                }
                cmd1.Connection.Close();
                if (alreadyExists == false)
                {
                    string query2 = string.Format("insert into `group` (`GroupName`) VALUE ('{0}')", name);
                    var cmd2 = new MySqlCommand(query2, Conn());
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("A group with this name (" + name + ") has been created");
                    cmd2.Connection.Close();
                }
                else
                {
                    MessageBox.Show("A group with this name already exists.");
                }
            }
            else
            {
                MessageBox.Show("No input given.");
            }
        }

        public static void DeleteStudentGroup(int iD)
        {
            bool groupHasStudents = false;
            string query3 = "select * from `student`";
            var cmd3 = new MySqlCommand(query3, Conn());
            var reader3 = cmd3.ExecuteReader();
            while (reader3.Read())
            {
                if (iD == (int)reader3["GroupID"])
                {
                    groupHasStudents = true;
                }
            }

            cmd3.Connection.Close();
            //----------------------------------------------------------------------------------------------------------
            if (groupHasStudents == false)
            {
                string query4 = string.Format("delete from `group` where GroupID ='{0}'",
                        iD);
                    var cmd4 = new MySqlCommand(query4, Conn());
                    cmd4.ExecuteNonQuery();
                    cmd4.Connection.Close();
                    MessageBox.Show("Group deleted.");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Deleting this student group will delete everything connected to it. Are you sure?", "Delete", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    string querryForMassDeletionFind =
                        string.Format("Select * from `student` where GroupID ='{0}'", iD);
                    var cmdForMassDeletionFind = new MySqlCommand(querryForMassDeletionFind, Conn());
                    var readerForMassDeletionFind = cmdForMassDeletionFind.ExecuteReader();
                    while (readerForMassDeletionFind.Read())
                    {
                        string querryForMassDeletion1 =
                            string.Format("delete from `subject evaluation` where StudentID='{0}'",
                                (int)readerForMassDeletionFind["StudentID"]);
                        var cmdForMassDeletion1 = new MySqlCommand(querryForMassDeletion1, Conn());
                        cmdForMassDeletion1.ExecuteNonQuery();
                    }

                    cmdForMassDeletionFind.Connection.Close();

                    string queryStudents1 = "select * from `student`";
                    string queryStudents2 = "SELECT COUNT(*) FROM `student`";
                    var cmdStudents1 = new MySqlCommand(queryStudents1, Conn());
                    var cmdStudents2 = new MySqlCommand(queryStudents2, Conn());
                    var readerStudents1 = cmdStudents1.ExecuteReader();
                    var readerStudents2 = cmdStudents2.ExecuteScalar();


                    int[] listStudents = new int[Convert.ToInt32(readerStudents2)];

                    for (int i = 0; readerStudents1.Read(); i++)
                    {
                        if (iD == (int)readerStudents1["GroupID"])
                        {
                            listStudents[i] = (int)readerStudents1["StudentID"];
                        }
                    }

                    cmdStudents1.Connection.Close();

                    string querryForMassDeletion2 = string.Format("delete from `student` where GroupID ='{0}'", iD);
                    var cmdForMassDeletion2 = new MySqlCommand(querryForMassDeletion2, Conn());
                    cmdForMassDeletion2.ExecuteNonQuery();
                    cmdForMassDeletion2.Connection.Close();
                    for (int i = 1; i <= Convert.ToInt32(readerStudents2); i++)
                    {
                        string querryForMassDeletionUser = string.Format("delete from `login` where LoginID ='{0}'",
                            listStudents[i - 1]);
                        var cmdForMassDeletionUser = new MySqlCommand(querryForMassDeletionUser, Conn());
                        cmdForMassDeletionUser.ExecuteNonQuery();
                        cmdForMassDeletionUser.Connection.Close();
                    }

                    cmdStudents2.Connection.Close();


                    string querryForMassDeletion3 =
                        string.Format("delete from `teaching subject` where GroupID ='{0}'", iD);
                    var cmdForMassDeletion3 = new MySqlCommand(querryForMassDeletion3, Conn());
                    cmdForMassDeletion3.ExecuteNonQuery();
                    cmdForMassDeletion3.Connection.Close();
                    string querryForMassDeletion4 = string.Format("delete from `group` where GroupID ='{0}'", iD);
                    var cmdForMassDeletion4 = new MySqlCommand(querryForMassDeletion4, Conn());
                    cmdForMassDeletion4.ExecuteNonQuery();
                    cmdForMassDeletion4.Connection.Close();

                    MessageBox.Show("Group deleted.");
                }
            }
        }
    }
}