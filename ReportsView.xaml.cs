using System.Windows.Controls;
using CafeClient.Presentation.ViewModels;
using CafeClient.BusinessLogic.Managers;
using CafeClient.DataAccess.Repositories;
using CafeClient.DataAccess;
using diplom.DataAcess.ViewModel;

namespace CafeClient.Presentation.Views
{
    public partial class ReportsView : UserControl
    {
        public ReportsView()
        {
            InitializeComponent();
            var db = new DbConnection();
            var clientRepo = new ClientRepository(db);
            var orderRepo = new OrderRepository(db);
            var menuRepo = new MenuItemRepository(db);
            var loyaltyRepo = new LoyaltyLevelRepository(db);
            var reportManager = new ReportManager(clientRepo, orderRepo, menuRepo, loyaltyRepo);
            DataContext = new ReportsViewModel(reportManager);
        }
    }
}