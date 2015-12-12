namespace HeroesOfFate.Models.Items.Potions
{
    public class AttackPotion : Potion
    {
        private const double AttackDefault = 100;
        private const double ArmorDefault = 0;
        private const double HealthEffect = 0;

        public AttackPotion(ItemType type, string id, decimal price) 
            : base(type, id, AttackDefault, ArmorDefault,HealthEffect, price)
        {
        }
    }
}