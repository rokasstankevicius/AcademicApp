using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using static AcademicApp.Admin.AdminSubMenus.ManageSubjectsLogic;

namespace AcademicApp.Admin.AdminSubMenus
{
    public partial class ManageSubjects : Form
    {
        public ManageSubjects()
        {
            InitializeComponent();
            RefreshData();
        }
        private void RefreshData()
        {
            dataGridView1.DataSource = ListOfSubjects();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newSubject = Interaction.InputBox("Please type in the new subjects name.","Subjects name");
            CreateSubject(newSubject);
            RefreshData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                DeleteSubject(Convert.ToInt16(dataGridView1.CurrentRow.Cells["SubjectID"].Value));
                RefreshData();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}