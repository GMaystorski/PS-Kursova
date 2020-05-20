using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    static public class UserData
    {

        private static List<User> _testUsers;

        public static List<User> TestUsers
        {
            get {
                ResetTestUserData();
                return _testUsers;
            }
            set { }
        }

        public static User IsUserPassCorrect(string username, string password)
        {
            User result = null;
            UserLoginContext context = new UserLoginContext();
            List<User> dbUsers = (from u in context.Users select u).ToList();
            foreach (User item in dbUsers)
            {
                if (item.Name.Equals(username) && item.Password.Equals(password))
                {
                    result = item;
                    break;
                }
            }

            return result;
        }

        public static void SetUserActiveTo(string username, DateTime activeTo)
        {
            if (null == _testUsers)
            {
                ResetTestUserData();
            }

            foreach (User item in _testUsers)
            {
                if (item.Name.Equals(username))
                {
                    item.ActiveDate = activeTo;
                    Logger.LogActivity("Changed active status of " + username);
                }
            }
        }

        public static void AssignUserRole(string username, UserRole newRole)
        {
            

            UserLoginContext context = new UserLoginContext();

            if (null == context.Users)
            {
                ResetTestUserData();
            }

            User usr =
            (from u in UserData.TestUsers
             where u.Name == username
             select u).First();
            usr.Role = (int)newRole;
            context.SaveChanges();
        }

        public static void ResetTestUserData()
        {
            if (_testUsers == null)
            {
                _testUsers = new List<User>(3);

                User user1 = new User();
                user1.Name = "test1";
                user1.Password = "test1";
                user1.FacultyNumber = "121217000";
                user1.Role = 1;
                user1.CreatedDate = DateTime.Now;
                user1.ActiveDate = DateTime.MaxValue;
                _testUsers.Add(user1);

                User user2 = new User();
                user2.Name = "test2";
                user2.Password = "test2";
                user2.FacultyNumber = "121217001";
                user2.Role = 4;
                user2.CreatedDate = DateTime.Now;
                user2.ActiveDate = DateTime.MaxValue;
                _testUsers.Add(user2);

                User user3 = new User();
                user3.Name = "test3";
                user3.Password = "test3";
                user3.FacultyNumber = "121217002";
                user3.Role = 4;
                user3.CreatedDate = DateTime.Now;
                user3.ActiveDate = DateTime.MaxValue;
                _testUsers.Add(user3);
            }
        }
    }
}
