using System;
using System.Text;

namespace _1._Person
{
    public class Person
    {
        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public virtual int Age
        {
            get => this.age;
            set 
                {
                if (value < 0)
                {
                    Console.WriteLine("Ne stava"); //throw new ArgumentException("Ne stava"); 
                }
                else
                {
                    this.age = value;
                }
            }
        }

        public string Name { get;  set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(String.Format("Name: {0}, Age: {1}",
                                 this.Name,
                                 this.Age));

            return sb.ToString();
        }

    }
}
