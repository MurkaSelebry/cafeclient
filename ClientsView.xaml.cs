using System.Windows.Controls;
using CafeClient.Presentation.ViewModels;
using CafeClient.BusinessLogic.Managers;

namespace CafeClient.Presentation.Views
{
    public partial class ClientsView : UserControl
    {
        public ClientsView()
        {
            InitializeComponent();
            // Передайте сюда ClientManager через DI или ServiceLocator
            DataContext = new ClientsViewModel(App.ClientManagerInstance);
        }
    }
}
