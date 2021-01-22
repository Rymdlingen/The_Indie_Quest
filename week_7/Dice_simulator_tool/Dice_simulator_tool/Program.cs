using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.IO;

namespace Dice_simulator_tool
{
    class Program
    {
        static List<int> rollsAndSum = new List<int> { };

        // Method for the actuall roll.
        static void DiceRoll(int numberOfRolls, int diceSides, int fixedBonus = 0)
        {
            var random = new Random();
            int diceSide;
            int sum = 0;

            // Remove the previous roll.
            rollsAndSum.RemoveRange(0, rollsAndSum.Count);


            // Rolling the dice and adding the roll too the sum.
            for (var i = 0; i < numberOfRolls; i++)
            {
                rollsAndSum.Add(diceSide = random.Next(1, diceSides + 1));
                sum += diceSide;
            }
            rollsAndSum.Add(sum + fixedBonus);
        }

        // Method for finding values from a string with standard dice notation.
        static void DiceRoll(string diceNotation)
        {
            // Creating a list of our values.
            string[] values = diceNotation.Split('d', '+', '-');

            // Puting the rigth values into the rigth strings.
            string numberOfRollsString = values[0];
            string diceSidesString = values[1];

            // If the number of rolls is not specidied we assume its 1.
            if (numberOfRollsString == "")
            {
                numberOfRollsString = "1";
            }

            // If the dice sides is not specidied we assume its 6.
            if (diceSidesString == "")
            {
                diceSidesString = "6";
            }

            // Making the string into ints.
            int numberOfRolls = Int32.Parse(numberOfRollsString);
            int diceSides = Int32.Parse(diceSidesString);

            // Ckecking if the notation has an modifier and making into a string and then an int.
            string fixedBonusString;
            int fixedBonus = 0;
            if (values.Length > 2)
            {
                fixedBonusString = values[2];
                fixedBonus = Int32.Parse(fixedBonusString);

                // If the notation contains a subtraction modifier.
                if (diceNotation.Contains('-'))
                {
                    fixedBonus = 0 - fixedBonus;
                }
            }

            DiceRoll(numberOfRolls, diceSides, fixedBonus);
        }

        // Method that makes sure that the input is a standard dice notation.
        static bool IsStandardDiceNotation(string text)
        {
            bool diceNotation = true;
            // RegEx for standard dice notation.
            string diceNotationPattern = "^\\d*d\\d+[+-]?\\d*$";
            if (Regex.IsMatch(text, diceNotationPattern))
            {

            }
            else
            {
                // If the input does not match the RegEx, this is not a standard dice notation.
                diceNotation = false;
            }

            return diceNotation;
        }

        // Method for displaying an ordinal nummer correctly.
        static string OrdinalNumber(int number)
        {

            // Notes.
            // Get the last digit of an integer by modding it with 10.
            // If the number is bigger than 10, also get the second to last digit by dividing the integer by 10 and then modding the result with 10.
            // If the second to last digit is 1, return the integer plus "th".
            // If the last digit is 1, return the integer plus "st".
            // If the last digit is 2, return the integer plus "nd".
            // If the last digit is 3, return the integer plus "rd".
            // Otherwise return integer plus "th".

            int lastDigit = number % 10;
            int secondDigit = 0;

            if (number > 10)
            {
                secondDigit = (number / 10) % 10;
            }

            if (secondDigit == 1)
            {
                return number + "th";
            }
            else if (lastDigit == 1)
            {
                return number + "st";
            }
            else if (lastDigit == 2)
            {
                return number + "nd";
            }
            else if (lastDigit == 3)
            {
                return number + "rd";
            }
            else
            {
                return number + "th";
            }

        }

