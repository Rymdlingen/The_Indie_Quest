using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Minotaurs_lair
{
    class Program
    {
        static int width;
        static int height;
        static char[,] map;

        // Variables for saving S(start) position
        static int startX;
        static int startY;

        static Random random = new Random();

        // Method for drawing the map
        static void DrawMap()
        {
            // Drawing every character of the map
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // Color for walls
                    Console.ForegroundColor = ConsoleColor.DarkGray;

                    // Randomly generating forest in the first three rows
                    if (y < 3)
                    {
                        if (random.Next(3 + y * 2) == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write("♠");
                            continue;
                        }
                    }

                    // Changing the color for the minotaur
                    if (map[x, y] == 'M')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }

                    // Drawing the character for this coordinate
                    Console.Write(map[x, y]);
                }
                // New line
                Console.WriteLine();
            }

            // Drawing the player at the start position
            Console.CursorTop = startY;
            Console.CursorLeft = startX;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("☺");

            // Setting the cursor at the bottom and the color back to gray
            Console.CursorTop = height;
            Console.CursorLeft = 0;
            Console.ResetColor();

            Console.Beep();
        }

        static void Main(string[] args)
        {
            // Extracting all lines from the text file
            string path = "MazeLevel.txt";
            string[] mazeLevelText = File.ReadAllLines(path);

            // Getting level name from the text file
            string levelName = mazeLevelText[0];

            // Getting level dimensions from text file
            string sizePattern = "(\\d+)x(\\d+)";
            Match sizes = Regex.Match(mazeLevelText[1], sizePattern);
            GroupCollection xAndY = sizes.Groups;

            // Dimensions (x, widthn and y, height)
            width = Int32.Parse(xAndY[1].Value);
            height = Int32.Parse(xAndY[2].Value);

            // Storing level information int an 2-dimensional array
            map = new char[width, height];
            for (int y = 0; y < height; y++)
            {
                // Storing all the data on this height
                string currentRow = mazeLevelText[y + 2];

                for (int x = 0; x < width; x++)
                {
                    // Checking for start position, storing the coordinates and setting the map char to space
                    if (currentRow[x] == 'S')
                    {
                        map[x, y] = ' ';
                        startX = x;
                        startY = y;
                    }
                    else
                    {
                        // Extarcting data from ever x on this y and storing it in the array
                        map[x, y] = currentRow[x];
                    }
                }
            }

            // Drawing!
            DrawMap();
        }
    }
}
