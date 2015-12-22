using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms.VisualStyles;
using HeroesOfFate.Contracts;
using HeroesOfFate.GameEngine.Combat;
using HeroesOfFate.GameEngine.IO;
using HeroesOfFate.Models.Characters.Heroes;
using HeroesOfFate.Models.Characters.Monsters;

namespace HeroesOfFate.GameEngine
{
    public static class Engine
    {
        private static List<string> map = DrawScreen.AddMap();// adding map to the game
        private static int[] heroPosition = { 5, 1 };
        private static char specSymbol = '═';
        private static char wallSymbol = '█';
        private static Core core = new Core();


        public static void GameStart()
        {
            
            Console.WindowHeight = 40;
            Console.WindowWidth = 90;
            core.Run();
            
            foreach (string v in map)// loading the map to be printed
            {
                DrawScreen.AddLineToBuffer(ref DrawScreen.area1, v);
            }

            DrawScreen.drawScreen(DrawScreen.area1, DrawScreen.area2);

            while (true)
            {
                string command = Console.ReadLine();
                string[] splitCommand = command.Split(' ');
                switch (splitCommand[0])
                {
                    case "move":
                        Move(command, splitCommand);
                        break;
                    case "inventory":
                        DrawScreen.AddLineToBuffer(ref DrawScreen.area2, Environment.NewLine);
                        DrawScreen.AddLineToBuffer(ref DrawScreen.area2, "Your inventory.. make your choice.(press help for info)");
                        InventoryWork();
                        break;
                    case "info":
                        DrawScreen.drawScreen(Info(), DrawScreen.area2);
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "exit":
                        Environment.Exit(0);
                        break;
                    default:
                        DrawScreen.AddLineToBuffer(ref DrawScreen.area2, "Please enter valid command!");
                        break;
                }
                DrawScreen.drawScreen(DrawScreen.area1, DrawScreen.area2);
            }
        }

        private static List<string> Info()
        {
            List<string> info = new List<string>();
            string[] infoString = core.Hero.ToString().Split('\n');
            foreach (var v in infoString)
            {
                DrawScreen.AddLineToBuffer(ref info, v);
            }
            return info;
        } 
        //inventory method
        private static void InventoryWork()
        {
            DrawInventory(null, "");
            bool check = true;
            while (check)
            {
                string[] inputArgs = Console.ReadLine().Split(' ');

                switch (inputArgs[0])
                {
                    case "equip":
                        core.Hero.Equip(core.Hero.Inventory.ElementAt(int.Parse(inputArgs[1]) - 1));
                        break;
                    case "help":
                        DrawInventory(HelpArea(), inputArgs[0]);
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "back":
                        check = false;
                        break;
                    default:
                        DrawScreen.AddLineToBuffer(ref DrawScreen.area2, "Invalid command.");
                        break;
                }
                DrawInventory(null, "");
            }
        }

        private static List<string> HelpArea()
        {
            List<string> helpArea = new List<string>();
            DrawScreen.AddLineToBuffer(ref helpArea, "Usable commands for inventory menu:");
            DrawScreen.AddLineToBuffer(ref helpArea, " - equip (item number) : equiping item coresponding to the specific number");
            DrawScreen.AddLineToBuffer(ref helpArea, " - back : return to the map.");
            for (int i = 0; i < 9; i++)
            {
                DrawScreen.AddLineToBuffer(ref helpArea, Environment.NewLine);
            }
            return helpArea;
        } 
        private static void DrawInventory(List<string> newArea, string command )
        {
            List<string> inventoryArea = new List<string>();
            List<string> equipArea = new List<string>();

            if (command != "help")
            {
                DrawScreen.AddLineToBuffer(ref inventoryArea, "Your inventory items:");
                int i = 1;
                foreach (var items in core.Hero.Inventory)
                {
                    DrawScreen.AddLineToBuffer(ref inventoryArea, i + ". " + items.ToString());
                    i++;
                }
                for (int j = i; j < 8; j++)
                {
                    DrawScreen.AddLineToBuffer(ref inventoryArea, Environment.NewLine);
                }
                DrawScreen.AddLineToBuffer(ref inventoryArea, new string('-', 90));
                DrawScreen.AddLineToBuffer(ref inventoryArea, "Your equiped items:");
                foreach (var equip in core.Hero.Equipment)
                {
                    DrawScreen.AddLineToBuffer(ref equipArea, equip.ToString());
                }
                var listCombine = equipArea.Concat(inventoryArea);
                inventoryArea = listCombine.ToList();
                DrawScreen.drawScreen(inventoryArea, DrawScreen.area2);
            }
            else
            {
                DrawScreen.drawScreen(newArea, DrawScreen.area2);
            }
            
        }

