using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class Program
    {
        static void Main(string[] args)
        {
            int amountOfHeroes = int.Parse(Console.ReadLine());
            List<BaseHero> heroes = new List<BaseHero>();

            while (heroes.Count < amountOfHeroes)
            {
                BaseHero hero;
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                try
                {
                    hero = type.ToLower() == "druid"
                        ? hero = new Druid(name)
                        : type.ToLower() == "paladin" ? hero = new Paladin(name)
                        : type.ToLower() == "rogue" ? hero = new Rogue(name)
                        : type.ToLower() == "warrior" ? hero = new Warrior(name)
                        : throw new Exception("Invalid hero!");

                    heroes.Add(hero);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            int bossPower = int.Parse(Console.ReadLine());

            heroes.ForEach(x => Console.WriteLine(x.CastAbility()));

            string battleResult = bossPower <= heroes.Sum(x => x.Power) ? "Victory!" : "Defeat...";
            Console.WriteLine(battleResult);
        }
    }
}
