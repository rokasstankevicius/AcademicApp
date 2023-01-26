using System;
using System.Windows.Forms;
using static AcademicApp.Student.StudentMenuLogic;

namespace AcademicApp.Student
{
    public partial class StudentMenu : Form
    {
        private int studentId;
        public StudentMenu(int iD)
        {
            studentId = iD;
            InitializeComponent();
            string fullName = new StudentMenuLogic().GiveStudentMenuName(studentId);
            this.label1.Text = "Welcome Admin: "+fullName;
            RefreshData();
        }
        
        private void RefreshData()
        {
            dataGridView1.DataSource = ListOfGrades(studentId);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}