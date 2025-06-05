using System;
using System.Configuration;
using System.Data;
using System.Windows;
using diplom.DataAcess.ViewModel;
namespace diplom;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        
        // Загружаем сохраненные настройки при запуске
        LoadSavedSettings();
    }

    private void LoadSavedSettings()
    {
        try
        {
            var settings = SettingsManager.LoadSettings();
            
            // Загружаем тему
            if (!string.IsNullOrEmpty(settings.Theme))
            {
                ApplyTheme(settings.Theme);
            }

            // Загружаем язык
            if (!string.IsNullOrEmpty(settings.Language))
            {
                ApplyLanguage(settings.Language);
            }
        }
        catch (Exception ex)
        {
            // В случае ошибки используем настройки по умолчанию
            MessageBox.Show($"Ошибка загрузки настроек: {ex.Message}", "Предупреждение", 
                MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }

    private void ApplyTheme(string theme)
    {
    }

    private void ApplyLanguage(string language)
    {
    }
}