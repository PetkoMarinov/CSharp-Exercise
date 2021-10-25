using System;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double CarAirConditionerIncrease = 0.9;

        public Car(double tankCapacity, double fuelQuantity, double consumption)
            : base(tankCapacity, fuelQuantity, consumption)
        {
        }

        public Car()
        {
        }

        public override double Consumption => base.Consumption + CarAirConditionerIncrease;

        protected override void CanDrive(bool canDrive, double distance)
        {
            Console.WriteLine(canDrive == true ?
                $"Car travelled {distance} km" : "Car needs refueling");
        }

        protected override void CanRefuel(bool ableToRefuel, double fuel)
        {
            if (ableToRefuel != true)
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
            }
        }
    }
}
