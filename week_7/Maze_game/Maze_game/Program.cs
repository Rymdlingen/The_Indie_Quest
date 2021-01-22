using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Maze_game
{
    class Program
    {
        static int width;
        static int height;
        static char[,] map;
        static string levelName;

        // Variables for saving S (start) position.
        static int playerX;
        static int playerY;

        static Random random = new Random();

        // Method for displaying the title screen.
        static void TitleScreen()
        {
            // Displaying the levels name and asking for player to press any key to continue.
            Console.WriteLine($"Get ready for: {levelName}!\n\nPress any key to start...");
            Console.ReadKey();
        }

        // Method for displaying the end screen if you win (catch the minotaur).
        static void Winner()
        {
            Console.WriteLine("You have reached the Minotaur. You win!");
        }

        // Method for drawing the map.
        static void DrawMap()
        {
            // Reset the cursor position to top left corenr so it draws over the previous text!
            Console.SetCursorPosition(0, 0);

            // Drawing every character of the map.
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // Color for walls.
                    Console.ForegroundColor = ConsoleColor.DarkGray;

                    // Changing color for the forest.
                    if (y < 3)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }

                    // Changing the color for the minotaur.
                    if (map[x, y] == 'M')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }

                    // Drawing the character for this coordinate.
                    Console.Write(map[x, y]);
                }
                // New line.
                Console.WriteLine();
            }
            Console.WriteLine();

            // Drawing the player at the start position.
            Console.SetCursorPosition(playerX, playerY);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("P");

            // Setting the cursor at the bottom and the color back to gray.
            Console.SetCursorPosition(0, height);
            Console.ResetColor();

            // BEEP!
            //Console.Beep();
        }


        static void Main(string[] args)
        {
            // Extracting all lines from the text file.
            string path = "MazeLevel.txt";
            string[] mazeLevelText = File.ReadAllLines(path);

            // Getting level name from the text file.
            levelName = mazeLevelText[0];

            // Getting level dimensions from text file.
            string sizePattern = "(\\d+)x(\\d+)";
            Match sizes = Regex.Match(mazeLevelText[1], sizePattern);
            GroupCollection xAndY = sizes.Groups;

            // Dimensions (x, widthn and y, height).
            width = Int32.Parse(xAndY[1].Value);
            height = Int32.Parse(xAndY[2].Value);

            // Storing level information in an 2-dimensional array.
            map = new char[width, height];
            for (int y = 0; y < height; y++)
            {
                // Storing all the data on this height.
                string currentRow = mazeLevelText[y + 2];

                for (int x = 0; x < width; x++)
                {
                    // Checking for start position, storing the coordinates and setting the map char to space.
                    if (currentRow[x] == 'S')
                    {
                        map[x, y] = ' ';
                        playerX = x;
                        playerY = y;
                    }
                    else
                    {
                        // Randomly generating forest in the first three rows.
                        if (y < 2 && y < 5)
                        {
                            if (random.Next(3 + y * 2) == 0)
                            {
                                map[x, y] = '♠';
                                continue;
                            }
                        }

                        // Extarcting data from ever x on this y and storing it in the array.
                        map[x, y] = currentRow[x];
                    }
                }
            }

            // Output title screen.
            TitleScreen();

            // Drawing map.
            DrawMap();

            // Asking for keyinput and draw new map ever time arrowkeys are pressed with a updated position for the player.
            bool stopGame = false;
            while (!stopGame)
            {
                var keyInput = Console.ReadKey(true).Key;

                // Up pressed.
                if (keyInput == ConsoleKey.UpArrow && playerY > 0 && map[playerX, playerY - 1] == ' ' || map[playerX, playerY - 1] == 'M')
                {
                    playerY -= 1;
                    DrawMap();
                } // Down pressed.
                else if (keyInput == ConsoleKey.DownArrow && playerY < height - 1 && map[playerX, playerY + 1] == ' ' || map[playerX, playerY + 1] == 'M')
                {
                    playerY += 1;
                    DrawMap();
                } // Left pressed.
                else if (keyInput == ConsoleKey.LeftArrow && playerX > 0 && map[playerX - 1, playerY] == ' ' || map[playerX - 1, playerY] == 'M')
                {
                    playerX -= 1;
                    DrawMap();
                } // Right pressed.
                else if (keyInput == ConsoleKey.RightArrow && playerX < width - 1 && map[playerX + 1, playerY] == ' ' || map[playerX + 1, playerY] == 'M')
                {
                    playerX += 1;
                    DrawMap();
                } // Escape (end game) pressed.
                else if (keyInput == ConsoleKey.Escape)
                {
                    stopGame = true;
                }

                // If the player reaches the M, the player wins and the end text is displayed.
                if (map[playerX, playerY] == 'M')
                {
                    Winner();
                    stopGame = true;
                }
            }
        }
    }
}
