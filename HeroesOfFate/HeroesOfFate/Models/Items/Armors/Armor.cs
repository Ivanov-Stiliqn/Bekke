namespace HeroesOfFate.Models.Items.Armors
{
    public class Armor : Item
    {
        private const double AttackDefault = 0;

        protected Armor(string id, double armorDefence, decimal price) 
            : base(id, AttackDefault, armorDefence, price)
        {
            
        }
    }
}