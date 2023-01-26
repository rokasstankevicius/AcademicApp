using System;
using System.Windows.Forms;

namespace AcademicApp.Login
{
    public partial class LoginMenu : Form
    {
        public LoginMenu()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string nUsername = textBoxUsername.Text;
            string nPassword = textBoxPassword.Text;
            
            this.Hide();
            new LoginMenuLogic().Open(nUsername,nPassword);
            textBoxUsername.Clear();
            textBoxPassword.Clear();
            this.Show();
        }

        public void HideForm()
        {
            this.Hide();
        }
        
        public void CloseFrom()
        {
            this.Close();
        }
    }
}