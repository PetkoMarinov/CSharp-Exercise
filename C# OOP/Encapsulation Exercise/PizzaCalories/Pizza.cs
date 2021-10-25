using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;

        public Pizza()
        {
            this.toppings = new List<Topping>();
        }

        public Pizza(string name) : this()
        {
            this.Name = name;
        }

        public Pizza(string name, Dough dough) : this(name)
        {
            this.Dough = dough;
        }

        public Dough Dough { get; set; }
        public List<Topping> Toppings { get => this.toppings; }

        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException($"Pizza name " +
                        $"should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }

        public double Calories =>  //това е геттер
                this.Dough.GetCalories() + this.Toppings.Sum(t => t.GetCalories());


        public void AddTopping(Topping topping)
        {
            if (this.Toppings.Count >= 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            toppings.Add(topping);
        }

        public override string ToString()
        {
            return $"{Name} - {Calories:f2} Calories.";
        }
    }
}
