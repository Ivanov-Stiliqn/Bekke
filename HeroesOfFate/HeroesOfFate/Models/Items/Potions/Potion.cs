namespace HeroesOfFate.Models.Items
{
    public class Potion : Item
    {
        protected Potion(ItemType type, string id, double potionEffect, decimal price) : base(type, id, price)
        {
            PotionEffect = potionEffect;
        }

        public double PotionEffect;
    }
}