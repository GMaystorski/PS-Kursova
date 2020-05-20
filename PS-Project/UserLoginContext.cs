using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace UserLogin
{
    public class UserLoginContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Logs> Logs { get; set; }

        public UserLoginContext() : base(Properties.Settings.Default.DbConnect)
        { }

        public bool TestUsersIfEmpty()
        {
            IEnumerable<User> queryUsers = Users;
            return queryUsers.Count() == 0;
        }
    }
}
