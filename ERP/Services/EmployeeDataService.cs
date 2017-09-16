using ERP.Model;
using System.Collections.ObjectModel;

namespace ERP.Services
{
    public class EmployeeDataService : IEmployeeDataService
    {
        readonly IEmployeeRepository _repository;

        public EmployeeDataService(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        
        /// <summary>
        /// Find employee by id
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns>Found employee</returns>
        public Employee GetEmployeeDetail(int employeeId)
        {
            return _repository.GetEmployeeById(employeeId);
        }

        /// <summary>
        /// Load employees
        /// </summary>
        /// <returns>List of loaded employees</returns>
        public ObservableCollection<Employee> GetAllEmployees()
        {
            return _repository.GetEmployees();
        }

        /// <summary>
        /// Load positions
        /// </summary>
        /// <returns>List of loaded positions</returns>
        public ObservableCollection<Position> GetPositions()
        {
            return _repository.GetPositions();
        }

        /// <summary>
        /// Update/edit the employee
        /// </summary>
        /// <param name="employee">Employee to update</param>
        /// <returns>Updated employee</returns>
        public Employee UpdateEmployee(Employee employee)
        {
            return _repository.UpdateEmployee(employee);
        }

        /// <summary>
        /// Delete the employee
        /// </summary>
        /// <param name="employee">Employee to delete</param>
        public void DeleteEmployee(Employee employee)
        {
            _repository.DeleteEmployee(employee);
        }

        /// <summary>
        /// Add an employee
        /// </summary>
        public void AddAnEmployee()
        {
            _repository.AddAnEmployee();
        }
    }
}
