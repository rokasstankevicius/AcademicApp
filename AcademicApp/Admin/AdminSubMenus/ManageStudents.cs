using System;
using System.Windows.Forms;
using static AcademicApp.Admin.AdminSubMenus.ManageStudentsLogic;

namespace AcademicApp.Admin.AdminSubMenus
{
    public partial class ManageStudents : Form
    {
        public ManageStudents()
        {
            InitializeComponent();
            RefreshData();
        }
        
        private void RefreshData()
        {
            dataGridView1.DataSource = LoadListOfStudents();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new PopUpCreateStudents().ShowDialog();
            RefreshData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                DeleteStudent(Convert.ToInt16(dataGridView1.CurrentRow.Cells["StudentID"].Value));
                RefreshData();
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}