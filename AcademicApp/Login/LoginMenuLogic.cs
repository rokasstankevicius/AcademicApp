using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AcademicApp.Admin;
using AcademicApp.Teacher;
using AcademicApp.Student;

namespace AcademicApp.Login
{
    public class LoginMenuLogic
    {
        //private bool loop = true;
        //public static Dictionary<string, Action> Actions = new Dictionary<string, System.Action>();
        public void Open(string UN, string PW)
        {
            Login login = new Login(UN, PW);
            if (login.userFound)
            {
                if (login.admin)
                {
                    //Console.Clear();
                    //new AdminMenu().Open(login.foundUsersID);
                    //MessageBox.Show("Admin login");

                    //new Form1().CloseFrom();
                    //new LoginMenu().HideForm();
                    AdminMenu adminMenu = new AdminMenu(login.foundUsersID);
                    adminMenu.ShowDialog();

                    //new LoginMenu().HideForm();
                    //PopUp PopUp = new PopUp();
                    //PopUp.Closed += (s, args) => new Form1().CloseFrom();
                    //PopUp.ShowDialog();


                }
                else if (login.teacher)
                {
                    //Console.Clear();
                    TeacherMenu teacherMenu = new TeacherMenu(login.foundUsersID);
                    teacherMenu.ShowDialog();

                    //new TeacherMenu().Open(login.foundUsersID);
                    //TeacherMenu();

                }
                else if (login.student)
                {
                    //Console.Clear();
                    StudentMenu studentMenu = new StudentMenu(login.foundUsersID);
                    studentMenu.ShowDialog();
                    //new StudentMenu().Open(login.foundUsersID);
                    //StudentMenu();

                }
            }
            else
            {
                MessageBox.Show("No login found");
            }
            
        }
    }
}