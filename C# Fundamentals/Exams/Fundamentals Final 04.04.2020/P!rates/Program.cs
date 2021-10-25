using System;
using System.Collections.Generic;
using System.Linq;

namespace P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            List<City> cities = new List<City>();
            string input = Console.ReadLine();

            while (input != "Sail")
            {
                string[] targetCity = input.Split("||");
                string name = targetCity[0];
                int population = int.Parse(targetCity[1]);
                int gold = int.Parse(targetCity[2]);

                if (cities.Any(c=>c.Name==name))
                {
                    var city = cities.Find(x => x.Name == name);
                    city.Population += population;
                    city.Gold += gold;
                }
                else
                {
                    cities.Add(new City(name, population, gold));
                }

                input = Console.ReadLine();
            }

            string events = Console.ReadLine();
            while (events != "End")
            {
                string[] eventsData = events.Split("=>");
                string command = eventsData[0];
                string townName = eventsData[1];

                if (command == "Plunder")
                {
                    int peopleKilled = int.Parse(eventsData[2]);
                    int plunderedGold = int.Parse(eventsData[3]);
                    var plunderedCity = cities.Find(x => x.Name == townName);
                    plunderedCity.Gold -= plunderedGold;
                    plunderedCity.Population -= peopleKilled;

                    Console.WriteLine($"{townName} plundered! {plunderedGold} gold stolen," +
                        $" {peopleKilled} citizens killed.");

                    if (plunderedCity.Gold <= 0 || plunderedCity.Population <= 0)
                    {
                        cities.Remove(plunderedCity);
                        Console.WriteLine($"{plunderedCity.Name} has been wiped off the map!");
                    }
                }
                else if (command == "Prosper")
                {
                    var prosperCity = cities.Find(x => x.Name == townName);
                    int prosperGold = int.Parse(eventsData[2]);

                    if (prosperGold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                    else
                    {
                        prosperCity.Gold += prosperGold;
                        Console.WriteLine($"{prosperGold} gold added to the city treasury." +
                            $" {townName} now has {prosperCity.Gold} gold.");
                    }
                }

                events = Console.ReadLine();
            }

            if (cities.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy" +
                    $" settlements to go to:");

                cities = cities.OrderByDescending(x => x.Gold).ThenBy(x => x.Name).ToList();
                
                foreach (var city in cities)
                {
                    Console.WriteLine($"{city.Name} -> Population: {city.Population}" +
                        $" citizens, Gold: {city.Gold} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered" +
                    " and destroyed!");
            }
        }
    }

    class City
    {
        public City(string name, int population, int gold)
        {
            Name = name;
            Population = population;
            Gold = gold;
        }

        public string Name { get; }
        public int Population { get; set; }
        public int Gold { get; set; }

        public void Prosper(int gold) => this.Gold += gold;
    }
}
