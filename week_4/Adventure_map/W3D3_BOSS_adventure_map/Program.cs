﻿using System;
using System.Collections.Generic;

namespace W3D3_BOSS_adventure_map
{
    class Program
    {

        // Method that first makes all the callculations based on the width and the height.
        // Then the method draws the map to the console based on those callculations.
        static void DrawMap(int width, int height)
        {
            // Addjusting the width and height values, to
            width = width - 1;
            height = height - 1;

            // Used for resetting the x value to zero for every new line (new y value)
            int a = 0;

            var random = new Random();

            // Symbols used for drawing the forest.
            string forestSymbol = "AT()&!Å";


            // Calculations.
            // Start of calculating the rivers position.
            var riverList = new List<int> { };
            int riverLast = width - width / 4;
            riverList.Add(riverLast);

            for (var y = 1; y < height - 1; y++)
            {

                if (riverLast < width - 3 && random.Next(2) == 0)
                {
                    riverLast += 1;
                }
                else if (riverLast > width - width / 4 && random.Next(2) == 0)
                {
                    riverLast -= 1;
                }

                riverList.Add(riverLast);
            }

            riverList.Add(riverLast);
            // End of calculating river.

            //road (h) start
            var roadList = new List<int> { };
            int roadLast = height / 2;
            roadList.Add(roadLast);

            for (int x = 1; x < width - 1; x++)
            {
                if (x >= riverList[roadLast] - 6)
                {
                    for (int i = 0; i < 12; i++)
                    {
                        roadList.Add(roadLast);
                    }

                    x += 12;
                }

                if (random.Next(8) == 0 && roadLast < height - 3)
                {
                    roadLast += 1;
                }
                else if (random.Next(8) == 0 && roadLast > 3)
                {
                    roadLast -= 1;
                }

                roadList.Add(roadLast);

            }

            //road (h) end

            int bridgePosition = 0;

            //drawing
            for (int y = 0; y <= height; y++)
            {

                for (int x = a; x <= width; x++)
                {
                    //border start
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
                    //border end

                    //Title start
                    string title = "ADVENTURE MAP";

                    if (y == 1 && x == (width) / 2 - title.Length / 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(title);
                        x += title.Length - 1;
                        continue;
                    }

                    //Title end

                    //Road(H) start
                    if (y == roadList[x - 1])
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("#");
                        continue;
                    }

                    //Road(H) end

                    //forest start
                    var forestList = new List<int> { };

                    if (x > 0 && x < width / 4)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;

                        int dense = x;

                        if (width > 15)
                        {
                            dense = x - 1;
                        }

                        if (random.Next(dense) == 0)
                        {
                            Console.Write(forestSymbol[random.Next(forestSymbol.Length)]);
                            continue;
                        }
                    }
                    //forest end

                    //Road(V) start
                    if (x == riverList[y - 1] - 5 && y > roadList[x])
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("#");
                        continue;
                    }

                    //Road(V) end



                    //Bridge start

                    if (x + 2 == riverList[y] && y + 1 == roadList[x])
                    {
                        bridgePosition = riverList[y];
                        Console.ForegroundColor = ConsoleColor.White;

                        for (int i = 0; i < 7; i++)
                        {
                            if (x + i == width)
                            {
                                x += i - 1;
                                break;

                            }

                            Console.Write("=");

                            if (i == 6)
                            {
                                x += 6;
                            }
                        }
                        continue;
                    }

                    if (x + 2 == bridgePosition && y - 1 == roadList[x])
                    {
                        Console.ForegroundColor = ConsoleColor.White;

                        for (int i = 0; i < 7; i++)
                        {
                            if (x + i == width)
                            {
                                x += i - 1;
                                break;
                            }

                            Console.Write("=");

                            if (i == 6)
                            {
                                x += 6;
                            }

                        }
                        continue;
                    }

                    //Bridge end


                    //river start
                    if (y == 1 && x == riverList[y - 1] + 1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;

                        for (var i = 0; i < 2; i++)
                        {
                            if (x - 1 < riverList[y])
                            {
                                Console.Write(@"(");
                                continue;
                            }

                            if (x - 1 > riverList[y])
                            {
                                Console.Write(")");
                                continue;
                            }

                            Console.Write("|");
                            continue;
                        }
                        x++;
                        continue;
                    }

                    if (y == 1 && x == riverList[y - 1] + 2)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;

                        if (x - 2 < riverList[y])
                        {
                            Console.Write(@"(");
                            continue;
                        }

                        if (x - 2 > riverList[y])
                        {
                            Console.Write(")");
                            continue;
                        }

                        Console.Write("|");
                        continue;


                    }


                    if (x == riverList[y - 1])
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;

                        for (var i = 0; i < 3; i++)
                        {

                            if (x < riverList[y])
                            {
                                Console.Write(@"(");
                                continue;
                            }

                            if (x > riverList[y])
                            {
                                Console.Write(")");
                                continue;
                            }

                            Console.Write("|");
                            continue;
                        }

                        x += 2;
                        continue;

                    }
                    //river end

                    //empty space
                    Console.Write(" ");
                }

                //next line
                a = 0;
                Console.WriteLine();

            }
            //drawing end
        }
        static void Main(string[] args)
        {
            Console.Clear();

            DrawMap(80, 35);
        }
    }
}
