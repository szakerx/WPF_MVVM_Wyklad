
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace MVVMTest {
    class MainWindowVM :INotifyPropertyChanged{
        private string _text;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowVM() {
            _text = "Text example";
            ChangeTextButtonCommand = new RelayCommand(ChangeText);
        }
        private void OnPropertyChanged(string propName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        public ICommand ChangeTextButtonCommand { get; set; }

        public string Text {
            get { return _text; }
            set { _text = value;
                OnPropertyChanged("Text");
            }
        }
        private void ChangeText(object obj) {
            Text = "Changed!";
            Console.WriteLine("dupa");
        }
    }
}
