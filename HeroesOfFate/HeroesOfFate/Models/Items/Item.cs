using System.Security.AccessControl;

namespace HeroesOfFate.Models
{
    // TO DO : ADD VALIDATION
    public abstract class Item
    {
        private ItemType type;
        private decimal price;

        protected Item(string id,decimal price)
        {
            this.Id = id;
            this.Price = price;
        }
        public ItemType Type { get; set; }

        public string Id { get; set; }

        public decimal Price { get; set; }
    }
}