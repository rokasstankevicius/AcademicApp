using System;
using System.Windows.Forms;
using static AcademicApp.Admin.AdminSubMenus.ManageModulesLogic;

namespace AcademicApp.Admin.AdminSubMenus
{
    public partial class ManageModules : Form
    {
        public ManageModules()
        {
            InitializeComponent();
            RefreshData();
        }

        private void RefreshData()
        {
            dataGridView1.DataSource = LoadListOfModules();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new PopUpCreateModules().ShowDialog();
            RefreshData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                DeleteModule(Convert.ToInt16(dataGridView1.CurrentRow.Cells["TeachingSubjectID"].Value));
                RefreshData();
            }
        }
    }
}