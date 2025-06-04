using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using CafeClient.BusinessLogic.Models;
using CafeClient.BusinessLogic.Managers;
using CafeClient.Presentation.ViewModels;
using CafeClient.DataAccess.Repositories;
using CafeClient.DataAccess;

namespace diplom.DataAcess.ViewModel
{
    public class AddOrderViewModel : INotifyPropertyChanged
    {
        private string _clientName;
        private string _loyaltyInfo;
        private int _bonusPoints;
        private ObservableCollection<OrderItemViewModel> _orderItems = new ObservableCollection<OrderItemViewModel>();
        private decimal _total;
        private ClientManager _clientManager;
        private Client _selectedClient;

        public string ClientName { get => _clientName; set { _clientName = value; OnPropertyChanged(); } }
        public string LoyaltyInfo { get => _loyaltyInfo; set { _loyaltyInfo = value; OnPropertyChanged(); } }
        public int BonusPoints { get => _bonusPoints; set { _bonusPoints = value; OnPropertyChanged(); } }
        public ObservableCollection<OrderItemViewModel> OrderItems { get => _orderItems; set { _orderItems = value; OnPropertyChanged(); UpdateTotal(); } }
        public decimal Total { get => _total; set { _total = value; OnPropertyChanged(); } }
        public Client SelectedClient { get => _selectedClient; set { _selectedClient = value; OnPropertyChanged(); UpdateClientInfo(); } }

        public ICommand SelectClientCommand { get; }
        public ICommand AddItemCommand { get; }
        public ICommand RemoveItemCommand { get; }
        public ICommand PayCommand { get; }
        public ICommand CancelCommand { get; }

        private readonly OrderManager _orderManager;
        private readonly Window _window;

        public AddOrderViewModel(OrderManager orderManager, Window window)
        {
            _orderManager = orderManager;
            _window = window;
            var db = new DbConnection();
            var clientRepo = new ClientRepository(db);
            var loyaltyRepo = new LoyaltyLevelRepository(db);
            _clientManager = new ClientManager(clientRepo, loyaltyRepo);
            SelectClientCommand = new RelayCommand(SelectClient);
            AddItemCommand = new RelayCommand(AddItem);
            RemoveItemCommand = new RelayCommand(RemoveItem);
            PayCommand = new RelayCommand(Pay);
            CancelCommand = new RelayCommand(_ => _window.Close());
        }

        private void SelectClient(object obj)
        {
            var window = new diplom.SelectClientWindow(null);
            var viewModel = new SelectClientViewModel(_clientManager, window);
            window.DataContext = viewModel;
            if (window.ShowDialog() == true && viewModel.SelectedClient != null)
            {
                SelectedClient = viewModel.SelectedClient;
            }
        }

        private void UpdateClientInfo()
        {
            if (SelectedClient != null)
            {
                ClientName = SelectedClient.GetFullName();
                BonusPoints = SelectedClient.BonusPoints;
                LoyaltyInfo = $"Уровень лояльности: {SelectedClient.LoyaltyLevelId}";
            }
            else
            {
                ClientName = string.Empty;
                BonusPoints = 0;
                LoyaltyInfo = string.Empty;
            }
        }

        private void AddItem(object obj)
        {
            // Пример добавления тестовой позиции (реализуйте выбор через отдельное окно по аналогии с клиентом)
            OrderItems.Add(new OrderItemViewModel { Name = "Капучино", Quantity = 1, Price = 150 });
            UpdateTotal();
        }

        private void RemoveItem(object obj)
        {
            if (obj is OrderItemViewModel item)
                OrderItems.Remove(item);
            UpdateTotal();
        }

        private void Pay(object obj)
        {
            if (SelectedClient == null || OrderItems.Count == 0) return;
            var order = new Order
            {
                ClientId = SelectedClient.Id,
                UserId = 1, // или текущий пользователь
                OrderDate = DateTime.Now.ToString(),
                TotalAmount = Total,
                DiscountAmount = 0,
                BonusPointsUsed = 0,
                BonusPointsEarned = 0,
                Status = "Closed"
            };
            _orderManager.CreateOrder(order);
            _window.DialogResult = true;
            _window.Close();
        }

        private void UpdateTotal()
        {
            decimal sum = 0;
            foreach (var item in OrderItems)
                sum += item.Total;
            Total = sum;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public class OrderItemViewModel : INotifyPropertyChanged
    {
        private string _name;
        private int _quantity;
        private decimal _price;
        public string Name { get => _name; set { _name = value; OnPropertyChanged(); OnPropertyChanged(nameof(Total)); } }
        public int Quantity { get => _quantity; set { _quantity = value; OnPropertyChanged(); OnPropertyChanged(nameof(Total)); } }
        public decimal Price { get => _price; set { _price = value; OnPropertyChanged(); OnPropertyChanged(nameof(Total)); } }
        public decimal Total => Price * Quantity;
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
} 