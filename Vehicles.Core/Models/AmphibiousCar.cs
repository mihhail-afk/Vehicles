namespace Vehicles.Core.Models;

public class AmphibiousCar : Vehicle
{
    public AmphibiousCar(string name) : base(name) { }

    public override string Move(double distance)
    {
        string baseMessage = base.Move(distance);
        return $"[AmphibiousCar] {baseMessage}";
    }
}