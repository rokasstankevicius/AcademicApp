using System;
using System.Windows.Forms;
using AcademicApp.Admin.AdminSubMenus;

namespace AcademicApp.Admin
{
    public partial class AdminMenu : Form
    {
        public AdminMenu(int iD)
        {
            InitializeComponent();
            string fullName = new AdminMenuLogic().GiveAdminMenuName(iD);
            this.label1.Text = "Welcome Admin: "+fullName;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ManageStudentGroups().ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ManageSubjects().ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ManageStudents().ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ManageTeachers().ShowDialog();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ManageModules().ShowDialog();
            this.Show();
        }
    }
}