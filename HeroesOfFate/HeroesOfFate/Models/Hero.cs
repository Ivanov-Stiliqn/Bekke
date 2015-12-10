using System;
using System.Collections;
using System.Collections.Generic;
using HeroesOfFate.Contracts;
using HeroesOfFate.Models.Items.Armors;


namespace HeroesOfFate.Models
{
    public abstract class Hero : Character,IInventory
    {
        
        private const short LevelDefault = 1;
        private const short ExpDefault = 0;
        private const double StartingGold = 0;

        private string name;
        private List<Item> inventory;
        private double gold;
        private List<Item> equipment; 

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
            this.inventory=new List<Item>();
            this.HeroRace = heroRace;
            this.Gold = gold;
            this.equipment = new List<Item>();

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

        public IEnumerable<Item> Inventory
        {
            get { return this.inventory; }
        }

        public IEnumerable<Item> Equipment
        {
            get { return this.equipment; }
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


        public void AddItemToInventory(Item item)
        {
            this.inventory.Add(item);

        }

        public void RemoveItemFromInventory(Item item)
        {
            this.inventory.Remove(item);
        }


        //TO DO : Equip two-handed weapon
        public void Equip(Item item)
        {
            bool isEquiped = false;

            foreach (var equipedItem in this.equipment)
            {
                if (item.Type == equipedItem.Type)
                {
                    this.equipment.Remove(equipedItem);
                    AddItemToInventory(equipedItem);

                    this.equipment.Add(item);
                    RemoveItemFromInventory(item);
                    isEquiped = true;
                }
            }
            if (!isEquiped)
            {
                this.equipment.Add(item);
                RemoveItemFromInventory(item);
            }
        }
    }
}
