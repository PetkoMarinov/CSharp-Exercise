using System;

namespace WildFarm
{
    public class Owl : Bird
    {
        private int foodEaten;

        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override int FoodEaten => foodEaten;

        public override void Eat(Food food)
        {
            if (food is Meat)
            {
                foodEaten = FoodEaten + food.Quantity;
                Weight += food.Quantity * 0.25;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override void AskForFood()
        {
            Console.WriteLine("Hoot Hoot");
        }
    }
}
