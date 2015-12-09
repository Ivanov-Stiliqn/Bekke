using System;
using System.Collections;
using System.Collections.Generic;


namespace HeroesOfFate.Models
{
    public abstract class Hero : Character
    {
        
        private const short LevelDefault = 1;
        private const short ExpDefault = 0;
        private const double StartingGold = 0;

        private string name;
        private List<Item> inventory;
        private double gold;


        protected Hero(
            string name,
            double x,
            double y,  
            Race heroRace,
            double damage,
            double health,
            double armor,
            double gold=StartingGold,
            short exp=ExpDefault, 
            short level=LevelDefault)

            :base(x, y,damage, health, armor,exp,level)
        {
            this.Name = name;
            this.Inventory=new List<Item>();
            this.HeroRace = heroRace;
            this.Gold = gold;
        }

        public string Name 
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null or empty !");
                }
                if (value.Length < 3)
                {
                    throw new ArgumentOutOfRangeException("Name length cannot be less than 3 symbols");
                }
                this.name = value;
            }
       }

        public IEnumerable Inventory { get; private set; }

        public void AddItemToInventory(IEnumerable<Item> items)
        {
            foreach (var item in items)
            {
                this.inventory.Add(item);
            }
        }

        public void RemoveItemFromInventory(IEnumerable<Item> items)
        {
            foreach (var item in items)
            {
                this.inventory.Remove(item);
            }
        }

        public double Gold 
        {
            get { return this.gold; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Gold cannot be negative");
                }
                this.gold = value;
            }
        }

        public Race HeroRace { get; set; }


        public override void Move(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
