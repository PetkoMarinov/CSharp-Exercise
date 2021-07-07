using System;
using System.Collections.Generic;

namespace Orders
{
    class Orders
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, List<double>> products = new Dictionary<string, List<double>>();

            while (input != "buy")
            {
                string product = input.Split()[0];
                double price = double.Parse(input.Split()[1]);
                double quantity = double.Parse(input.Split()[2]);

                if (!products.ContainsKey(product))
                {
                    products.Add(product, new List<double>() { price, quantity });
                }
                else
                {
                    products[product][0] = price;
                    products[product][1] += quantity;
                }

                input = Console.ReadLine();
            }

            foreach (var item in products)
            {
                Console.WriteLine($"{item.Key} -> {item.Value[0] * item.Value[1]:f2}");
            }

        }
    }
}