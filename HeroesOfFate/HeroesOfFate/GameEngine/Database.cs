using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using HeroesOfFate.Contracts;

namespace HeroesOfFate.GameEngine
{
    public class Database
    {
        private ICollection<IMonster> monsters;
        private ICollection<IItem> items;
        private ICollection<IItemChest> itemChests; 

        public Database()
        {
            this.monsters = new List<IMonster>();
            this.items = new List<IItem>();
            this.itemChests = new List<IItemChest>();
        }

        public IEnumerable<IMonster> Monsters
        {
            get { return this.monsters; }
        }

        public IEnumerable<IItem> Items
        {
            get { return this.items; }
        }

        public IEnumerable<IItemChest> ItemChests
        {
            get { return itemChests; }
        } 

        public void AddMonster(params IMonster[] monsters)
        {
            foreach (var monster in monsters)
            {
                this.monsters.Add(monster);
            }
        }

        public void AddItem(IItem item)
        {
            this.items.Add(item);
        }

        public void AddItemChest(IItemChest itemChest)
        {
            this.itemChests.Add(itemChest);
        }

        public IItem GetitemByIndex(int index)
        {
            int count = 0;

            foreach (var item in this.Items)
            {
                if (count == index)
                {
                    return item;
                }
                count++;
            }

            return null;
        }
    }
}
