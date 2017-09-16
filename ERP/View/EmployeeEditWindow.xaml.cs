using MahApps.Metro.Controls;

namespace ERP.View
{
    /// <summary>
    /// Interaction logic for EmployeeEditWindow.xaml
    /// </summary>
    public partial class EmployeeEditWindow : MetroWindow
    {
        public Employee SelectedEmployee { get; set; }

        public EmployeeEditWindow()
        {
            InitializeComponent();
        }
    }
}
