using System;
using System.Collections.Generic;

namespace Standard_dice_notation
{
    class Program
    {
        // Method for the actuall roll
        static int DiceRoll(int numberOfRolls, int diceSides, int fixedBonus = 0)
        {
            var random = new Random();
            int diceSide;
            int sum = 0;

            // Rolling the dice
            for (var i = 0; i < numberOfRolls; i++)
            {
                diceSide = random.Next(1, diceSides + 1);
                sum += diceSide;
            }

            return sum + fixedBonus;
        }

        // Method for finding values from a string with standard dice notation
        static int DiceRoll(string diceNotation)
        {
            int numberOfRolls, diceSides;

            // Error message if d is not in the dice notation
            if (!diceNotation.Contains('d'))
            {
                throw new ArgumentException($"Roll description is not in standard dice notation.");
            }

            // Creating an array that stores the number of rolls
            string[] values = diceNotation.Split('d');


            // Puting the rigth values into the rigth strings
            string numberOfRollsString = values[0];

            // Error message if number of rolls is negative
            if (values[0].Contains("-"))
            {
                throw new ArgumentException($"Number of rolls ({numberOfRollsString}) has to be positive.");
            }

            // If the number of rolls is not specidied we assume its 1
            if (numberOfRollsString == "")
            {
                numberOfRollsString = "1";
            }

            // Error message if number of rolls is not an int
            try
            {
                numberOfRolls = Int32.Parse(numberOfRollsString);
            }
            catch
            {
                throw new ArgumentException($"Number of rolls ({numberOfRollsString}) is not an integer.");
            }

            // Error message if number of rolls is 0
            if (numberOfRolls == 0)
            {
                throw new ArgumentException($"Number of rolls ({numberOfRollsString}) has to be positive.");
            }

            // Changing the array to have all three parts of the dice notation
            values = diceNotation.Split('d', '+', '-');
            string diceSidesString = values[1];

            // Error message if dice sides is not an int
            try
            {
                diceSides = Int32.Parse(diceSidesString);
            }
            catch
            {
                throw new ArgumentException($"Number of dice sides ({diceSidesString}) is not an integer.");
            }

            // Ckecking if the notation has an modifier and making into a string and then an int
            string fixedBonusString;
            int fixedBonus = 0;
            if (values.Length > 2)
            {
                fixedBonusString = values[2];
                fixedBonus = Int32.Parse(fixedBonusString);

                // If the notation contains a subtraction modifier
                if (diceNotation.Contains('-'))
                {
                    fixedBonus = 0 - fixedBonus;
                }
            }

            return DiceRoll(numberOfRolls, diceSides, fixedBonus);
        }

        static void Main(string[] args)
        {
            int cursorPosition = 0;

            while (true)
            {
                string diceNotation = Console.ReadLine();
                var listOfRolls = new List<int> { };
                int numberOfThrows = 10;

                try
                {
                    // Making a list of all the throws
                    for (int throws = 0; throws < numberOfThrows; throws++)
                    {
                        listOfRolls.Add(DiceRoll(diceNotation));
                    }
                    // Displaying the throws
                    Console.CursorTop = cursorPosition;
                    Console.WriteLine($"Throwing {diceNotation} ... {string.Join(" ", listOfRolls)}");
                }
                catch (Exception error)
                {
                    Console.CursorTop = cursorPosition;
                    Console.WriteLine($"Can't throw {diceNotation} ... {error.Message}");
                }
                cursorPosition++;
            }
        }
    }
}