using System.Windows.Controls;
using CafeClient.Presentation.ViewModels;
using CafeClient.BusinessLogic.Managers;
using CafeClient.DataAccess.Repositories;
using CafeClient.DataAccess;
using diplom.DataAcess.ViewModel;

namespace CafeClient.Presentation.Views
{
    public partial class OrdersView : UserControl
    {
        public OrdersView()
        {
            InitializeComponent();
            var db = new DbConnection();
            var orderRepo = new OrderRepository(db);
            var orderItemRepo = new OrderItemRepository(db);
            var orderManager = new OrderManager(orderRepo, orderItemRepo);
            DataContext = new OrdersViewModel(orderManager);
        }
    }
}