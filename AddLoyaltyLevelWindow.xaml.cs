using System.Windows;

namespace diplom
{
    public partial class AddLoyaltyLevelWindow : Window
    {
        public AddLoyaltyLevelWindow(object viewModel)
        {
            this.InitializeComponent();
            this.DataContext = viewModel;
        }
    }
} 