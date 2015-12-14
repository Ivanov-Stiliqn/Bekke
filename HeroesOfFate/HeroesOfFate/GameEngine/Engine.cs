<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;

namespace HeroesOfFate.GameEngine
=======
﻿namespace HeroesOfFate.GameEngine
>>>>>>> 2a4d919b54031fd1274f8302035774384bde1748
{
    public static class Engine
    {
        private static List<string> map = DrawScreen.AddMap();
        private static int[] heroPosition = { 5, 1 };
        private static char specSymbol = '═';
        private static char wallSymbol = '█';

        public static void GameStart()
        {
            Console.WindowHeight = 40;
            Console.WindowWidth = 90;
            
            foreach (string v in map)
            {
                DrawScreen.AddLineToBuffer(ref DrawScreen.area1, v);
            }
            DrawScreen.drawScreen();
            int i = 0;
            while (true)
            {
                i++;
                string command = Console.ReadLine();
                string[] splitCommand = command.Split(' ');
                if (splitCommand[0] == "move")
                {
                    DrawScreen.AddLineToBuffer(ref DrawScreen.area2, command);
                    int[] tempposition = { heroPosition[0], heroPosition[1] };
                    try
                    {
                        changeHeroCoordinates(int.Parse(splitCommand[1]), splitCommand[2]);
                        CheckValidMapMove(map.Count, map[0].Length);
                        HeroMove(map, tempposition, heroPosition, splitCommand[2]);
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
                else
                {
                    DrawScreen.AddLineToBuffer(ref DrawScreen.area2, "Please enter valid command!");
                }
                if (splitCommand[0] == "exit") break;
                // jumb between areas
                //if (i % 2 == 0)
                //    AddLineToBuffer(ref area1, Console.ReadLine());
                //else
                //    AddLineToBuffer(ref area2, Console.ReadLine());
                //
                DrawScreen.drawScreen();
            }

        }
        private static void CheckValidMapMove(int hight, int width)
        {
            if ((heroPosition[0] > hight || heroPosition[1] > width) || (heroPosition[0] <= 0 || heroPosition[1] <= 0))
            {
                throw new ArgumentException("Outside Map boundaries!");
            }
        }
        private static bool CheckForWallsInPAth(List<string> Map, int[] oldPosition, int[] newPosition)
        {
            if (oldPosition[0] < newPosition[0] || oldPosition[1] < newPosition[1])
            {
                if (oldPosition[0] == newPosition[0])
                {
                    char[] tempMapOldLine = Map[oldPosition[0] - 1].ToCharArray();
                    for (int i = oldPosition[1] - 1; i < newPosition[1] - 1; i++)
                    {
                        if (tempMapOldLine[i] == wallSymbol) return false;
                    }
                }
                else
                {
                    for (int i = oldPosition[0] - 1; i < newPosition[0] - 1; i++)
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
                    for (int i = newPosition[1] - 1; i < oldPosition[1] - 1; i++)
                    {
                        if (tempMapOldLine[i] == wallSymbol) return false;
                    }
                }
                else
                {
                    for (int i = newPosition[0] - 1; i < oldPosition[0] - 1; i++)
                    {
                        char[] tempMapOldLine = Map[i].ToCharArray();
                        if (tempMapOldLine[oldPosition[1] - 1] == wallSymbol) return false;
                    }
                }
            }

            return true;
        }
        private static int SpecialSymbolReach(char symbol, string command)
        {
            switch (symbol)
            {
                case '▓':
                    DrawScreen.AddLineToBuffer(ref DrawScreen.area2, "You found a chest and you loot 1500g!!!");
                    if (command == "up" || command == "down") specSymbol = '║';
                    else specSymbol = '═';
                    return 1;
                case '§':
                    DrawScreen.AddLineToBuffer(ref DrawScreen.area2, "You faced The demon and you died !!!");
                    DrawScreen.drawScreen();
                    Environment.Exit(0);
                    return 2;
                default:
                    return 0;
            }
        }
        private static List<string> HeroMove(List<string> oldMap, int[] oldPosition, int[] newPosition, string command)
        {
            char[] tempMapOldLine = oldMap[oldPosition[0] - 1].ToCharArray();
            char[] tempMapNewLine = oldMap[newPosition[0] - 1].ToCharArray();
            if (!CheckForWallsInPAth(oldMap, oldPosition, newPosition))//wallSymbol == tempMapNewLine[newPosition[1] - 1])
            {
                throw new ArgumentException("You can`t go there !");
            }
            else
            {

                tempMapOldLine[oldPosition[1] - 1] = specSymbol;
                oldMap[oldPosition[0] - 1] = new string(tempMapOldLine);
                int temp = SpecialSymbolReach(tempMapNewLine[newPosition[1] - 1], command);
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
