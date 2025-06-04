using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using CafeClient.BusinessLogic.Models;
using CafeClient.BusinessLogic.Managers;
using CafeClient.Presentation.ViewModels;
using diplom;

namespace diplom.DataAcess.ViewModel
{
    public class AddClientViewModel : INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;
        private string _phone;
        private string _email;
        private string _birthDate;
        private string _loyaltyLevelId;
        private string _bonusPoints;

        public string FirstName { get => _firstName; set { _firstName = value; OnPropertyChanged(); } }
        public string LastName { get => _lastName; set { _lastName = value; OnPropertyChanged(); } }
        public string Phone { get => _phone; set { _phone = value; OnPropertyChanged(); } }
        public string Email { get => _email; set { _email = value; OnPropertyChanged(); } }
        public string BirthDate { get => _birthDate; set { _birthDate = value; OnPropertyChanged(); } }
        public string LoyaltyLevelId { get => _loyaltyLevelId; set { _loyaltyLevelId = value; OnPropertyChanged(); } }
        public string BonusPoints { get => _bonusPoints; set { _bonusPoints = value; OnPropertyChanged(); } }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        private readonly ClientManager _clientManager;
        private readonly Window _window;

        public AddClientViewModel(ClientManager clientManager, Window window)
        {
            _clientManager = clientManager;
            _window = window;
            SaveCommand = new RelayCommand(SaveClient);
            CancelCommand = new RelayCommand(_ => _window.Close());
        }

        private void SaveClient(object obj)
        {
            var client = new Client
            {
                FirstName = FirstName,
                LastName = LastName,
                Phone = Phone,
                Email = Email,
                BirthDate = DateTime.TryParse(BirthDate, out var date) ? date : (DateTime?)null,
                LoyaltyLevelId = int.TryParse(LoyaltyLevelId, out var level) ? level : 0,
                BonusPoints = int.TryParse(BonusPoints, out var points) ? points : 0,
                RegistrationDate = DateTime.Now
            };
            _clientManager.RegisterClient(client);
            _window.DialogResult = true;
            _window.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
} 