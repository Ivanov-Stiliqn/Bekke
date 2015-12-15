namespace HeroesOfFate.Models.Items.Potions
{
    public class HealthPotion : Potion
    {
        private const double AttackDefault = 0;
        private const double ArmorDefault = 0;
        private const double HealthEffectDefault = 150;

        public HealthPotion(string id, decimal price) 
            : base(id, AttackDefault, ArmorDefault, HealthEffectDefault, price)
        {

        }
    }
}