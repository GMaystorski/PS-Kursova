using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfExample
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ICommand hiButtonCommand;
        private ICommand toggleExecuteCommand { get; set; }
        private bool canExecute = true;
        private string _currentDate;

        public event PropertyChangedEventHandler PropertyChanged; // from INotifyPropertyChanged interface

        public string CurrentDate { get { return _currentDate; } set { _currentDate = value; } }

        public string HiButtonContent
        {
            get { return "click to hi"; }
        }

        public bool CanExecute
        {
            get { return this.canExecute; }
            set
            {
                if (this.canExecute == value)
                { return; }
                this.canExecute = value;
            }
        }

        public ICommand ToggleExecuteCommand
        {
            get
            { return toggleExecuteCommand; }
            set
            { toggleExecuteCommand = value; }
        }

        public ICommand HiButtonCommand
        {
            get
            { return hiButtonCommand; }
            set
            { hiButtonCommand = value; }
        }

        public MainWindowViewModel()
        {
            HiButtonCommand = new RelayCommand(ShowMessage, param => this.canExecute);
            toggleExecuteCommand = new RelayCommand(ChangeCanExecute);
        }

        public void ShowMessage(object obj)
        {
            //it is good we do this with binding to some control
            // System.Windows.MessageBox.Show(obj.ToString());

            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                CurrentDate = DateTime.Now.ToLongTimeString();
                var e = new PropertyChangedEventArgs("CurrentDate");
                handler(this, e);
            }
        }

        public void ChangeCanExecute(object obj)
        {
            canExecute = !canExecute;
        }
    }
}
