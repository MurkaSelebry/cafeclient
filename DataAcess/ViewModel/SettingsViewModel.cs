using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CafeClient.Presentation.ViewModels;

namespace diplom.DataAcess.ViewModel
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        private string _selectedTheme = "Светлая";
        private string _selectedLanguage = "Русский";
        private string _databasePath = "cafeclient.db";
        public string SelectedTheme { get => _selectedTheme; set { _selectedTheme = value; OnPropertyChanged(); } }
        public string SelectedLanguage { get => _selectedLanguage; set { _selectedLanguage = value; OnPropertyChanged(); } }
        public string DatabasePath { get => _databasePath; set { _databasePath = value; OnPropertyChanged(); } }
        public ICommand SaveCommand { get; }
        public SettingsViewModel()
        {
            SaveCommand = new RelayCommand(SaveSettings);
        }
        private void SaveSettings(object obj)
        {
            // Здесь можно реализовать сохранение настроек в файл или user config
            System.Windows.MessageBox.Show("Настройки сохранены!", "Сохранение", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
