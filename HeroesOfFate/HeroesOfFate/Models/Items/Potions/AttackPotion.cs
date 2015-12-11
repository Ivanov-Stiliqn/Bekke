namespace HeroesOfFate.Models.Items.Potions
{
    public class AttackPotion : Potion
    {
        public AttackPotion(ItemType type, string id, double potionEffect, decimal price) : base(type, id, potionEffect, price)
        {
        }
    }
}