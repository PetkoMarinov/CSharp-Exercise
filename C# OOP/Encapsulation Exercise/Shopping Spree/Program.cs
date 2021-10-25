using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            string peopleData = Console.ReadLine();
            string productData = Console.ReadLine();

            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();
            try
            {
                if (peopleData.Split(';') != null)
                {
                    string[] temp = peopleData.Split(';', StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < temp.Length; i++)
                    {
                        string personName = temp[i].Split('=')[0];
                        double personMoney = double.Parse(temp[i].Split('=')[1]);
                        people.Add(new Person(personName, personMoney));
                    }
                }
                else
                {
                    string personName = peopleData.Split('=')[0];
                    double personMoney = double.Parse(peopleData.Split('=')[1]);
                    people.Add(new Person(personName, personMoney));
                }

                if (productData.Split(';') != null)
                {
                    string[] temp = productData.Split(';', StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < temp.Length; i++)
                    {
                        string productName = temp[i].Split('=')[0];
                        double productCost = double.Parse(temp[i].Split('=')[1]);
                        products.Add(new Product(productName, productCost));
                    }
                }
                else
                {
                    string productName = productData.Split('=')[0];
                    double productCost = double.Parse(productData.Split('=')[1]);
                    products.Add(new Product(productName, productCost));
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }


            string command = Console.ReadLine();

            while (command != "END")
            {
                string person = command.Split(' ')[0];
                string product = command.Split(' ')[1];
                people.Find(p => p.Name == person).AddProduct(products.Find(p => p.Name == product));

                command = Console.ReadLine();
            }

            foreach (var person in people)
            {
                if (person.BagOfProducts.Count == 0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                    continue;
                }

                Console.WriteLine($"{person.Name} - {string.Join(", ", person.BagOfProducts)}");
            }
        }
    }
}
