using System.Windows.Controls;
using CafeClient.Presentation.ViewModels;
using CafeClient.BusinessLogic.Managers;
using CafeClient.DataAccess.Repositories;
using CafeClient.DataAccess;
using diplom.DataAcess.ViewModel;

namespace CafeClient.Presentation.Views
{
    public partial class ClientsView : UserControl
    {
        public ClientsView()
        {
            InitializeComponent();
            var db = new DbConnection();
            var clientRepo = new ClientRepository(db);
            var loyaltyRepo = new LoyaltyLevelRepository(db);
            var clientManager = new ClientManager(clientRepo, loyaltyRepo);
            DataContext = new ClientsViewModel(clientManager);
        }

       
    }
}
