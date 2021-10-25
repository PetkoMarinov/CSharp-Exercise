using System;
using Vehicles.Classes;

namespace Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            IVehicle car = new Car();
            IVehicle truck = new Truck();
            IVehicle bus = new Bus();
           
            for (int i = 1; i <= 3; i++)
            {
                string[] vehicleInfo = Console.ReadLine().Split(' ');
                string vehicleType = vehicleInfo[0];
                double initialFuel = double.Parse(vehicleInfo[1]);
                double consumption = double.Parse(vehicleInfo[2]);
                double capacity = double.Parse(vehicleInfo[3]);

                switch (vehicleType.ToLower())
                {
                    case "car": car = new Car(capacity, initialFuel, consumption); break;
                    case "truck": truck = new Truck(capacity, initialFuel, consumption); break;
                    case "bus": bus = new Bus(capacity, initialFuel, consumption); break;
                }
            }

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] commandInfo = Console.ReadLine().Split(' ');

                string command = commandInfo[0].ToLower();
                string vehicle = commandInfo[1].ToLower();

                if (command == "drive")
                {
                    double distance = double.Parse(commandInfo[2]);
                    switch (vehicle)
                    {
                        case "car": car.Drive(distance); break;
                        case "truck": truck.Drive(distance); break;
                        case "bus": bus.Drive(distance); break;
                    }
                }
                else if (command == "refuel")
                {
                    double liters = double.Parse(commandInfo[2]);
                    switch (vehicle)
                    {
                        case "car": car.Refuel(liters); break;
                        case "truck": truck.Refuel(liters); break;
                        case "bus": bus.Refuel(liters); break;
                    }
                }
                else if (command == "driveempty")
                {
                    double distance = double.Parse(commandInfo[2]);
                    if (bus is Bus)
                    {
                        ((Bus)bus).IsEmpty = true;
                        bus.Drive(distance);
                    }
                }
            }
           
            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}
