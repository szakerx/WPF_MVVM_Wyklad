
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace MVVMTest {
    class MainWindowVM :INotifyPropertyChanged{
        private string _text;
        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        // Event i funkcja 
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public MainWindowVM()
        {
            ChangeTextButtonCommand = new RelayCommand(ChangeText);
        }

        public ICommand ChangeTextButtonCommand { get; set; }

        private void ChangeText(object obj)
        {
            //Text = "Changed!";
            Console.WriteLine("dupa");
        }
    }
}
