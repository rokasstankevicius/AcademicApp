using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using static AcademicApp.Admin.AdminSubMenus.ManageStudentGroupsLogic;

namespace AcademicApp.Admin.AdminSubMenus
{
    public partial class ManageStudentGroups : Form
    {
        public ManageStudentGroups()
        {
            
            InitializeComponent();
            RefreshData();
        }

        private void RefreshData()
        {
            dataGridView1.DataSource = LoadListOfGroups();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newStudentGroup = Interaction.InputBox("Please type in the new student groups name.","Student Group Name");
            CreateStudentGroup(newStudentGroup);
            RefreshData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                DeleteStudentGroup(Convert.ToInt16(dataGridView1.CurrentRow.Cells["GroupID"].Value));
                RefreshData();
            }
        }
    }
}