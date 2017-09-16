using System.Collections.ObjectModel;

namespace ERP.Model
{
    public interface IEmployeeRepository
    {
        void DeleteEmployee(Employee employee);
        void AddAnEmployee();
        Employee GetAnEmployee();
        Employee GetEmployeeById(int id);
        ObservableCollection<Employee> GetEmployees();
        ObservableCollection<Position> GetPositions();
        Employee UpdateEmployee(Employee employee);
    }
}
