using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AcademicApp.Admin.AdminSubMenus
{
    public class ManageStudentsLogic : Connection
    {
        public static DataTable LoadListOfStudents()
        {
            string query1 = "SELECT student.StudentID, student.FirstName, student.LastName, `group`.GroupName FROM student INNER JOIN `group` ON student.GroupID = `group`.GroupID";
            var cmd1 = new MySqlCommand(query1, Conn());
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cmd1.Connection.Close();
            return dt;
        }
        public static void CreateStudent(string fName, string lName, string gName)
        {
            int gId = 0;
            bool studentFound = false;
            if (fName != String.Empty)
            {
                if (lName != String.Empty)
                {
                    //------------------------------------------------------------------------------------------------------
                    string query1 = "select * from student";
                    var cmd1 = new MySqlCommand(query1, Conn());
                    var reader1 = cmd1.ExecuteReader();

                    while (reader1.Read() && studentFound == false)
                    {
                        if (fName == (string)reader1["FirstName"] && lName == (string)reader1["LastName"])
                        {
                            studentFound = true;
                        }
                    }

                    cmd1.Connection.Close();
                    if (studentFound == false)
                    {
                        //------------------------------------------------------------------------------------------------------
                        string query2 = "select * from `group`";
                        var cmd2 = new MySqlCommand(query2, Conn());
                        var reader2 = cmd2.ExecuteReader();
                        while (reader2.Read())
                        {
                            if ((string)reader2["GroupName"] == gName)
                            {
                                gId = (int)reader2["GroupID"];
                            }
                        }
                        cmd2.Connection.Close();
                        //------------------------------------------------------------------------------------------------------
                        if (gId == 0)
                        {
                            MessageBox.Show("Group selection error.");
                        }
                        else
                        {
                            string query4 =
                                string.Format("insert into login(Username, Password) VALUE ('{0}','{1}')", fName,
                                    lName);
                            var cmd4 = new MySqlCommand(query4, Conn());
                            cmd4.ExecuteNonQuery();
                            int newStudentId = (int)cmd4.LastInsertedId;
                            cmd4.Connection.Close();
                            //-------------------------------------------------------------------------------------------
                            string query5 =
                                string.Format(
                                    "insert into student(StudentID, FirstName, LastName, GroupID) VALUE ('{0}','{1}','{2}','{3}')",
                                    newStudentId, fName, lName, gId);
                            var cmd5 = new MySqlCommand(query5, Conn());
                            cmd5.ExecuteNonQuery();
                            cmd5.Connection.Close();
                            //-------------------------------------------------------------------------------------------

                            MessageBox.Show("Student created.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Student with the same name and last name already exists.");
                    }
                }
            }
        }
        public static void DeleteStudent(int iD)
        {
            //----------------------------------------------------------------------------------------------------------
            DialogResult dialogResult = MessageBox.Show("Deleting this student will delete everything connected to them. Are you sure?", "Delete", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                string query3 = string.Format("delete from `student` where StudentID ='{0}'", iD);
                var cmd3 = new MySqlCommand(query3, Conn());
                cmd3.ExecuteNonQuery();
                cmd3.Connection.Close();
                string query4 = string.Format("delete from `login` where LoginID ='{0}'", iD);
                var cmd4 = new MySqlCommand(query4, Conn());
                cmd4.ExecuteNonQuery();
                cmd4.Connection.Close();
                string query5 = string.Format("delete from `subject evaluation` where StudentID ='{0}'",
                    iD);
                var cmd5 = new MySqlCommand(query5, Conn());
                cmd5.ExecuteNonQuery();
                cmd5.Connection.Close();
                MessageBox.Show("Student deleted.");
            }
            //----------------------------------------------------------------------------------------------------------
        }
    }
}