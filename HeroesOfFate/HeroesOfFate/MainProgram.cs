using System;
using HeroesOfFate.Models;
using HeroesOfFate.Models.Characters;
using HeroesOfFate.Models.Characters.Heroes;
using HeroesOfFate.Models.Items;
using HeroesOfFate.Models.Items.Armors;
using HeroesOfFate.Models.Items.Weapons.OneHWeapons;

namespace HeroesOfFate
{
    public class MainProgram
    {
        static void Main()
        {
            Warrior warrior = new Warrior("Todar", Race.Orc);

            Console.WriteLine(warrior.ToString());

            Weapon axe = new Axe(ItemType.MainHand, 100, "Laina", 15m);
            Weapon sword = new Sword(ItemType.MainHand, 200, "laina 2", 10m);
            Armor shield = new Shield(ItemType.OffHand, "more laina", 50, 5m);

            warrior.AddItemToInventory(axe);
            warrior.Equip(axe);
            Console.WriteLine(warrior.ToString());

            warrior.AddItemToInventory(shield);
            warrior.Equip(shield);
            Console.WriteLine(warrior.ToString());

            warrior.AddItemToInventory(sword);
            warrior.Equip(sword);
            Console.WriteLine(warrior.ToString());
        }
    }
}
