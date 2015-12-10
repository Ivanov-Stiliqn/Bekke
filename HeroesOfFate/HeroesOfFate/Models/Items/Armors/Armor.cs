namespace HeroesOfFate.Models.Items
{
    public class Armor : Item
    {
        public Armor(string id, double armorDefence, decimal price) : base(id, price)
        {
            this.ArmorDefence = armorDefence;
        }

        public double ArmorDefence { get; set; }
    }
}