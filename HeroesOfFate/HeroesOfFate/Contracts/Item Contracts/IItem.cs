using HeroesOfFate.Models.Items;

namespace HeroesOfFate.Contracts
{
    public interface IItem
    {
        ItemType Type { get; set; }

        double WeaponAttack{ get; set; }

        double ArmorDefence{ get; set; }

        string Id { get; set; }

        decimal Price { get; set; }
    }
}