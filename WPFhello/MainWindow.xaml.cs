using System;
using System.Windows;
using System.Windows.Controls;

namespace WPFhello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ListBoxItem james = new ListBoxItem();
            james.Content = "James";
            peopleListBox.Items.Add(james);

            ListBoxItem david = new ListBoxItem();
            david.Content = "David";
            peopleListBox.Items.Add(david);

            peopleListBox.SelectedItem = james;
        }

        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            string concatenatedResult = "";

            foreach (var controlElement in GridWithNames.Children)
            {
                if (controlElement is TextBox)
                {
                    concatenatedResult = concatenatedResult + ", " + ((TextBox)controlElement).Text;
                }
            }

            txtName1.Text = DateTime.Now.ToString();
            MessageBox.Show("Здравейте" + concatenatedResult + " !");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Exit?", "My App", MessageBoxButton.OKCancel);

            if (!result.Equals(MessageBoxResult.OK))
                e.Cancel = true;
        }

        private void PrintSelectedName(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Chosen: " +
                (peopleListBox.SelectedItem as ListBoxItem).Content.ToString());
        }

        private void NewWindow(object sender, RoutedEventArgs e)
        {
            MyMessage window = new MyMessage();
            window.Show();
        }
    }
}
