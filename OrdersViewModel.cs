using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CafeClient.BusinessLogic.Managers;
using CafeClient.BusinessLogic.Models;

namespace CafeClient.Presentation.ViewModels
{
    public class OrdersViewModel : INotifyPropertyChanged
    {
        private readonly OrderManager _orderManager;
        private string _searchText;
        private ObservableCollection<Order> _orders;

        public OrdersViewModel(OrderManager orderManager)
        {
            _orderManager = orderManager;
            LoadOrders();
            AddOrderCommand = new RelayCommand(AddOrder);
            SearchCommand = new RelayCommand(SearchOrders);
        }

        public ObservableCollection<Order> Orders
        {
            get => _orders;
            set { _orders = value; OnPropertyChanged(); }
        }

        public string SearchText
        {
            get => _searchText;
            set { _searchText = value; OnPropertyChanged(); }
        }

        public ICommand AddOrderCommand { get; }
        public ICommand SearchCommand { get; }

        private void LoadOrders()
        {
            Orders = new ObservableCollection<Order>(_orderManager.GetOrdersByClientId(0)); // или GetAllOrders()
        }

        private void AddOrder(object obj)
        {
            // Открыть окно добавления заказа
        }

        private void SearchOrders(object obj)
        {
            // Реализуйте поиск по заказам
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
