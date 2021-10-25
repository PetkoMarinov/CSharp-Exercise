using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, double[]> studentData = new Dictionary<string, double[]>();

            for (int i = 0; i < n; i++)
            {
                string student = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!studentData.ContainsKey(student))
                {
                    studentData.Add(student, new double[n]);
                }

                studentData[student][i] = grade;
            }

            string[] keys = studentData.Keys.ToArray();

            for (int i = 0; i < keys.Length; i++)
            {
                studentData[keys[i]] = studentData[keys[i]]
                    .Where(x => x != 0)
                    .ToArray();

                if (studentData[keys[i]].Average() < 4.50)
                {
                    studentData.Remove(keys[i]);
                }
            }

            foreach (var item in studentData.OrderByDescending(x => x.Value.Average()))
            {
                Console.WriteLine($"{item.Key} -> {item.Value.Average():f2}");
            }

        }
    }
}