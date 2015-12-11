using System;
using System.Security.AccessControl;

namespace HeroesOfFate.Models
{
    public abstract class Item
    {
        private ItemType type;
        private string id;
        private decimal price;

        protected Item(ItemType type, string id,decimal price)
        {
            Type = type;
            this.Id = id;
            this.Price = price;
        }

        public ItemType Type { get { return type; } set { type = value; } }

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