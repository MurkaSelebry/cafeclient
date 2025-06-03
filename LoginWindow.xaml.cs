using System.Windows;
using CafeClient.BusinessLogic.Managers;
using CafeClient.BusinessLogic.Models;
using diplom;


namespace CafeClient.Presentation.Views
{
    public partial class LoginWindow : Window
    {
        private readonly AuthManager _authManager;

        public LoginWindow()
        {
            InitializeComponent();
            _authManager = new AuthManager();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            
            string username = UsernameBox.Text.Trim();
            string password = PasswordBox.Password;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ShowError("Пожалуйста, введите имя пользователя и пароль.");
                return;
            }

           User user = _authManager.Login(username, password);
            if (user != null)
            {
                var mainWindow = new MainWindow(); // Передайте пользователя, если нужно
                mainWindow.Show();
            }
            else
            {
                ShowError("Неверное имя пользователя или пароль.");
            }
        }

        private void ShowError(string message)
        {
            ErrorText.Text = message;
            ErrorText.Visibility = Visibility.Visible;
        }
    }
}
