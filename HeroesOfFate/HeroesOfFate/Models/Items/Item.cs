﻿using System;
using System.Security.AccessControl;

namespace HeroesOfFate.Models
{
    public abstract class Item
    {
        private ItemType type;
        private double weaponAttack;
        private double armorDefence;
        private string id;
        private decimal price;

        protected Item(double weaponAttack, double armorDefence, string id,decimal price)
        {
            Type = type;
            WeaponAttack = weaponAttack;
            ArmorDefence = armorDefence;
            this.Id = id;
            this.Price = price;
        }

        public ItemType Type { get { return this.type; } set { this.type = value; } }

        public double WeaponAttack { get; set; }

        public double ArmorDefence { get; set; }

        public string Id
        {
            get { return id; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("item id", "Item name cannot be null or empty !");
                }
                id = value;
            }
            
        }

        public decimal Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("item price", "Price cannot be negative !");
                }
                price = value;
            }
        }
    }
}