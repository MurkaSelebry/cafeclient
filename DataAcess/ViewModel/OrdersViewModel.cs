using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CafeClient.BusinessLogic.Managers;
using CafeClient.BusinessLogic.Models;
using CafeClient.Presentation.ViewModels;

namespace diplom.DataAcess.ViewModel
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
            Orders = new ObservableCollection<Order>(_orderManager.GetAllOrders());
        }

        private void AddOrder(object obj)
        {
            var window = new diplom.AddOrderWindow(new AddOrderViewModel(_orderManager, null));
            var viewModel = new AddOrderViewModel(_orderManager, window);
            window.DataContext = viewModel;
            if (window.ShowDialog() == true)
            {
                LoadOrders();
            }
        }

        private void SearchOrders(object obj)
        {
            if (string.IsNullOrWhiteSpace(SearchText))
                LoadOrders();
            else
                Orders = new ObservableCollection<Order>(_orderManager.SearchOrders(SearchText));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
