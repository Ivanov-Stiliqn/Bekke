using System;
using HeroesOfFate.Models;
using HeroesOfFate.Models.Characters;
using HeroesOfFate.Models.Characters.Heroes;
using HeroesOfFate.Models.Items;
using HeroesOfFate.Models.Items.Armors;
using HeroesOfFate.Models.Items.Weapons.OneHWeapons;
using HeroesOfFate.Models.Items.Weapons.TwoHWeapons;

namespace HeroesOfFate
{
    public class MainProgram
    {
        static void Main()
        {
            Warrior warrior = new Warrior("Todar", Race.Orc);

            Console.WriteLine(warrior.ToString());

            Weapon axe = new Axe(100, "Laina", 15m);
            Weapon greatSword = new Greatsword(200, "laina 2", 10m);
            Armor shield = new Shield("more laina", 50, 5m);
            Staff staff = new Staff(300,"Gandalf",330330);


            
            warrior.AddItemToInventory(staff);
            warrior.Equip(staff);
            Console.WriteLine(warrior.ToString());

            Armor armor=new Body("blqt",100,231);

            warrior.AddItemToInventory(armor);
            warrior.Equip(armor);
            Console.WriteLine(warrior.ToString());

            warrior.Exp = 799;
            Console.WriteLine(warrior.ToString());
            Console.WriteLine(warrior.Exp);
            Console.WriteLine(warrior.MaxHealth);
            Console.WriteLine(warrior.Level);
        }
    }
}
