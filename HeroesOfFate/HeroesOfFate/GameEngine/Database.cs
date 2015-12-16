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

        public Database()
        {
            this.monsters = new List<IMonster>();
            this.items = new List<IItem>();
        }

        public IEnumerable<IMonster> Monsters
        {
            get { return this.monsters; }
        }

        public IEnumerable<IItem> Items
        {
            get { return this.items; }
        }

        public void AddMonster(IMonster monster)
        {
            this.monsters.Add(monster);
        }

        public void AddItem(IItem item)
        {
            this.items.Add(item);
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
