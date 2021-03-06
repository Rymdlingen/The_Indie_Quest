﻿using System;
using System.Collections.Generic;

namespace W3D1_bowling_pins
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();

            // Creating an array of 10 rolls
            int[][] allRolls = new int[10][];

            for (int frame = 0; frame < 10; frame++)
            {
                int roll1 = random.Next(11);

                if (roll1 < 10 && frame == 9)
                {
                    int roll2 = random.Next(11 - roll1);

                    if (roll1 + roll2 == 10)
                    {
                        int roll3 = random.Next(11);
                        allRolls[frame] = new int[] { roll1, roll2, roll3 };
                    }
                    else
                    {
                        allRolls[frame] = new int[] { roll1, roll2 };
                    }
                }
                else if (roll1 < 10)
                {
                    int roll2 = random.Next(11 - roll1);
                    allRolls[frame] = new int[] { roll1, roll2 };
                }
                else if (roll1 == 10 && frame == 9)
                {
                    int roll2 = random.Next(11);
                    int roll3 = random.Next(11 - roll2);
                    allRolls[frame] = new int[] { roll1, roll2, roll3 };
                }
                else if (roll1 == 10)
                {
                    allRolls[frame] = new int[] { roll1 };
                }
            }

            // Calculating gained points for each frame
            int[] pointsGained = new int[10];

            for (int frame = 0; frame <= allRolls.Length - 1; frame++)
            {
                for (int rolls = 0; rolls <= allRolls[frame].Length - 1; rolls++)
                {
                    pointsGained[frame] += allRolls[frame][rolls];

                    // If it's the last frame this will just add the last rolls together
                    // and then skip the rest of the calculations, since they don't need to happen
                    if (frame == 9)
                    {
                        continue;
                    }

                    // If you get a strike
                    if (allRolls[frame].Length == 1)
                    {
                        if (allRolls[frame + 1].Length == 2 || allRolls[frame + 1].Length == 3)
                        {
                            pointsGained[frame] += allRolls[frame + 1][rolls];
                            pointsGained[frame] += allRolls[frame + 1][rolls + 1];
                        }
                        else
                        {
                            pointsGained[frame] += allRolls[frame + 1][rolls];
                            pointsGained[frame] += allRolls[frame + 2][rolls];
                        }
                    }

                    // If you get a spare
                    if (rolls == 1 && allRolls[frame][rolls - 1] + allRolls[frame][rolls] == 10)
                    {
                        pointsGained[frame] += allRolls[frame + 1][0];
                    }

                }
            }

            // Calculating the total score (and storing the score from each frame)

            int[] frameScores = new int[10];

            frameScores[0] = pointsGained[0];

            for (int frame = 1; frame < pointsGained.Length; frame++)
            {
                frameScores[frame] = frameScores[frame - 1] + pointsGained[frame];
            }

            // Displaying my array
            for (int frame = 0; frame < allRolls.Length; frame++)
            {
                Console.WriteLine("Frame {0}", frame + 1);

                int rolls = 0;

                // Calculating this frames total knocked pins
                int knockedPins = allRolls[frame][rolls];
                if (allRolls[frame].Length == 2)
                {
                    knockedPins += allRolls[frame][rolls + 1];
                }
                if (allRolls[frame].Length == 3)
                {
                    knockedPins += allRolls[frame][rolls + 1] + allRolls[frame][rolls + 2];
                }

                // Displaying a frame with 1 roll
                if (allRolls[frame].Length == 1)
                {
                    Console.WriteLine($"Roll {rolls + 1}: X");
                }
                // Displaying a fram with 2 rolls
                else if (allRolls[frame].Length == 2)
                {
                    while (rolls < 2)
                    {
                        if (rolls == 0)
                        {
                            if (allRolls[frame][rolls] == 10)
                            {
                                Console.WriteLine($"Roll {rolls + 1}: X");
                            }
                            else
                            {
                                Console.WriteLine($"Roll {rolls + 1}: " + "{0}", allRolls[frame][rolls] == 0 ? "-" : $"{allRolls[frame][rolls]}");
                            }
                        }
                        else
                        {
                            if (allRolls[frame][rolls] == 10)
                            {
                                Console.WriteLine($"Roll {rolls + 1}: " + "{0}", allRolls[frame][rolls - 1] == 10 ? "X" : "/");
                            }
                            else if (allRolls[frame][rolls] > 0)
                            {
                                Console.WriteLine($"Roll {rolls + 1}: " + "{0}", allRolls[frame][rolls] + allRolls[frame][rolls - 1] == 10 ? "/" : $"{allRolls[frame][rolls]}");
                            }
                            else
                            {
                                Console.WriteLine($"Roll {rolls + 1}: -");
                            }
                        }
                        rolls++;
                    }
                }
                // Displaying a frame with 3 rolls
                else
                {
                    while (rolls < 3)
                    {
                        if (rolls == 0)
                        {
                            if (allRolls[frame][rolls] == 10)
                            {
                                Console.WriteLine($"Roll {rolls + 1}: X");
                            }
                            else
                            {
                                Console.WriteLine($"Roll {rolls + 1}: " + "{0}", allRolls[frame][rolls] == 0 ? "-" : $"{allRolls[frame][rolls]}");
                            }
                        }
                        else if (rolls == 1)
                        {
                            if (allRolls[frame][rolls] == 10)
                            {
                                Console.WriteLine($"Roll {rolls + 1}: " + "{0}", allRolls[frame][rolls - 1] == 10 ? "X" : "/");
                            }
                            else if (allRolls[frame][rolls] > 0)
                            {
                                Console.WriteLine($"Roll {rolls + 1}: " + "{0}", allRolls[frame][rolls] + allRolls[frame][rolls - 1] == 10 ? "/" : $"{allRolls[frame][rolls]}");
                            }
                            else
                            {
                                Console.WriteLine($"Roll {rolls + 1}: -");
                            }
                        }
                        else
                        {
                            if ((allRolls[frame][rolls - 1] == 10 || allRolls[frame][rolls - 2] + allRolls[frame][rolls - 1] == 10) && allRolls[frame][rolls] == 10)
                            {
                                Console.WriteLine($"Roll {rolls + 1}: X");
                            }
                            else if (allRolls[frame][rolls] > 0)
                            {
                                Console.WriteLine($"Roll {rolls + 1}: " + "{0}", allRolls[frame][rolls] + allRolls[frame][rolls - 1] == 10 && allRolls[frame][rolls - 2] + allRolls[frame][rolls - 1] != 10 ? "/" : $"{allRolls[frame][rolls]}");
                            }
                            else
                            {
                                Console.WriteLine($"Roll {rolls + 1}: -");
                            }
                        }
                        rolls++;
                    }
                }
                Console.WriteLine($"Knocked pins: {knockedPins}");
                Console.WriteLine($"Points gained: {pointsGained[frame]}");
                Console.WriteLine($"Score: {frameScores[frame]}");
                Console.WriteLine();
            }
        }
    }
}