using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class LoginValidation
    {
        public delegate void ActionOnError(string errorMsg);

        public static string Username { get; set; }
        public static string Password { get; set; }

        private string ErrorMessage { get; set; }
        private ActionOnError ErrorAction { get; set; }
        private readonly string fileName = "D:/Downloads/PS-Upr6/PS-Upr6/PS-Project/users.txt";

        public static UserRole CurrentUserRole { private set; get; }
          

        public LoginValidation(string username, string password, ActionOnError errorDelegateFunction)
        {
            Username = username;
            Password = password;
            ErrorAction = new ActionOnError(errorDelegateFunction);
        }

        public bool ValidateUserInput(ref User user) 
        {
            if (Username.Length < 5)
            {
                ErrorMessage = "Username too short";
                ErrorAction(ErrorMessage);
                return false;
            }

            if (Password.Length < 5)
            {
                ErrorMessage = "Password too short";
                ErrorAction(ErrorMessage);
                return false;
            }

            user = UserData.IsUserPassCorrect(Username, Password);

            if (null == user)
            {
                ErrorMessage = "No such user found";
                CurrentUserRole = UserRole.ANONYMOUS;
                ErrorAction(ErrorMessage);
                return false;
            }

            CurrentUserRole = (UserRole) user.Role;

            Logger.LogActivity("Logged in successful as " + CurrentUserRole);
            Logger.LogActivity("Times logged in before: " + GetLoggedInTimes(user));

            SaveUserToFile(user);

            return user != null;
        }

        private string[] GettAllLines()
        {
            if (File.Exists(fileName))
                return File.ReadAllLines(fileName);
            else
                return new string[0];
        }

        private void SaveUserToFile(User userToSave)
        {
            if (File.Exists(fileName))
            {
                string lineToWrite = userToSave.Name + "|" + DateTime.Now.ToString() + "\n";
                File.AppendAllText(fileName, lineToWrite);
            }
        }

        private int GetLoggedInTimes(User user)
        {
            string[] lines = GettAllLines();

            int timesFound = 0;
            foreach (string line in lines)
            {
                string[] tokens = line.Split('|');
                DateTime sevenDaysAgo = DateTime.Now.AddDays(-7);
                DateTime logInDate = DateTime.Parse(tokens[1]);

                if (tokens[0].Equals(user.Name) && sevenDaysAgo <= logInDate)
                {
                    timesFound++;
                }
            }

            return timesFound;
        }
    }
}
