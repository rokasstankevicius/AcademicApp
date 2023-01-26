using System;
using System.Windows.Forms;
using static AcademicApp.Teacher.ManageStudentGradesLogic;
using static AcademicApp.Teacher.TeacherMenuLogic;

namespace AcademicApp.Teacher
{
    public partial class ManageStudentGrades : Form
    {
        private int formId;
        public ManageStudentGrades(int iD)
        {
            formId = iD;
            InitializeComponent();
            RefreshData();
        }
        
        private void RefreshData()
        {
            dataGridView1.DataSource = LoadListOfTeachersModules(formId);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                this.Hide();
                int groupId = GiveGroupId(Convert.ToString(dataGridView1.CurrentRow.Cells["GroupName"].Value));
                new StudentsGradeManageMenu(Convert.ToInt16(dataGridView1.CurrentRow.Cells["TeachingSubjectID"].Value), groupId).ShowDialog();
                //RefreshData();
                this.Show();
            }
        }
    }
}