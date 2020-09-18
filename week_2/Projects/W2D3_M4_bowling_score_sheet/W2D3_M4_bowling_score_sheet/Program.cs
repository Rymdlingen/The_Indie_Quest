using System;

namespace mission_4_bowling_score_sheet
{
    class Program
    {
        static void Main(string[] args)
        {
            //firstTry();
            //secondTry();
            //emptyScoreSheet();
            bowling();

        }

        static void bowling()
        {
            var random = new Random();

            int roll1;
            int roll2;

            string roll1Text = "";
            string roll2Text = "";

            int numberOfRolls = random.Next(1, 11);
            int rolls = 0;

            string topBot = "";
            string topBotEnd = "+";
            string row2 = "";
            string row2End = "|";
            string row3 = "";
            string row3End = "|";
            string row4 = "";
            string row4End = "|";

            while (rolls < numberOfRolls)
            {
                roll1 = random.Next(0, 11);
                roll2 = random.Next(0, 11 - roll1);

                if (roll1 < 10)
                {
                    if (roll1 == 0)
                    {
                        roll1Text += "-";
                    }
                    else
                    {
                        roll1Text += roll1;
                    }
                }
                else
                {
                    roll1Text += "X";
                    roll2Text += " ";
                }

                if (roll1 != 10)
                {
                    if (roll2 < 10 - roll1)
                    {
                        if (roll2 == 0)
                        {
                            roll2Text += "-";
                        }
                        else
                        {
                            roll2Text += roll2;
                        }

                    }
                    else
                    {
                        roll2Text += "/";
                    }

                }

                topBot += "+-----";
                row2 += $"| |{roll1Text}|{roll2Text}";
                row3 += "| ----";
                row4 += "|     ";

                rolls++;

                roll1Text = "";
                roll2Text = "";

            }

            Console.Write(topBot);
            Console.WriteLine(topBotEnd);
            Console.Write(row2);
            Console.WriteLine(row2End);
            Console.Write(row3);
            Console.WriteLine(row3End);
            Console.Write(row4);
            Console.WriteLine(row4End);
            Console.Write(topBot);
            Console.WriteLine(topBotEnd);

            //Console.WriteLine(numberOfRolls);
        }

        static void secondTry()
        {
            var random = new Random();
            int roll1 = random.Next(0, 11);
            int roll2 = random.Next(0, 11 - roll1);
            int knockedPins = roll1 + roll2;
            string roll1Text = "First roll: ";
            string roll2Text = "Second roll: ";

            if (roll1 < 10)
            {
                if (roll1 == 0)
                {
                    roll1Text += "-";
                }
                else
                {
                    roll1Text += $"{roll1}";
                }
            }
            else
            {
                roll1Text += "X";
            }

            Console.WriteLine(roll1Text);

            if (roll1 != 10)
            {
                if (roll2 < 10 - roll1)
                {
                    if (roll2 == 0)
                    {
                        roll2Text += "-";
                    }
                    else
                    {
                        roll2Text += $"{roll2}";
                    }

                }
                else
                {
                    roll2Text += "/";
                }

                Console.WriteLine(roll2Text);
            }



            Console.WriteLine($"Knocked pins: {knockedPins}");
        }


        static void emptyScoreSheet()
        {
            var random = new Random();
            int totalFrames = random.Next(1, 11);
            string topBot = "+-----";
            string topBotEnd = "+";
            string row2 = "| | | ";
            string row2End = "|";
            string row3 = "| ----";
            string row3End = "|";
            string row4 = "|     ";
            string row4End = "|";

            for (int loops = 0; loops < totalFrames; loops++)
            {
                Console.Write(topBot);

            }
            Console.WriteLine(topBotEnd);

            for (int loops = 0; loops < totalFrames; loops++)
            {
                Console.Write(row2);

            }
            Console.WriteLine(row2End);

            for (int loops = 0; loops < totalFrames; loops++)
            {
                Console.Write(row3);

            }
            Console.WriteLine(row3End);

            for (int loops = 0; loops < totalFrames; loops++)
            {
                Console.Write(row4);

            }
            Console.WriteLine(row4End);

            for (int loops = 0; loops < totalFrames; loops++)
            {
                Console.Write(topBot);

            }
            Console.WriteLine(topBotEnd);

            Console.WriteLine(totalFrames);
        }


        static void firstTry()
        {

            var random = new Random();
            int roll1 = random.Next(0, 11);
            int roll2 = random.Next(0, 11 - roll1);
            int knockedPins = roll1 + roll2;

            if (roll1 < 10)
            {
                if (roll2 != 10 - roll1)
                {
                    if (roll1 == 0 || roll2 == 0)
                    {
                        if (roll1 == 0)
                        {
                            Console.WriteLine("First roll: -");
                            Console.WriteLine($"Second roll: {roll2}");
                            Console.WriteLine($"Knocked pins: {knockedPins}");
                        }
                        else
                        {
                            Console.WriteLine($"First roll: {roll1}");
                            Console.WriteLine($"Second roll: -");
                            Console.WriteLine($"Knocked pins: {knockedPins}");
                        }

                    }
                    else
                    {
                        Console.WriteLine($"First roll: {roll1}");
                        Console.WriteLine($"Second roll: {roll2}");
                        Console.WriteLine($"Knocked pins: {knockedPins}");
                    }
                }
                else
                {
                    Console.WriteLine($"First roll: {roll1}");
                    Console.WriteLine("Second roll: /");
                    Console.WriteLine($"Knocked pins: {knockedPins}");
                }
            }
            else
            {
                Console.WriteLine("First roll: X");
                Console.WriteLine($"Knocked pins: {knockedPins}");
            }
        }
    }
}
