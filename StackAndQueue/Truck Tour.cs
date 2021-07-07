using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Truck_Tour
{
    class Program
    {

        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Queue<int[]> pumps = new Queue<int[]>();

            for (int i = 0; i < count; i++)
            {
                int[] petrolPump = Console.ReadLine().Split().Select(int.Parse).ToArray();
                pumps.Enqueue(petrolPump);
            }

            int index = 0;

            while (true)
            {
                int totalFuel = 0;

                foreach (int [] pump in pumps)
                {
                    int petrol = pump[0];
                    int distance = pump[1];
                    totalFuel += petrol - distance;

                    if (totalFuel<0)
                    {
                        pumps.Enqueue(pumps.Dequeue());
                        index++;
                        break;
                    }
                }

                if (totalFuel>=0)
                {
                    break;
                }
            }
            Console.WriteLine(index);
        }
    }
}