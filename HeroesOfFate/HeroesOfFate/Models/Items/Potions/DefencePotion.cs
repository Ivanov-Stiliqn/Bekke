namespace HeroesOfFate.Models.Items.Potions
{
    public class DefencePotion : Potion
    {
        private const double AttackDefault = 0;
        private const double ArmorDefault = 50;
        private const double HealthEffect = 0;

        public DefencePotion(ItemType type, string id, decimal price) 
            : base(type, id, AttackDefault, ArmorDefault,HealthEffect, price)
        {
        }
    }
}