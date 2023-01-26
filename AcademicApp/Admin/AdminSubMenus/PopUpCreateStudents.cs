using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static AcademicApp.Admin.AdminSubMenus.PopUpCreateStudentsLogic;
using static AcademicApp.Admin.AdminSubMenus.ManageStudentsLogic;

namespace AcademicApp.Admin.AdminSubMenus
{
    public partial class PopUpCreateStudents : Form
    {
        public PopUpCreateStudents()
        {
            InitializeComponent();
            RefreshData();
        }

        private void RefreshData()
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            //comboBox1.DataSource = LoadListOfGroupNames();
            List<string> groupNames = LoadListOfGroupNames();
            foreach (string groupName in groupNames)
            {
                comboBox1.Items.Add(groupName);
            }
            //comboBox1.Items.Add(LoadListOfGroupNames());
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            string fName = textBox1.Text;
            string lName = textBox2.Text;
            string gName = comboBox1.Text;

            if (fName == null || fName == " " ||
                lName == null || lName == " " ||
                gName == null || gName == " ")
            {
                MessageBox.Show("Please fill in all the text boxes and the drop down box.");
            }
            else
            {
                CreateStudent(fName,lName,gName);
                this.Close();
            }
        }
    }
}