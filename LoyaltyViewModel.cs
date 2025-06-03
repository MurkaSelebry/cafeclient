using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CafeClient.BusinessLogic.Managers;
using CafeClient.BusinessLogic.Models;

namespace CafeClient.Presentation.ViewModels
{
    public class LoyaltyViewModel : INotifyPropertyChanged
    {
        private readonly LoyaltyManager _loyaltyManager;
        private ObservableCollection<LoyaltyLevel> _levels;

        public LoyaltyViewModel(LoyaltyManager loyaltyManager)
        {
            _loyaltyManager = loyaltyManager;
            LoadLevels();
            AddLevelCommand = new RelayCommand(AddLevel);
        }

        public ObservableCollection<LoyaltyLevel> Levels
        {
            get => _levels;
            set { _levels = value; OnPropertyChanged(); }
        }

        public ICommand AddLevelCommand { get; }

        private void LoadLevels()
        {
            Levels = new ObservableCollection<LoyaltyLevel>(_loyaltyManager.GetLoyaltyLevels());
        }

        private void AddLevel(object obj)
        {
            // Открыть окно добавления уровня лояльности
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
