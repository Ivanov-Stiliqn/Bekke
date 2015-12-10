
using HeroesOfFate.Contracts;
using HeroesOfFate.Contracts.ICharacters;

namespace HeroesOfFate.Models.Characters
{
    public class Archer : Hero, IArcher
    {
        private const double DamageDefault = 0;
        private const double HealthDefault = 0;
        private const double ArmorDefault = 0;
        private const double ArchDmgRedDefault = 0.15;

        public Archer(string name, Race heroRace)
            :base(name,heroRace,DamageDefault,HealthDefault,ArmorDefault)
        {
                
        }


    }
}