using System;
using System.Linq;
using HeroesOfFate.Contracts.ICharacters;
using HeroesOfFate.Models.Items;

namespace HeroesOfFate.Models.Characters.Heroes
{
    public class Warrior : Hero, IWarrior
    {
        private const double DamageDefault = 75;
        private const double HealthDefault = 250;
        private const double ArmorDefault = 125;
        private const double WrrDmgRedDefault = 0.40;

        public Warrior(string name, Race heroRace)
            :base(name,heroRace,DamageDefault,HealthDefault,ArmorDefault)
        {

        }

        public override string ToString()
        {
            return string.Format(base.ToString());
        }
    }
}