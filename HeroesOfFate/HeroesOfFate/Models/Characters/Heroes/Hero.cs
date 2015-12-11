using System;
using System.Collections.Generic;
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
            this.Inventory = new List<Item>();
            this.Equipment = new List<Item>();
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

        public List<Item> Inventory
        {
            get;
            private set; 
            
        }

        public List<Item> Equipment
        {
            get;
            private set; 
            
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


        public abstract void AddItemToInventory(Item item);

        public abstract void RemoveItemFromInventory(Item item);

        protected virtual void ApplyWeaponDmg(Weapon weapon)
        {
            this.Damage += weapon.WeaponAttack;
        }

        protected virtual void ApplyArmorValue(Armor armor)
        {
            this.Armor += armor.ArmorDefence;
        }

        protected virtual void RemoveWeaponDmg(Weapon weapon)
        {
            this.Damage -= weapon.WeaponAttack;
        }

        protected virtual void RemoveArmorValue(Armor armor)
        {
            this.Armor -= armor.ArmorDefence;
        }

        public abstract void Equip(Item item);
        //TO DO : Equip two-handed weapon

        public override string ToString()
        {
            return string.Format("Name: {0}, Race: {1}, Damage: {2}, Armor: {3}, Health: {4}",
                this.Name, this.HeroRace, this.Damage, this.Armor, Health);
        }
    }
}
