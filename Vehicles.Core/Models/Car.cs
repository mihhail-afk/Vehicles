namespace Vehicles.Core.Models;

public class Car : Vehicle
{
    public Car(string name) : base(name) { }

    public override string Move(double distance)
    {
        string baseMessage = base.Move(distance);
        return $"[Car] {baseMessage}";
    }
}