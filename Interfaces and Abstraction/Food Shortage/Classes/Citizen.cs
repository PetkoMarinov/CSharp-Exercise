using System;
using FoodShortage.Classes;
using FoodShortage.Interfaces;

namespace FoodShortage
{
    public class Citizen : Population
    {
        private int tempFood = 0;

        public Citizen(string name, int age, string id, string birthdate)
            : base(name,age)
        {
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public string Id { get; }
        public string Birthdate { get; }

        public override int Food { get => tempFood; }

        public override void BuyFood()
        {
            this.tempFood += 10;
        }

        public override void Print(string property)
        {
            Console.WriteLine(property.ToLower() == "name" ? Name
                : property.ToLower() == "age" ? Age.ToString()
                : property.ToLower() == "id" ? Id
                : property.ToLower() == "birthdate" ? Birthdate : throw new Exception());
        }
    }
}

