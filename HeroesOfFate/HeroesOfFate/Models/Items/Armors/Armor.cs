using HeroesOfFate.Contracts.Item_Contracts;

namespace HeroesOfFate.Models.Items.Armors
{
    public class Armor : Item, IArmor
    {

        protected Armor(string id, double armorDefence, decimal price) 
            : base(id, price)
        {
            this.ArmorDefence = armorDefence;
        }
    }
}