using System;

namespace WildFarm.Classes.Amimals.Mammals
{
    public class Dog : Mammal
    {
        private int foodEaten;

        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override int FoodEaten => foodEaten;

        public override void AskForFood()
        {
            Console.WriteLine("Woof!");
        }

        public override void Eat(Food food)
        {
            if (food is Meat)
            {
                foodEaten = FoodEaten + food.Quantity;
                Weight += food.Quantity * 0.40;
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
