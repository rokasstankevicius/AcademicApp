using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static AcademicApp.Admin.AdminSubMenus.ManageModulesLogic;
using static AcademicApp.Admin.AdminSubMenus.PopUpCreateModulesLogic;

namespace AcademicApp.Admin.AdminSubMenus
{
    public partial class PopUpCreateModules : Form
    {
        public PopUpCreateModules()
        {
            InitializeComponent();
            RefreshData();
        }

        private void RefreshData()
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            List<string> subjectNames = LoadListOfSubjectNames();
            foreach (string subjectName in subjectNames)
            {
                comboBox1.Items.Add(subjectName);
            }
            List<string> teacherNames = LoadListOfTeacherNames();
            foreach (string teacherName in teacherNames)
            {
                comboBox2.Items.Add(teacherName);
            }
            List<string> groupNames = LoadListOfGroupNames();
            foreach (string groupName in groupNames)
            {
                comboBox3.Items.Add(groupName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int sId = FindSubjectId(comboBox1.Text);
            int tId = FindTeacherId(comboBox2.Text);
            int gId = FindGroupId(comboBox3.Text);
            
            if (comboBox1.Text == null || comboBox1.Text == " " ||
                comboBox2.Text == null || comboBox2.Text == " " ||
                comboBox3.Text == null || comboBox3.Text == " ")
            {
                MessageBox.Show("Please fill in all the text boxes and the drop down box.");
            }
            else
            {
                if (sId == 0 || tId == 0 || gId == 0)
                {
                    MessageBox.Show("Error: One or more ID's are zero");
                }
                else
                {
                    CreateModule(sId,tId,gId);
                    this.Close();
                }
            }
        }
    }
}