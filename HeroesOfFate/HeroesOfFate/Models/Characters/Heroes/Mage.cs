using HeroesOfFate.Contracts;
using HeroesOfFate.Models.Items.Weapons.TwoHWeapons;

namespace HeroesOfFate.Models.Characters.Heroes
{
    public class Mage : Hero, IMage
    {
        private const double DamageMinDefault = 75;
        private const double DamageMaxDefault = 125;
        private const double HealthDefault = 150;
        private const double ArmorDefault = 75;
        private const double MaxHealthDefault = HealthDefault;
        
        public Mage(string name, Race heroRace)
            : base(name, heroRace, DamageMinDefault, DamageMaxDefault, HealthDefault, ArmorDefault,MaxHealthDefault)
        {
            
        }

        public override string ToString()
        {
            return string.Format(base.ToString());
        }
    }
}