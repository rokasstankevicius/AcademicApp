using System;
using System.Windows.Forms;
using static AcademicApp.Admin.AdminSubMenus.ManageTeachersLogic;

namespace AcademicApp.Admin.AdminSubMenus
{
    public partial class ManageTeachers : Form
    {
        public ManageTeachers()
        {
            InitializeComponent();
            RefreshData();
        }
        private void RefreshData()
        {
            dataGridView1.DataSource = LoadListOfTeachers();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new PopUpCreateTeachers().ShowDialog();
            RefreshData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                DeleteTeacher(Convert.ToInt16(dataGridView1.CurrentRow.Cells["TeacherID"].Value));
                RefreshData();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}