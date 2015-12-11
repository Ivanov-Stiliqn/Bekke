namespace HeroesOfFate.Models.Items.Potions
{
    public class HealthPotion : Potion
    {
        public HealthPotion(ItemType type, string id, double potionEffect, decimal price) : base(type, id, potionEffect, price)
        {
        }
    }
}