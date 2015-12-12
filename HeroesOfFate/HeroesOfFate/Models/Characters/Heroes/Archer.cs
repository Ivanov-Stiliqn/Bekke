using System;
using System.Linq;
using HeroesOfFate.Contracts.ICharacters;
using HeroesOfFate.Models.Items;

namespace HeroesOfFate.Models.Characters.Heroes
{
    public class Archer : Hero, IArcher
    {
        private const double DamageDefault = 100;
        private const double HealthDefault = 200;
        private const double ArmorDefault = 100;
        private const double ArchDmgRedDefault = 0.30;

        public Archer(string name, Race heroRace)
            : base(name, heroRace, DamageDefault, HealthDefault, ArmorDefault)
        {

        }

        public override string ToString()
        {
            return string.Format(base.ToString());
        }
    }
}