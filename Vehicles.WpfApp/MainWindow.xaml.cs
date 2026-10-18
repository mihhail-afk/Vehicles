using System.Windows;

namespace Vehicles.WpfApp
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
            DataContext = _viewModel;
        }

        private void AddCar_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddCar();
        }

        private void RemoveCar_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.RemoveCar();
        }

        private void AddBoat_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddBoat();
        }

        private void RemoveBoat_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.RemoveBoat();
        }
    }
}