using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentInfoSystem
{
    class LoginController
    {
        private LoginModel model;
        private LoginForm view;

        public LoginController(LoginForm view)
        {
            this.view = view;
            model = new LoginModel();
        }

        public void LogAction(object sender, RoutedEventArgs e)
        {   
            
            bool success = model.LogUser(view.UsernameInput.Text, view.PasswordInput.Text, PrintError);

            if (success)
            {
                MainForm next = new MainForm();
                next.Show();
                view.Close();
            }
            else
            {
                MessageBox.Show("Грешка");
            }
        }

        public void AddStudentsAction()
        {
            model.AddStudents();
        }

        public void AddUsersAction()
        {
            model.AddUsers();
        }

        private void PrintError(string msg)
        {
            MessageBox.Show(msg);
        }
    }
}
