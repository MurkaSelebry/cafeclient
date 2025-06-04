using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CafeClient.BusinessLogic.Managers;
using CafeClient.BusinessLogic.Models;
using CafeClient.Presentation.ViewModels;

namespace diplom.DataAcess.ViewModel
{
    public class ClientsViewModel : INotifyPropertyChanged
    {
        private readonly ClientManager _clientManager;
        private string _searchText;
        private ObservableCollection<Client> _clients;

        public ClientsViewModel(ClientManager clientManager)
        {
            _clientManager = clientManager;
            LoadClients();
            AddClientCommand = new RelayCommand(AddClient);
            SearchCommand = new RelayCommand(SearchClients);
        }

        public ObservableCollection<Client> Clients
        {
            get => _clients;
            set { _clients = value; OnPropertyChanged(); }
        }

        public string SearchText
        {
            get => _searchText;
            set { _searchText = value; OnPropertyChanged(); }
        }

        public ICommand AddClientCommand { get; }
        public ICommand SearchCommand { get; }

        private void LoadClients()
        {
            Clients = new ObservableCollection<Client>(_clientManager.GetAllClients());
        }

        private void AddClient(object obj)
        {
            var window = new diplom.AddClientWindow(new AddClientViewModel(_clientManager, null));
            var viewModel = new AddClientViewModel(_clientManager, window);
            window.DataContext = viewModel;
            if (window.ShowDialog() == true)
            {
                LoadClients();
            }
        }

        private void SearchClients(object obj)
        {
            if (string.IsNullOrWhiteSpace(SearchText))
                LoadClients();
            else
                Clients = new ObservableCollection<Client>(_clientManager.SearchClients(SearchText));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
