using System;
using System.Collections.Generic;

namespace W3D1_bowling_pins
{
    class Program
    {
        static string Pin(bool knocked)
        {
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

        static void Main(string[] args)
        {
            int roll1;
            int roll2;
            string roll1Text = " ";
            string roll2Text = " ";
            var random = new Random();
            int numberOfRolls = random.Next(1, 11);
            int rolls = 0;
            string topBot = "+-----";
            string topBotEnd = "+";
            string row2;
            string row2End = "|";
            string row3 = "| ----";
            string row3End = "|";
            string row4 = "|     ";
            string row4End = "|";

            while (rolls < numberOfRolls)
            {
                var pinsStanding = new List<bool> { true, true, true, true, true, true, true, true, true, true };
                roll1 = random.Next(0, 11);
                roll2 = random.Next(0, 11 - roll1);

                //Empty frame and all pins standing
                row2 = $"| |{roll1Text}|{roll2Text}";
                Console.WriteLine($"Frame {rolls + 1}.\n");
                Console.WriteLine(topBot + topBotEnd);
                Console.WriteLine(row2 + row2End);
                Console.WriteLine(row3 + row3End);
                Console.WriteLine(row4 + row4End);
                Console.WriteLine(topBot + topBotEnd);
                Console.WriteLine("\nCurrent pins:\n");
                Console.WriteLine($"" +
                    $"{Pin(pinsStanding[6])}   {Pin(pinsStanding[7])}   {Pin(pinsStanding[8])}   {Pin(pinsStanding[9])}\n" +
                    $"\n  {Pin(pinsStanding[3])}   {Pin(pinsStanding[4])}   {Pin(pinsStanding[5])}\n" +
                    $"\n    {Pin(pinsStanding[1])}   {Pin(pinsStanding[2])}\n" +
                    $"\n      {Pin(pinsStanding[0])}");
                //Console.WriteLine(numberOfRolls);
                Console.WriteLine("\nPress enter to roll.");
                Console.ReadLine();
                Console.Clear();

                //First roll
                if (roll1 < 10)
                {
                    if (roll1 == 0)
                    {
                        roll1Text = "-";
                    }
                    else
                    {
                        roll1Text = $"{ roll1}";
                        for (var knocked = 0; knocked < roll1; knocked++)
                        {
                            var changeToFalse = random.Next(10);
                            if (pinsStanding[changeToFalse] == true)
                            {
                                pinsStanding[changeToFalse] = false;
                            }
                            else
                            {
                                knocked--;
                            }
                        }
                    }
                }
                else
                {
                    roll1Text = "X";
                    for (int pins = 0; pins < 10; pins++)
                    {
                        pinsStanding[pins] = false;
                    }
                }

                //First roll draw
                row2 = $"| |{roll1Text}|{roll2Text}";
                Console.WriteLine($"Frame {rolls + 1}.\n");
                Console.WriteLine(topBot + topBotEnd);
                Console.WriteLine(row2 + row2End);
                Console.WriteLine(row3 + row3End);
                Console.WriteLine(row4 + row4End);
                Console.WriteLine(topBot + topBotEnd);
                Console.WriteLine("\nCurrent pins:\n");
                Console.WriteLine($"" +
                    $"{Pin(pinsStanding[6])}   {Pin(pinsStanding[7])}   {Pin(pinsStanding[8])}   {Pin(pinsStanding[9])}\n" +
                    $"\n  {Pin(pinsStanding[3])}   {Pin(pinsStanding[4])}   {Pin(pinsStanding[5])}\n" +
                    $"\n    {Pin(pinsStanding[1])}   {Pin(pinsStanding[2])}\n" +
                    $"\n      {Pin(pinsStanding[0])}");
                Console.WriteLine("\nPress enter to roll.");
                Console.ReadLine();
                Console.Clear();

                //To continue to next round if you get a strike
                if (roll1 == 10)
                {
                    rolls++;
                    roll1Text = " ";
                    continue;
                }

                //Second roll
                if (roll1 != 10)
                {
                    if (roll2 < 10 - roll1)
                    {
                        if (roll2 == 0)
                        {
                            roll2Text = "-";
                        }
                        else
                        {
                            roll2Text = $"{roll2}";
                            for (var knocked = 0; knocked < roll2; knocked++)
                            {
                                var changeToFalse = random.Next(10);
                                if (pinsStanding[changeToFalse] == true)
                                {
                                    pinsStanding[changeToFalse] = false;
                                }
                                else
                                {
                                    knocked--;
                                }
                            }
                        }
                    }
                    else
                    {
                        roll2Text = "/";
                        for (int pins = 0; pins < 10; pins++)
                        {
                            pinsStanding[pins] = false;
                        }
                    }
                }

                //Second roll draw
                row2 = $"| |{roll1Text}|{roll2Text}";
                Console.WriteLine($"Frame {rolls + 1}.\n");
                Console.WriteLine(topBot + topBotEnd);
                Console.WriteLine(row2 + row2End);
                Console.WriteLine(row3 + row3End);
                Console.WriteLine(row4 + row4End);
                Console.WriteLine(topBot + topBotEnd);
                Console.WriteLine("\nCurrent pins:\n");
                Console.WriteLine($"" +
                    $"{Pin(pinsStanding[6])}   {Pin(pinsStanding[7])}   {Pin(pinsStanding[8])}   {Pin(pinsStanding[9])}\n" +
                    $"\n  {Pin(pinsStanding[3])}   {Pin(pinsStanding[4])}   {Pin(pinsStanding[5])}\n" +
                    $"\n    {Pin(pinsStanding[1])}   {Pin(pinsStanding[2])}\n" +
                    $"\n      {Pin(pinsStanding[0])}");
                Console.WriteLine("\nPress enter to continue.");
                Console.ReadLine();
                Console.Clear();

                roll1Text = " ";
                roll2Text = " ";
                rolls++;
            }
        }
    }
}
