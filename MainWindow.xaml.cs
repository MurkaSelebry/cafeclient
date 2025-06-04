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
        private readonly ClientsView _clientsView = new ClientsView();
        private readonly OrdersView _ordersView = new OrdersView();
        private readonly LoyaltyView _loyaltyView = new LoyaltyView();
        private readonly ReportsView _reportsView = new ReportsView();
        private readonly SettingsView _settingsView = new SettingsView();

    public MainWindow(/*User user*/)
    {
        InitializeComponent();
        //var loginWindow = new LoginWindow();
        //loginWindow.Show();
        //UserInfoText.Text = $"Администратор: {user.FullName}";
        MainContentPresenter.Content = _clientsView; // По умолчанию "Клиенты"
    }

    private void NavButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender == BtnClients)
                MainContentPresenter.Content = _clientsView;
            else if (sender == BtnOrders)
                MainContentPresenter.Content = _ordersView;
            else if (sender == BtnLoyalty)
                MainContentPresenter.Content = _loyaltyView;
            else if (sender == BtnReports)
                MainContentPresenter.Content = _reportsView;
            else if (sender == BtnSettings)
                MainContentPresenter.Content = _settingsView;
        }


}