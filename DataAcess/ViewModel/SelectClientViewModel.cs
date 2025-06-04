using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using CafeClient.BusinessLogic.Managers;
using CafeClient.BusinessLogic.Models;
using CafeClient.Presentation.ViewModels;

namespace diplom.DataAcess.ViewModel
{
    public class SelectClientViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Client> _clients;
        private Client _selectedClient;
        public ObservableCollection<Client> Clients { get => _clients; set { _clients = value; OnPropertyChanged(); } }
        public Client SelectedClient { get => _selectedClient; set { _selectedClient = value; OnPropertyChanged(); } }
        public ICommand SelectCommand { get; }
        public ICommand CancelCommand { get; }
        private readonly Window _window;
        public SelectClientViewModel(ClientManager clientManager, Window window)
        {
            _window = window;
            Clients = new ObservableCollection<Client>(clientManager.GetAllClients());
            SelectCommand = new RelayCommand(_ => { if (SelectedClient != null) { _window.DialogResult = true; _window.Close(); } });
            CancelCommand = new RelayCommand(_ => _window.Close());
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
} 