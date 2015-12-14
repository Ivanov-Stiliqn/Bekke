using System.Collections.Generic;
using HeroesOfFate.Models.Items;

namespace HeroesOfFate.Models.Characters.Monsters
{
    public abstract class Monster : Character
    {
        private const short MonsterLevelDefault = 1;
        private const double GoldRewardDefault = 50;

        private readonly List<Item> lootTable;

        private double goldReward;

        protected Monster(
            double damage,
            double health,
            double armor,
            int level = MonsterLevelDefault)
            :base(damage,health,armor,level)
        {
            this.lootTable = new List<Item>();
            this.GoldReward = GoldRewardDefault;
        }

        public IEnumerable<Item> LootTable
        {
            get { return lootTable; }
        }

        public double GoldReward
        {
            get { return this.goldReward; }
            set { goldReward = value; }
        }

        public void LevelUp(int level)
        {
            this.Level = level;
            this.Damage += 5 * level;
            this.Health += 10 * level;
            this.GoldReward += 25 * level;
        }

        public void AddItemToLootTable(Item item)
        {
            this.lootTable.Add(item);
        }
    }
}