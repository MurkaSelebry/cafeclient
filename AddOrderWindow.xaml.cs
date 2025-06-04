using System.Windows;

namespace diplom
{
    public partial class AddOrderWindow : Window
    {
        public AddOrderWindow(object viewModel)
        {
            this.InitializeComponent();
            this.DataContext = viewModel;
        }
    }
} 