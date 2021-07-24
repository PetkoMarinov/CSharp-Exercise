namespace WildFarm.Classes.Amimals.Mammals
{
    public abstract class Feline : Mammal 
    {
        public Feline(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion)
        {
            Breed = breed;
        }

        public string Breed { get; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Breed}, {Weight}," +
                $" {LivingRegion}, {FoodEaten}]";
        }
    }
}
