using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;
using static UserLogin.LoginValidation;

namespace StudentInfoSystem
{
    class LoginModel
    {
        public bool LogUser(string username, string password, ActionOnError errorDelegateFunction)
        {
            User user = new User();

            LoginValidation validator = new LoginValidation(username, password, errorDelegateFunction);
            return validator.ValidateUserInput(ref user);
        }

        public void AddStudents()
        {
            StudentInfoContext context = new StudentInfoContext();

            if (context.TestStudentsIfEmpty())
            {
                foreach (Student st in StudentData.TestStudents)
                {
                    context.Students.Add(st);
                }
                context.SaveChanges();
            }
        }

        public void AddUsers()
        {
            UserLoginContext usersContext = new UserLoginContext();

            if (usersContext.TestUsersIfEmpty())
            {
                Logs logEntry = new Logs
                {
                    LogMessage = "New login attempt",
                    Date = DateTime.Now
                };
                usersContext.Logs.Add(logEntry);

                foreach (User user in UserData.TestUsers)
                {
                    usersContext.Users.Add(user);
                }
                usersContext.SaveChanges();
            }
        }
    }
}
