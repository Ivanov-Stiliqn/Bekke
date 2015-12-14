using System;
using System.Collections.Generic;
using System.IO;

namespace HeroesOfFate.GameEngine
{
    static class DrawScreen
    {
        public static List<string> area1 = new List<string>();
        public static List<string> area2 = new List<string>();
        static int areaHeights = (Console.WindowHeight - 2) / 2;
        public static List<string> AddMap()
        {
            List<string> map = new List<string>();
            using (StreamReader file = new StreamReader("d:\\map.txt"))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    map.Add(line);
                }
            }
            return map;
        }
        public static void AddLineToBuffer(ref List<string> areaBuffer, string line)
        {
            areaBuffer.Insert(0, line);

            if (areaBuffer.Count == areaHeights)
            {
                areaBuffer.RemoveAt(areaHeights - 1);
            }
        }
        public static void drawScreen()
        {
            Console.Clear();

            // Draw the area divider
            for (int i = 0; i < Console.BufferWidth; i++)
            {
                Console.SetCursorPosition(i, areaHeights);
                Console.Write('=');
            }

            int currentLine = areaHeights - 1;

            for (int i = 0; i < area1.Count; i++)
            {
                Console.SetCursorPosition(0, currentLine - (i + 1));
                Console.WriteLine(area1[i]);

            }

            currentLine = (areaHeights * 2);
            for (int i = 0; i < area2.Count; i++)
            {
                Console.SetCursorPosition(0, currentLine - (i + 1));
                Console.WriteLine(area2[i]);
            }

            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.Write("> ");
        }
    }
}
