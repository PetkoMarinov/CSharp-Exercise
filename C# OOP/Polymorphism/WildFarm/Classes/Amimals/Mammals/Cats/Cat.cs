using System;

namespace WildFarm.Classes.Amimals.Mammals.Cats
{
    public class Cat : Feline
    {
        private int foodEaten;

        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override int FoodEaten => foodEaten;

        public override void Eat(Food food)
        {
            if (food is Vegetable || food is Meat)
            {
                foodEaten = FoodEaten + food.Quantity;
                Weight += food.Quantity * 0.30;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override void AskForFood()
        {
            Console.WriteLine("Meow");
        }
    }
}
