using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CafeClient.Presentation.ViewModels;
using System.Windows;
using System.Windows.Markup;
using System.Globalization;
using System.Linq;

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
            // Смена темы
            var app = Application.Current;
            var dict = new ResourceDictionary();
            if (SelectedTheme == "Темная")
                dict.Source = new System.Uri("Themes/DarkTheme.xaml", System.UriKind.Relative);
            else
                dict.Source = new System.Uri("Themes/LightTheme.xaml", System.UriKind.Relative);
            // Удаляем старую тему
            var oldTheme = app.Resources.MergedDictionaries.FirstOrDefault(x => x.Source != null && x.Source.OriginalString.Contains("Theme"));
            if (oldTheme != null) app.Resources.MergedDictionaries.Remove(oldTheme);
            app.Resources.MergedDictionaries.Add(dict);

            // Смена языка
            var langDict = new ResourceDictionary();
            if (SelectedLanguage == "English")
                langDict.Source = new System.Uri("Languages/en-US.xaml", System.UriKind.Relative);
            else
                langDict.Source = new System.Uri("Languages/ru-RU.xaml", System.UriKind.Relative);
            var oldLang = app.Resources.MergedDictionaries.FirstOrDefault(x => x.Source != null && x.Source.OriginalString.Contains("Languages"));
            if (oldLang != null) app.Resources.MergedDictionaries.Remove(oldLang);
            app.Resources.MergedDictionaries.Add(langDict);

            // Установка культуры для динамического перевода (если используется)

            try
            {
                if (SelectedLanguage == "English")
                    FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(XmlLanguage.GetLanguage("en-US")));
                else if (SelectedLanguage == "Русский")
                    FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(XmlLanguage.GetLanguage("ru-RU")));
                else
                    MessageBox.Show("Настройки заданы!", "Сохранение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при смене языка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            MessageBox.Show("Настройки сохранены!", "Сохранение", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
