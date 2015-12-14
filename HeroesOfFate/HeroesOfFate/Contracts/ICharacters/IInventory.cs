using HeroesOfFate.Models.Items;

namespace HeroesOfFate.Contracts.ICharacters
{
    public interface IInventory
    {
        void AddItemToInventory(Item item);

        void RemoveItemFromInventory(Item item);
    }
}
