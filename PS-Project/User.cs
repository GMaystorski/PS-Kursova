using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string FacultyNumber { get; set; }
        public int Role { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ActiveDate { get; set; }
        public System.Int32 UserId { get; set; }
    }
}
