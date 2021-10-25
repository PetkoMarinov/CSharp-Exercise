using FoodShortage.Classes;
using System;

namespace FoodShortage
{
    public class Rebel : Population
    {
        private int tempFood = 0;
        public Rebel(string name, int age, string group) : base(name, age)
        {
            this.Group = group;
        }

        public string Group { get; }
        public override int Food { get => tempFood; }

        public override void BuyFood() => tempFood += 5;

        public override void Print(string property)
        {
            Console.WriteLine(property.ToLower() == "name" ? Name
                : property.ToLower() == "age" ? Age.ToString()
                : property.ToLower() == "group" ? Group : throw new Exception());
        }
    }
}
