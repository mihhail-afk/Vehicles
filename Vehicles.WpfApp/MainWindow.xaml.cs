using System;
using System.Collections.ObjectModel;
using System.Windows;
using Vehicles.Core.Models;

namespace Vehicles.WpfApp;

public partial class MainWindow : Window
{
    public ObservableCollection<Vehicle> Vehicles { get; set; } = new();

    public MainWindow()
    {
        InitializeComponent();
        VehiclesListBox.ItemsSource = Vehicles;
    }

    private void AddVehicle_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            string name = NameInput.Text;
            string selectedType = (TypeComboBox.SelectedItem as System.Windows.Controls.ComboBoxItem)?.Content.ToString() ?? "";

            Vehicle newVehicle = selectedType switch
            {
                "Car" => new Car(name),
                "Boat" => new Boat(name),
                "AmphibiousCar" => new AmphibiousCar(name),
                _ => throw new InvalidOperationException("Unknown vehicle type.")
            };

            Vehicles.Add(newVehicle);
            Log($"Added vehicle: {newVehicle}");
            NameInput.Clear();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }

    private void Move10_Click(object sender, RoutedEventArgs e)
    {
        if (VehiclesListBox.SelectedItem is not Vehicle selectedVehicle)
        {
            MessageBox.Show("Please select a vehicle from the list!", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
            return;
        }

        try
        {
            string resultMessage = selectedVehicle.Move(10);
            Log(resultMessage);
            VehiclesListBox.Items.Refresh();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Movement Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void ClearLog_Click(object sender, RoutedEventArgs e)
    {
        LogTextBox.Clear();
    }

    private void Log(string message)
    {
        LogTextBox.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}{Environment.NewLine}");
        LogTextBox.ScrollToEnd();
    }
}