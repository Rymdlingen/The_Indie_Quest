using System;
using System.Collections.Generic;

namespace W3D2_BOSS_adventure_map
{
    class Program
    {

        static void DrawMap(int width, int height)
        {
            width = width - 1;
            height = height - 1;
            int a = 0;

            var random = new Random();
            string forestSymbol = "AT()&!Å";

            for (int y = 0; y <= height; y++)
            {
                for (int x = a; x <= width; x++)
                {
                    if ((x == 0 && y == 0) || (x == 0 && y == height) || (x == width && y == 0) || (x == width && y == height))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("+");
                        continue;
                    }

                    if ((x == 0 || x == width) && (y > 0 && y < height))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("|");
                        continue;
                    }

                    if ((x > 0 && x < width) && (y == 0 || y == height))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("-");
                        continue;
                    }

                    var forestList = new List<int> { };

                    if (x > 0 && x < width / 4)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;

                        int dense = x;

                        if(width > 15)
                        {
                            dense = x - 1;
                        }

                        if (random.Next(dense) == 0)
                        {
                            Console.Write(forestSymbol[random.Next(forestSymbol.Length)]);
                            continue;
                        }
                    }

                    Console.Write(" ");
                }

                a = 0;
                Console.WriteLine();

            }
        }
        static void Main(string[] args)
        {
            Console.Clear();

            DrawMap(60, 15);
        }
    }
}

