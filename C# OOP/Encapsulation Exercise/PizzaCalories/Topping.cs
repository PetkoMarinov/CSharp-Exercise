using System;

namespace PizzaCalories
{
    public class Topping
    {
        private const double CaloriesPerGram = 2;
        private const double MeatModifier = 1.2;
        private const double VeggiesModifier = 0.80;
        private const double CheeseModifier = 1.1;
        private const double SauceModifier = 0.9;

        private string name;
        private double weight;

        public Topping(string name, int weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name 
        { 
            get { return this.name; }
            private set
            {
                switch (value.ToLower())
                {
                    case "meat":
                    case "veggies":
                    case "cheese":
                    case "sauce":
                        this.name = value;break;
                    default: throw new ArgumentException
                            ($"Cannot place {value} on top of your pizza.");
                }
            } 
        }

        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{Name} weight should be in the range [1..50].");
                }
                this.weight = value;
            }
        }

        public double GetCalories()
        {
            double calories = 0;

            calories = Name.ToLower() == "meat" ? Weight * CaloriesPerGram * MeatModifier :
                Name.ToLower() == "veggies" ? Weight * CaloriesPerGram * VeggiesModifier :
                Name.ToLower() == "cheese" ? Weight * CaloriesPerGram * CheeseModifier :
                Name.ToLower() == "sauce" ? Weight * CaloriesPerGram * SauceModifier : -1;

            return calories;
        }
    }
}
