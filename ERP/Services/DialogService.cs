using ERP.View;
using System.Windows;

namespace ERP.Services
{
    public class DialogService : IDialogService
    {
        Window _employeeEditView;

        /// <summary>
        /// Show employee edit dialog
        /// </summary>
        public void ShowEditDialog()
        {
            _employeeEditView = new EmployeeEditWindow();
            _employeeEditView.ShowDialog();
        }

        /// <summary>
        /// Close employee edit dialog if opened
        /// </summary>
        public void CloseEditDialog()
        {
            _employeeEditView?.Close();
        }
    }
}
