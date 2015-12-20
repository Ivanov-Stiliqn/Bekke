using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroesOfFate.GameEngine;

namespace HeroesOfFate.GameEngine.Combat
{
    public static class BattleScreen
    {
        public static List<string> battleArea1 = new List<string>();
        public static List<string> battleArea2 = new List<string>();
        private static List<string> commandShow = new List<string>();
        public static void StartBattle()
        {
            fillArea();
            CommandsShow();
            combineArea();
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
                            break;
                        case 2:
                            DrawScreen.AddLineToBuffer(ref battleArea2, "You used y and did strong hit to your opponent for x amount of damage!");
                            break;
                        case 3:
                            DrawScreen.AddLineToBuffer(ref battleArea2, "You used potion to restore x amount of HP");
                            break;
                        case 4:
                            DrawScreen.AddLineToBuffer(ref battleArea2, "You used special hit wich did x amount of damage!");
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
        private static void fillArea()
        {
            DrawScreen.AddLineToBuffer(ref battleArea1, Environment.NewLine);
            DrawScreen.AddLineToBuffer(ref battleArea1, " ".PadLeft(4, ' ') + "charName".PadRight(50, ' ') + "monsterName");
            DrawScreen.AddLineToBuffer(ref battleArea1, " ".PadLeft(4, ' ') + "charDamage ".PadRight(50, ' ') + "monsterDamage");
            DrawScreen.AddLineToBuffer(ref battleArea1, " ".PadLeft(4, ' ') + "charHP".PadRight(50, ' ') + "MonsterHP");
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
