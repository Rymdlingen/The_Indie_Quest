using System;
using System.Collections.Generic;

//System.Console.CursorLeft james suggestion to use that to animate the squirrel

namespace W3D3_BOSS_adventure_map
{
    class Program
    {
        /* Method for generating vertical curves 
           (width (x) value for start of curve and minimum (x) value for curve, max (x) value for curve, 
           chanse for curve to appear written in % (0-100), how high the the map is (y)) */
        static List<int> GenerateCurve(int startX, int endX, int curveChansePercent, int heightOfMap)
        {
            var random = new Random();
            var listOfCurves = new List<int> { };
            int lastPosition = startX;
            listOfCurves.Add(lastPosition);

            // Goes from the top of the map (plus 1 for the frame) to the bottom of the map (minus 1 for the frame), generates x values and store them in a list.
            for (var y = 1; y < heightOfMap - 1; y++)
            {
                // Randomly decides to change the position.
                if (lastPosition < endX && random.Next(100) < curveChansePercent)
                {
                    // Randomly decides if the curve is changing to th left or right.
                    if (random.Next(2) == 0)
                    {
                        // Change to the right.
                        if (lastPosition < endX)
                        {
                            lastPosition++;
                        }
                    }
                    else
                    {
                        // Change to the left.
                        if (lastPosition > startX)
                        {
                            lastPosition--;
                        }
                    }
                }

                // Add the latest (possibly changed) location to the list.
                listOfCurves.Add(lastPosition);
            }

            // Add the last position one last time, it is not going to be drawn but is used to male sure the river is drawn nicely.
            listOfCurves.Add(lastPosition);
            return listOfCurves;
        }

        /* Method for generating a character when drawing a vertical curve
         
           (width (x), height (y), name of list containing the curve, symbol for no curve (straight down),
           symbol for curve to the right, symbol for curve to the left)*/
        static string Characters(int x, int y, List<int> listContainingCurve, string symbolStraight, string symbolRight, string symbolLeft)
        {
            string symbol = " ";

            // Checks if the current x value is on the list of curves for this y (-1 because the list starts after the frame).
            if (x == listContainingCurve[y - 1])
            {
                // If the next x value for the curve is more then the current x draw the symobl that curves to the right.
                if (x < listContainingCurve[y])
                {
                    symbol = symbolRight;
                }
                // If the next x value for the curve is less then the current x draw the symobl that curves to the left.
                else if (x > listContainingCurve[y])
                {
                    symbol = symbolLeft;
                }
                // If the next x value for the curve is the same as the current x draw the symobl that does not curve.
                else
                {
                    symbol = symbolStraight;
                }
            }

            // Returns the current symbol to be drawn before the method does a new calculation.
            return symbol;
        }