        static void Main(string[] args)
        {
            bool sameRoll = true;
            bool newRoll = true;
            string inputDiceNotation = " ";

            // Write the title of the tool.
            Console.WriteLine("DICE SIMULATOR\n");

            while (sameRoll)
            {
                // Asking for a new input of standard dice notation.
                while (newRoll)
                {
                    // Asking for input.
                    Console.WriteLine("Enter desired dice roll in standard dice notation:");
                    inputDiceNotation = Console.ReadLine();

                    // Checking if the input is in standard dice notation.
                    while (!IsStandardDiceNotation(inputDiceNotation))
                    {
                        Console.WriteLine("\nYou did not use standard dice notation. Try again:");
                        inputDiceNotation = Console.ReadLine();
                    }

                    newRoll = false;
                }

                DiceRoll(inputDiceNotation);

                Console.WriteLine("\nSimulating...\n");

                // Reading text files with ASCII-art of dices.
                string pathD4 = "d4.txt";
                string pathD6 = "d6.txt";
                string[][] dices = new string[7][];

                dices[4] = File.ReadAllLines(pathD4);
                dices[6] = File.ReadAllLines(pathD6);

                // Displaying all the rolls and the sum.
                for (int rolls = 0; rolls < rollsAndSum.Count - 1; rolls++)
                {
                    // Checking for dice with 6 sides.
                    if (Regex.IsMatch(inputDiceNotation, @"\d*d6.*"))
                    {
                        string ordinalNumber = OrdinalNumber(rolls + 1);
                        Console.WriteLine($"{ordinalNumber} roll:");

                        // Draw ASCII-art for the dice.
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        foreach (string dice in dices[6])
                        {
                            if (Regex.IsMatch(dice, @"\d"))
                            {
                                if (rollsAndSum[rolls] == 1)
                                {
                                    string newDiceLine = dice.Replace('1', 'O');
                                    newDiceLine = newDiceLine.Replace('2', ' ');
                                    newDiceLine = newDiceLine.Replace('3', ' ');
                                    newDiceLine = newDiceLine.Replace('4', ' ');
                                    Console.WriteLine(newDiceLine);
                                }
                                else if (rollsAndSum[rolls] == 2)
                                {
                                    string newDiceLine = dice.Replace('1', ' ');
                                    newDiceLine = newDiceLine.Replace('2', 'O');
                                    newDiceLine = newDiceLine.Replace('3', ' ');
                                    newDiceLine = newDiceLine.Replace('4', ' ');
                                    Console.WriteLine(newDiceLine);
                                }
                                else if (rollsAndSum[rolls] == 3)
                                {
                                    string newDiceLine = dice.Replace('1', 'O');
                                    newDiceLine = newDiceLine.Replace('2', ' ');
                                    newDiceLine = newDiceLine.Replace('3', 'O');
                                    newDiceLine = newDiceLine.Replace('4', ' ');
                                    Console.WriteLine(newDiceLine);
                                }
                                else if (rollsAndSum[rolls] == 4)
                                {
                                    string newDiceLine = dice.Replace('1', ' ');
                                    newDiceLine = newDiceLine.Replace('2', ' ');
                                    newDiceLine = newDiceLine.Replace('3', 'O');
                                    newDiceLine = newDiceLine.Replace('4', 'O');
                                    Console.WriteLine(newDiceLine);
                                }
                                else if (rollsAndSum[rolls] == 5)
                                {
                                    string newDiceLine = dice.Replace('1', 'O');
                                    newDiceLine = newDiceLine.Replace('2', ' ');
                                    newDiceLine = newDiceLine.Replace('3', 'O');
                                    newDiceLine = newDiceLine.Replace('4', 'O');
                                    Console.WriteLine(newDiceLine);
                                }
                                else if (rollsAndSum[rolls] == 6)
                                {
                                    string newDiceLine = dice.Replace('1', ' ');
                                    newDiceLine = newDiceLine.Replace('2', 'O');
                                    newDiceLine = newDiceLine.Replace('3', 'O');
                                    newDiceLine = newDiceLine.Replace('4', 'O');
                                    Console.WriteLine(newDiceLine);
                                }
                            }
                            else
                            {
                                Console.WriteLine(dice);
                            }
                        }
                        Console.WriteLine();
                        Console.ResetColor();

                    } // Checking for dice with 4 sides.
                    else if (Regex.IsMatch(inputDiceNotation, @"\d*d4.*"))
                    {
                        string ordinalNumber = OrdinalNumber(rolls + 1);
                        Console.WriteLine($"{ordinalNumber} roll:");

                        // Draw ASCII-art for the dice
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        foreach (string dice in dices[4])
                        {
                            if (dice.Contains('n'))
                            {
                                char number = Convert.ToChar(rollsAndSum[rolls].ToString());
                                Console.WriteLine(dice.Replace('n', number));
                            }
                            else
                            {
                                Console.WriteLine(dice);
                            }
                        }
                        Console.WriteLine();
                        Console.ResetColor();
                    }
                    else // All other dices (there is no ASCII-art for them).
                    {
                        string ordinalNumber = OrdinalNumber(rolls + 1);
                        Console.WriteLine($"{ordinalNumber} roll is: {rollsAndSum[rolls]}");
                    }
                }

                // Displaying total score.
                Console.WriteLine($"\nYou rolled {rollsAndSum[rollsAndSum.Count - 1]}.");

                // Asking if reapet, enter next notation or quit.
                bool answer = false;
                while (!answer)
                {
                    Console.WriteLine("\nDo you want to (r)epeat, enter a (n)ew roll or (q)uit?");
                    string action = Console.ReadLine();
                    Console.WriteLine();

                    // Reapeat the same roll.
                    if (action == "r" || action == "repeat")
                    {
                        answer = true;
                    } // Next roll.
                    else if (action == "n" || action == "new roll" || action == "new" || action == "roll")
                    {
                        newRoll = true;
                        answer = true;
                    } // Quit the tool.
                    else if (action == "q" || action == "quit")
                    {
                        sameRoll = false;
                        answer = true;
                    }
                }
            }
        }
    }
}
