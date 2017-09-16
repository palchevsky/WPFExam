using System;
using System.Collections.ObjectModel;
using System.Linq;
using static ERP.Helpers.RandomNames;

namespace ERP.Model
{
    public class EmployeesRepository : IEmployeeRepository
    {
        private static ObservableCollection<Employee> _employees;
        private Employee _oneEmployee;
        private Results _someName;
        private static ObservableCollection<Position> _positions;
        Random _random;

        /// <summary>
        /// Loading 1 employee
        /// </summary>
        /// <returns>An employee</returns>
        public Employee GetAnEmployee()
        {
            if (_employees == null)
                LoadEmployees(1);
            return _employees.FirstOrDefault();
        }

        /// <summary>
        /// Loading 10 employees
        /// </summary>
        /// <returns>Collection of 10 random employees</returns>
        public ObservableCollection<Employee> GetEmployees()
        {
            if (_employees == null)
                LoadEmployees(10);
            return _employees;
        }

        /// <summary>
        /// Populate positions to a collection
        /// </summary>
        /// <returns>Collection of positions</returns>
        public ObservableCollection<Position> GetPositions()
        {
            if (_positions == null)
                LoadPositions();
            return _positions;
        }

        /// <summary>
        /// Get the employee with certain id
        /// </summary>
        /// <param name="id">id of the employee</param>
        /// <returns>The employee with id</returns>
        public Employee GetEmployeeById(int id)
        {
            if (_employees == null)
                LoadEmployees(1);
            return _employees.Where(e => e.UniqueId.Equals(id)).FirstOrDefault();
        }

        /// <summary>
        /// Delete the employee
        /// </summary>
        /// <param name="employee">The employee to delete</param>
        public void DeleteEmployee(Employee employee)
        {
            _employees.Remove(employee);
        }

        /// <summary>
        /// Generate one random employee
        /// </summary>
        public void AddAnEmployee()
        {
            _employees.Add(LoadAnEmployee());
        }

        /// <summary>
        /// Updating an employee
        /// </summary>
        /// <param name="employee">The employee to update</param>
        /// <returns>Updated employee</returns>
        public Employee UpdateEmployee(Employee employee)
        {
            Employee employeeToUpdate = _employees.Where(e => e.UniqueId == employee.UniqueId).FirstOrDefault();
            return employeeToUpdate;
        }

        /// <summary>
        /// Populating one employee with random data
        /// </summary>
        /// <returns>A random generated employee</returns>
        private Employee LoadAnEmployee()
        {
            _someName = new Results();
            _someName = GetSingleDummyUser();
            _random = new Random();
            _oneEmployee = new Employee
            {
                UniqueId = _someName.id.value,
                FirstName = _someName.name.first,
                LastName = _someName.name.last,
                Birthday = RandomDayFunc(),
                Street = _someName.location.street,
                City = _someName.location.city,
                Phone = _someName.phone,
                Email = _someName.email,
                UserPic = _someName.picture.large,
                Position = GetOnePosition(),
                Salary = _random.Next(500, 2000)
            };
            return _oneEmployee;
        }

        /// <summary>
        /// Populating a number of random employees
        /// </summary>
        /// <param name="num">Number of random employees to generate</param>
        private void LoadEmployees(int num)
        {
            _employees = new ObservableCollection<Employee>();

            for (var i = 0; i < num; i++)
            {
                _employees.Add(LoadAnEmployee());
            }
        }

        /// <summary>
        /// Generate a random birthday from 1960
        /// </summary>
        /// <returns>Generated birthday</returns>
        private DateTime RandomDayFunc()
        {
            var start = new DateTime(1960, 1, 1);
            _random = new Random();
            var range = ((TimeSpan)(new DateTime(2000, 1, 1) - start)).Days;
            return start.AddDays(_random.Next(range));
        }

        /// <summary>
        /// Generate one random position
        /// </summary>
        /// <returns>Generated position</returns>
        private Position GetOnePosition()
        {
            _random = new Random();
            if (_positions == null)
                LoadPositions();
            var index = _random.Next(_positions.Count);
            return _positions[index];
        }

        /// <summary>
        /// List of positions
        /// </summary>
        private static void LoadPositions()
        {
            _positions = new ObservableCollection<Position>
            {
                new Position("Product Manager"),
                new Position("Customer Manager"),
                new Position("Middle Developer"),
                new Position("Junior Developer"),
                new Position("Lead Developer"),
                new Position("Sales Manager"),
                new Position("Technician"),
                new Position("Cleaning Personnel"),
                new Position("Administration"),
                new Position("System Administrator")
            };
        }
    }
}