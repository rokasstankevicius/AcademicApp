using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using static AcademicApp.Teacher.StudentsGradeManageMenuLogic;
using static AcademicApp.Teacher.TeacherMenuLogic;

namespace AcademicApp.Teacher
{
    public partial class StudentsGradeManageMenu : Form
    {
        private int modulesId;
        private int groupId;

        public StudentsGradeManageMenu(int iD, int gId)
        {
            modulesId = iD;
            groupId = gId;
            InitializeComponent();
            RefreshData();
        }

        private void RefreshData()
        {
            dataGridView1.DataSource = LoadListOfStudentsAndTheirGrades(modulesId);
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_1_Click_1(object sender, EventArgs e)
        {
            new PopUpGradeStudent(modulesId,groupId).ShowDialog();
            RefreshData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                try
                {
                    int newGrade =
                        Convert.ToInt16(Interaction.InputBox("Please type in the new grade. The new grade needs to be a number from 1 to 10.", "Change Grade"));
                    if (newGrade > 0 && newGrade <= 10)
                    {
                        UpdateStudentsGrade(Convert.ToInt16(dataGridView1.CurrentRow.Cells["SubjectEvaluationID"].Value),newGrade);
                        RefreshData();
                    }
                    else
                    {
                        MessageBox.Show("The new grade needs to be from 1 to 10 ");
                    }
                    
                }
                catch (FormatException)
                {
                    MessageBox.Show("The grade needs to be a number from 1 to 10.");
                }
            }
        }
    }
}