using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Minotaurs_lair
{
    class Program
    {
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
            int x = Int32.Parse(xAndY[1].Value);
            int y = Int32.Parse(xAndY[2].Value);

            // Variables for saving S(start) position
            int startX;
            int startY;

            // Storing level information int an 2-dimensional array
            char[,] level = new char[x, y];
            for (int height = 0; height < y; height++)
            {
                // Storing all the data on this height
                string currentRow = mazeLevelText[height + 2];

                for (int width = 0; width < x; width++)
                {
                    // Extarcting data from ever x on this y
                    level[width, height] = currentRow[width];

                    // Checking for start position and storing the coordinates
                    if (currentRow[width] == 'S')
                    {
                        startX = width;
                        startY = height;
                    }
                }
            }
        }
    }
}
