using System;
using HeroesOfFate.Contracts;
using HeroesOfFate.GameEngine;

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
            set 
            {
                if (value == null)
                {
                    throw new ArgumentException(string.Format(ExceptionConstants.NullOrEmptyException, "Item type"));
                }
                this.type = value; 
            } 
            
        }

        public string Id
        {
            get { return id; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(string.Format(ExceptionConstants.NullOrNegativeException, "Item id"));
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
                    throw new ArgumentOutOfRangeException(string.Format(ExceptionConstants.NullOrNegativeException, "Item price"));
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