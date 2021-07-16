using System;
using System.Collections.Generic;
using System.Linq;
using BorderControl.Classes;

namespace BorderControl
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            City city = new City();

            while (input != "End")
            {
                string[] data = input.Split(' ');

                if (data.Length == 3)
                {
                    city.AddInhabitant(new Citizen(data[0], int.Parse(data[1]), data[2]));
                }
                else
                {
                    city.AddInhabitant(new Robot(data[0], data[1]));
                }

                input = Console.ReadLine();
            }

            string detain = Console.ReadLine();

            Console.WriteLine(string.Join("\n", city.Detained(detain)));
        }
    }
}
