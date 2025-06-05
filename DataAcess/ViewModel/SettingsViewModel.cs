using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using CafeClient.Presentation.ViewModels;

namespace diplom.DataAcess.ViewModel
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        private string _selectedTheme = "Светлая";
        private string _selectedLanguage = "Русский";
        private string _databasePath = "";

        public string SelectedTheme
        {
            get => _selectedTheme;
            set
            {
                _selectedTheme = value;
                OnPropertyChanged(nameof(SelectedTheme));
            }
        }

        public string SelectedLanguage
        {
            get => _selectedLanguage;
            set
            {
                _selectedLanguage = value;
                OnPropertyChanged(nameof(SelectedLanguage));
            }
        }

        public string DatabasePath
        {
            get => _databasePath;
            set
            {
                _databasePath = value;
                OnPropertyChanged(nameof(DatabasePath));
            }
        }

        public ICommand SaveCommand { get; }

        public SettingsViewModel()
        {
            SaveCommand = new RelayCommand(SaveSettings);
            LoadCurrentSettings();
        }

        private void LoadCurrentSettings()
        {
            try
            {
                var settings = SettingsManager.LoadSettings();
                SelectedTheme = settings.Theme;
                SelectedLanguage = settings.Language;
                DatabasePath = settings.DatabasePath;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка загрузки настроек: {ex.Message}");
            }
        }

        private void SaveSettings(object parameter)
        {
            try
            {
                var settings = new AppSettings
                {
                    Theme = SelectedTheme,
                    Language = SelectedLanguage,
                    DatabasePath = DatabasePath
                };

                SettingsManager.SaveSettings(settings);

                // Применяем тему
                ApplyTheme();

                // Применяем язык
                ApplyLanguage();

                MessageBox.Show("Настройки успешно сохранены!", "Настройки", 
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении настроек: {ex.Message}", "Ошибка", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ApplyTheme()
        {
            try
            {
                var app = Application.Current;
                
                // Удаляем старые ресурсы тем
                var resourcesToRemove = new System.Collections.Generic.List<ResourceDictionary>();
                foreach (ResourceDictionary dictionary in app.Resources.MergedDictionaries)
                {
                    if (dictionary.Source != null && 
                        (dictionary.Source.ToString().Contains("LightTheme.xaml") || 
                         dictionary.Source.ToString().Contains("DarkTheme.xaml")))
                    {
                        resourcesToRemove.Add(dictionary);
                    }
                }

                foreach (var resource in resourcesToRemove)
                {
                    app.Resources.MergedDictionaries.Remove(resource);
                }

                // Добавляем новую тему
                string themeFile = SelectedTheme == "Темная" ? "DarkTheme.xaml" : "LightTheme.xaml";
                var themeUri = new Uri($"pack://application:,,,/Themes/{themeFile}", UriKind.Absolute);
                app.Resources.MergedDictionaries.Add(new ResourceDictionary { Source = themeUri });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при применении темы: {ex.Message}", "Ошибка", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ApplyLanguage()
        {
            try
            {
                var app = Application.Current;
                
                // Удаляем старые языковые ресурсы
                var resourcesToRemove = new System.Collections.Generic.List<ResourceDictionary>();
                foreach (ResourceDictionary dictionary in app.Resources.MergedDictionaries)
                {
                    if (dictionary.Source != null && 
                        (dictionary.Source.ToString().Contains("ru-RU.xaml") || 
                         dictionary.Source.ToString().Contains("en-US.xaml")))
                    {
                        resourcesToRemove.Add(dictionary);
                    }
                }

                foreach (var resource in resourcesToRemove)
                {
                    app.Resources.MergedDictionaries.Remove(resource);
                }

                // Добавляем новый язык
                string languageFile = SelectedLanguage == "English" ? "en-US.xaml" : "ru-RU.xaml";
                var languageUri = new Uri($"pack://application:,,,/Languages/{languageFile}", UriKind.Absolute);
                app.Resources.MergedDictionaries.Add(new ResourceDictionary { Source = languageUri });

                // Устанавливаем культуру
                var culture = SelectedLanguage == "English" ? "en-US" : "ru-RU";
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture);
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(culture);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при применении языка: {ex.Message}", "Ошибка", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}