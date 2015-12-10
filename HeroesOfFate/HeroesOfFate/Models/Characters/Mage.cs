using HeroesOfFate.Contracts.ICharacters;

namespace HeroesOfFate.Models.Characters
{
    public class Mage : Hero, IMage
    {
        private const double DamageDefault = 0;
        private const double HealthDefault = 0;
        private const double ArmorDefault = 0;

        public Mage(
            string name,
            double x,
            double y,
            Race heroRace,
            double damage,
            double health,
            double armor )
            :base(name,x,y,heroRace,damage,health,armor)
        {
                
        }
         
    }
}