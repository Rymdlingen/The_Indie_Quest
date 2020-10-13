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
            // Creating a list of our values
            string[] values = diceNotation.Split('d', '+', '-');

            // Puting the rigth values into the rigth strings
            string numberOfRollsString = values[0];
            string diceSidesString = values[1];

            // If the number of rolls is not specidied we assume its 1
            if (numberOfRollsString == "")
            {
                numberOfRollsString = "1";
            }

            // Making the string into ints
            int numberOfRolls = Int32.Parse(numberOfRollsString);
            int diceSides = Int32.Parse(diceSidesString);

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

                // Making a list of all the throws
                for (int throws = 0; throws < numberOfThrows; throws++)
                {
                    listOfRolls.Add(DiceRoll(diceNotation));
                }
                Console.CursorTop = cursorPosition;
                // Displaying the throws
                Console.WriteLine($"Throwing {diceNotation} ... {string.Join(" ", listOfRolls)}");
                cursorPosition++;
            }
        }
    }
}