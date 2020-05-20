using UserLogin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window
    {
        private LoginController controller;

        public LoginForm()
        {
            InitializeComponent();
            controller = new LoginController(this);
            controller.AddStudentsAction();
            controller.AddUsersAction();
        }

        public void Login(object sender, RoutedEventArgs e)
        {
            controller.LogAction(sender, e);
        }

    }
}
