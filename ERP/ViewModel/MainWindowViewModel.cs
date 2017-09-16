using ERP.Messages;
using ERP.Model;
using ERP.Services;
using ERP.Utility;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

namespace ERP.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly IEmployeeDataService _employeeDataService;
        private readonly IDialogService _dialogService;

        public ICommand EditCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand ResetFilter { get; private set; }

        #region Properties
        private bool _canRemovePositionFilter;
        public bool CanRemovePositionFilter
        {
            get => _canRemovePositionFilter;
            set
            {
                _canRemovePositionFilter = value;
                RaisePropertyChanged("CanRemovePositionFilter");
            }
        }

        private Position _selectedPosition;
        public Position SelectedPosition
        {
            get => _selectedPosition;
            set
            {
                if (_selectedPosition == value)
                    return;
                _selectedPosition = value;
                RaisePropertyChanged("SelectedPosition");
                if (_selectedPosition != null)
                { AddPositionFilter(); }
            }
        }

        private ObservableCollection<Employee> _employees;
        public ObservableCollection<Employee> Employees
        {
            get => _employees;
            set
            {
                _employees = value;
                RaisePropertyChanged("Employees");
            }
        }

        private CollectionViewSource Cvs { get; set; }

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
            get => _positions;
            set
            {
                if (_positions == value) return;
                _positions = value;
                RaisePropertyChanged("Positions");
            }
        } 
        #endregion

        #region Constructor
        public MainWindowViewModel(IEmployeeDataService employeeDataService, IDialogService dialogService)
        {
            _employeeDataService = employeeDataService;
            _dialogService = dialogService;
            LoadData();
            LoadCommands();
            Messenger.Default.Register<UpdateListMessage>(this, OnUpdateListMessageReceived);
        } 
        #endregion

        #region Methods

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private static bool CanAddEmployee(object obj)
        {
            return true;
        }

        /// <summary>
        /// Add an employee
        /// </summary>
        /// <param name="obj"></param>
        private void AddAnEmployee(object obj)
        {
            _employeeDataService.AddAnEmployee();
            Messenger.Default.Send(new UpdateListMessage());
        }

        /// <summary>
        /// Load commands for buttons
        /// </summary>
        private void LoadCommands()
        {
            EditCommand = new CustomCommand(EditEmployee, CanEditEmployee);
            AddCommand = new CustomCommand(AddAnEmployee, CanAddEmployee);
            ResetFilter = new CustomCommand(ResetFilters, null);
        }

        /// <summary>
        /// Reset position filter
        /// </summary>
        /// <param name="obj"></param>
        private void ResetFilters(object obj)
        {
            if (Cvs == null)
            {
                Cvs = new CollectionViewSource();
                return;
            }

            Cvs.Filter -= FilterByPosition;
            SelectedPosition = null;
            CanRemovePositionFilter = false;
        }

        /// <summary>
        /// Filter by selected position
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FilterByPosition(object sender, FilterEventArgs e)
        {
            if (!(e.Item is Employee src))
                e.Accepted = false;
            else if (!SelectedPosition.Equals(src.Position))
                e.Accepted = false;
        }

        /// <summary>
        /// Add position filter
        /// </summary>
        public void AddPositionFilter()
        {
            if (CanRemovePositionFilter)
            {
                if (Cvs == null) return;
                Cvs.Filter -= FilterByPosition;
                Cvs.Filter += FilterByPosition;
            }
            else
            {
                Cvs.Filter += FilterByPosition;
                CanRemovePositionFilter = true;
            }
        }

        private bool CanEditEmployee(object obj)
        {
            if (SelectedEmployee != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Edit the employee
        /// </summary>
        /// <param name="obj"></param>
        private void EditEmployee(object obj)
        {
            Messenger.Default.Send(_selectedEmployee);
            _dialogService.ShowEditDialog();
        }

        /// <summary>
        /// Update list message
        /// </summary>
        /// <param name="obj"></param>
        private void OnUpdateListMessageReceived(UpdateListMessage obj)
        {
            LoadData();
            _dialogService.CloseEditDialog();
            if (Cvs == null)
            { Cvs = obj.Cvs; }
        }

        /// <summary>
        /// Load employees and positions
        /// </summary>
        private void LoadData()
        {
            Employees = _employeeDataService.GetAllEmployees();
            Positions = _employeeDataService.GetPositions();
        }

        #endregion
    }
}
