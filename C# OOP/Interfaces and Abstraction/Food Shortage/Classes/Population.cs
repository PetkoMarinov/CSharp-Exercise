using FoodShortage.Interfaces;

namespace FoodShortage.Classes
{
    public abstract class Population : INameable, IAgeable, IBuyer
    {
        public string Name { get; }

        public int Age { get; }

        public abstract int Food { get; }

        public Population(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public abstract void Print(string property);

        public abstract void BuyFood();

    }
}
