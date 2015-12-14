using System.Collections.Generic;

namespace HeroesOfFate.Models.Items.Chests
{
    public class ItemChest : Chest
    {
        private readonly List<Item> lootTable;

        public ItemChest(string id) : base(id)
        {
            this.lootTable = new List<Item>();
        }

        public IEnumerable<Item> LootTable
        {
            get { return this.lootTable; }
        }

        public void AddItemToChest(Item item)
        {
            this.lootTable.Add(item);
        }
    }
}