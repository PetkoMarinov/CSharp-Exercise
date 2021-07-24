using System;

namespace WildFarm
{
    public class Hen : Bird
    {
        private int foodEaten;

        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override int FoodEaten => foodEaten;

        public override void Eat(Food food)
        {
            foodEaten = FoodEaten + food.Quantity;
            Weight += food.Quantity * 0.35;
        }

        public override void AskForFood()
        {
            Console.WriteLine("Cluck");
        }
    }
}
