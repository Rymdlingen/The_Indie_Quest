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

            // Calculating gained points for each frame
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
                bool calculatingStrike = false;
                bool calculatingSpare = false;

                //Loop for displaying the frame and pins three times
                for (int rolls = 0; rolls < 4; rolls++)
                {
                    //Rolls in 10th frame
                    if (frames == 9 && rolls > 0)
                    {
                        //First roll
                        if (rolls == 1)
                        {
                            if (allRolls[frames][rolls - 1] == 0)
                            {
                                roll1Text = "-";
                            }
                            else if (allRolls[frames][rolls - 1] == 10)
                            {
                                roll1Text = "X";
                                strike = true;
                            }
                            else
                            {
                                roll1Text = $"{allRolls[frames][rolls - 1]}";
                            }

                            rollText[frames][rolls - 1] = roll1Text;
                        }

                        //Second roll
                        if (rolls == 2)
                        {
                            if (allRolls[frames][rolls - 2] < 10)
                            {
                                if (allRolls[frames][rolls - 1] == 0)
                                {
                                    roll2Text = "-";
                                }
                                else if (allRolls[frames][rolls - 2] + allRolls[frames][rolls - 1] == 10)
                                {
                                    roll2Text = "/";
                                    spare = true;
                                }
                                else
                                {
                                    roll2Text = $"{allRolls[frames][rolls - 1]}";
                                }

                                rollText[frames][rolls - 1] = roll2Text;
                            }
                            else
                            {
                                if (allRolls[frames][rolls - 1] == 0)
                                {
                                    roll2Text = "-";
                                }
                                else if (allRolls[frames][rolls - 1] == 10)
                                {
                                    roll2Text = "X";
                                    strike = true;
                                }
                                else
                                {
                                    roll2Text = $"{allRolls[frames][rolls - 1]}";
                                }

                                rollText[frames][rolls - 1] = roll2Text;
                            }
                        }

                        //Third roll (MAke shure rolls cpunt is correct, make sure this roll works correctly whn you get strikes)
                        if (rolls == 3)
                        {
                            if (allRolls[frames][rolls - 1] == 0)
                            {
                                roll3Text = "-";
                            }
                            else if (allRolls[frames][rolls - 2] + allRolls[frames][rolls - 1] == 10)
                            {
                                roll3Text = "/";
                            }
                            else
                            {
                                roll3Text = $"{allRolls[frames][rolls - 1]}";
                            }

                            rollText[frames][rolls - 1] = roll3Text;
                        }
                    }
                    else //Rolls in all other frames
                    {
                        //First roll
                        if (rolls == 1)
                        {

                            if (allRolls[frames][rolls - 1] == 0)
                            {
                                roll1Text = "-";
                            }
                            else if (allRolls[frames][rolls - 1] == 10)
                            {
                                roll1Text = "X";
                                strike = true;
                            }
                            else
                            {
                                roll1Text = $"{allRolls[frames][rolls - 1]}";
                            }

                            rollText[frames][rolls - 1] = roll1Text;
                        }

                        //Second roll
                        if (rolls == 2 && allRolls[frames][rolls - 2] < 10)
                        {
                            if (allRolls[frames][rolls - 1] == 0)
                            {
                                roll2Text = "-";
                            }
                            else if (allRolls[frames][rolls - 2] + allRolls[frames][rolls - 1] == 10)
                            {
                                roll2Text = "/";
                            }
                            else
                            {
                                roll2Text = $"{allRolls[frames][rolls - 1]}";
                            }

                            rollText[frames][rolls - 1] = roll2Text;
                        }
                    }

                    bool thirdRoll = false;

                    if (frames == 9 && (strike || spare))
                    {
                        thirdRoll = true;
                    }

                    // Calculate score
                    if (rolls > 0)
                    {
                        // strike and then strike again (need to add the stike and then another strike and then the first roll)
                        if (frames > 1 && allRolls[frames - 2][0] == 10 && allRolls[frames - 1][0] == 10)
                        {
                            pointsGained[frames - 2] = allRolls[frames - 2][0] + allRolls[frames - 1][0] + allRolls[frames][0];
                            frameScores[frames - 2] = pointsGained[frames - 2];
                            calculatingStrike = true;

                            if (frames > 2)
                            {
                                frameScores[frames - 2] += frameScores[frames - 3];
                            }

                            if (allRolls[frames][0] + allRolls[frames][1] < 10 && allRolls[frames][1] > -1)
                            {
                                pointsGained[frames] = allRolls[frames][0] + allRolls[frames][1];
                                frameScores[frames] = frameScores[frames - 1] + pointsGained[frames];
                            }
                        }
                        // strike and then not a strike (two rolls in next frame) frame + two next rolls
                        else if (frames > 0 && rolls > 1 && allRolls[frames - 1][0] == 10 && allRolls[frames][0] < 10)
                        {
                            pointsGained[frames - 1] = allRolls[frames - 1][0] + allRolls[frames][0] + allRolls[frames][1];
                            frameScores[frames - 1] = pointsGained[frames - 1];

                            if (frames > 1)
                            {
                                frameScores[frames - 1] += frameScores[frames - 2];
                            }

                            calculatingStrike = true;

                            if (allRolls[frames][0] + allRolls[frames][1] < 10 && allRolls[frames][1] > -1)
                            {
                                pointsGained[frames] = allRolls[frames][0] + allRolls[frames][1];
                                frameScores[frames] = frameScores[frames - 1] + pointsGained[frames];
                            }
                        }
                        // spare, two rolls in the frame plus the forst roll of next frame
                        else if (frames > 0 && rolls < 2 && allRolls[frames - 1][0] + allRolls[frames - 1][1] == 10)
                        {
                            pointsGained[frames - 1] = 10 + allRolls[frames][0];
                            frameScores[frames - 1] = pointsGained[frames - 1];

                            if (frames > 1)
                            {
                                frameScores[frames - 1] += frameScores[frames - 2];
                            }

                            calculatingSpare = true;
                        }
                        // no strike, no spare
                        else if (frames < 9 && allRolls[frames][0] + allRolls[frames][1] < 10 && allRolls[frames][1] > -1)
                        {
                            pointsGained[frames] = allRolls[frames][0] + allRolls[frames][1];
                        }

                        // for frame 10
                        if (frames == 9)
                        {
                            if (rolls > 1 && allRolls[frames][2] == -1)
                            {
                                pointsGained[frames] = allRolls[frames][0] + allRolls[frames][1];
                            }
                            else if (rolls > 2)
                            {
                                pointsGained[frames] = allRolls[frames][0] + allRolls[frames][1] + allRolls[frames][2];
                            }
                        }

                        // Add points to total score for each frame
                        // For frame 10
                        if (frames == 9 && ((rolls == 2 && allRolls[frames][2] == -1) || (rolls == 3 && allRolls[frames][2] > -1)))
                        {
                            frameScores[frames] = frameScores[frames - 1] + pointsGained[frames];
                        }
                        // For other frames
                        else if (calculatingStrike && frames < 1)
                        {
                            frameScores[frames] = pointsGained[frames];
                        }
                        else if (calculatingSpare && frames < 1)
                        {
                            frameScores[frames] = pointsGained[frames];
                        }
                        else if (frames > 0 && frames < 9 && pointsGained[frames] > -1)
                        {
                            frameScores[frames] = frameScores[frames - 1] + pointsGained[frames];
                        }
                        // Score for first frame if its not at strike or spare
                        else
                        {
                            frameScores[frames] = pointsGained[frames];
                        }
                    }

                    //Draw

                    Console.WriteLine($"Frame: {frames + 1}");
                    DrawScoreSheet(allRolls, frameScores, rollText);
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
                        Console.Write($"{"".PadLeft((path - 1) * 2, ' ')}^");
                    }

                    // Asking for player to choose path
                    // For frame 10
                    if (frames == 9)
                    {
                        if (rolls < 2)
                        {
                            if (strike)
                            {
                                allPinsStanding = new List<bool> { true, true, true, true, true, true, true, true, true, true };
                                strike = false;
                                Console.Write("\nYou get to roll again! Pressenter to continue.");
                                Console.ReadLine();
                                Console.CursorLeft = 0;
                                Console.CursorTop = 9;
                                Console.WriteLine($"" +
                                $"{Pin(allPinsStanding[6])}   {Pin(allPinsStanding[7])}   {Pin(allPinsStanding[8])}   {Pin(allPinsStanding[9])}\n" +
                                $"\n  {Pin(allPinsStanding[3])}   {Pin(allPinsStanding[4])}   {Pin(allPinsStanding[5])}\n" +
                                $"\n    {Pin(allPinsStanding[1])}   {Pin(allPinsStanding[2])}\n" +
                                $"\n      {Pin(allPinsStanding[0])}");
                            }

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
                        }
                        else if (thirdRoll)
                        {
                            if (strike)
                            {
                                allPinsStanding = new List<bool> { true, true, true, true, true, true, true, true, true, true };
                                strike = false;
                                Console.Write("\nYou get to roll again! Press enter to continue.");
                                Console.ReadLine();
                                Console.CursorLeft = 0;
                                Console.CursorTop = 9;
                                Console.WriteLine($"" +
                                $"{Pin(allPinsStanding[6])}   {Pin(allPinsStanding[7])}   {Pin(allPinsStanding[8])}   {Pin(allPinsStanding[9])}\n" +
                                $"\n  {Pin(allPinsStanding[3])}   {Pin(allPinsStanding[4])}   {Pin(allPinsStanding[5])}\n" +
                                $"\n    {Pin(allPinsStanding[1])}   {Pin(allPinsStanding[2])}\n" +
                                $"\n      {Pin(allPinsStanding[0])}");
                            }

                            if (spare)
                            {
                                allPinsStanding = new List<bool> { true, true, true, true, true, true, true, true, true, true };
                                spare = false;
                                Console.Write("\nYou get to roll again! Press enter to continue.");
                                Console.ReadLine();
                                Console.CursorLeft = 0;
                                Console.CursorTop = 9;
                                Console.WriteLine($"" +
                                $"{Pin(allPinsStanding[6])}   {Pin(allPinsStanding[7])}   {Pin(allPinsStanding[8])}   {Pin(allPinsStanding[9])}\n" +
                                $"\n  {Pin(allPinsStanding[3])}   {Pin(allPinsStanding[4])}   {Pin(allPinsStanding[5])}\n" +
                                $"\n    {Pin(allPinsStanding[1])}   {Pin(allPinsStanding[2])}\n" +
                                $"\n      {Pin(allPinsStanding[0])}");
                            }

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
                        }
                        else
                        {
                            // After two or three rolls, reset bowlinglane
                            Console.Write("\nPress enter to continue.");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                    }
                    // For all other frames
                    else if (rolls < 2 && strike == false)
                    {
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
                    }
                    else
                    {
                        // After two rolls, reset bowlinglane
                        Console.Write("\nPress enter to continue.");
                        Console.ReadLine();
                        strike = false;
                        Console.Clear();
                        break;
                    }

                    // Calculate roll 1
                    if (rolls == 0)
                    {
                        allRolls[frames][rolls] = KnockedPinOnPath(path, allPinsStanding);
                    }

                    // Calculate roll 2
                    if (rolls == 1)
                    {
                        allRolls[frames][rolls] = KnockedPinOnPath(path, allPinsStanding);
                    }

                    // Calculate roll 3
                    if (rolls == 2)
                    {
                        allRolls[frames][rolls] = KnockedPinOnPath(path, allPinsStanding);
                    }

                    Console.Clear();
                }

                // Reset the frame
                roll1Text = " ";
                roll2Text = " ";
                frames++;
            }

            DrawScoreSheet(allRolls, frameScores, rollText);
            Console.WriteLine($"Well played! Your total score is: {frameScores[frames - 1]}!");
        }
    }
}

