using System;
using System.Linq;
using HeroesOfFate.Contracts.ICharacters;
using HeroesOfFate.Models.Items;

namespace HeroesOfFate.Models.Characters.Heroes
{
    public class Mage : Hero, IMage
    {
        private const double DamageDefault = 125;
        private const double HealthDefault = 150;
        private const double ArmorDefault = 75;
        private const double MageDmgRedDefault = 0.20;
        private const double MaxHealthDefault = HealthDefault;
        


        public Mage(string name, Race heroRace)
            : base(name, heroRace, DamageDefault, HealthDefault, ArmorDefault,MaxHealthDefault)
        {
            
        }

        

        public override string ToString()
        {
            return string.Format(base.ToString());
        }
    }
}