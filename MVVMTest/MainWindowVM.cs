using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace MVVMTest {
    class MainWindowVM : INotifyPropertyChanged {
        #region Private fields
        private string _welcomeMessage;
        private List<User> _users;
        private List<string> _usersList;
        #endregion
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        #region Properties
        public ICommand AddUserCommand { get; private set; }
        public ICommand GetUsersInformationCommand { get; private set; }
        public string Name { private get; set; }
        public string WelcomeMessage {
            get { return _welcomeMessage; }
            private set {
                _welcomeMessage = value;
                OnPropertyChanged("WelcomeMessage");
            }
        }
        public List<string> UsersList {
            get { return _usersList; }
            private set {
                _usersList = value;
                OnPropertyChanged("UsersList");
            }
        }
        #endregion
        public MainWindowVM() {
            AddUserCommand = new RelayCommand(HelloUser);
            GetUsersInformationCommand = new RelayCommand(GetUsersInformation,CanGetUsers);
            _users = new List<User>();
        }
        private void OnPropertyChanged(string propName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        private void HelloUser(object obj) {
            WelcomeMessage = "Witaj " + Name;
            _users.Add(new User(Name));
        }
        private void GetUsersInformation(object obj) {
            List<string> temp = new List<string>();
            foreach (var x in _users)
                temp.Add(x.Id + " " + x.Name);
            UsersList = temp;
        }
        private bool CanGetUsers(object obj) {
            if (_users.Count < 1)
                return false;
            return true;
        }
    }
}
