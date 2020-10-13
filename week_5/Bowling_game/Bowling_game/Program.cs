using System;
using System.Collections.Generic;

namespace Bowling_game
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

            int knockedPinsCount = 0;

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
                knockedPinsCount = 1;
                pinsStanding[6] = false;
            }
            // Path 2
            else if (path == 2 && pinsStanding[3] == true)
            {
                knockedPinsCount = 1;
                pinsStanding[3] = false;
            }
            // Path 3
            else if (path == 3)
            {
                if (pinsStanding[1] == true)
                {
                    knockedPinsCount = 1;
                    pinsStanding[1] = false;
                }
                else if (pinsStanding[7] == true)
                {
                    knockedPinsCount = 1;
                    pinsStanding[7] = false;
                }
            }
            // Path 4
            else if (path == 4)
            {
                if (pinsStanding[0] == true)
                {
                    knockedPinsCount = 1;
                    pinsStanding[0] = false;
                }
                else if (pinsStanding[4] == true)
                {
                    knockedPinsCount = 1;
                    pinsStanding[4] = false;
                }
            }
            // Path 5
            else if (path == 5)
            {
                if (pinsStanding[2] == true)
                {
                    knockedPinsCount = 1;
                    pinsStanding[2] = false;
                }
                else if (pinsStanding[8] == true)
                {
                    knockedPinsCount = 1;
                    pinsStanding[8] = false;
                }
            }
            // Path 6
            else if (path == 6 && pinsStanding[5] == true)
            {
                knockedPinsCount = 1;
                pinsStanding[5] = false;
            }
            // Path 7
            else if (path == 7 && pinsStanding[9] == true)
            {
                knockedPinsCount = 1;
                pinsStanding[9] = false;
            }

            // If you hit a pin this part calculates if the pin or the ball hits more pins
            if (knockedPinsCount > 0)
            {
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
            }
            return knockedPinsCount;
        }

        static void DrawScoreSheet(int[][] allRolls, int[] totalScore, string[][] rollText)
        {

            string totalScoreString = totalScore.ToString();

            // LeftTop corner
            char topLeftCorner = '\u250F';
            // RightTop corner
            char topRightCorner = '\u2513';
            // LeftBottom corner
            char bottomLeftCorner = '\u2517';
            // RightBottom corner
            char bottomRightCorner = '\u251B';
            // TopBottom line
            char horizentalLine = '\u2501';
            // LeftRight line
            char verticalLine = '\u2503';
            // TopDown intersection
            char topDownLine = '\u2533';
            // BottomUp intersection
            char bottomUpLine = '\u253B';
            // LineLeft intersection
            char verticalLeftLine = '\u252B';




            for (int drawingFrameRows = 0; drawingFrameRows < 5; drawingFrameRows++)
            {
                // Top row
                if (drawingFrameRows == 0)
                {
                    Console.Write(topLeftCorner);

                    for (int frames = 0; frames < allRolls.Length; frames++)
                    {
                        if (frames == 9)
                        {
                            // for frame 10
                            for (int frameSize = 0; frameSize < allRolls[frames].Length; frameSize++)
                            {
                                Console.Write($"{horizentalLine}{topDownLine}");
                            }
                        }
                        else
                        {
                            for (int frameSize = 0; frameSize <= allRolls[frames].Length; frameSize++)
                            {
                                Console.Write($"{horizentalLine}{topDownLine}");
                            }
                        }
                    }

                    Console.WriteLine($"{horizentalLine}{topRightCorner}");
                }
                // Second row
                else if (drawingFrameRows == 1)
                {
                    Console.Write($"{verticalLine} ");

                    for (int frames = 0; frames < allRolls.Length; frames++)
                    {
                        if (frames == 9)
                        {
                            // for frame 10
                            for (int frameSize = 0; frameSize < allRolls[frames].Length; frameSize++)
                            {
                                // dont forget to add that if roll is -1 output space (if you get a strike)
                                Console.Write($"{verticalLine}{rollText[frames][frameSize]}");
                            }
                        }
                        else
                        {
                            for (int frameSize = 0; frameSize < allRolls[frames].Length; frameSize++)
                            {
                                // dont forget to add that if roll is -1 output space (if you get a strike)
                                Console.Write($"{verticalLine}{rollText[frames][frameSize]}");
                            }
                        }

                        Console.Write($"{verticalLine} ");
                    }
                    Console.WriteLine();
                }
                // Third row
                else if (drawingFrameRows == 2)
                {
                    Console.Write($"{verticalLine}");

                    for (int frames = 0; frames < allRolls.Length; frames++)
                    {
                        if (frames == 9)
                        {
                            // for frame 10
                            Console.Write($" {bottomLeftCorner}{horizentalLine}{bottomUpLine}{horizentalLine}{bottomUpLine}{horizentalLine}{verticalLeftLine}");
                        }
                        else
                        {
                            Console.Write($" {bottomLeftCorner}{horizentalLine}{bottomUpLine}{horizentalLine}{verticalLeftLine}");
                        }
                    }
                    Console.WriteLine();
                }
                // Fourth row
                else if (drawingFrameRows == 3)
                {
                    Console.Write($"{verticalLine}");

                    for (int frames = 0; frames < allRolls.Length; frames++)
                    {
                        if (totalScore[frames] > -1)
                        {
                            if (frames == 9)
                            {
                                // for frame 10
                                Console.Write($"{$"{totalScore[frames]}  ",7}{verticalLine}");

                            }
                            else
                            {
                                Console.Write($"{$"{totalScore[frames]} ",5}{verticalLine}");
                            }
                        }
                        else
                        {
                            if (frames == 9)
                            {
                                // for frame 10
                                Console.Write($"       {verticalLine}");

                            }
                            else
                            {
                                Console.Write($"     {verticalLine}");
                            }
                        }

                    }
                    Console.WriteLine();
                }
                else
                {
                    // Bottom row
                    Console.Write(bottomLeftCorner);

                    for (int frames = 0; frames < allRolls.Length; frames++)
                    {
                        if (frames == 9)
                        {
                            // for frame 10
                            for (int frameSize = 0; frameSize < allRolls[frames].Length; frameSize++)
                            {
                                Console.Write($"{horizentalLine}{horizentalLine}");
                            }
                        }
                        else
                        {
                            for (int frameSize = 0; frameSize <= allRolls[frames].Length - 1; frameSize++)
                            {
                                Console.Write($"{horizentalLine}{horizentalLine}");
                            }
                            Console.Write($"{horizentalLine}{bottomUpLine}");
                        }
                    }
                    Console.WriteLine($"{horizentalLine}{bottomRightCorner}");
                }
            }
        }

        static void DrawPins(List<bool> allPinsStanding)
        {
            Console.WriteLine("\nCurrent pins:\n");
            Console.WriteLine($"" +
                $"{Pin(allPinsStanding[6])}   {Pin(allPinsStanding[7])}   {Pin(allPinsStanding[8])}   {Pin(allPinsStanding[9])}\n" +
                $"\n  {Pin(allPinsStanding[3])}   {Pin(allPinsStanding[4])}   {Pin(allPinsStanding[5])}\n" +
                $"\n    {Pin(allPinsStanding[1])}   {Pin(allPinsStanding[2])}\n" +
                $"\n      {Pin(allPinsStanding[0])}");
            Console.WriteLine("\n1 2 3 4 5 6 7");
        }

        static void Main(string[] args)
        {
            // Creating an array of 10 rolls with all rolls set to - 1
            int[][] allRolls = new int[10][];
            {
                int frame = 0;

                while (frame < allRolls.Length)
                {
                    allRolls[frame] = new int[] { -1, -1 };
                    frame++;
                }

                allRolls[frame - 1] = new int[] { -1, -1, -1 };
            }

            // Creating an array of 10 text outputs for displaying number of hits
            string[][] rollText = new string[10][];
            {
                int frame = 0;

                while (frame < rollText.Length)
                {
                    rollText[frame] = new string[] { " ", " " };
                    frame++;
                }

                rollText[frame - 1] = new string[] { " ", " ", " " };
            }

            // Arrays for calculating gained points for each frame
            int[] pointsGained = new int[10];
            int[] frameScores = new int[10];
            for (int i = 0; i < 10; i++)
            {
                pointsGained[i] = -1;
                frameScores[i] = -1;
            }

            int path = 0;
            string roll1Text;
            string roll2Text;
            string roll3Text;
            int frames = 0;

            while (frames < 10)
            {
                var allPinsStanding = new List<bool> { true, true, true, true, true, true, true, true, true, true };
                bool strike = false;
                bool spare = false;
                bool thirdRoll = false;

                //Loop for displaying the frame and pins three times
                for (int rolls = 0; rolls < 4; rolls++)
                {
                    //Rolls in 10th frame
                    if (frames == 9 && rolls > 0)
                    {
                        //First roll
                        if (rolls == 1)
                        {
                            // symbol for a miss
                            if (allRolls[frames][rolls - 1] == 0)
                            {
                                roll1Text = "-";
                            } // symbol for a strike
                            else if (allRolls[frames][rolls - 1] == 10)
                            {
                                roll1Text = "X";
                                strike = true;
                                thirdRoll = true;
                            } // outputing the number of pins if you don't miss or get a strike
                            else
                            {
                                roll1Text = $"{allRolls[frames][rolls - 1]}";
                            }

                            // moving the symbol or number to the rollText array
                            rollText[frames][rolls - 1] = roll1Text;
                        }

                        //Second roll
                        if (rolls == 2)
                        {
                            if (allRolls[frames][rolls - 2] < 10)
                            {
                                // symbol for a miss
                                if (allRolls[frames][rolls - 1] == 0)
                                {
                                    roll2Text = "-";
                                } // symbol for a spare
                                else if (allRolls[frames][rolls - 2] + allRolls[frames][rolls - 1] == 10)
                                {
                                    roll2Text = "/";
                                    spare = true;
                                    thirdRoll = true;
                                } // outputing the number of pins if you don't miss or get a spare
                                else
                                {
                                    roll2Text = $"{allRolls[frames][rolls - 1]}";
                                }

                                // moving the symbol or number to the rollText array
                                rollText[frames][rolls - 1] = roll2Text;
                            }
                            else
                            {
                                // symbol for a miss
                                if (allRolls[frames][rolls - 1] == 0)
                                {
                                    roll2Text = "-";
                                } // symbol for a strike
                                else if (allRolls[frames][rolls - 1] == 10)
                                {
                                    roll2Text = "X";
                                    strike = true;
                                } // outputing the number of pins if you don't miss or get a strike
                                else
                                {
                                    roll2Text = $"{allRolls[frames][rolls - 1]}";
                                }

                                // moving the symbol or number to the rollText array
                                rollText[frames][rolls - 1] = roll2Text;
                            }
                        }

                        //Third roll
                        if (rolls == 3)
                        {
                            // symbol for a miss
                            if (allRolls[frames][rolls - 1] == 0)
                            {
                                roll3Text = "-";
                            } // symbol for a spare
                            else if (allRolls[frames][0] == 10 && allRolls[frames][rolls - 2] + allRolls[frames][rolls - 1] == 10)
                            {
                                roll3Text = "/";
                            } // symbol for a strike
                            else if (allRolls[frames][rolls - 1] == 10)
                            {
                                roll3Text = "X";
                            } // outputing the number of pins if you don't miss or get a strike or a spare
                            else
                            {
                                roll3Text = $"{allRolls[frames][rolls - 1]}";
                            }

                            // moving the symbol or number to the rollText array
                            rollText[frames][rolls - 1] = roll3Text;
                        }
                    }
                    //Rolls in all other frames
                    else
                    {
                        //First roll
                        if (rolls == 1)
                        {
                            // symbol for a miss
                            if (allRolls[frames][rolls - 1] == 0)
                            {
                                roll1Text = "-";
                            } // symbol for a strike
                            else if (allRolls[frames][rolls - 1] == 10)
                            {
                                roll1Text = "X";
                                strike = true;
                            } // outputing the number of pins if you don't miss or get a strike
                            else
                            {
                                roll1Text = $"{allRolls[frames][rolls - 1]}";
                            }

                            // moving the symbol or number to the rollText array
                            rollText[frames][rolls - 1] = roll1Text;
                        }

                        //Second roll
                        if (rolls == 2 && allRolls[frames][rolls - 2] < 10)
                        {
                            // symbol for a miss
                            if (allRolls[frames][rolls - 1] == 0)
                            {
                                roll2Text = "-";
                            } // symbol for a spare
                            else if (allRolls[frames][rolls - 2] + allRolls[frames][rolls - 1] == 10)
                            {
                                roll2Text = "/";
                            } // outputing the number of pins if you don't miss or get a spare
                            else
                            {
                                roll2Text = $"{allRolls[frames][rolls - 1]}";
                            }

                            // moving the symbol or number to the rollText array
                            rollText[frames][rolls - 1] = roll2Text;
                        }
                    }

                    // Calculate score
                    if (rolls > 0)
                    {
                        // strike and then strike again
                        if (frames > 1 && rolls == 1 && allRolls[frames - 2][0] == 10 && allRolls[frames - 1][0] == 10)
                        {
                            pointsGained[frames - 2] = allRolls[frames - 2][0] + allRolls[frames - 1][0] + allRolls[frames][0];
                            frameScores[frames - 2] = pointsGained[frames - 2];

                            // adds the previous frames score if this is not the first frame
                            if (frames > 2)
                            {
                                frameScores[frames - 2] += frameScores[frames - 3];
                            }
                        }

                        // if you roll multiple strikes in a row in the 10th frame
                        if (frames == 9 && rolls == 2 && allRolls[frames - 1][0] == 10 && allRolls[frames][0] == 10)
                        {
                            pointsGained[frames - 1] = allRolls[frames - 1][0] + allRolls[frames][0] + allRolls[frames][1];
                            frameScores[frames - 1] = frameScores[frames - 2] + pointsGained[frames - 1];
                        }

                        // strike and then not a strike
                        if (frames > 0 && rolls > 1 && allRolls[frames - 1][0] == 10 && allRolls[frames][0] < 10)
                        {
                            pointsGained[frames - 1] = allRolls[frames - 1][0] + allRolls[frames][0] + allRolls[frames][1];
                            frameScores[frames - 1] = pointsGained[frames - 1];

                            // adds the previous frames score if this is not the first frame
                            if (frames > 1)
                            {
                                frameScores[frames - 1] += frameScores[frames - 2];
                            }
                        }

                        // if you roll a spare
                        if (frames > 0 && rolls < 2 && allRolls[frames - 1][0] + allRolls[frames - 1][1] == 10)
                        {
                            pointsGained[frames - 1] = 10 + allRolls[frames][0];
                            frameScores[frames - 1] = pointsGained[frames - 1];

                            // adds the previous frames score if this is not the first frame
                            if (frames > 1)
                            {
                                frameScores[frames - 1] += frameScores[frames - 2];
                            }
                        }

                        // no strike, no spare
                        if (frames < 9 && rolls > 1 && allRolls[frames][0] + allRolls[frames][1] < 10)
                        {
                            pointsGained[frames] = allRolls[frames][0] + allRolls[frames][1];
                            frameScores[frames] = pointsGained[frames];

                            // adds the previous frames score if this is not the first frame
                            if (frames > 0)
                            {
                                frameScores[frames] += frameScores[frames - 1];
                            }
                        }

                        // for frame 10
                        if (frames == 9)
                        {
                            // if you get a third roll, adds the points to the score after the third roll
                            if (thirdRoll && rolls > 2)
                            {
                                pointsGained[frames] = allRolls[frames][0] + allRolls[frames][1] + allRolls[frames][2];
                                frameScores[frames] = frameScores[frames - 1] + pointsGained[frames];
                            } // if you don't get a third roll, adds the points to the score after the second roll
                            else if (!thirdRoll && rolls > 1)
                            {
                                pointsGained[frames] = allRolls[frames][0] + allRolls[frames][1];
                                frameScores[frames] = frameScores[frames - 1] + pointsGained[frames];
                            }
                        }
                    }

                    //Drawing the pins
                    Console.WriteLine($"Frame: {frames + 1}");
                    DrawScoreSheet(allRolls, frameScores, rollText);
                    DrawPins(allPinsStanding);

                    // Marking the choosen path
                    if (rolls > 0)
                    {
                        Console.Write($"{"".PadLeft((path - 1) * 2, ' ')}^");
                    }

                    // Asking for player to choose path
                    // For frame 10
                    if (frames == 9)
                    {
                        // The first two rolls of the 10th frame
                        if (rolls < 2)
                        {
                            // If you rolled a strike in the first roll this resets the pins
                            if (strike)
                            {
                                allPinsStanding = new List<bool> { true, true, true, true, true, true, true, true, true, true };
                                strike = false;
                                Console.Write("\nYou get to roll again! Press enter to continue.");
                                Console.ReadLine();
                                Console.CursorLeft = 0;
                                Console.CursorTop = 6;
                                DrawPins(allPinsStanding);
                            }

                            // rewriting asking for path 
                            Console.CursorTop = 18;
                            Console.Write($"\n                                                  ");
                            Console.CursorTop = 18;
                            Console.Write($"\nEnter where you roll the ball (1-7): ");
                            string choosenPath = Console.ReadLine();

                            // If player just press enter, ask for path again
                            while (choosenPath == "")
                            {
                                Console.CursorLeft = 0;
                                Console.CursorTop = 19;
                                Console.Write("You have to write a number.              ");
                                Console.Write($"\nEnter where you roll the ball (1-7): ");
                                choosenPath = Console.ReadLine();
                            }
                            path = Int32.Parse(choosenPath);
                        } // if you get to roll a third time
                        else if (thirdRoll && rolls == 2)
                        {
                            // If you rolled a strike or a spare in the second roll this resets the pins
                            if (strike || spare)
                            {
                                allPinsStanding = new List<bool> { true, true, true, true, true, true, true, true, true, true };
                                strike = false;
                                spare = false;
                                Console.Write("\nYou get to roll again! Press enter to continue.");
                                Console.ReadLine();
                                Console.CursorLeft = 0;
                                Console.CursorTop = 6;
                                DrawPins(allPinsStanding);
                            }

                            // rewriting asking for path 
                            Console.CursorTop = 18;
                            Console.Write($"\n                                                  ");
                            Console.CursorTop = 18;
                            Console.Write($"\nEnter where you roll the ball (1-7): ");
                            string choosenPath = Console.ReadLine();

                            // If player just press enter, ask for path again
                            while (choosenPath == "")
                            {
                                Console.CursorLeft = 0;
                                Console.CursorTop = 19;
                                Console.Write("You have to write a number.              ");
                                Console.Write($"\nEnter where you roll the ball (1-7): ");
                                choosenPath = Console.ReadLine();
                            }
                            path = Int32.Parse(choosenPath);
                        } // After two or three rolls, reset bowlinglane
                        else
                        {
                            Console.Write("\nPress enter to continue.");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                    }
                    // For all other frames
                    else if (rolls < 2 && strike == false)
                    {
                        // Asking player to choose path
                        Console.Write($"\nEnter where you roll the ball (1-7): ");
                        string choosenPath = Console.ReadLine();

                        // If player just press enter, ask for path again
                        while (choosenPath == "")
                        {
                            Console.CursorLeft = 0;
                            Console.CursorTop = 19;
                            Console.Write("You have to write a number.              ");
                            Console.Write($"\nEnter where you roll the ball (1-7): ");
                            choosenPath = Console.ReadLine();
                        }
                        path = Int32.Parse(choosenPath);
                    } // After two rolls, reset bowlinglane
                    else
                    {
                        Console.Write("\nPress enter to continue.");
                        Console.ReadLine();
                        strike = false;
                        Console.Clear();
                        break;
                    }

                    // Calculate number of pins that get knocked down in roll 1
                    if (rolls == 0)
                    {
                        allRolls[frames][rolls] = KnockedPinOnPath(path, allPinsStanding);
                    }

                    // Calculate number of pins that get knocked down in roll 2
                    if (rolls == 1)
                    {
                        allRolls[frames][rolls] = KnockedPinOnPath(path, allPinsStanding);
                    }

                    // Calculate number of pins that get knocked down in roll 3
                    if (rolls == 2)
                    {
                        allRolls[frames][rolls] = KnockedPinOnPath(path, allPinsStanding);
                    }

                    Console.Clear();
                }

                // Reset the frame
                /*roll1Text = " ";
                roll2Text = " ";
                */
                frames++;
            }

            DrawScoreSheet(allRolls, frameScores, rollText);
            Console.WriteLine($"Well played! Your total score is: {frameScores[frames - 1]}!");
        }
    }
}
