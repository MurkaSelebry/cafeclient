using System.Windows.Controls;
using CafeClient.Presentation.ViewModels;
using diplom.DataAcess.ViewModel;

namespace CafeClient.Presentation.Views
{
    public partial class SettingsView : UserControl
    {
        public SettingsView()
        {
            InitializeComponent();
            DataContext = new SettingsViewModel();
        }
    }
}
