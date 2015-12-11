namespace HeroesOfFate.Models.Items.Potions
{
    public class ExpPotion : Potion
    {
        public ExpPotion(ItemType type, string id, double potionEffect, decimal price) : base(type, id, potionEffect, price)
        {
        }
    }
}