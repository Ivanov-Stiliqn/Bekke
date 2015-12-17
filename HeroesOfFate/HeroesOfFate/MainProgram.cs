using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using HeroesOfFate.Contracts;
using HeroesOfFate.Contracts.FactoryContracts;
using HeroesOfFate.Contracts.Item_Contracts;
using HeroesOfFate.Factories;
using HeroesOfFate.GameEngine;
using HeroesOfFate.Models.Characters.Heroes;
using HeroesOfFate.Models.Characters.Monsters;
using HeroesOfFate.Models.Items.Weapons.OneHWeapons;
using HeroesOfFate.Models.Items.Weapons.TwoHWeapons;

namespace HeroesOfFate
{
    public class MainProgram
    {
        public static void Main()
        {
            //After creating hero implement the bottom commentar. It automaticly create items and add
            //them to the loot table of the monsters. The monster automaticly level up with the event below!
            ///////////////////////////////////////////////////////////////////////////////////////////////
            //warrior.ChangedLevel += (sender, eventArgs) => 
            //monsters.ForEach(m => m.LevelUp(eventArgs.Level));
            //core.ImplementItems();

            Core core = new Core();

            core.Run();
        }
    }
}
