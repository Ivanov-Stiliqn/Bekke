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

            Item axe = new Axe(ItemType.MainHand, "Skulllaina", 10, 15m);
            Item axe2 = new Axe(ItemType.MainHand, "LainaLaina", 30, 15m);
            Item body = new Body(ItemType.Body, "Armor", 50, 10m);
            Item body2 = new Body(ItemType.Body, "Laina", 100, 15m);
            Item sword = new Sword(ItemType.MainHand, "Sword", 50, 10m);
            Item helm = new Helm(ItemType.Helmet, "Cais", 10, 15m);

            warrior.AddItemToInventory(axe);
            warrior.Equip(axe);
            Console.WriteLine(warrior.ToString());

            warrior.AddItemToInventory(axe2);
            warrior.Equip(axe2);
            Console.WriteLine(warrior.ToString());

            warrior.AddItemToInventory(body);
            warrior.Equip(body);
            Console.WriteLine(warrior.ToString());

            warrior.AddItemToInventory(helm);
            warrior.Equip(helm);
            Console.WriteLine(warrior.ToString());
        }
    }
}
