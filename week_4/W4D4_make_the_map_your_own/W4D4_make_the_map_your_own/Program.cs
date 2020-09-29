using System;
using System.Collections.Generic;

namespace W3D3_BOSS_adventure_map
{
    class Program
    {
        /* function for generating vertical curves 
           (width (x) value for start of curve and minimum (x) value for curve, max (x) value for curve, 
           chanse for curve to appear written in % (0-100), how high the the map is (y)) */
        static List<int> GenerateCurve(int startX, int endX, int curveChansePercent, int heightOfMap)
        {
            var random = new Random();
            var listOfCurves = new List<int> { };
            int lastPosition = startX;
            listOfCurves.Add(lastPosition);

            for (var y = 1; y < heightOfMap - 1; y++)
            {
                if (lastPosition < endX && random.Next(100) < curveChansePercent)
                {
                    if (random.Next(2) == 0)
                    {
                        if (lastPosition < endX)
                        {
                            lastPosition++;
                        }
                    }
                    else
                    {
                        if (lastPosition > startX)
                        {
                            lastPosition--;
                        }
                    }
                }

                listOfCurves.Add(lastPosition);
            }

            listOfCurves.Add(lastPosition);

            return listOfCurves;

        }

        /* Function for generating a character when drawing a vertical curve
         
           (width (x), height (y), name of list containing the curve, symbol for no curve (straight down),
           symbol for curve to the right, symbol for curve to the left)*/
        static string Characters(int x, int y, List<int> listContainingCurve, string symbolStraight, string symbolRight, string symbolLeft)
        {
            string symbol = " ";

            if (x == listContainingCurve[y - 1])
            {
                if (x < listContainingCurve[y])
                {
                    symbol = symbolRight;
                }
                else if (x > listContainingCurve[y])
                {
                    symbol = symbolLeft;
                }
                else
                {
                    symbol = symbolStraight;
                }
            }

            return symbol;
        }

        /* Function to draw the map
         
          (width (x) of map - a number from 15 and higher (including border),
           height (y) of map - a number from 7 and higher (including border)*/
        static void DrawMap(int width, int height)
        {
            //adjusting width and height to work with the code
            width--;
            height--;
            var random = new Random();

            //Calculating phase

            //Wall start
            List<int> wallListOfCurves = GenerateCurve(width / 4, width / 3, 100, height);
            //Wall end

            //River start
            List<int> riverListOfCurves = GenerateCurve(width - width / 4, width - 3, 99, height);
            //River end

            //Road (horizontal) start
            var roadListofCurve = new List<int> { };
            int roadLastYPosition = height / 2;
            roadListofCurve.Add(roadLastYPosition);

            for (int x = 1; x < width - 1; x++)
            {
                //straight road when crossing wall
                if (x + 2 == wallListOfCurves[roadLastYPosition - 2] || x + 2 == wallListOfCurves[roadLastYPosition - 1] || x + 2 == wallListOfCurves[roadLastYPosition - 3])
                {
                    for (int straightRoad = 0; straightRoad < 5; straightRoad++)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        roadListofCurve.Add(roadLastYPosition);
                    }

                    x += 5;
                }

                //straight road in the middle when road to city
                if (x == width / 2 - 2 && width > 25)
                {
                    for (int straightRoad = 0; straightRoad < 4; straightRoad++)
                    {
                        roadListofCurve.Add(roadLastYPosition);
                    }

                    x += 4;
                }

                //straight road when crossing river
                if ((x + 6 >= riverListOfCurves[roadLastYPosition]) && (x + 4 <= riverListOfCurves[roadLastYPosition]))
                {
                    for (int straightRoad = 0; straightRoad < 12; straightRoad++)
                    {
                        roadListofCurve.Add(roadLastYPosition);
                    }

                    x += 12;
                }

                //Roadcurves, curve down
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

                //Curve up
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

                if (roadLastYPosition == roadListofCurve[roadListofCurve.Count - 1] - 2)
                {
                    roadLastYPosition += 1;
                }

                if (roadLastYPosition == roadListofCurve[roadListofCurve.Count - 1] + 2)
                {
                    roadLastYPosition -= 1;
                }

                roadListofCurve.Add(roadLastYPosition);
            }
            //road (horizontal) end
            //Calculation phase end

