using System;
using System.Windows.Forms;
using static AcademicApp.Admin.AdminSubMenus.ManageTeachersLogic;

namespace AcademicApp.Admin.AdminSubMenus
{
    public partial class PopUpCreateTeachers : Form
    {
        public PopUpCreateTeachers()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string fName = textBox1.Text;
            string lName = textBox2.Text;

            if (fName == null || fName == " " ||
                lName == null || lName == " " )
            {
                MessageBox.Show("Please fill in all the text boxes and the drop down box.");
            }
            else
            {
                CreateTeacher(fName,lName);
                this.Close();
            }
        }
    }
}