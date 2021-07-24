using System;
using System.Collections.Generic;
using WildFarm.Classes;
using WildFarm.Classes.Amimals.Mammals;
using WildFarm.Classes.Amimals.Mammals.Cats;

namespace WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Animal> animals = new List<Animal>();
            List<Food> foods = new List<Food>();

            while (input != "End")
            {
                string[] animalData = input.Split(' ');
                Animal animal;

                string type = animalData[0].ToLower();
                string name = animalData[1];
                double weight = double.Parse(animalData[2]);

                string livingRegion = type == "cat"
                    || type == "tiger" || type == "dog" || type == "mouse"
                    ? animalData[3]
                    : string.Empty;

                double wingSize = type == "hen" || type == "owl"
                    ? double.Parse(animalData[3])
                    : -1;

                string breed = type == "cat" || type == "tiger"
                    ? animalData[4]
                    : string.Empty;

                animal = type == "cat" ? new Cat(name, weight, livingRegion, breed)
                    : animal = type == "tiger" ? new Tiger(name, weight, livingRegion, breed)
                    : animal = type == "dog" ? new Dog(name, weight, livingRegion)
                    : animal = type == "mouse" ? new Mouse(name, weight, livingRegion)
                    : animal = type == "hen" ? new Hen(name, weight, wingSize)
                    : animal = type == "owl" ? new Owl(name, weight, wingSize)
                    : throw new Exception();

                animals.Add(animal);

                Food food;
                string[] foodData = Console.ReadLine().Split(' ');
                string foodType = foodData[0].ToLower();
                int quantity = int.Parse(foodData[1]);

                food = foodType == "vegetable" ? new Vegetable(quantity)
                    : food = foodType == "fruit" ? new Fruit(quantity)
                    : food = foodType == "meat" ? new Meat(quantity)
                    : food = foodType == "seeds" ? new Seeds(quantity)
                    : throw new Exception();

                foods.Add(food);

                animal.AskForFood();
                animal.Eat(food);

                input = Console.ReadLine();
            }

            animals.ForEach(x => Console.WriteLine(x));
        }
    }
}

