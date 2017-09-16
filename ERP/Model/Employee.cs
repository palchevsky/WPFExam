using ERP.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ERP
{
    public class Employee : INotifyPropertyChanged
    {
        Random _rand;
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Properties
        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                RaisePropertyChanged("Email");
            }
        }

        private string _phone;
        public string Phone
        {
            get => _phone;
            set
            {
                _phone = value;
                RaisePropertyChanged("Phone");
            }
        }

        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                RaisePropertyChanged("FirstName");
            }
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                RaisePropertyChanged("LastName");
            }
        }

        private string _street;
        public string Street
        {
            get => _street;
            set
            {
                _street = value;
                RaisePropertyChanged("Street");
            }
        }

        private DateTime _birthday;
        public DateTime Birthday
        {
            get => _birthday;
            set
            {
                _birthday = value;
                RaisePropertyChanged("Birthday");
            }
        }

        private string _city;
        public string City
        {
            get => _city;
            set
            {
                _city = value;
                RaisePropertyChanged("City");
            }
        }

        private string _userpic;
        public string UserPic
        {
            get => _userpic;
            set
            {
                _userpic = value;
                RaisePropertyChanged("UserPic");
            }
        }

        private string _uniqueId;
        public string UniqueId
        {
            get => _uniqueId;
            set
            {
                _uniqueId = value;
                RaisePropertyChanged("UniqueId");
            }
        }

        private Position _position;
        public Position Position
        {
            get => _position;
            set
            {
                _position = value;
                RaisePropertyChanged("Position");
            }
        }

        private decimal _salary;
        public decimal Salary
        {
            get => _salary;
            set
            {
                _salary = value;
                RaisePropertyChanged("Salary");
            }
        }

        private ObservableCollection<Rating> _rating;
        public ObservableCollection<Rating> Rating
        {
            get
            {
                if (_rating != null) return _rating;
                _rand = new Random();
                _rating = new ObservableCollection<Rating>
                {
                    new Rating { Category = "Command proficiency", Number = _rand.Next(0, 100) },
                    new Rating { Category = "Completed projects", Number = _rand.Next(0, 100) },
                    new Rating { Category = "Effectiveness of management", Number = _rand.Next(0, 100) }
                };
                return _rating;
            }
            set
            {
                _rating = value;
                RaisePropertyChanged("Rating");
            }
        }

        private ObservableCollection<Task> _tasks;
        public ObservableCollection<Task> Tasks
        {
            get
            {
                if (_tasks == null)
                {
                    _rand = new Random();
                    _tasks = new ObservableCollection<Task>();
                    for (int i = 0; i < _rand.Next(1, 5); i++)
                    {
                        _rand = new Random();
                        _tasks.Add(new Task());
                    }
                };

                return _tasks;
            }
            set
            {
                _tasks = value;
                RaisePropertyChanged("Tasks");
            }
        } 
        #endregion
    }
}