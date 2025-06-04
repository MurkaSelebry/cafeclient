using System.Windows;

namespace diplom
{
    public partial class AddClientWindow : Window
    {
        public AddClientWindow(object viewModel)
        {
            this.InitializeComponent();
            this.DataContext = viewModel;
        }
    }
} 