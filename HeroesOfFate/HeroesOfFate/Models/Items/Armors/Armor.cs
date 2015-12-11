namespace HeroesOfFate.Models.Items
{
    public class Armor : Item
    {
        protected Armor(ItemType type, string id, double armorDefence, decimal price) : base(type, id, price)
        {
            this.ArmorDefence = armorDefence;
        }

        public double ArmorDefence { get; set; }
    }
}