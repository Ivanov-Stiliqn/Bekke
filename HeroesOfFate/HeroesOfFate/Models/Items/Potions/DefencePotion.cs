namespace HeroesOfFate.Models.Items.Potions
{
    public class DefencePotion : Potion
    {
        private const double AttackDefault = 0;
        private const double ArmorDefault = 50;
        private const double HealthEffectDefault = 0;

        public DefencePotion(string id, decimal price) 
            : base(id, AttackDefault, ArmorDefault,HealthEffectDefault, price)
        {

        }
    }
}