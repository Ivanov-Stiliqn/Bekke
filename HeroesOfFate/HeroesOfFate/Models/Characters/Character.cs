using System;
using HeroesOfFate.Contracts.ICharacters;

namespace HeroesOfFate.Models.Characters
{
    public abstract class Character : ICharacter
    {
        private int level;
        private double damage;
        private double health;
        private double armor;
        private bool isDead;

        protected Character(
            double damage,
            double health,
            double armor,
            int level)
        {
            
            this.Level = level;
            this.Damage = damage;
            this.Health = health;
            this.Armor = armor;
            this.isDead = false;
        }

        public double Damage 
        {
            get { return this.damage; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Damage cannot be neggative !");
                }
                this.damage = value;
            }
        }

        public double Health
        {
            get { return this.health; }
            set
            {
                if (value < 0)
                {
                    isDead = true;
                }
                this.health = value;
            }
        }

        public double Armor
        {
            get { return this.armor; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Armor cannot be neggative !");
                }
                this.armor = value;
            }
        }

        public int Level
        {
            get { return this.level; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Level cannot be negative");
                }
                this.level = value;
            }
        }

        public bool IsDead
        {
            get { return this.isDead; }
        }

    }
}