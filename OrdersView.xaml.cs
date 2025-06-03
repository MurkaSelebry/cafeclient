using System.Windows.Controls;
using CafeClient.Presentation.ViewModels;
using CafeClient.BusinessLogic.Managers;

namespace CafeClient.Presentation.Views
{
    public partial class OrdersView : UserControl
    {
        public OrdersView()
        {
            InitializeComponent();
            DataContext = new OrdersViewModel(App.OrderManagerInstance);
        }
    }
}