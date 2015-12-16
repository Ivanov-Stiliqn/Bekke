using HeroesOfFate.Contracts;

namespace HeroesOfFate.Models.Items.Potions
{
    public class AttackPotion : Potion,IDamage
    {
        private const double AttackDefault = 100;
       
        public AttackPotion(string id, decimal price) 
            : base(id, price)
        {
            this.WeaponAttack = AttackDefault;
        }
    }
}