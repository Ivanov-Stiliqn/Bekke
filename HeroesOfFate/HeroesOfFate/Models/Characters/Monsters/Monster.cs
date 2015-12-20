using System.Collections.Generic;
using HeroesOfFate.Contracts;

namespace HeroesOfFate.Models.Characters.Monsters
{
    public abstract class Monster : Character, IMonster
    {
        private const short MonsterLevelDefault = 1;
        private const double GoldRewardDefault = 50;

        private readonly List<IItem> lootTable;
        private double goldReward;

        protected Monster(
            double damageMin,
            double damageMax,
            double health
            )
            :base(MonsterLevelDefault, damageMin, damageMax, health)
        {
            this.lootTable = new List<IItem>();
            this.GoldReward = GoldRewardDefault;
        }

        public IEnumerable<IItem> LootTable
        {
            get { return this.lootTable; }
        }

        public double GoldReward
        {
            get { return this.goldReward; }
            set { this.goldReward = value; }
        }

        public void LevelUp(int level)
        {
            this.Level = level;
            this.DamageMin += 5 * level;
            this.DamageMax += 5 * level;
            this.Health += 10 * level;
            this.GoldReward += 25 * level;
        }

        public void AddItemToLootTable(params IItem[] items)
        {
            foreach (var item in items)
            {
                this.lootTable.Add(item);
            }
        }

        //Test !!!
        public override string ToString()
        {
            return string.Format(this.GetType().Name);
        }
        //Test !!!
    }
}