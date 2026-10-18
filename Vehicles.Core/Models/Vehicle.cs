using Vehicles.Core.Interfaces;

namespace Vehicles.Core.Models
{
    public abstract class Vehicle : IEntity, IMovable
    {
        private string _name = string.Empty;

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty.");
                _name = value.Trim();
            }
        }

        public double Odometer { get; protected set; }

        protected Vehicle(string name)
        {
            Name = name;
            Odometer = 0;
        }

        public virtual string Move(double distance)
        {
            if (distance <= 0)
                throw new ArgumentException("Distance must be greater than 0.");

            Odometer += distance;
            return $"{Name} moved {distance} km. New odometer: {Odometer} km.";
        }

        public virtual string Honk()
        {
            return $"{Name} honks!";
        }

        public virtual string FlashLights()
        {
            return $"{Name} flashes lights!";
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {Name} | Odometer: {Odometer} km";
        }
    }
}