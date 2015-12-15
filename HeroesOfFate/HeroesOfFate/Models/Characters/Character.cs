﻿using System;
using HeroesOfFate.Contracts;

namespace HeroesOfFate.Models.Characters
{
    public abstract class Character : ICharacter
    {
        private int level;
        private double health;
        private double damageMin;
        private double damageMax;
        private bool isDead;

        protected Character(
            int level,
            double health,
            double damageMin,
            double damageMax)
        {

            this.Level = level;
            this.DamageMin = damageMin;
            this.DamageMax = damageMax;
            this.Health = health;
            this.isDead = false;
        }

        public int Level
        {
            get { return this.level; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("level", "Level cannot be negative");
                }
                this.level = value;
            }
        }

        public double Health
        {
            get { return this.health; }
            set
            {
                if (value <= 0)
                {
                    isDead = true;
                }
                this.health = value;
            }
        }

        public double DamageMin
        {
            get { return this.damageMin; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("minimum damage", "Damage cannot be 0 or negative !");
                }
                this.damageMin = value;
            } 
        }

        public double DamageMax
        {
            get { return this.damageMax; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("maximum damage", "Damage cannot be 0 or negative !");
                }
                this.damageMax = value;
            }
        }

        public bool IsDead
        {
            get { return this.isDead; }
        }
    }
}