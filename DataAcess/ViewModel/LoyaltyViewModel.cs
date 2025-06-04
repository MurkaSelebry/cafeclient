using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CafeClient.BusinessLogic.Managers;
using CafeClient.BusinessLogic.Models;
using CafeClient.Presentation.ViewModels;
using CafeClient.DataAccess.Repositories;
using CafeClient.DataAccess;
using System.Linq;

namespace diplom.DataAcess.ViewModel
{
    public class LoyaltyViewModel : INotifyPropertyChanged
    {
        private readonly LoyaltyManager _loyaltyManager;
        private ObservableCollection<LoyaltyLevel> _levels;
        private ObservableCollection<string> _stats;

        public ObservableCollection<LoyaltyLevel> Levels
        {
            get => _levels;
            set { _levels = value; OnPropertyChanged(); }
        }

        public ObservableCollection<string> Stats
        {
            get => _stats;
            set { _stats = value; OnPropertyChanged(); }
        }

        public ICommand AddLevelCommand { get; }

        public LoyaltyViewModel(LoyaltyManager loyaltyManager)
        {
            _loyaltyManager = loyaltyManager;
            LoadLevels();
            UpdateStats();
            AddLevelCommand = new RelayCommand(AddLevel);
        }

        private void LoadLevels()
        {
            Levels = new ObservableCollection<LoyaltyLevel>(_loyaltyManager.GetLoyaltyLevels());
            UpdateStats();
        }

        private void AddLevel(object obj)
        {
            var db = new DbConnection();
            var loyaltyRepo = new LoyaltyLevelRepository(db);
            var clientRepo = new ClientRepository(db);
            var loyaltyManager = new LoyaltyManager(loyaltyRepo, clientRepo);
            var window = new diplom.AddLoyaltyLevelWindow(null);
            var viewModel = new AddLoyaltyLevelViewModel(loyaltyManager, window);
            window.DataContext = viewModel;
            if (window.ShowDialog() == true)
            {
                LoadLevels();
            }
        }

        private void UpdateStats()
        {
            var db = new DbConnection();
            var clientRepo = new ClientRepository(db);
            var clients = clientRepo.GetAll();
            var total = clients.Count;
            var levels = Levels.ToList();
            var stats = new ObservableCollection<string> { $"Всего участников: {total}" };
            foreach (var level in levels)
            {
                var count = clients.Count(c => c.LoyaltyLevelId == level.Id);
                stats.Add($"{level.Name}: {count}");
            }
            Stats = stats;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
