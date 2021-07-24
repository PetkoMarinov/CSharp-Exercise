using System;

namespace WildFarm.Classes.Amimals.Mammals
{
    public class Mouse : Mammal
    {
        private int foodEaten;

        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override int FoodEaten => foodEaten;

        public override void AskForFood()
        {
            Console.WriteLine("Squeak");
        }

        public override void Eat(Food food)
        {
            if (food is Vegetable || food is Fruit)
            {
                foodEaten = FoodEaten + food.Quantity;
                Weight += food.Quantity * 0.10;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
