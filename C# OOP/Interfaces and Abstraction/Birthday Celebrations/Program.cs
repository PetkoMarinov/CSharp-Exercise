using System;

namespace BirthdayCelebrations
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
                string inhabitant = data[0];
                string name = data[1];

                switch (inhabitant)
                {
                    case "Citizen": 
                        int age = int.Parse(data[2]);
                        string id = data[3];
                        string birthdate = data[4];
                        city.AddInhabitant(new Citizen(name, age, id,birthdate)); break;
                    case "Robot":
                        string robotId = data[2];
                        city.AddInhabitant(new Robot(name, robotId)); break;
                    case "Pet":
                        string petBirthdate = data[2];
                        city.AddInhabitant(new Pet(name, petBirthdate)); break; 
                }
                
                input = Console.ReadLine();
            }
           
            string year = Console.ReadLine();
            city.BornThisYear(year).ForEach(x => x.Print("Birthdate"));
        }
    }
}