        /* Method to draw the map
         
          (width (x) of map - a number from 15 and higher (including border),
           height (y) of map - a number from 7 and higher (including border)*/
        static void DrawMap(int width, int height)
        {
            // Adjusting width and height to work with the code.
            width--;
            height--;
            var random = new Random();

            //Calculating phase

            // Wall calculation start.
            // Generates a list of the x values of the vertical curve for the wall.
            List<int> wallListOfCurves = GenerateCurve(width / 4, width / 3, 40, height);
            // Wall calculation end.

            // River calculation start.
            // Generates a list of the x values of the vertical curve for the river.
            List<int> riverListOfCurves = GenerateCurve(width - width / 4, width - 3, 80, height);
            // River calculation end.

            //Road (horizontal) calculation start.
            var roadListofCurve = new List<int> { };
            int roadLastYPosition = height / 2;
            roadListofCurve.Add(roadLastYPosition);

            for (int x = 1; x < width - 1; x++)
            {
                // Makes sure the road is straight when crossing the wall.
                if (x + 2 == wallListOfCurves[roadLastYPosition] || x + 2 == wallListOfCurves[roadLastYPosition - 1] || x + 2 == wallListOfCurves[roadLastYPosition + 1])
                {
                    for (int straightRoad = 0; straightRoad < 5; straightRoad++)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        roadListofCurve.Add(roadLastYPosition);
                    }

                    x += 5;
                }

                // Makes sure the road is straight when there is going to be a small vertical road to the city..
                if (x == width / 2 - 2 && width > 25)
                {
                    for (int straightRoad = 0; straightRoad < 4; straightRoad++)
                    {
                        roadListofCurve.Add(roadLastYPosition);
                    }

                    x += 4;
                }

                // Makes sure the road is straight when crossing the river.
                if ((x + 6 >= riverListOfCurves[roadLastYPosition]) && (x + 4 <= riverListOfCurves[roadLastYPosition]))
                {
                    for (int straightRoad = 0; straightRoad < 12; straightRoad++)
                    {
                        roadListofCurve.Add(roadLastYPosition);
                    }

                    x += 12;
                }

                // Calculating the curves of the road.
                // Curve down.
                if (random.Next(6) == 0 && roadLastYPosition < height - height / 4 - 1)
                {
                    roadLastYPosition += 1;
                    if (x > 2 && roadListofCurve[roadListofCurve.Count - 2] == roadLastYPosition && roadListofCurve[roadListofCurve.Count - 1] == roadLastYPosition - 1)
                    {
                        if (random.Next(4) <= 2 && roadLastYPosition < height - 3)
                        {
                            roadLastYPosition -= 2;
                        }
                        else
                        {
                            roadLastYPosition -= 1;
                        }
                    }
                }

                // Curve up.
                if (random.Next(8) == 0 && roadLastYPosition > 3)
                {
                    roadLastYPosition -= 1;
                    if (x > 2 && roadListofCurve[roadListofCurve.Count - 2] == roadLastYPosition && roadListofCurve[roadListofCurve.Count - 1] == roadLastYPosition + 1)
                    {
                        if (random.Next(4) <= 2 && roadLastYPosition > 3)
                        {
                            roadLastYPosition += 2;
                        }
                        else
                        {
                            roadLastYPosition += 1;
                        }
                    }
                }

                // Makes sure the road never goes directly in the opposite direction that creates a zigzag pattern, example: up, down, up.
                if (roadLastYPosition == roadListofCurve[roadListofCurve.Count - 1] - 2)
                {
                    roadLastYPosition += 1;
                }

                if (roadLastYPosition == roadListofCurve[roadListofCurve.Count - 1] + 2)
                {
                    roadLastYPosition -= 1;
                }

                // After all these rules, random chanses and calculations add the y value to the list.
                roadListofCurve.Add(roadLastYPosition);
            }
            // Road (horizontal) calculation end.

            // Squirrel calculations start.
            // Randomly decides of there is going to be a squirrel on the map and randomly decides where its going to be.
            bool squirrel = random.Next(2) == 0;
            int squirrelYPosition = random.Next(1, height - 4);
            // Squirrel calculations end.

            // Tower calculations start.
            // Randomly decides if is going to be a tower on the map.
            bool tower = random.Next(2) == 0;

            // Randomly decides if the tower is going to be above or below the horizental road.
            int towerYPosition = 0;
            if (random.Next(2) == 0)
            {
                if (roadListofCurve[width - 2] > 10)
                {
                    towerYPosition = random.Next(1, roadListofCurve[width - 2] - 9);
                }
            }
            else
            {
                if (roadListofCurve[width - 2] < height - 10)
                {
                    towerYPosition = random.Next(roadListofCurve[width - 2] + 1, height - 8);
                }
            }
            // Tower calculations end.

            // Calculation phase end.



            // Drawing phase starts.

            // Variable used to reset x on every row (for every new y value).
            int resetXForNewRow = 0;

            // Variable needed to be initialized outside the drawing loop for making the bridge straight.
            int bridgeXPosition = 0;

            // Count of swans drawn.
            int swan = 0;

