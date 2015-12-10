using HeroesOfFate.Contracts.ICharacters;

namespace HeroesOfFate.Models.Characters
{
    public class Warrior : Hero, IWarrior
    {
        private const double DamageDefault = 0;
        private const double HealthDefault = 0;
        private const double ArmorDefault = 0;
        private const double WrrDmgRedDefault = 0.20;

      public Warrior(string name, Race heroRace)
            :base(name,heroRace,DamageDefault,HealthDefault,ArmorDefault)
        {
                
        }


    }
}