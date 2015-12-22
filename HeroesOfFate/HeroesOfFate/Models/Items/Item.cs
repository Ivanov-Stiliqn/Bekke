using System;
using HeroesOfFate.Contracts;

namespace HeroesOfFate.Models.Items
{
    public abstract class Item : IItem
    {
        private ItemType type;
        private string id;
        private decimal price;

        protected Item(string id,decimal price)
        {
            this.Type = type;
            this.Id = id;
            this.Price = price;
        }

        public ItemType Type
        {
            get { return this.type; }
            set { this.type = value; } 
            
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

        public virtual bool IsOneH { get; set; }
        //TODO: validation
        public double WeaponAttack { get; set; }

        public double ArmorDefence { get; set; }

        public double HealthEffect { get; set; }

        public override string ToString()
        {
            return string.Format("Type: {0}, Name: {1}", this.GetType().Name, this.Id);
        }
    }
}