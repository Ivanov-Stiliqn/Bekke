using System;
using HeroesOfFate.Contracts;

namespace HeroesOfFate.Models.Items
{
    public abstract class Item : IItem
    {
        private ItemType type;
        private double weaponAttack;
        private double armorDefence;
        private string id;
        private decimal price;

        protected Item(string id, double weaponAttack, double armorDefence, decimal price)
        {
            this.Type = type;
            this.Id = id;
            this.WeaponAttack = weaponAttack;
            this.ArmorDefence = armorDefence;
            this.Price = price;
        }

        public ItemType Type
        {
            get { return this.type; }
            set { this.type = value; } 
            
        }

        public double WeaponAttack
        {
            get { return this.weaponAttack; }
            set { this.weaponAttack = value; }
        }

        public double ArmorDefence
        {
            get { return this.armorDefence; }
            set { this.armorDefence = value; } 
        }

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