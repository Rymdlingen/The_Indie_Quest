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
            int roll = 0;
            int hitsRoll1 = 0;
            int hitsRoll2 = 0;
            string roll1Text = " ";
            string roll2Text = " ";
            var random = new Random();
            int numberOfFrames = random.Next(1, 11);
            int frames = 0;
            string topBot = "+-----";
            string topBotEnd = "+";
            string row2;
            string row2End = "|";
            string row3 = "| ----";
            string row3End = "|";
            string row4 = "|     ";
            string row4End = "|";

            while (frames < numberOfFrames)
            {
                var allPinsStanding = new List<bool> { true, true, true, true, true, true, true, true, true, true };

                //Loop for displaying the frame and pins three times
                for (int rolls = 0; rolls < 3; rolls++)
                {
                    //First roll
                    if (rolls == 1)
                    {

                        if (hitsRoll1 == 0)
                        {
                            roll1Text = "-";
                        }
                        else if (hitsRoll1 == 10)
                        {
                            roll1Text = "X";
                        }
                        else
                        {
                            roll1Text = $"{hitsRoll1}";
                        }
                    }

                    //Second roll
                    if (rolls == 2 && hitsRoll1 < 10)
                    {
                        if (hitsRoll2 == 0)
                        {
                            roll2Text = "-";
                        }
                        else if (hitsRoll1 + hitsRoll2 == 10)
                        {
                            roll2Text = "/";
                        }
                        else
                        {
                            roll2Text = $"{hitsRoll2}";
                        }
                    }

                    //Draw
                    row2 = $"| |{roll1Text}|{roll2Text}";
                    Console.WriteLine($"Frame {frames + 1}.\n");
                    Console.WriteLine(topBot + topBotEnd);
                    Console.WriteLine(row2 + row2End);
                    Console.WriteLine(row3 + row3End);
                    Console.WriteLine(row4 + row4End);
                    Console.WriteLine(topBot + topBotEnd);
                    Console.WriteLine("\nCurrent pins:\n");
                    Console.WriteLine($"" +
                        $"{Pin(allPinsStanding[6])}   {Pin(allPinsStanding[7])}   {Pin(allPinsStanding[8])}   {Pin(allPinsStanding[9])}\n" +
                        $"\n  {Pin(allPinsStanding[3])}   {Pin(allPinsStanding[4])}   {Pin(allPinsStanding[5])}\n" +
                        $"\n    {Pin(allPinsStanding[1])}   {Pin(allPinsStanding[2])}\n" +
                        $"\n      {Pin(allPinsStanding[0])}");
                    Console.WriteLine("\n1 2 3 4 5 6 7");

                    // Marking the choosen path
                    if (rolls > 0)
                    {
                        Console.Write($"{"".PadLeft((roll - 1) * 2, ' ')}^");
                    }

                    // Asking for player to choose path
                    if (rolls < 2 && hitsRoll1 < 10)
                    {
                        Console.Write($"\nEnter where you roll the ball (1-7): ");
                        string choosenPath = Console.ReadLine();
                        // If player just press enter, ask for path again
                        while (choosenPath == "")
                        {
                            Console.CursorLeft = 0;
                            Console.CursorTop = 19;
                            Console.Write("You have to write a number.");
                            Console.Write($"\nEnter where you roll the ball (1-7): ");
                            choosenPath = Console.ReadLine();
                        }
                        roll = Int32.Parse(choosenPath);
                    }
                    else
                    {
                        // After two rolls, reset bowlinglane
                        Console.Write("\nPress enter to continue.");
                        Console.ReadLine();
                        hitsRoll1 = 0;
                        Console.Clear();
                        break;
                    }

                    // Calculate roll 1
                    if (rolls == 0)
                    {
                        hitsRoll1 = KnockedPinOnPath(roll, allPinsStanding);
                    }

                    // Calculate roll 2
                    if (rolls == 1)
                    {
                        hitsRoll2 = KnockedPinOnPath(roll, allPinsStanding);
                    }

                    Console.Clear();
                }

                // Reset the frame
                roll1Text = " ";
                roll2Text = " ";
                frames++;
            }
        }
    }
}