            // Outer loop for height (y).
            for (int y = 0; y <= height; y++)
            {
                // Inner loop for width (x).
                for (int x = resetXForNewRow; x <= width; x++)
                {
                    // Checks if border should be drawn at the current x and y values.
                    if ((x == 0 && y == 0) || (x == 0 && y == height) || (x == width && y == 0) || (x == width && y == height))
                    {
                        // Corners.
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("+");
                        continue;
                    }
                    if ((x == 0 || x == width) && (y > 0 && y < height))
                    {
                        // Left and right side.
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("|");
                        continue;
                    }
                    if ((x > 0 && x < width) && (y == 0 || y == height))
                    {
                        // Top and bottom row.
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("-");
                        continue;
                    }
                    // End of border drawing.


                    // Checks if title should be drawn at the current x and y values.
                    string title = "ADVENTURE MAP";

                    if (y == 1 && x == width / 2 - title.Length / 2)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(title);
                        x += title.Length - 1;
                        continue;
                    }
                    // End of title drawing.


                    // Checks if squirrel should be drawn at the current x and y values.
                    if (width >= 59 && height >= 19)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;

                        // Checks if it was decided that there should be a squirrel.
                        if (squirrel)
                        {
                            // Draws the ASCII-art for the squirrel at the correct position and with the correct colors.
                            if (x == 5 && y == squirrelYPosition)
                            {
                                Console.Write("‚,");
                                x++;
                                continue;
                            }
                            if (x == 2 && y == squirrelYPosition + 1)
                            {
                                Console.Write("/)/");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("∞");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(@"\");
                                x += 4;
                                continue;
                            }
                            if (x == 1 && y == squirrelYPosition + 2)
                            {
                                Console.Write(@"(_(,”,)");
                                x += 6;
                                continue;
                            }
                        }
                    }
                    // End of squirrel drawing.


                    // Checks if tower should be drawn at the current x and y values.
                    if (riverListOfCurves.Contains(width - 10))
                    {
                        //If the river goes to far to the right at any point the tower won't be drawn
                    }
                    else if (width >= 79 && height >= 24 && towerYPosition != 0)
                    {
                        // If there was space for the tower, this code draws the ASCII-art for it int the correct position and with the correct colors.
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        if (tower)
                        {
                            if (x == width - 3 && y == towerYPosition)
                            {
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.Write("~");
                                continue;
                            }
                            if (x == width - 1 && y == towerYPosition + 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.Write("~");
                                continue;
                            }
                            if (x == width - 4 && y == towerYPosition + 2)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write(@"/\n");
                                x += 2;
                                continue;
                            }
                            if (x == width - 6 && y == towerYPosition + 3)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write(@"„/");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("*°");
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write(@"\");
                                x += 4;
                                continue;
                            }
                            if (x == width - 7 && y == towerYPosition + 4)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write(@"/");
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.Write("|");
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("____");
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.Write("|");
                                x += 6;
                                continue;
                            }
                            if (x == width - 7 && y == towerYPosition + 5)
                            {
                                Console.Write("l_|");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("•°");
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.Write("|");
                                x += 5;
                                continue;
                            }
                            if (x == width - 5 && y == towerYPosition + 6)
                            {
                                Console.Write("|");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("~ ");
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.Write("|");
                                x += 3;
                                continue;
                            }
                            if (x == width - 5 && y == towerYPosition + 7)
                            {
                                Console.Write("|");
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("n");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("°");
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.Write("|");
                                x += 3;
                                continue;
                            }
                        }
                    }
                    // End of tower drawing.

                    // Checks if road (horizontal) should be drawn at the current x and y values.
                    if (y == roadListofCurve[x - 1])
                    {
                        // Draws the road.
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("€");
                        continue;
                    }
                    // End of road (horizontal) drawing.


