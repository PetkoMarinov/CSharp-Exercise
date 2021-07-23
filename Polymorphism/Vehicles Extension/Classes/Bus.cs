using System;

namespace Vehicles.Classes
{
    public class Bus : Vehicle
    {
        private const double BusAirConditionerIncrease = 1.4;

        public Bus(double tankCapacity, double fuelQuantity, double consumption)
            : base(tankCapacity, fuelQuantity, consumption)
        {
        }

        public Bus()
        {
        }

        public bool IsEmpty { get; set; }

        public override double Consumption => this.IsEmpty 
            ? base.Consumption
            : base.Consumption + BusAirConditionerIncrease;

        protected override void CanDrive(bool canDrive, double distance)
        {
            Console.WriteLine(canDrive == true ?
                $"Bus travelled {distance} km" : "Bus needs refueling");
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
