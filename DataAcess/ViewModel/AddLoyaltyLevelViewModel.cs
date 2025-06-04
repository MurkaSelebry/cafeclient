using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using CafeClient.BusinessLogic.Models;
using CafeClient.BusinessLogic.Managers;
using CafeClient.Presentation.ViewModels;

namespace diplom.DataAcess.ViewModel
{
    public class AddLoyaltyLevelViewModel : INotifyPropertyChanged
    {
        private string _name;
        private string _minPoints;
        private string _discountPercent;

        public string Name { get => _name; set { _name = value; OnPropertyChanged(); } }
        public string MinPoints { get => _minPoints; set { _minPoints = value; OnPropertyChanged(); } }
        public string DiscountPercent { get => _discountPercent; set { _discountPercent = value; OnPropertyChanged(); } }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        private readonly LoyaltyManager _loyaltyManager;
        private readonly Window _window;

        public AddLoyaltyLevelViewModel(LoyaltyManager loyaltyManager, Window window)
        {
            _loyaltyManager = loyaltyManager;
            _window = window;
            SaveCommand = new RelayCommand(SaveLevel);
            CancelCommand = new RelayCommand(_ => _window.Close());
        }

        private void SaveLevel(object obj)
        {
            var level = new LoyaltyLevel
            {
                Name = Name,
                MinPoints = int.TryParse(MinPoints, out var min) ? min : 0,
                DiscountPercent = decimal.TryParse(DiscountPercent, out var disc) ? disc : 0
            };
            _loyaltyManager.AddLoyaltyLevel(level);
            _window.DialogResult = true;
            _window.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
} 