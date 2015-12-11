namespace HeroesOfFate.Models.Items.Potions
{
    public class ManaPotion : Potion
    {
        public ManaPotion(ItemType type, string id, double potionEffect, decimal price) : base(type, id, potionEffect, price)
        {
        }
    }
}