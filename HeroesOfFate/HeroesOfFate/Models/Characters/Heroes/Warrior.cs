using HeroesOfFate.Contracts;
using HeroesOfFate.Models.Items.Armors;
using HeroesOfFate.Models.Items.Weapons.OneHWeapons;

namespace HeroesOfFate.Models.Characters.Heroes
{
    public class Warrior : Hero, IWarrior
    {
        private const double DamageMinDefault = 25;
        private const double DamageMaxDefault = 75;
        private const double HealthDefault = 250;
        private const double ArmorDefault = 125;
        private const double MaxHealthDefault = HealthDefault;
        
        public Warrior(string name, Race heroRace)
            :base(name, heroRace, DamageMinDefault, DamageMaxDefault, HealthDefault, ArmorDefault, MaxHealthDefault)
        {
            
        }

        public override string ToString()
        {
            return string.Format(base.ToString());
        }
    }
}