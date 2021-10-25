using System;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double TruckAirConditionerIncrease = 1.6;
        public Truck(double tankCapacity, double fuelQuantity, double consumption)
            : base(tankCapacity, fuelQuantity, consumption)
        {
        }

        public Truck()
        {

        }

        public override double Consumption => base.Consumption + TruckAirConditionerIncrease;

        protected override void CanDrive(bool canDrive, double distance)
        {
            Console.WriteLine(canDrive == true ? $"Truck travelled {distance} km" : "Truck needs refueling");
        }

        public override void Refuel(double fuel)
        {
            base.Refuel(fuel * 0.95);
        }

        protected override void CanRefuel(bool ableToRefuel, double fuel)
        {
            if (ableToRefuel != true)
            {
                Console.WriteLine($"Cannot fit {fuel / 0.95} fuel in the tank");
            }
        }
    }
}
