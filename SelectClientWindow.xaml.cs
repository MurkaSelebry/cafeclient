using System.Windows;

namespace diplom
{
    public partial class SelectClientWindow : Window
    {
        public SelectClientWindow(object viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
} 