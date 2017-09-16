using ERP.Messages;
using ERP.Utility;
using MahApps.Metro.Controls;
using System.Windows.Data;

namespace ERP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        Messenger.Default.Send(new UpdateListMessage { Cvs = (CollectionViewSource)Resources["Collection"] });
        }
    }
}
