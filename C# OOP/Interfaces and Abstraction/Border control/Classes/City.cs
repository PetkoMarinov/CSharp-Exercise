using System;
using System.Collections.Generic;
using System.Linq;

using BorderControl.Classes;

namespace BorderControl
{
    public class City
    {
        private List<Inhabitant> Population = new List<Inhabitant>();

        public void AddInhabitant(Inhabitant inhabitant)
        {
            Population.Add(inhabitant);
        }

        public List<Inhabitant> Detained(string detain)
        {
            return Population
                .Where(x => x.Id.Substring(x.Id.Length - detain.Length, detain.Length) 
                == detain)
                .ToList();
        }
    }
}
