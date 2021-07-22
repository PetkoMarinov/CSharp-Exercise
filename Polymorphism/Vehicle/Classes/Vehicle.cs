using System;

namespace Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        private double distanceTravelled;
        private double fuelQuantity;

        public Vehicle(double tankCapacity, double fuelQuantity, double consumption)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            Consumption = consumption;
        }

        public Vehicle()
        {
        }

        public double FuelQuantity
        {
            get => this.fuelQuantity;
            private set
            {
                if (value > TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
            }
        }

        public virtual double Consumption { get; }
        public double DistanceTravelled { get => this.distanceTravelled; }

        public double TankCapacity { get; }

        public void Drive(double distance)
        {
            double possibleDistance = FuelQuantity / Consumption;
            bool canDrive = possibleDistance >= distance;
            double fuelSpent = canDrive ? distance * Consumption : 0;

            FuelQuantity -= fuelSpent;
            distanceTravelled += distance;

            CanDrive(canDrive, distance);
        }

        public virtual void Refuel(double fuel)
        {
            bool ableToRefuel = (fuel > 0) && (fuel + FuelQuantity <= TankCapacity);

            if (fuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (ableToRefuel)
            {
                FuelQuantity += fuel;
                CanRefuel(ableToRefuel, fuel);
            }
        }

        protected abstract void CanDrive(bool canDrive, double distance);
        // (canDrive == true ? new Action(()
        // => Console.WriteLine("fdgd")) : () => Console.WriteLine("fg"))();

        protected abstract void CanRefuel(bool ableToRefuel, double fuel);
    }
}
