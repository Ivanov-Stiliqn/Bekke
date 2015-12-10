namespace HeroesOfFate.Models
{
    public abstract class Item
    {
        private ItemType type;

        protected Item()
        {
            
        }

        public ItemType Type { get; set; }

       

    }
}