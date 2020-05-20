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
    /// Interaction logic for MainForm.xaml
    /// </summary>
    public partial class MainForm : Window
    {
        //private bool _isActive = true;

        public MainForm()
        {
            InitializeComponent();
        }

        //public void ToggleActive(object sender, RoutedEventArgs e)
        //{
        //    _isActive = !_isActive;

        //    foreach (var gridElement in StudentInfoGrid.Children)
        //    {
        //        if (gridElement is TextBox)
        //            ((TextBox)gridElement).IsEnabled = _isActive;
        //    }

        //    foreach (var gridElement in PersonalDataGrid.Children)
        //    {
        //        if (gridElement is TextBox)
        //            ((TextBox)gridElement).IsEnabled = _isActive;
        //    }
        //}

        //public void CrearWholeInput(object sender, RoutedEventArgs e)
        //{
        //    foreach (var gridElement in StudentInfoGrid.Children)
        //    {
        //        if (gridElement is TextBox)
        //        {
        //            ((TextBox)gridElement).Text = "";
        //        }
        //    }

        //    foreach (var gridElement in PersonalDataGrid.Children)
        //    {
        //        if (gridElement is TextBox)
        //        {
        //            ((TextBox)gridElement).Text = "";
        //        }
        //    }
        //}

        //public void CollectInfoFromForm(object sender, RoutedEventArgs e)
        //{
        //    Student studentFromForm = new Student();

        //    studentFromForm.FirstName = FirstName.Text;
        //    studentFromForm.SecondName = SecondName.Text;
        //    studentFromForm.LastName = LastName.Text;
        //    studentFromForm.Faculty = Faculty.Text;
        //    studentFromForm.Specialty = Specialty.Text;
        //    studentFromForm.Degree = Degree.Text;
        //    studentFromForm.Status = Status.Text;
        //    studentFromForm.FacultyNumber = FacultyNumber.Text;
        //    studentFromForm.Year = int.Parse(Year.Text);
        //    studentFromForm.Potok = int.Parse(Potok.Text);
        //    studentFromForm.Group = int.Parse(Group.Text);

        //    MessageBox.Show(studentFromForm.FirstName + " " + studentFromForm.FacultyNumber);
        //}
    }
}