                    // Checks if wall should be drawn at the current x and y values.
                    if (x == wallListOfCurves[y - 1])
                    {
                        // Makes sure the tower does not collide with the title.
                        if (y == 1 && x + 1 == width / 2 - title.Length / 2)
                        {
                            Console.Write(" ");
                            continue;
                        }

                        // Checks if a wall tower needs to be drawn.
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        if (y - 1 == roadListofCurve[x - 1] || y + 1 == roadListofCurve[x - 1])
                        {
                            Console.Write("{ }");
                            x++;

                        } // Draws the wall.
                        else
                        {
                            for (var wallThickness = 0; wallThickness < 2; wallThickness++)
                            {
                                Console.Write(Characters(x, y, wallListOfCurves, "|", @"\", "/"));
                            }
                        }

                        x += 1;
                        continue;
                    }
                    // End of wall drawing.


                    // Checks if the pond should be drawn at the current x and y values.
                    // Symbols used for drawing the pond.
                    string pondSymbols = "   o≈≈≈≈~~~~";
                    // The start value for the denisty of symbols in the pond.
                    int density = 0;

                    // The pond is always drawn in the bottom quarter of the map, to the right of the wall and only if the map is big enough.
                    if (y > height - height / 4 && x - 2 == wallListOfCurves[y - 1] && width >= 29 && height >= 14)
                    {
                        // Draws the pond.
                        Console.ForegroundColor = ConsoleColor.Blue;
                        for (int pondSize = 0; pondSize < y - 2; pondSize++)
                        {
                            // If pond is close to the right edge of the map this stops the drawing of the pond.
                            if (x == width - 1)
                            {
                                x = width - 1;
                                break;
                            }

                            // Randomly places up to two swans in the pond.
                            if (random.Next(40) == 0 && swan <= 1)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("2");
                                swan++;
                            }
                            // Otherwise draws a pond symbol.
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(pondSymbols[random.Next(pondSymbols.Length)]);
                                density++;
                            }

                            x++;
                        }
                    }
                    // End of pond drawing.


                    // Checks if the pond should be drawn at the current x and y values.
                    // Symbols used to draw the forest.
                    string forestSymbol = "AT()&!Å";
                    if (x > 0 && x < width / 4)
                    {
                        // Randomly draws a forest symbol based on the current x value, the lower x value, the higher chanse of a tree.
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        if (random.Next(x) <= 1)
                        {
                            Console.Write(forestSymbol[random.Next(forestSymbol.Length)]);
                            continue;
                        }
                    }
                    // End of forest drawing.


