namespace WildFarm
{
    public abstract class Animal
    {
        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; }

        public double Weight { get; protected set; }

        public virtual int FoodEaten { get;}

        public abstract void AskForFood();

        public abstract void Eat(Food food);
    }
}
