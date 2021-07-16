using BorderControl.Classes;
using System.Collections.Generic;

namespace BorderControl
{
    public class Citizen : Inhabitant
    {
        public Citizen(string name, int age, string id) : base(name, id)
        {
            this.Age = age;
        }

        public int Age { get; }
    }
}
