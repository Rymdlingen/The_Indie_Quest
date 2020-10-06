using System;
using System.Collections.Generic;

namespace W3D3_BOSS_adventure_map
{
    class Program
    {
        // Method for generating road network
        static void GenerateRoad(bool[,] roads, int x, int y, int direction)
        {

            int width = roads.GetLength(0);
            int height = roads.GetLength(1);

            while (x < width && y < height && x >= 0 && y >= 0)
            {
                roads[x, y] = true;

                if (direction == 0)
                {
                    y--;
                }

                if (direction == 1)
                {
                    y++;
                }

                if (direction == 2)
                {
                    x--;
                }

                if (direction == 3)
                {
                    x++;
                }

            }
        }

        // Method for generating intersections with a 70% chanse of roads in each direction.
        static void GenerateIntersection(bool[,] roads, int x, int y)
        {
            /*int width = roads.GetLength(0);
            int height = roads.GetLength(1);*/
            var random = new Random();
            int up = random.Next(10);
            int down = random.Next(10);
            int left = random.Next(10);
            int right = random.Next(10);

            if (up <= 6)
            {
                GenerateRoad(roads, x, y, 0);
            }

            if (down <= 6)
            {
                GenerateRoad(roads, x, y, 1);
            }

            if (left <= 6)
            {
                GenerateRoad(roads, x, y, 2);
            }

            if (right <= 6)
            {
                GenerateRoad(roads, x, y, 3);
            }


        }

        /* Method to draw the map
         
          (width (x) of map - a number from 15 and higher (including border),
           height (y) of map - a number from 7 and higher (including border)*/
        static void DrawMap(int width, int height)
        {
            //adjusting width and height to work with the code
            width--;
            height--;
            var random = new Random();

            //Calculating phase

            //Roads start

            var roads = new bool[width + 1, height + 1];

            GenerateIntersection(roads, random.Next(0, width + 1), random.Next(0, height + 1));
            GenerateIntersection(roads, random.Next(0, width + 1), random.Next(0, height + 1));
            GenerateIntersection(roads, random.Next(0, width + 1), random.Next(0, height + 1));

            //Roads end

            //Calculation phase end

            //Drawing phase

            //variable used to reset x on every row
            int resetXForNewRow = 0;

            //height (y) loop
            for (int y = 0; y <= height; y++)
            {
                //width (x) loop
                for (int x = resetXForNewRow; x <= width; x++)
                {
                    //Border start
                    //corners
                    if ((x == 0 && y == 0) || (x == 0 && y == height) || (x == width && y == 0) || (x == width && y == height))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("+");
                        continue;
                    }
                    //left and right side
                    if ((x == 0 || x == width) && (y > 0 && y < height))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("|");
                        continue;
                    }
                    //top and bottom row
                    if ((x > 0 && x < width) && (y == 0 || y == height))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("-");
                        continue;
                    }
                    //Border end


                    //Title start
                    string title = "CITY MAP";

                    if (y == 1 && x == width / 2 - title.Length / 2)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write(title);
                        x += title.Length - 1;
                        continue;
                    }
                    //Title end


                    //Roads start

                    if (roads[x, y] == true && x > 0 && y > 0 && x < width && y < height)
                    {
                        bool roadAbove = roads[x, y - 1];
                        bool roadBelow = roads[x, y + 1];
                        bool roadToTheRight = roads[x + 1, y];
                        bool roadToTheLeft = roads[x - 1, y];

                        /* Matej showing things with ++
                        int i = 0;
                        int[] vals;
                        int sum = 0;
                        while(i<100)
                        {
                            sum += vals[i++];
                        }*/

                        if (roadAbove && roadBelow && roadToTheRight && roadToTheLeft)
                        {
                            Console.Write("╬");
                            continue;
                        }

                        if (roadAbove && roadBelow && roadToTheRight)
                        {
                            Console.Write("╠");
                            continue;
                        }

                        if (roadAbove && roadBelow && roadToTheLeft)
                        {
                            Console.Write("╣");
                            continue;
                        }

                        if (roadBelow && roadToTheLeft && roadToTheRight)
                        {
                            Console.Write("╦");
                            continue;
                        }

                        if (roadAbove && roadToTheLeft && roadToTheRight)
                        {
                            Console.Write("╩");
                            continue;
                        }

                        if (roadAbove && roadToTheLeft)
                        {
                            Console.Write("╝");
                            continue;
                        }

                        if (roadBelow && roadToTheLeft)
                        {
                            Console.Write("╗");
                            continue;
                        }

                        if (roadAbove && roadToTheRight)
                        {
                            Console.Write("╚");
                            continue;
                        }

                        if (roadBelow && roadToTheRight)
                        {
                            Console.Write("╔");
                            continue;
                        }

                        if (roadAbove && roadBelow)
                        {
                            Console.Write("║");
                            continue;
                        }

                        if (roadToTheLeft && roadToTheRight)
                        {
                            Console.Write("═");
                            continue;
                        }
                    }
                    //Roads end

                    //Empty space
                    Console.Write(" ");
                }
                //Next row
                resetXForNewRow = 0;
                Console.WriteLine();
            }
            //Drawing end
        }

        static void Main(string[] args)
        {
            DrawMap(60, 20);
        }
    }
}