using ERP.Messages;
using ERP.Model;
using ERP.Services;
using ERP.Utility;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace ERP.ViewModel
{
    public class EmployeeEditViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly IEmployeeDataService _employeeDataService;
        private IDialogService _dialogService;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        #region Properties
        private Employee _selectedEmployee;
        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                _selectedEmployee = value;
                RaisePropertyChanged("SelectedEmployee");
            }
        }

        private ObservableCollection<Position> _positions;
        public ObservableCollection<Position> Positions
        {
            get
            {
                if (_positions == null)
                    _positions = _employeeDataService.GetPositions();
                return _positions;
            }
            set
            {
                _positions = value;
                RaisePropertyChanged("Positions");
            }
        } 
        #endregion

        #region Constructor
        public EmployeeEditViewModel(IEmployeeDataService employeeDataService, IDialogService dialogService)
        {
            _employeeDataService = employeeDataService;
            _dialogService = dialogService;

            Messenger.Default.Register<Employee>(this, OnEmployeeReceived);

            SaveCommand = new CustomCommand(SaveEmployee, CanSaveEmployee);
            DeleteCommand = new CustomCommand(DeleteEmployee, CanDeleteEmployee);
        } 
        #endregion

        #region Methods
        /// <summary>
        /// Get selected employee
        /// </summary>
        /// <param name="obj"></param>
        private void OnEmployeeReceived(Employee obj)
        {
            SelectedEmployee = obj;
        }

        private static bool CanDeleteEmployee(object obj)
        {
            return true;
        }

        /// <summary>
        /// Delete the employee
        /// </summary>
        /// <param name="obj"></param>
        private void DeleteEmployee(object obj)
        {
            _employeeDataService.DeleteEmployee(_selectedEmployee);
            Messenger.Default.Send(new UpdateListMessage());
        }

        private static bool CanSaveEmployee(object obj)
        {
            return true;
        }

        /// <summary>
        /// Save the employee
        /// </summary>
        /// <param name="obj"></param>
        private void SaveEmployee(object obj)
        {
            _employeeDataService.UpdateEmployee(_selectedEmployee);
            Messenger.Default.Send(new UpdateListMessage());
        } 
        #endregion
    }
}
