using System;
using System.Collections.Generic;

namespace SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, string> parkingData = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];
                string user = input[1];
                string plateNumber = string.Empty;
                
                if (command=="register")
                {
                    plateNumber = input[2];

                    if (!parkingData.ContainsKey(user))
                    {
                        parkingData.Add(user, plateNumber);
                        Console.WriteLine($"{user} registered {plateNumber} successfully");
                    }
                    else
                    {
                        Console.WriteLine("ERROR: already registered with " +
                            $"plate number { plateNumber}");
                    }
                }
                else if (command == "unregister")
                {
                    if (!parkingData.ContainsKey(user))
                    {
                        Console.WriteLine($"ERROR: user {user} not found");
                    }
                    else
                    {
                        parkingData.Remove(user);
                        Console.WriteLine($"{user} unregistered successfully");
                    }
                }
            }

            foreach (var item in parkingData)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }

        }
    }
}
