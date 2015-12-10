using System.Security.AccessControl;

namespace HeroesOfFate.Models
{
    public abstract class Item
    {
        private ItemType type;

        protected Item(string id)
        {
            Id = id;
            
        }
        public ItemType Type { get; set; }
        public string Id { get; set; }
    }
}