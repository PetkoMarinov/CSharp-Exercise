using System;

namespace PizzaCalories
{
    public class Dough
    {
        private const int CaloriesPerGram = 2;
        private const double WhiteDoughModifier = 1.5;
        private const double WholeGrainModifier = 1;
        private const double CrispyBakingTechniqueModifier = 0.9;
        private const double ChewyBakingTechniqueModifier = 1.1;
        private const double HomemadeBakingTechniqueModifier = 1;
        private string flour;
        private string bakingTechnique;
        private double weight;

        public Dough()
        {
        }

        public Dough(string flour, string bakingTechnique, double weight)
        {
            this.Flour = flour;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string Flour
        {
            get => this.flour;
            private set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.flour = value;
            }
        }

        public string BakingTechnique
        {
            get => this.bakingTechnique;
            private set
            {
                switch (value.ToLower())
                {
                    case "crispy":
                    case "chewy":
                    case "homemade":
                        this.bakingTechnique = value; break;
                    default: throw new ArgumentException("Invalid type of dough.");
                }
            }
        }

        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                this.weight = value;
            }
        }

        public double GetCalories()
        {
            double calories = 0;

            if (Flour.ToLower() =="white")
            {
                if (BakingTechnique.ToLower()== "crispy")
                {
                    calories = Weight * CaloriesPerGram
                        * WhiteDoughModifier * CrispyBakingTechniqueModifier;
                }
                else if (BakingTechnique.ToLower() == "chewy")
                {
                    calories = Weight * CaloriesPerGram
                        * WhiteDoughModifier * ChewyBakingTechniqueModifier;
                }
                else if(BakingTechnique.ToLower() == "homemade")
                {
                    calories = Weight * CaloriesPerGram
                        * WhiteDoughModifier * HomemadeBakingTechniqueModifier;
                }
            }
            else if(Flour.ToLower() == "wholegrain")
            {
                if (BakingTechnique.ToLower() == "crispy")
                {
                    calories = Weight * CaloriesPerGram
                        * WholeGrainModifier * CrispyBakingTechniqueModifier;
                }
                else if (BakingTechnique.ToLower() == "chewy")
                {
                    calories = Weight * CaloriesPerGram
                        * WholeGrainModifier * ChewyBakingTechniqueModifier;
                }
                else if (BakingTechnique.ToLower() == "homemade")
                {
                    calories = Weight * CaloriesPerGram
                        * WholeGrainModifier * HomemadeBakingTechniqueModifier;
                }
            }

            return calories;
        }
    }
}