        //move method
        private static void Move(string command, string[] splitCommand)
        {
            DrawScreen.AddLineToBuffer(ref DrawScreen.area2, command); //output here "command"
            int[] tempposition = {heroPosition[0], heroPosition[1]};
            try
            {
                changeHeroCoordinates(int.Parse(splitCommand[1]), splitCommand[2]);
                CheckValidMapMove(map.Count, map[0].Length);
                HeroMove(map, tempposition, heroPosition, splitCommand[2], core.Hero);
                if ((core.Hero.Health + int.Parse(splitCommand[1])*2) <= core.Hero.MaxHealth)
                    core.Hero.Health += int.Parse(splitCommand[1])*2; //Health regen per move
                else core.Hero.Health = core.Hero.MaxHealth;
            }
            catch (ArgumentException e)
            {
                heroPosition[0] = tempposition[0];
                heroPosition[1] = tempposition[1];
                DrawScreen.AddLineToBuffer(ref DrawScreen.area2, e.Message);
            }
            catch (FormatException)
            {
                DrawScreen.AddLineToBuffer(ref DrawScreen.area2, "Number you entered is not a valid one!");
            }

            DrawScreen.area1.Clear();
            foreach (string v in map)
            {
                DrawScreen.AddLineToBuffer(ref DrawScreen.area1, v);
            }
        }

        private static void CheckValidMapMove(int hight, int width)//check if move is outside the map
        {
            if ((heroPosition[0] > hight || heroPosition[1] > width) || (heroPosition[0] <= 0 || heroPosition[1] <= 0))
            {
                throw new ArgumentException("Outside Map boundaries!");
            }
        }

        private static bool CheckForWallsInPAth(List<string> Map, int[] oldPosition, int[] newPosition)//checking if there is a wall on the road
        {
            if (oldPosition[0] < newPosition[0] || oldPosition[1] < newPosition[1])
            {
                if (oldPosition[0] == newPosition[0])
                {
                    char[] tempMapOldLine = Map[oldPosition[0] - 1].ToCharArray();
                    for (int i = oldPosition[1] - 1; i <= newPosition[1] - 1; i++)
                    {
                        if (tempMapOldLine[i] == wallSymbol) return false;
                    }
                }
                else
                {
                    for (int i = oldPosition[0] - 1; i <= newPosition[0] - 1; i++)
                    {
                        char[] tempMapOldLine = Map[i].ToCharArray();
                        if (tempMapOldLine[oldPosition[1] - 1] == wallSymbol) return false;
                    }
                }

            }
            else
            {
                if (oldPosition[0] == newPosition[0])
                {
                    char[] tempMapOldLine = Map[oldPosition[0] - 1].ToCharArray();
                    for (int i = newPosition[1] - 1; i <= oldPosition[1] - 1; i++)
                    {
                        if (tempMapOldLine[i] == wallSymbol) return false;
                    }
                }
                else
                {
                    for (int i = newPosition[0] - 1; i <= oldPosition[0] - 1; i++)
                    {
                        char[] tempMapOldLine = Map[i].ToCharArray();
                        if (tempMapOldLine[oldPosition[1] - 1] == wallSymbol) return false;
                    }
                }
            }

            return true;
        }

        private static int SpecialSymbolReach(char symbol, string command, Hero hero)// special symbols what to do when you find one
        {
            switch (symbol)
            {
                case '▓':
                    DrawScreen.AddLineToBuffer(ref DrawScreen.area2, "You found a chest and you loot 1500g!!!");
                    if (command == "up" || command == "down") specSymbol = '║';
                    else specSymbol = '═';
                    return 1;
                case '§':
                    //DrawScreen.AddLineToBuffer(ref DrawScreen.area2, "You faced The demon and you died !!!");
                    BattleScreen battle = new BattleScreen(core);
                    battle.StartBattle();
                    //Environment.Exit(0);
                    return 2;
                default:
                    return 0;
            }
        }

        private static List<string> HeroMove(List<string> oldMap, int[] oldPosition, int[] newPosition, string command, Hero hero) // moving method
        {
            char[] tempMapOldLine = oldMap[oldPosition[0] - 1].ToCharArray();
            char[] tempMapNewLine = oldMap[newPosition[0] - 1].ToCharArray();
            if (!CheckForWallsInPAth(oldMap, oldPosition, newPosition))
            {
                throw new ArgumentException("You can`t go there !");
            }
            else
            {

                tempMapOldLine[oldPosition[1] - 1] = specSymbol;
                oldMap[oldPosition[0] - 1] = new string(tempMapOldLine);
                int temp = SpecialSymbolReach(tempMapNewLine[newPosition[1] - 1], command, hero);
                if (temp == 0) specSymbol = tempMapNewLine[newPosition[1] - 1];
                tempMapNewLine = oldMap[newPosition[0] - 1].ToCharArray();
                tempMapNewLine[newPosition[1] - 1] = '©';
                oldMap[newPosition[0] - 1] = new string(tempMapNewLine);
                return oldMap;
            }
        }

        private static void changeHeroCoordinates(int steps, string direction) 
        {
            if (direction == "left") heroPosition[1] -= steps;
            else if (direction == "right") heroPosition[1] += steps;
            else if (direction == "up") heroPosition[0] -= steps;
            else if (direction == "down") heroPosition[0] += steps;
            else
            {
                throw new ArgumentException("Enter valid direction!");
            }
        }
    }
}