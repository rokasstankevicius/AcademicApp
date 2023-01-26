using System;
using System.Windows.Forms;
using static AcademicApp.Teacher.TeacherMenuLogic;

namespace AcademicApp.Teacher
{
    public partial class TeacherMenu : Form
    {
        private int formId;
        
        public TeacherMenu(int iD)
        {
            formId = iD;
            InitializeComponent();
            string fullName = GiveTeacherMenuName(formId);
            this.label1.Text = "Welcome Teacher: "+fullName;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckIfTeacherHasModules(formId) == true)
            {
                this.Hide();
                new ManageStudentGrades(formId).ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("You have no modules.");
            }
        }
    }
}