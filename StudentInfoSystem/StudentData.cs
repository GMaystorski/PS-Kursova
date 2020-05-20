using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    class StudentData
    {
        public static IEnumerable<Student> TestStudents {
            get
            {
                List<Student> students = new List<Student>();
                Student student = new Student
                {
                    FirstName = "Ivan",
                    SecondName = "Ivanov",
                    LastName = "Ivanov",
                    Faculty = "FKST",
                    Specialty = "KSI",
                    Degree = " ",
                    Status = " ",
                    FacultyNumber = "121217111",
                    Year = 2,
                    Potok= 4,
                    Group = 34
                };
                students.Add(student);
                return students;
            }

            private set { }
        }
    }
}
