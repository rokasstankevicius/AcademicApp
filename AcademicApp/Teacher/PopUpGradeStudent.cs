using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.SqlServer.Server;
using static AcademicApp.Teacher.PopUpGradeStudentLogic;
using static AcademicApp.Teacher.TeacherMenuLogic;

namespace AcademicApp.Teacher
{
    public partial class PopUpGradeStudent : Form
    {
        private int modulesId;
        private int groupId;
        public PopUpGradeStudent(int mId, int gId)
        {
            modulesId = mId;
            groupId = gId;
            InitializeComponent();
            RefreshData();
        }

        private void RefreshData()
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            List<string> fullNames = ListOfStudentNames(groupId);
            foreach (string fullName in fullNames)
            {
                comboBox1.Items.Add(fullName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "" || comboBox1.Text == " " ||
                    textBox1.Text == "" || comboBox1.Text == " ")
                {
                    MessageBox.Show("Plese fill in all the boxes.");
                }
                else
                {
                    if (Convert.ToInt16(textBox1.Text) > 0 && Convert.ToInt16(textBox1.Text) <= 10)
                    {
                        int studentId = GetStudentsId(comboBox1.Text);
                        int studentsGrade = Convert.ToInt16(textBox1.Text);
                        GradeStudent(modulesId, studentId, studentsGrade);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("The grade needs to be between 1 and 10");
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("The Grade needs to be a number wiht no spaces.");
            }
        }
    }
}