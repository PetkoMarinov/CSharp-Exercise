using System;
using System.Collections.Generic;
using System.Text;

namespace _1._Person
{
    public class Child : Person
    {
        public Child(string name, int age)
            : base(name, age)
        {
        }

        public override int Age
        {
            get => base.Age;
            set
            {
                if (value > 15)
                {
                    Console.WriteLine("Deteto e dryto");  //throw new ArgumentException();
                }
                else
                {
                    base.Age = value;
                }
            }
        }

    }
}
