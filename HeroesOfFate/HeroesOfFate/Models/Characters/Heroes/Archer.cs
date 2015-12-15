using HeroesOfFate.Contracts;
using HeroesOfFate.Models.Items.Weapons.TwoHWeapons;

namespace HeroesOfFate.Models.Characters.Heroes
{
    public class Archer : Hero, IArcher
    {
        private const double DamageMinDefault = 75;
        private const double DamageMaxDefault = 100;
        private const double HealthDefault = 200;
        private const double ArmorDefault = 100;
        private const double MaxHealthDefault = HealthDefault;

        public Archer(string name, Race heroRace)
            : base(name, heroRace, DamageMinDefault, DamageMaxDefault, HealthDefault, ArmorDefault, MaxHealthDefault)
        {
            
        }

        public override string ToString()
        {
            return string.Format(base.ToString());
        }
    }
}