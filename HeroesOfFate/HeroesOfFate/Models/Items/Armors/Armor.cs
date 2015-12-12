namespace HeroesOfFate.Models.Items
{
    public abstract class Armor : Item
    {
        private const double AttackDefault = 0;

        protected Armor(string id, double armorDefence, decimal price) : base(AttackDefault, armorDefence, id, price)
        {
            
        }
    }
}