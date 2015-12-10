using HeroesOfFate.Contracts.ICharacters;

namespace HeroesOfFate.Models.Characters
{
    public class Mage : Hero, IMage
    {
        private const double DamageDefault = 0;
        private const double HealthDefault = 0;
        private const double ArmorDefault = 0;
        private const double MageDmgRedDefault = 0.10;

        public Mage(string name, Race heroRace)
            :base(name,heroRace,DamageDefault,HealthDefault,ArmorDefault)
        {
                
        }
         
    }
}