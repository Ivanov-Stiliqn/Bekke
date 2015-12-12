namespace HeroesOfFate.Models.Items.Armors
{
    public class Gloves : Armor
    {
        public Gloves(string id, double glovesDefence, decimal price) : base(id, glovesDefence, price)
        {
            this.Type = ItemType.Gloves;
        }
    }
}