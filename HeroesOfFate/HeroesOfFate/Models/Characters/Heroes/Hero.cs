using System;
using System.Collections.Generic;
using System.Linq;
using HeroesOfFate.Contracts;
using HeroesOfFate.Models.Items;

namespace HeroesOfFate.Models.Characters.Heroes
{
    public abstract class Hero : Character,IInventory
    {
        
        private const short LevelDefault = 1;
        private const short ExpDefault = 0;
        private const double StartingGold = 0;

        private string name;
        private double gold;
        private readonly List<Item> inventory;
        private readonly List<Item> equipment; 

        protected Hero(
            string name,
            Race heroRace,
            double damage,
            double health,
            double armor,
            double gold = StartingGold,
            short exp = ExpDefault, 
            short level = LevelDefault)

            :base(damage, health, armor,exp,level)
        {
            this.Name = name;
            this.HeroRace = heroRace;
            this.inventory = new List<Item>();
            this.equipment = new List<Item>();
            this.Gold = gold;
        }

        public string Name 
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("hero name","Name cannot be null or empty !");
                }
                if (value.Length < 3)
                {
                    throw new ArgumentOutOfRangeException("hero name length" ,"Name length cannot be less than 3 symbols");
                }
                this.name = value;
            }
       }

        public IEnumerable<Item> Inventory
        {
            get { return inventory; }
        }

        public IEnumerable<Item> Equipment
        {
            get { return equipment; } 
            
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

        protected void ApplyItemEffect(Item item)
        {
            this.Damage += item.WeaponAttack;
            this.Armor += item.ArmorDefence;
        }

        protected void RemoveItemEffect(Item item)
        {
            this.Damage -= item.WeaponAttack;
            this.Armor -= item.ArmorDefence;
        }

        public void Equip(Item item)
        {
            bool isEquiped = false;

            foreach (Item equipedItem in this.equipment.ToList())
            {
                if (item.Type == equipedItem.Type)
                {
                    this.equipment.Remove(equipedItem);
                    this.RemoveItemEffect(equipedItem);
                    this.AddItemToInventory(equipedItem);
                    this.equipment.Add(item);
                    this.ApplyItemEffect(item);
                    this.RemoveItemFromInventory(item);
                    isEquiped = true;
                }
            }

            if (!isEquiped)
            {
                this.equipment.Add(item);
                this.ApplyItemEffect(item);
                this.RemoveItemFromInventory(item);
            }
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, Race: {1}, Damage: {2}, Armor: {3}, Health: {4}",
                this.Name, this.HeroRace, this.Damage, this.Armor, Health);
        }
    }
}
