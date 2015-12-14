using System;
using System.Collections.Generic;
using System.Linq;
using HeroesOfFate.Contracts.ICharacters;
using HeroesOfFate.Events;
using HeroesOfFate.Models.Items;
using HeroesOfFate.Models.Items.Potions;
using HeroesOfFate.Models.Items.Weapons;

namespace HeroesOfFate.Models.Characters.Heroes
{
    public abstract class Hero : Character,IInventory
    {
        
        private const int LevelDefault = 1;
        private const double StartingGold = 0;

        public event HeroLevelChangeEventHandler ChangedLevel;

        private string name;
        private double gold;
        private int exp;
        private readonly List<Item> inventory;
        private readonly List<Item> equipment; 

        protected Hero(
            string name,
            Race heroRace,
            double damage,
            double health,
            double armor,
            double maxHealth,
            double gold = StartingGold, 
            int level = LevelDefault)

            :base(damage, health, armor,level)
        {
            this.Name = name;
            this.HeroRace = heroRace;
            this.inventory = new List<Item>();
            this.equipment = new List<Item>();
            this.Gold = gold;
            this.Exp = exp;
            this.MaxHealth = maxHealth;
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

        public int Exp
        {
            get { return this.exp; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("hero exp" ,"Experience cannot be negative");
                }
                if (value >= 100)
                {
                    this.LevelUp(value);
                }
                else
                {
                    this.exp = value;
                }
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
                    throw new ArgumentOutOfRangeException("hero gold" ,"Gold cannot be negative");
                }
                this.gold = value;
            }
        }

        public Race HeroRace { get; set; }

        public double MaxHealth { get; set; }



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

        public void ApplyPotionEffect(Potion potion)
        {
            this.Damage += potion.WeaponAttack;
            this.Armor += potion.ArmorDefence;
            this.Health += potion.HealthEffect;

            if (this.Health > this.MaxHealth)
            {
                this.Health = this.MaxHealth;
            }

        }

        public void RemovePotionEffect(Potion potion)
        {
            this.Damage -= potion.WeaponAttack;
            this.Armor -= potion.ArmorDefence;
            this.Health -= potion.HealthEffect;
        }

        public void Equip(Item item)
        {
            bool isEquiped = false;

            foreach (Item equipedItem in this.equipment.ToList())
            {
                if (item.Type == equipedItem.Type)
                {
                    if (item.Type == ItemType.MainHand)
                    {
                        var weapon = new Weapon(item.WeaponAttack, item.Id, item.Price);
                        if (!weapon.IsOneH)
                        {
                            Item shield = this.FindShield();
                            if (shield != null)
                            {
                                this.equipment.Remove(shield);
                                this.AddItemToInventory(shield);
                                this.RemoveItemEffect(shield);
                            }
                        }
                    }
                   
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
                if (item.Type == ItemType.OffHand)
                {
                    Weapon weapon = this.FindWeapon();
                    if (weapon != null)
                    {
                        if (!weapon.IsOneH)
                        {
                            this.equipment.Remove(weapon);
                            this.AddItemToInventory(weapon);
                            this.RemoveItemEffect(weapon);
                        }
                    }
                }
                this.equipment.Add(item);
                this.ApplyItemEffect(item);
                this.RemoveItemFromInventory(item);
            }
        }

        private Item FindShield()
        {
            foreach (var item in this.equipment)
            {
                if (item.Type == ItemType.OffHand)
                {
                    return item;
                }
            }
            return null;
        }

        private Weapon FindWeapon()
        {
            foreach (var item in this.equipment)
            {
                if (item.Type == ItemType.MainHand)
                {
                    return (Weapon)item;
                }
            }
            return null;
        }

        public void LevelUp(int value)
        {
            this.Level += value / 100;
            this.exp = value % 100;
            this.MaxHealth += (this.Level-1)*10;
            this.Health = this.MaxHealth;

            OnLevelChange(this,new HeroChangeLevelEventArgs(this.Level));
        }

        private void OnLevelChange(object sender,HeroChangeLevelEventArgs eventArgs)
        {
            if (this.ChangedLevel != null)
            {
                this.ChangedLevel(sender, eventArgs);
            }
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, Race: {1}, Damage: {2}, Armor: {3}, Health: {4}",
                this.Name, this.HeroRace, this.Damage, this.Armor, this.Health);
        }
    }
}