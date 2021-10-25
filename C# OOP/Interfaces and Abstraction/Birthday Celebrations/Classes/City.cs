using System.Collections.Generic;
using System.Linq;
using BirthdayCelebrations.Classes;

namespace BirthdayCelebrations
{
    public class City
    {
        private List<Inhabitant> population = new List<Inhabitant>();

        public void AddInhabitant(Inhabitant inhabitant)
        {
            population.Add(inhabitant);
        }

        public List<Inhabitant> BornThisYear(string speciaficYear)
        {
            var bornThisYear = population
                .Where(x => x.GetType().FullName == "BirthdayCelebrations.Citizen"
                || x.GetType().ToString() == "BirthdayCelebrations.Pet")
                .Where(x => x.BirthYear() == speciaficYear)
                .ToList();

            return bornThisYear;
        }
    }
}
