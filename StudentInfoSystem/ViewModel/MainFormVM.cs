using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;

namespace StudentInfoSystem.ViewModel
{
    class MainFormVM : INotifyPropertyChanged
    {
        private bool _isEnabled = true;
        public bool IsEnabled { get { return _isEnabled; } set { _isEnabled = value; } }
        public Student StudentProp { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentSecondName { get; set; }
        public string StudentLastName { get; set; }
        public string StudentFaculty { get; set; }
        public string StudentSpecialty { get; set; }
        public string StudentDegree { get; set; }
        public string StudentStatus { get; set; }
        public string StudentFacultyNumber { get; set; }
        public string StudentYear { get; set; }
        public string StudentPotok { get; set; }
        public string StudentGroup { get; set; }

        public List<string> StudStatusChoices { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;


        public MainFormVM()
        {
            FillStudStatusChoices();
        }


        public ICommand EnableCommand
        {
            get { return new BasicCommand(SwapIsEnabled); }
        }

        private void SwapIsEnabled()
        {
            IsEnabled = !IsEnabled;
            PropertyChanged(this, new PropertyChangedEventArgs("IsEnabled"));
        }

        public ICommand ClearDataCommand
        {
            get { return new BasicCommand(ClearData); }
        }

        private void ClearData()
        {
            StudentFirstName = "";
            PropertyChanged(this, new PropertyChangedEventArgs("StudentFirstName"));
            StudentSecondName = "";
            PropertyChanged(this, new PropertyChangedEventArgs("StudentSecondName"));
            StudentLastName = "";
            PropertyChanged(this, new PropertyChangedEventArgs("StudentLastName"));
            StudentFaculty = "";
            PropertyChanged(this, new PropertyChangedEventArgs("StudentFaculty"));
            StudentSpecialty = "";
            PropertyChanged(this, new PropertyChangedEventArgs("StudentSpecialty"));
            StudentDegree = "";
            PropertyChanged(this, new PropertyChangedEventArgs("StudentDegree"));
            StudentStatus = "";
            PropertyChanged(this, new PropertyChangedEventArgs("StudentStatus"));
            StudentFacultyNumber = "";
            PropertyChanged(this, new PropertyChangedEventArgs("StudentFacultyNumber"));
            StudentYear = "";
            PropertyChanged(this, new PropertyChangedEventArgs("StudentYear"));
            StudentPotok = "";
            PropertyChanged(this, new PropertyChangedEventArgs("StudentPotok"));
            StudentGroup = "";
            PropertyChanged(this, new PropertyChangedEventArgs("StudentGroup"));
        }


        public ICommand CollectDataCommand
        {
            get { return new BasicCommand(CollectData); }
        }

        private void CollectData()
        {
            if (StudentProp == null) StudentProp = new Student();
            StudentProp.FirstName = StudentFirstName;
            StudentProp.SecondName = StudentSecondName;
            StudentProp.LastName = StudentLastName;
            StudentProp.Faculty = StudentFaculty;
            StudentProp.Specialty = StudentSpecialty;
            StudentProp.Degree = StudentDegree;
            StudentProp.Status = StudentStatus;
            StudentProp.FacultyNumber = StudentFacultyNumber;
            StudentProp.Year = int.Parse(StudentYear);
            StudentProp.Potok = int.Parse(StudentPotok);
            StudentProp.Group = int.Parse(StudentGroup);

            MessageBox.Show(StudentProp.FirstName + " " + StudentProp.FacultyNumber);

            Console.WriteLine("StudentFirstName -" + StudentFirstName);
            Console.WriteLine("StudentSecondName -" + StudentSecondName);
            Console.WriteLine("StudentLastName -" + StudentLastName);
            Console.WriteLine("StudentFaculty -" + StudentFaculty);
            Console.WriteLine("StudentSpecialty -" + StudentSpecialty);
            Console.WriteLine("StudentDegree -" + StudentDegree);
            Console.WriteLine("StudentStatus -" + StudentStatus);
            Console.WriteLine("StudentFacultyNumber -" + StudentFacultyNumber);
            Console.WriteLine("StudentYear -" + StudentYear);
            Console.WriteLine("StudentPotok -" + StudentPotok);
            Console.WriteLine("StudentGroup -" + StudentGroup);
        }

        private void FillStudStatusChoices()
        {
            StudStatusChoices = new List<string>();
            using (IDbConnection connection = new
            SqlConnection(Properties.Settings.Default.DbConnect))
            {
                string sqlquery = @"SELECT StatusDescr FROM StudStatus";
                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = sqlquery;

                IDataReader reader = command.ExecuteReader();

                bool notEndOfResult;
                notEndOfResult = reader.Read();
                while (notEndOfResult)
                {
                    string s = reader.GetString(0);
                    StudStatusChoices.Add(s);
                    notEndOfResult = reader.Read();
                }
            }
        }

    }

}
