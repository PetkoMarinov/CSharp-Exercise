using System.Collections.Generic;
using System.Linq;
using BorderControl.Interfaces;

namespace BorderControl.Classes
{
    public class Inhabitant : IIdentical, INameable
    {
        public string Id { get; }

        public string Name { get; }

        public Inhabitant(string name, string id)
        {
            this.Name = name;
            this.Id = id;
        }

        public override string ToString()
        {
            return Id;
        }
    }
}
