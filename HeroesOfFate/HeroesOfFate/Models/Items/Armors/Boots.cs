namespace HeroesOfFate.Models.Items.Armors
{
    public class Boots : Armor
    {
        public Boots(string id, double bootsDefence, decimal price) : base(id, bootsDefence, price)
        {
            this.Type = ItemType.Boots;
        }
    }
}