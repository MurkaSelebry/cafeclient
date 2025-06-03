using System.Windows.Controls;
using CafeClient.Presentation.ViewModels;
using CafeClient.BusinessLogic.Managers;

namespace CafeClient.Presentation.Views
{
    public partial class LoyaltyView : UserControl
    {
        public LoyaltyView()
        {
            InitializeComponent();
            DataContext = new LoyaltyViewModel(App.LoyaltyManagerInstance);
        }
    }
}
