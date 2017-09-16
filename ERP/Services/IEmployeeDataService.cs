using ERP.Model;
using System.Collections.ObjectModel;

namespace ERP.Services
{
    public interface IEmployeeDataService
    {
        void DeleteEmployee(Employee employee);
        void AddAnEmployee();
        ObservableCollection<Employee> GetAllEmployees();
        ObservableCollection<Position> GetPositions();
        Employee GetEmployeeDetail(int employeeId);
        Employee UpdateEmployee(Employee employee);
    }
}
