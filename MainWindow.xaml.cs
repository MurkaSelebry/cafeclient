using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CafeClient.Presentation.Views;
namespace diplom;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow(/*User user*/)
    {
        InitializeComponent();
        //var loginWindow = new LoginWindow();
        //loginWindow.Show();
        // UserInfoText.Text = $"Администратор: {user.FullName}";
        ShowClientsView();
    }

    private void NavListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        switch (NavListBox.SelectedIndex)
        {
            case 0:
                ShowClientsView();
                break;
            case 1:
                ShowOrdersView();
                break;
            case 2:
                ShowLoyaltyView();
                break;
            case 3:
                ShowReportsView();
                break;
            case 4:
                ShowSettingsView();
                break;
        }
    }

    private void ShowClientsView()
    {
        MainContent.Content = new ClientsView(); // Реализуйте этот UserControl отдельно
    }

    private void ShowOrdersView()
    {
        MainContent.Content = new OrdersView(); // Реализуйте этот UserControl отдельно
    }

    private void ShowLoyaltyView()
    {
        MainContent.Content = new LoyaltyView(); // Реализуйте этот UserControl отдельно
    }

    private void ShowReportsView()
    {
        MainContent.Content = new ReportsView(); // Реализуйте этот UserControl отдельно
    }

    private void ShowSettingsView()
    {
        MainContent.Content = new SettingsView(); // Реализуйте этот UserControl отдельно
    }
}