namespace HeroesOfFate.Models.Items.Potions
{
    public class HealthPotion : Potion
    {
        private const double AttackDefault = 0;
        private const double ArmorDefault = 0;
        private const double HealthEffect = 150;

        public HealthPotion(ItemType type, string id, double potionEffect, decimal price) 
            : base(type, id, AttackDefault, ArmorDefault, HealthEffect, price)
        {
        }
    }
}