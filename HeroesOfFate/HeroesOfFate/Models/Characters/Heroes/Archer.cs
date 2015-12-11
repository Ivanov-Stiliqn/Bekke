using System;
using System.Linq;
using HeroesOfFate.Contracts.ICharacters;
using HeroesOfFate.Models.Items;

namespace HeroesOfFate.Models.Characters.Heroes
{
    public class Archer : Hero, IArcher
    {
        private const double DamageDefault = 100;
        private const double HealthDefault = 200;
        private const double ArmorDefault = 100;
        private const double ArchDmgRedDefault = 0.30;

        private double attackDamage;
        private double armorDefence;

        public Archer(string name, Race heroRace)
            : base(name, heroRace, DamageDefault, HealthDefault, ArmorDefault)
        {
            AttackDamage = DamageDefault;
            ArmorDefence = ArmorDefault;
        }

        public double AttackDamage
        {
            get { return attackDamage; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("mage damage", "Mage damage cannot be zero or negative !");
                }
                attackDamage = value;
            }
        }

        public double ArmorDefence
        {
            get { return armorDefence; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("mage armor", "Mage armor cannot be negative !");
                }
                armorDefence = value;
            }
        }

        public override void AddItemToInventory(Item item)
        {
            this.Inventory.Add(item);

        }

        public override void RemoveItemFromInventory(Item item)
        {
            this.Inventory.Remove(item);
        }


        protected override void ApplyWeaponDmg(Weapon weapon)
        {
            AttackDamage += weapon.WeaponAttack;
            base.ApplyWeaponDmg(weapon);
        }

        protected override void ApplyArmorValue(Armor armor)
        {
            this.ArmorDefence += armor.ArmorDefence;
            base.ApplyArmorValue(armor);
        }

        protected override void RemoveWeaponDmg(Weapon weapon)
        {
            AttackDamage -= weapon.WeaponAttack;
            base.RemoveWeaponDmg(weapon);
        }

        protected override void RemoveArmorValue(Armor armor)
        {
            this.ArmorDefence -= armor.ArmorDefence;
            base.RemoveArmorValue(armor);
        }

        public override void Equip(Item item)
        {
            bool isEquiped = false;

            foreach (Item equipedItem in this.Equipment.ToList())
            {
                if (item.Type == equipedItem.Type)
                {
                    if (item is Weapon)
                    {
                        this.Equipment.Remove(equipedItem);
                        this.RemoveWeaponDmg((Weapon)equipedItem);
                        this.AddItemToInventory(equipedItem);
                        this.Equipment.Add(item);
                        this.ApplyWeaponDmg((Weapon)item);
                        this.RemoveItemFromInventory(item);
                        isEquiped = true;
                    }

                    if (item is Armor)
                    {
                        this.Equipment.Remove(equipedItem);
                        this.RemoveArmorValue((Armor)equipedItem);
                        this.AddItemToInventory(equipedItem);
                        this.Equipment.Add(item);
                        this.ApplyArmorValue((Armor)item);
                        this.RemoveItemFromInventory(item);
                        isEquiped = true;
                    }
                }
            }

            if (!isEquiped)
            {
                if (item is Weapon)
                {
                    this.Equipment.Add(item);
                    this.ApplyWeaponDmg((Weapon)item);
                    this.RemoveItemFromInventory(item);
                }
                if (item is Armor)
                {
                    this.Equipment.Add(item);
                    this.ApplyArmorValue((Armor)item);
                    this.RemoveItemFromInventory(item);
                }
            }
        }

        public override string ToString()
        {
            return string.Format(base.ToString());
        }
    }
}