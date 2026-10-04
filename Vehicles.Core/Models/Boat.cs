namespace Vehicles.Core.Models;

public class Boat : Vehicle
{
    public Boat(string name) : base(name) { }

    public override string Move(double distance)
    {
        string baseMessage = base.Move(distance);
        return $"[Boat] {baseMessage}";
    }
}