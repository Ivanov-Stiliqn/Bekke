using System;
using HeroesOfFate.Contracts;
using HeroesOfFate.GameEngine;

namespace HeroesOfFate.Models.Items.Chests
{
    public class GoldChest : Chest, IGoldChest
    {
        private double gold;
        private double exp;

        public GoldChest(string id, double gold, double exp) : base(id)
        {
            this.Gold = gold;
            this.Exp = exp;
        }

        public double Gold
        {
            get { return this.gold; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ExceptionConstants.NullOrNegativeException, "Gold"));
                }
                this.gold = value; 
            }
        }

        public double Exp
        {
            get { return this.exp; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ExceptionConstants.NullOrNegativeException, "Exp"));
                }
                this.exp = value; 
            }
        }
    }
}