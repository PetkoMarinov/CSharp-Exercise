using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int food = int.Parse(Console.ReadLine());
            int[] ordersQty = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Queue<int> orders = new Queue<int>(ordersQty);

            int biggestOrder = int.MinValue;

            int numberOfOrders = orders.Count;

            for (int i = 0; i < numberOfOrders; i++)
            {
                int nextОrder = orders.Dequeue();
                orders.Enqueue(nextОrder);

                if (biggestOrder < nextОrder)
                {
                    biggestOrder = nextОrder;
                }
            }

            Console.WriteLine(biggestOrder);

            while (orders.Count > 0)
            {
                int nextОrder = orders.Peek();

                if (food >= nextОrder)
                {
                    food -= nextОrder;
                    nextОrder = orders.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(" ", orders)}"); break;
                }
            }

            if (orders.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
