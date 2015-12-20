using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroesOfFate.GameEngine;
using HeroesOfFate.Models.Characters.Heroes;
using HeroesOfFate.Models.Characters.Monsters;

namespace HeroesOfFate.GameEngine.Combat
{
    public static class BattleScreen
    {
        private static List<string> battleArea1 = new List<string>();
        private static List<string> battleArea2 = new List<string>();
        private static List<string> commandShow = new List<string>();
        public static void StartBattle(Hero hero)
        {
            Random rnd = new Random();
            int monsterChoice = rnd.Next(1, 6);
            Monster monster = monsterSelect(monsterChoice);
            ScreenUpdate(hero, monster);
            DrawBattle();
            while (true)
            {
                try
                {
                    uint command = uint.Parse(Console.ReadLine());
                    switch (command)
                    {
                        case 1:
                            DrawScreen.AddLineToBuffer(ref battleArea2, "You hitted your opponent for x amount of damage!");
                            ScreenUpdate(hero, monster);
                            break;
                        case 2:
                            DrawScreen.AddLineToBuffer(ref battleArea2, "You used y and did strong hit to your opponent for x amount of damage!");
                            ScreenUpdate(hero, monster);
                            break;
                        case 3:
                            DrawScreen.AddLineToBuffer(ref battleArea2, "You used potion to restore x amount of HP");
                            ScreenUpdate(hero, monster);
                            break;
                        case 4:
                            DrawScreen.AddLineToBuffer(ref battleArea2, "You used special hit wich did x amount of damage!");
                            ScreenUpdate(hero, monster);
                            break;
                        case 0:
                            break;
                        default:
                            DrawScreen.AddLineToBuffer(ref battleArea2, "Invalid command enter the numbet coresponding to the specific action!");
                            break;
                    }
                    DrawBattle();
                    if (command == 0) break;
                }
                catch (FormatException)
                {
                    DrawScreen.AddLineToBuffer(ref battleArea2, "Invalid command enter the numbet coresponding to the specific action!");
                    DrawBattle();
                }
                catch (OverflowException)
                {
                    DrawScreen.AddLineToBuffer(ref battleArea2, "Invalid command enter the numbet coresponding to the specific action!");
                    DrawBattle();
                }
            }
            
        }
        private static Monster monsterSelect(int number)
        {
            Monster monster = null;
            switch (number)
            {
                case 1:
                    monster = new Goblin();
                    break;
                case 2:
                    monster = new Ogre();
                    break;
                case 3:
                    monster = new Troll();
                    break;
                case 4:
                    monster = new Undead();
                    break;
                case 5:
                    monster = new Wolf();
                    break;
                default:
                    break;
            }
            return monster;
        }
        private static void ScreenUpdate(Hero hero, Monster monster)
        {
            ScreenClear();
            fillArea(hero, monster);
            CommandsShow();
            combineArea();
        }
        private static void ScreenClear()
        {
            battleArea1.Clear();
            battleArea2.Clear();
        }
        private static void fillArea(Hero hero, Monster monster)
        {
            DrawScreen.AddLineToBuffer(ref battleArea1, Environment.NewLine);
            DrawScreen.AddLineToBuffer(ref battleArea1,
                " ".PadLeft(4, ' ') + hero.Name.PadRight(50, ' ') + monster.ToString());
            DrawScreen.AddLineToBuffer(ref battleArea1,
                " ".PadLeft(4, ' ') + ("Damage " + hero.DamageMin + " - " + hero.DamageMax).PadRight(50, ' ') + "Damage " + monster.DamageMin + " - " + monster.DamageMax);
            DrawScreen.AddLineToBuffer(ref battleArea1,
                " ".PadLeft(4, ' ') + ("HP: " + hero.Health).PadRight(50, ' ') + "HP: " + monster.Health);
            for (int i = 0; i < 3; i++)
            {
                DrawScreen.AddLineToBuffer(ref battleArea1, Environment.NewLine);
            }
            DrawScreen.AddLineToBuffer(ref battleArea1, new string('-', 90));
        }
        private static void CommandsShow()
        {
            for (int i = 0; i < 5; i++)
            {
                commandShow.Add(Environment.NewLine);
            }
            commandShow.Add("4.Use Ultimate skill.");
            commandShow.Add("3.Use HP potion.");
            commandShow.Add("2.Use Crush.");
            commandShow.Add("1.Normal hit.");
        }
        private static void combineArea()
        {
            var temp = commandShow.Concat(battleArea1);
            battleArea1 = temp.ToList();
        }
        private static void DrawBattle()
        {
            DrawScreen.drawScreen(battleArea1, battleArea2);
        }

    }
}
