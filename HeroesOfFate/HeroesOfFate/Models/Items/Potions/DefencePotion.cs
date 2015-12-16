using HeroesOfFate.Contracts;

namespace HeroesOfFate.Models.Items.Potions
{
    public class DefencePotion : Potion,IDeffence
    {
        
        private const double ArmorDefault = 50;

        public DefencePotion(string id, decimal price) 
            : base(id, price)
        {
            this.ArmorDefence = ArmorDefault;
        }
    }
}