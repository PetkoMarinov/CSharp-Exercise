using System;
using System.Linq;

namespace PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Pizza pizza = new Pizza();
            Dough dough;
            Topping topping;

            while (input != "END")
            {
                string[] command = input.Split(' ');

                try
                {
                    switch (command[0])
                    {
                        case "Pizza":
                            string name = command[1];
                            pizza.Name = name;
                            break;

                        case "Dough":
                            string flour = command[1];
                            string bakingTechnique = command[2];
                            double weight = double.Parse(command[3]);
                            dough = new Dough(flour, bakingTechnique, weight);
                            pizza.Dough = dough;
                            break;

                        case "Topping":
                            string toppingName = command[1];
                            int toppingWeight = int.Parse(command[2]);
                            topping = new Topping(toppingName, toppingWeight);
                            pizza.AddTopping(topping);
                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    return;
                }
                
                input = Console.ReadLine();
            }

            Console.WriteLine(pizza);
        }
    }
}
