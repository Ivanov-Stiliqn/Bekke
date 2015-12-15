namespace HeroesOfFate.Models.Items.Potions
{
    public class AttackPotion : Potion
    {
        private const double AttackDefault = 100;
        private const double ArmorDefault = 0;
        private const double HealthEffectDefault = 0;

        public AttackPotion(string id, decimal price) 
            : base(id, AttackDefault, ArmorDefault,HealthEffectDefault, price)
        {

        }
    }
}