                    // Checks if road (vertical) next to river should be drawn at the current x and y values.
                    if (x == riverListOfCurves[y - 1] - 5 && y > roadListofCurve[x])
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("€");
                        continue;
                    }
                    // End of road (vertical) next to river drawing.

                    // Checks if road (vertical) next to wall should be drawn at the current x and y values.
                    if (x == wallListOfCurves[y - 1] + 3 && y > roadListofCurve[x] && width >= 29 && height >= 14)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("s");
                        continue;
                    }
                    // End of road (vertical) next to wall drawing.


                    // Checks if the bridge should be drawn at the current x and y values.
                    // Check if the road and river crosses.
                    if (x + 2 == riverListOfCurves[y] && y + 1 == roadListofCurve[x])
                    {
                        bridgeXPosition = riverListOfCurves[y];
                        Console.ForegroundColor = ConsoleColor.DarkGray;

                        // Draw bridge above road.
                        for (int bridgeWidth = 0; bridgeWidth < 7; bridgeWidth++)
                        {
                            // If bridge is close to right edge of the map this stops the drawing of the bridge.
                            if (x + bridgeWidth == width)
                            {
                                x += bridgeWidth - 1;
                                break;
                            }
                            // Bridge symbol.
                            Console.Write("x");

                            // If the bridge symbol is drawn 6 times, the bridge is done. 
                            if (bridgeWidth == 6)
                            {
                                x += 6;
                            }
                        }

                        continue;
                    }

                    // Draw bridge below road.
                    if (x + 2 == bridgeXPosition && y - 1 == roadListofCurve[x])
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        for (int bridgeWidth = 0; bridgeWidth < 7; bridgeWidth++)
                        {
                            // If bridge is close to right edge of the map this stops the drawing of the bridge.
                            if (x + bridgeWidth == width)
                            {
                                x += bridgeWidth - 1;
                                break;
                            }
                            // Bridge symbol.
                            Console.Write("x");

                            // If the bridge symbol is drawn 6 times, the bridge is done. 
                            if (bridgeWidth == 6)
                            {
                                x += 6;
                            }
                        }

                        continue;
                    }
                    // End of bridge drawing.


                    // Checks if the river should be drawn at the current x and y values.
                    // If the title collides with the first character of the rivers first row the second character of that row is drawn.
                    if (y == 1 && x == riverListOfCurves[y - 1] + 1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        for (var twoRiverSymbols = 0; twoRiverSymbols < 2; twoRiverSymbols++)
                        {
                            if (x - 1 < riverListOfCurves[y])
                            {
                                Console.Write(@"(");
                                continue;
                            }

                            if (x - 1 > riverListOfCurves[y])
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

                    // Third character of first row of river.
                    if (y == 1 && x == riverListOfCurves[y - 1] + 2)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        if (x - 2 < riverListOfCurves[y])
                        {
                            Console.Write(@"(");
                            continue;
                        }

                        if (x - 2 > riverListOfCurves[y])
                        {
                            Console.Write(")");
                            continue;
                        }
                        Console.Write("|");
                        continue;
                    }
                    // End of first river row (if it collides with title).

                    // Drawing a river 3 characters wide, based on the generated curve.
                    if (x == riverListOfCurves[y - 1])
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        for (var riverWidth = 0; riverWidth < 3; riverWidth++)
                        {
                            Console.Write(Characters(x, y, riverListOfCurves, "|", "(", ")"));
                        }

                        x += 2;
                        continue;
                    }
                    // End of river drawing.


                    // Initializing variables for the position of the city.
                    int cityX = width / 3;
                    int cityY = height / 4;
                    // City symbols.
                    string cityBuildings = "arn^hjo|°•";

                    // Checks if the city should be drawn at the current x and y values.
                    if (width > 0 && x >= cityX && x <= cityX * 2 && y >= cityY && y <= cityY * 2)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        // Checks if the current position should have this density (1).
                        if (x > cityX + 3 && x < cityX * 2 - 3 && y >= cityY && y <= cityY + cityY / 3)
                        {
                            // Drawing random city symbols.
                            if (random.Next(5) == 0)
                            {
                                Console.Write(cityBuildings[random.Next(cityBuildings.Length)]);
                                continue;
                            }
                        }
                        // Checks if the current position should have this density (2).
                        if (((x > cityX && x < cityX + cityX / 4) || (x > cityX * 2 - cityX / 4 && x < cityX * 2)) && y >= cityY + cityY / 3 && y <= cityY * 2)
                        {
                            // Drawing random city symbols.
                            if (random.Next(4) == 0)
                            {
                                Console.Write(cityBuildings[random.Next(cityBuildings.Length)]);
                                continue;
                            }
                        }
                        // Checks if the current position should have this density (3 and 4).
                        if (x >= cityX + cityX / 4 && x <= cityX * 2 - cityX / 4)
                        {
                            if (y >= cityY * 2 - cityY / 3 && y <= cityY * 2)
                            {
                                // Drawing random city symbols (density 3).
                                if (random.Next(3) >= 1)
                                {
                                    Console.Write(cityBuildings[random.Next(cityBuildings.Length)]);
                                    continue;
                                }
                            }
                            else if (y >= cityY + cityY / 3 && y <= cityY * 2 - cityY / 3)
                            {
                                // Drawing random city symbols (density 4).
                                Console.Write(cityBuildings[random.Next(cityBuildings.Length)]);
                                continue;
                            }
                        }
                    }
                    // End of city drawing.


                    // Checks if the city road should be drawn at the current x and y values.
                    if (roadListofCurve[width / 2] > height / 2 && x == width / 2 - 1 && y > height / 2 - 1 && y < roadListofCurve[width / 2])
                    {
                        // Custumises the road depending on the width of the map.
                        if (width >= 49)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write("•");
                            x++;
                        }

                        if (width >= 34)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("||");
                            x++;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write(" |");
                            x++;
                        }

                        if (width >= 49)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write("•");
                            x++;
                        }
                        continue;
                    }
                    // End of city road drawing.


                    // Checks if the mountains should be drawn at the current x and y values.
                    string mountainSymbols = "///////^";
                    if (x > width - width / 10 && x < width && x > riverListOfCurves[y - 1] && width > height)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        // Randomly chooses a symbol or nothing.
                        if (random.Next(width - x) <= 0)
                        {
                            Console.Write(mountainSymbols[random.Next(mountainSymbols.Length)]);
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                        continue;
                    }
                    // End of mountains drawing.


                    // Draws empty space.
                    Console.Write(" ");
                }
                // Resets the x value for the next row.
                resetXForNewRow = 0;
                Console.WriteLine();
            }
            // End of drawing phase.
        }

        static void Main(string[] args)
        {
            DrawMap(90, 35);
        }
    }
}