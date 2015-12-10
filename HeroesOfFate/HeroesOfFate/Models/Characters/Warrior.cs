using HeroesOfFate.Contracts.ICharacters;

namespace HeroesOfFate.Models.Characters
{
    public class Warrior : Hero, IWarrior
    {
        private const double DamageDefault = 0;
        private const double HealthDefault = 0;
        private const double ArmorDefault = 0;

      public Warrior(
            string name,
            Race heroRace,
            double damage,
            double health,
            double armor )
            :base(name,heroRace,damage,health,armor)
        {
                
        }


    }
}