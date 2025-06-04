using System.Windows.Controls;
using CafeClient.Presentation.ViewModels;
using CafeClient.BusinessLogic.Managers;
using CafeClient.DataAccess.Repositories;
using CafeClient.DataAccess;
using diplom.DataAcess.ViewModel;

namespace CafeClient.Presentation.Views
{
    public partial class LoyaltyView : UserControl
    {
        public LoyaltyView()
        {
            InitializeComponent();
            var db = new DbConnection();
            var loyaltyRepo = new LoyaltyLevelRepository(db);
            var clientRepo = new ClientRepository(db);
            var loyaltyManager = new LoyaltyManager(loyaltyRepo, clientRepo);
            DataContext = new LoyaltyViewModel(loyaltyManager);
        }
    }
}
