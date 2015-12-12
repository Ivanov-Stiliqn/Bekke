namespace HeroesOfFate.Models.Items
{
    public abstract class Armor : Item
    {
        private const double AttackDefault = 0;

        protected Armor(ItemType type, string id, double armorDefence, decimal price) : base(type, AttackDefault, armorDefence, id, price)
        {
            
        }
    }
}