using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace Expenselt
{
    /// <summary>
    /// Interaction logic for ExpenseItHome.xaml
    /// </summary>
    public partial class ExpenseItHome : Window, INotifyPropertyChanged
    {
        private DateTime lastChecked;
        public DateTime LastChecked
        {
            get { return lastChecked; }
            set
            {
                lastChecked = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("LastChecked"));
            }
        }

        public ObservableCollection<string> PersonsChecked { get; set; }

        public ExpenseItHome()
        {
            InitializeComponent();
            LastChecked = DateTime.Now;
            this.DataContext = this;
            PersonsChecked = new ObservableCollection<string>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OpenReport(object sender, RoutedEventArgs e)
        {
            ExpenseReport expenseReport = new ExpenseReport(peopleListBox.SelectedItem);
            expenseReport.Width = this.Width;
            expenseReport.Height = this.Height;
            expenseReport.Show();
        }

        private void peopleListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            LastChecked = DateTime.Now;
            PersonsChecked.Add((peopleListBox.SelectedItem as System.Xml.XmlElement).Attributes["Name"].Value);
        }
    }

}
