using ERP.Model;
using ERP.Services;
using ERP.ViewModel;

namespace ERP
{
    public class ViewModelLocator
    {
        private static readonly IDialogService dialogService = new DialogService();
        private static readonly IEmployeeDataService employeeDataService = new EmployeeDataService(new EmployeesRepository());

        public static MainWindowViewModel MainWindowViewModel { get; } = new MainWindowViewModel(employeeDataService, dialogService);

        public static EmployeeEditViewModel EmployeeEditViewModel { get; } = new EmployeeEditViewModel(employeeDataService, dialogService);
    }
}
