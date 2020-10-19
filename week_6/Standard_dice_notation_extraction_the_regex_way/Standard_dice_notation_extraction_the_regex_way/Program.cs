using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
            // Pattern for a standard dice notation
            string diceNotationPattern = "^(\\d*)d(\\d+)[+-]?(\\d*)$";

            // Looking for matches
            MatchCollection matches = Regex.Matches(diceNotation, diceNotationPattern);

            // Creating a list with all the captured groups
            GroupCollection groups;
            var values = new List<string> { };
            foreach (Match match in matches)
            {
                groups = match.Groups;

                foreach (Group group in groups)
                {
                    values.Add(group.Value);
                }
            }

            // Puting the rigth values into the rigth strings
            string numberOfRollsString = values[1];
            string diceSidesString = values[2];

            // If the number of rolls is not specidied we assume its 1
            if (numberOfRollsString == "")
            {
                numberOfRollsString = "1";
            }

            // If the dice sides is not specidied we assume its 6
            if (diceSidesString == "")
            {
                diceSidesString = "6";
            }

            // Making the string into ints
            int numberOfRolls = Int32.Parse(numberOfRollsString);
            int diceSides = Int32.Parse(diceSidesString);

            // Ckecking if the notation has an modifier and making into a string and then an int
            string fixedBonusString;
            int fixedBonus = 0;
            if (values[3] == "")
            {

            }
            else
            {
                fixedBonusString = values[3];
                fixedBonus = Int32.Parse(fixedBonusString);

                // If the notation contains a subtraction modifier
                if (diceNotation.Contains('-'))
                {
                    fixedBonus = 0 - fixedBonus;
                }
            }

            return DiceRoll(numberOfRolls, diceSides, fixedBonus);
        }

        // Method that makes sure that the input is a standard dice notation
        static bool IsStandardDiceNotation(string text)
        {
            bool diceNotation = true;

            // Wired pattern to make sure nothing that isn't standard dice notation passes
            string diceNotationPattern = "(^[^0]^\\d+d|^[1-9]+\\d*d|d)\\d+[+-]?\\d*$";
            if (Regex.IsMatch(text, diceNotationPattern))
            {

            }
            else
            {
                diceNotation = false;
            }

            return diceNotation;
        }

        static void Main(string[] args)
        {
            int cursorPosition = 0;

            while (true)
            {
                string diceNotation = Console.ReadLine();
                var listOfRolls = new List<int> { };
                int numberOfThrows = 10;

                // Checking if the input is in standard dice notation
                if (IsStandardDiceNotation(diceNotation))
                {
                    // Making a list of all the throws
                    for (int throws = 0; throws < numberOfThrows; throws++)
                    {
                        listOfRolls.Add(DiceRoll(diceNotation));
                    }
                    Console.CursorTop = cursorPosition;
                    // Displaying the throws
                    Console.WriteLine($"Throwing {diceNotation} ... {string.Join(" ", listOfRolls)}");
                    cursorPosition++;
                } // Output if the input is not in standard dice notation
                else
                {
                    Console.CursorTop = cursorPosition;
                    Console.WriteLine($"Can't throw {diceNotation}, it is not in standard dice notation.");
                    cursorPosition++;
                }
            }
        }
    }
}