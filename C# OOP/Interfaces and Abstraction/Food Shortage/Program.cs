using FoodShortage.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Population> people = new List<Population>();

            for (int i = 0; i < n; i++)
            {
                string[] personInfo = Console.ReadLine().Split(' ');
                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                if (personInfo.Length == 4)
                {
                    string id = personInfo[2];
                    string birthdate = personInfo[3];
                    people.Add(new Citizen(name, age, id, birthdate));
                }
                else if (personInfo.Length == 3)
                {
                    string group = personInfo[2];
                    people.Add(new Rebel(name, age, group));
                }
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                foreach (var person in people)
                {
                    try
                    {
                        if (person.Name == input)
                        {
                            person.BuyFood();
                        }
                        else
                        {
                            throw new ArgumentException();
                        }
                    }
                    catch (ArgumentException ex)
                    {
                       // Console.WriteLine(ex.Message);
                    }

                }

                input = Console.ReadLine();
            }

            Console.WriteLine(people.Sum(x => x.Food));
        }
    }
}
