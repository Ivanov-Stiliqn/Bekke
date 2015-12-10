namespace HeroesOfFate.Models.Items
{
    public class Armor : Item
    {
        public Armor(string id, double armorDefence) : base(id)
        {
            ArmorDefence = armorDefence;
        }

        public double ArmorDefence;
    }
}