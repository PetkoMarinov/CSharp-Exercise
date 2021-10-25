namespace Vehicles
{
    public interface IVehicle
    {
        public double FuelQuantity { get; }

        public double Consumption { get;}
        public double DistanceTravelled { get; }
        public double TankCapacity { get; }

        public void Drive(double distance);

        public void Refuel(double fuel);
    }
}
