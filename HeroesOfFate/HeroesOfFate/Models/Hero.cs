using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesOfFate.Models
{
    public abstract class Hero : Character
    {
        private List<Item> inventory;


        protected Hero(int x, int y, short exp, short level, double damage, double health, double armor)
            : base(x, y, exp, level, damage, health, armor)
        {
            this.Inventory=new List<Item>();
        }

        public IEnumerable Inventory { get; private set; }

        public void AddItemToInventory(IEnumerable<Item> items)
        {
            foreach (var item in items)
            {
                this.inventory.Add(item);
            }
            
        }
    }
}