            //Drawing phase

            //Random squirrel
            bool squirrel = random.Next(1) == 0;
            int squirrelYPosition = random.Next(1, height - 4);

            //variable used to reset x on every row
            int resetXForNewRow = 0;

            //variable needed outside the drawing loop for making the bridge straight
            int bridgeXPosition = 0;

            //Swan
            int swan = 0;

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
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("+");
                        continue;
                    }

                    //left and right side
                    if ((x == 0 || x == width) && (y > 0 && y < height))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("|");
                        continue;
                    }

                    //top and bottom row
                    if ((x > 0 && x < width) && (y == 0 || y == height))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("-");
                        continue;
                    }
                    //Border end


                    //Title start
                    string title = "ADVENTURE MAP";

                    if (y == 1 && x == width / 2 - title.Length / 2)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(title);
                        x += title.Length - 1;
                        continue;
                    }
                    //Title end

                    //Squirrel start
                    if (width >= 59 && height >= 19)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        if (squirrel)
                        {

                            if (x == 4 && y == squirrelYPosition)
                            {
                                Console.Write(" ‚,");
                                x += 2;
                                continue;
                            }
                            if (x == 1 && y == squirrelYPosition + 1)
                            {
                                Console.Write(" /)/");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("∞");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(@"\");
                                x += 5;
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
                    //Squirrel end

                    //Tower start DO THIS TODAY!!!
                    if (width >= 59 && height >= 19)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        if (squirrel)
                        {

                            if (x == 4 && y == squirrelYPosition)
                            {
                                Console.Write(" ‚,");
                                x += 2;
                                continue;
                            }
                            if (x == 1 && y == squirrelYPosition + 1)
                            {
                                Console.Write(" /)/");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("∞");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(@"\");
                                x += 5;
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
                    //Tower end

                    //Road (horizontal) start
                    if (y == roadListofCurve[x - 1])
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("€");
                        continue;
                    }
                    //Road (horizontal) end

                    //Wall start
                    if (x == wallListOfCurves[y - 1])
                    {
                        if (y == 1 && x + 1 == width / 2 - title.Length / 2)
                        {
                            Console.Write(" ");
                            continue;
                        }

                        Console.ForegroundColor = ConsoleColor.DarkGray;

                        //if tower needs to be drawn
                        if (y - 1 == roadListofCurve[x - 1] || y + 1 == roadListofCurve[x - 1])
                        {
                            Console.Write("{ }");
                            x++;

                        } //drawing the wall
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
                    //Wall end

                    //Pond start
                    string pondSymbols = "   o≈≈≈≈~~~~";
                    int density = 0;

                    if (y > height - height / 4 && x - 2 == wallListOfCurves[y - 1] && width >= 29 && height >= 14)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        for (int pondSize = 0; pondSize < y - 2; pondSize++)
                        {
                            //if pond is close to edge this stops the drawing of the bridge
                            if (pondSize == width - 1)
                            {
                                x = pondSize;
                                break;
                            }
                            if (random.Next(40) == 0 && swan <= 1)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("2");
                                swan++;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(pondSymbols[random.Next(pondSymbols.Length)]);
                                density++;
                            }
                            x++;
                        }
                    }
                    //Pond end


                    //Forest start
                    string forestSymbol = "AT()&!Å";
                    if (x > 0 && x < width / 4)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;

                        if (random.Next(x) <= 1)
                        {
                            Console.Write(forestSymbol[random.Next(forestSymbol.Length)]);
                            continue;
                        }
                    }
                    //Forest end


                    //Road (vertical) next to river start
                    if (x == riverListOfCurves[y - 1] - 5 && y > roadListofCurve[x])
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("€");

                        continue;
                    }
                    //Road (vertical) next to river end


                    //Road (vertical) next to wall start
                    if (x == wallListOfCurves[y - 1] + 3 && y > roadListofCurve[x] && width >= 29 && height >= 14)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("s");

                        continue;
                    }
                    //Road (vertical) next to wall end


                    //Bridge start
                    //when road and river crosses
                    if (x + 2 == riverListOfCurves[y] && y + 1 == roadListofCurve[x])
                    {
                        bridgeXPosition = riverListOfCurves[y];
                        Console.ForegroundColor = ConsoleColor.DarkGray;

                        //build bridge above road
                        for (int bridgeWidth = 0; bridgeWidth < 7; bridgeWidth++)
                        {
                            //if bridge is close to edge this stops the drawing of the bridge
                            if (x + bridgeWidth == width)
                            {
                                x += bridgeWidth - 1;
                                break;
                            }

                            Console.Write("x");

                            if (bridgeWidth == 6)
                            {
                                x += 6;
                            }
                        }
                        continue;
                    }

                    //build bridge below road
                    if (x + 2 == bridgeXPosition && y - 1 == roadListofCurve[x])
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;

                        for (int bridgeWidth = 0; bridgeWidth < 7; bridgeWidth++)
                        {
                            //if bridge is close to edge this stops the drawing of the bridge
                            if (x + bridgeWidth == width)
                            {
                                x += bridgeWidth - 1;
                                break;
                            }

                            Console.Write("x");

                            if (bridgeWidth == 6)
                            {
                                x += 6;
                            }

                        }
                        continue;
                    }
                    //Bridge end


                    //River start
                    //if title overlaps the first character of the first row of river
                    //second character of first row of river
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

                    //third character of first row of river
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
                    //end of first river row

                    //for the rest of the river
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
                    //River end


                    //City start
                    int cityX = width / 3;
                    int cityY = height / 4;
                    string cityBuildings = "arn^hjo|°•";

                    if (width > 0 && x >= cityX && x <= cityX * 2 && y >= cityY && y <= cityY * 2)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        //density 1
                        if (x > cityX + 3 && x < cityX * 2 - 3 && y >= cityY && y <= cityY + cityY / 3)
                        {
                            //draw
                            if (random.Next(5) == 0)
                            {
                                Console.Write(cityBuildings[random.Next(cityBuildings.Length)]);
                                continue;
                            }
                        }

                        //density 2
                        if (((x > cityX && x < cityX + cityX / 4) || (x > cityX * 2 - cityX / 4 && x < cityX * 2)) && y >= cityY + cityY / 3 && y <= cityY * 2)
                        {
                            //draw
                            if (random.Next(4) == 0)
                            {
                                Console.Write(cityBuildings[random.Next(cityBuildings.Length)]);
                                continue;
                            }
                        }

                        //density 3 & 4
                        if (x >= cityX + cityX / 4 && x <= cityX * 2 - cityX / 4)
                        {
                            if (y >= cityY * 2 - cityY / 3 && y <= cityY * 2)
                            {
                                //draw density 3
                                if (random.Next(3) >= 1)
                                {
                                    Console.Write(cityBuildings[random.Next(cityBuildings.Length)]);
                                    continue;
                                }
                            }
                            else if (y >= cityY + cityY / 3 && y <= cityY * 2 - cityY / 3)
                            {
                                //draw density 4
                                Console.Write(cityBuildings[random.Next(cityBuildings.Length)]);
                                continue;
                            }
                        }
                    }
                    //City end

                    //City road start
                    if (roadListofCurve[width / 2] > height / 2 && x == width / 2 - 1 && y > height / 2 - 1 && y < roadListofCurve[width / 2])
                    {
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
                    //City road end

                    //Mountains start
                    string mountainSymbols = "///////^";
                    if (x > width - width / 10 && x < width && x > riverListOfCurves[y - 1] && width > height)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;

                        if (random.Next(width + 1 - x) == 0)
                        {
                            Console.Write(mountainSymbols[random.Next(mountainSymbols.Length)]);
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                        continue;
                    }
                    //Mountains end

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
