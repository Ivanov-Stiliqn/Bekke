
using System;
using HeroesOfFate.Contracts;

namespace HeroesOfFate.Models
{
    public abstract class Creature : ICreature
    {
        private const double DamageDefault = 0;
        private const double HealthDefault = 0;
        private const double ArmorDefault = 0;
        private const short LevelDefault = 1;
        private const short ExpDefault = 0;

        private short exp;
        private short level;
        private double damage;
        private double health;
        private double armor;
        private bool isDead;

        protected Creature(double x,double y,short exp=ExpDefault,short level=LevelDefault,
            double damage=DamageDefault,double health=HealthDefault,double armor=ArmorDefault)
        {
            
            this.X = x;
            this.Y = y;
            this.Exp = exp;
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

        public double X { get; protected set; }

        public double Y { get; protected set; }

        public short Exp
        {
            get { return this.exp; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Experience cannot be negative");
                }
                this.exp = value;
            }
        }

        public short Level
        {
            get { return this.level; }
            protected set
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
