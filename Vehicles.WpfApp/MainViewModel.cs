using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Vehicles.Core.Models;
using Vehicles.Core.Repositories;

namespace Vehicles.WpfApp
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly Repository<Car> _carRepository = new();
        private readonly Repository<Boat> _boatRepository = new();

        public ObservableCollection<Car> Cars { get; } = new();
        public ObservableCollection<Boat> Boats { get; } = new();
        public ObservableCollection<string> LogEntries { get; } = new();

        private Car? _selectedCar;
        public Car? SelectedCar
        {
            get => _selectedCar;
            set { _selectedCar = value; OnPropertyChanged(); }
        }

        private Boat? _selectedBoat;
        public Boat? SelectedBoat
        {
            get => _selectedBoat;
            set { _selectedBoat = value; OnPropertyChanged(); }
        }

        private string _carNameInput = string.Empty;
        public string CarNameInput
        {
            get => _carNameInput;
            set { _carNameInput = value; OnPropertyChanged(); }
        }

        private string _boatNameInput = string.Empty;
        public string BoatNameInput
        {
            get => _boatNameInput;
            set { _boatNameInput = value; OnPropertyChanged(); }
        }

        public MainViewModel()
        {
            _carRepository.OnItemAdded += (newCar, existingCar) =>
            {
                LogEntries.Add($"{existingCar.Name} honks at newcomer {newCar.Name}!");
            };

            _carRepository.OnItemRemoved += (removedCar, remainingCar) =>
            {
                LogEntries.Add($"{remainingCar.Name} flashes lights saying goodbye to {removedCar.Name}.");
            };

            _boatRepository.OnItemAdded += (newBoat, existingBoat) =>
            {
                LogEntries.Add($"{existingBoat.Name} honks at newcomer {newBoat.Name}!");
            };

            _boatRepository.OnItemRemoved += (removedBoat, remainingBoat) =>
            {
                LogEntries.Add($"{remainingBoat.Name} flashes lights saying goodbye to {removedBoat.Name}.");
            };
        }

        public void AddCar()
        {
            if (string.IsNullOrWhiteSpace(CarNameInput)) return;
            var car = new Car(CarNameInput.Trim());
            _carRepository.Add(car);
            Cars.Add(car);
            LogEntries.Add($"Added car: {car.Name}");
            CarNameInput = string.Empty;
        }

        public void RemoveCar()
        {
            if (SelectedCar == null) return;
            var carName = SelectedCar.Name;
            _carRepository.Remove(SelectedCar);
            Cars.Remove(SelectedCar);
            LogEntries.Add($"Removed car: {carName}");
            SelectedCar = null;
        }

        public void AddBoat()
        {
            if (string.IsNullOrWhiteSpace(BoatNameInput)) return;
            var boat = new Boat(BoatNameInput.Trim());
            _boatRepository.Add(boat);
            Boats.Add(boat);
            LogEntries.Add($"Added boat: {boat.Name}");
            BoatNameInput = string.Empty;
        }

        public void RemoveBoat()
        {
            if (SelectedBoat == null) return;
            var boatName = SelectedBoat.Name;
            _boatRepository.Remove(SelectedBoat);
            Boats.Remove(SelectedBoat);
            LogEntries.Add($"Removed boat: {boatName}");
            SelectedBoat = null;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}