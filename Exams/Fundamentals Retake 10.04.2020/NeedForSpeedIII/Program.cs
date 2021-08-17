using System;
using System.Collections.Generic;
using System.Linq;

namespace Need_for_Speed_III
{
    class Program
    {
        static void Main(string[] args)
        {
            int carCount = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < carCount; i++)
            {
                string[] carInfo = Console.ReadLine().Split('|');
                string make = carInfo[0];
                int mileage = int.Parse(carInfo[1]);
                int fuelAvailable = int.Parse(carInfo[2]);
                cars.Add(new Car(make, mileage, fuelAvailable));
            }

            string input = Console.ReadLine();

            while (input != "Stop")
            {
                string[] commandInfo = input.Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                string command = commandInfo[0];
                string make = commandInfo[1];
                Car usedCar = cars.Find(x => x.Make == make);

                switch (command)
                {
                    case "Drive":
                        int distance = int.Parse(commandInfo[2]);
                        int fuel = int.Parse(commandInfo[3]);

                        if (usedCar.FuelAvailable >= fuel)
                        {
                            usedCar.Drive(distance, fuel);
                            Console.WriteLine($"{usedCar.Make} driven for {distance} " +
                                $"kilometers. {fuel} liters of fuel consumed.");
                        }
                        else
                        {
                            Console.WriteLine("Not enough fuel to make that ride");
                        }

                        if (usedCar.Mileage >= 100000)
                        {
                            Console.WriteLine($"Time to sell the {usedCar.Make}!");
                            cars.Remove(usedCar);
                        }
                        break;

                    case "Refuel":
                        int fuelToRefuel = int.Parse(commandInfo[2]);
                        int ableToRefuel = usedCar.FuelAbleToRefuel(fuelToRefuel);

                        usedCar.Refuel(fuelToRefuel);
                        Console.WriteLine($"{usedCar.Make} refueled with " +
                            $"{ableToRefuel} liters");
                        break;

                    case "Revert":
                        int kilometers = int.Parse(commandInfo[2]);
                        int revertedKm = usedCar.KilometersAbleToRevert(kilometers);

                        usedCar.Revert(kilometers);

                        if (usedCar.Mileage > 10000)
                        {
                            Console.WriteLine($"{usedCar.Make} mileage decreased by " +
                                $"{revertedKm} kilometers");
                        }
                        break;
                }

                input = Console.ReadLine();
            }

            cars.OrderByDescending(x => x.Mileage)
                .ThenBy(x => x.Make)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.Make} -> Mileage: {x.Mileage} kms," +
                $" Fuel in the tank: {x.FuelAvailable} lt."));
        }
    }

    public class Car
    {
        public Car(string make, int mileage, int fuelAvailable)
        {
            Make = make;
            Mileage = mileage;
            FuelAvailable = fuelAvailable;
        }

        public string Make { get; }
        public int Mileage { get; private set; }
        public int FuelAvailable { get; private set; }

        public void Drive(int distance, int fuel)
        {
            if (this.FuelAvailable >= fuel)
            {
                this.FuelAvailable -= fuel;
                this.Mileage += distance;
            }
        }

        public void Refuel(int fuelToRefuel)
        {
            this.FuelAvailable += FuelAbleToRefuel(fuelToRefuel);
        }

        public int FuelAbleToRefuel(int fuelToRefuel) => (this.FuelAvailable + fuelToRefuel) > 75
        ? (75 - this.FuelAvailable)
        : fuelToRefuel;

        public void Revert(int kilometers)
        {
            this.Mileage -= KilometersAbleToRevert(kilometers);
        }

        public int KilometersAbleToRevert(int kilometers) =>
            (this.Mileage - kilometers) >= 10000
            ? kilometers
            : this.Mileage - 10000;
    }
}
