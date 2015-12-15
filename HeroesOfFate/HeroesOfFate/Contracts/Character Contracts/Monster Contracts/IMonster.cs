using System.Collections.Generic;

namespace HeroesOfFate.Contracts
{
    public interface IMonster
    {
        double GoldReward { get; set; }

        IEnumerable<IItem> LootTable { get; }

        void LevelUp(int level);

        void AddItemToLootTable(params IItem[] items);
    }
}