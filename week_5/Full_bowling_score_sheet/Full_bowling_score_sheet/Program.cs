using System;
using System.Collections.Generic;

namespace W3D1_bowling_pins
{
    class Program
    {
        static string Pin(bool knocked)
        {
            // Returns a different symbol if the pin is standing or not
            string symbol;
            if (knocked == true)
            {
                symbol = "O";
            }
            else
            {
                symbol = " ";
            }
            return symbol;
        }

        static int KnockedPinOnPath(int path, List<bool> pinsStanding)
        {
            // Calculates how many pins get knocked down
            var random = new Random();

            // Randomly changes path if the player dosent hit straight
            if (random.Next(10) == 0)
            {
                path++;
            }

            if (random.Next(10) == 0)
            {
                path--;
            }

            // Path 1
            if (path == 1 && pinsStanding[6] == true)
            {
                int knockedPinsCount = 1;
                pinsStanding[6] = false;

                for (int pinAndBall = 0; pinAndBall < 2; pinAndBall++)
                {
                    int newPath = random.Next(5);
                    if (newPath < 2)
                    {
                        knockedPinsCount += KnockedPinOnPath(path + 1, pinsStanding);
                    }
                    else if (newPath > 2)
                    {
                        knockedPinsCount += KnockedPinOnPath(path - 1, pinsStanding);
                    }
                    else
                    {
                        knockedPinsCount += KnockedPinOnPath(path, pinsStanding);
                    }
                }

                return knockedPinsCount;
            }
            // Path 2
            else if (path == 2 && pinsStanding[3] == true)
            {
                int knockedPinsCount = 1;
                pinsStanding[3] = false;

                for (int pinAndBall = 0; pinAndBall < 2; pinAndBall++)
                {
                    int newPath = random.Next(5);
                    if (newPath < 2)
                    {
                        knockedPinsCount += KnockedPinOnPath(path + 1, pinsStanding);
                    }
                    else if (newPath > 2)
                    {
                        knockedPinsCount += KnockedPinOnPath(path - 1, pinsStanding);
                    }
                    else
                    {
                        knockedPinsCount += KnockedPinOnPath(path, pinsStanding);
                    }
                }

                return knockedPinsCount;
            }
            // Path 3
            else if (path == 3)
            {
                if (pinsStanding[1] == true)
                {
                    int knockedPinsCount = 1;
                    pinsStanding[1] = false;

                    for (int pinAndBall = 0; pinAndBall < 2; pinAndBall++)
                    {
                        int newPath = random.Next(5);
                        if (newPath < 2)
                        {
                            knockedPinsCount += KnockedPinOnPath(path + 1, pinsStanding);
                        }
                        else if (newPath > 2)
                        {
                            knockedPinsCount += KnockedPinOnPath(path - 1, pinsStanding);
                        }
                        else
                        {
                            knockedPinsCount += KnockedPinOnPath(path, pinsStanding);
                        }
                    }

                    return knockedPinsCount;
                }
                else if (pinsStanding[7] == true)
                {
                    int knockedPinsCount = 1;
                    pinsStanding[7] = false;

                    for (int pinAndBall = 0; pinAndBall < 2; pinAndBall++)
                    {
                        int newPath = random.Next(5);
                        if (newPath < 2)
                        {
                            knockedPinsCount += KnockedPinOnPath(path + 1, pinsStanding);
                        }
                        else if (newPath > 2)
                        {
                            knockedPinsCount += KnockedPinOnPath(path - 1, pinsStanding);
                        }
                        else
                        {
                            knockedPinsCount += KnockedPinOnPath(path, pinsStanding);
                        }
                    }

                    return knockedPinsCount;
                }
            }
            // Path 4
            else if (path == 4)
            {
                if (pinsStanding[0] == true)
                {
                    int knockedPinsCount = 1;
                    pinsStanding[0] = false;

                    for (int pinAndBall = 0; pinAndBall < 2; pinAndBall++)
                    {
                        int newPath = random.Next(5);
                        if (newPath < 2)
                        {
                            knockedPinsCount += KnockedPinOnPath(path + 1, pinsStanding);
                        }
                        else if (newPath > 2)
                        {
                            knockedPinsCount += KnockedPinOnPath(path - 1, pinsStanding);
                        }
                        else
                        {
                            knockedPinsCount += KnockedPinOnPath(path, pinsStanding);
                        }
                    }

                    return knockedPinsCount;
                }
                else if (pinsStanding[4] == true)
                {
                    int knockedPinsCount = 1;
                    pinsStanding[4] = false;

                    for (int pinAndBall = 0; pinAndBall < 2; pinAndBall++)
                    {
                        int newPath = random.Next(5);
                        if (newPath < 2)
                        {
                            knockedPinsCount += KnockedPinOnPath(path + 1, pinsStanding);
                        }
                        else if (newPath > 2)
                        {
                            knockedPinsCount += KnockedPinOnPath(path - 1, pinsStanding);
                        }
                        else
                        {
                            knockedPinsCount += KnockedPinOnPath(path, pinsStanding);
                        }
                    }

                    return knockedPinsCount;
                }
            }
            // Path 5
            else if (path == 5)
            {
                if (pinsStanding[2] == true)
                {
                    int knockedPinsCount = 1;
                    pinsStanding[2] = false;

                    for (int pinAndBall = 0; pinAndBall < 2; pinAndBall++)
                    {
                        int newPath = random.Next(5);
                        if (newPath < 2)
                        {
                            knockedPinsCount += KnockedPinOnPath(path + 1, pinsStanding);
                        }
                        else if (newPath > 2)
                        {
                            knockedPinsCount += KnockedPinOnPath(path - 1, pinsStanding);
                        }
                        else
                        {
                            knockedPinsCount += KnockedPinOnPath(path, pinsStanding);
                        }
                    }

                    return knockedPinsCount;
                }
                else if (pinsStanding[8] == true)
                {
                    int knockedPinsCount = 1;
                    pinsStanding[8] = false;

                    for (int pinAndBall = 0; pinAndBall < 2; pinAndBall++)
                    {
                        int newPath = random.Next(5);
                        if (newPath < 2)
                        {
                            knockedPinsCount += KnockedPinOnPath(path + 1, pinsStanding);
                        }
                        else if (newPath > 2)
                        {
                            knockedPinsCount += KnockedPinOnPath(path - 1, pinsStanding);
                        }
                        else
                        {
                            knockedPinsCount += KnockedPinOnPath(path, pinsStanding);
                        }
                    }

                    return knockedPinsCount;
                }
            }
            // Path 6
            else if (path == 6 && pinsStanding[5] == true)
            {
                int knockedPinsCount = 1;
                pinsStanding[5] = false;

                for (int pinAndBall = 0; pinAndBall < 2; pinAndBall++)
                {
                    int newPath = random.Next(5);
                    if (newPath < 2)
                    {
                        knockedPinsCount += KnockedPinOnPath(path + 1, pinsStanding);
                    }
                    else if (newPath > 2)
                    {
                        knockedPinsCount += KnockedPinOnPath(path - 1, pinsStanding);
                    }
                    else
                    {
                        knockedPinsCount += KnockedPinOnPath(path, pinsStanding);
                    }
                }

                return knockedPinsCount;
            }
            // Path 7
            else if (path == 7 && pinsStanding[9] == true)
            {
                int knockedPinsCount = 1;
                pinsStanding[9] = false;

                for (int pinAndBall = 0; pinAndBall < 2; pinAndBall++)
                {
                    int newPath = random.Next(5);
                    if (newPath < 2)
                    {
                        knockedPinsCount += KnockedPinOnPath(path + 1, pinsStanding);
                    }
                    else if (newPath > 2)
                    {
                        knockedPinsCount += KnockedPinOnPath(path - 1, pinsStanding);
                    }
                    else
                    {
                        knockedPinsCount += KnockedPinOnPath(path, pinsStanding);
                    }
                }
                // Total knocked pins in one roll
                return knockedPinsCount;
            }
            // Miss
            return 0;
        }

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

            // Displaying my array
            for (int frame = 0; frame < allRolls.Length; frame++)
            {
                Console.WriteLine("Frame {0}", frame + 1);

                int rolls = 0;

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
                Console.WriteLine();
            }
        }
    }
}