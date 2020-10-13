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

        // Method that makes sure that the input is a standard dice notation
        static bool IsStandardDiceNotation(string text)
        {
            bool diceNotation = true;

            // Creating a list of valid chars for a standard dice notation
            var validChars = new List<int> { };
            // Adding numbers 0 - 9
            for (int code = 48; code < 58; code++)
            {
                validChars.Add(code);
            }
            // Adding + to valid chars
            validChars.Add(43);
            // Adding - to valid chars
            validChars.Add(45);
            // Adding d to valid chars
            validChars.Add(100);

            // Is there only valid chars int te text?
            for (int allChars = 0; allChars < text.Length; allChars++)
            {
                char checkThisChar = text[allChars];

                // if the chars in the text is not in the valid chars list then return false
                if (validChars.Contains(checkThisChar))
                {

                }
                else
                {
                    diceNotation = false;
                    break;
                }
            }

            // Do the text contain 'd'?
            if (text.Contains('d'))
            {
                int oneD = text.IndexOf('d');
                bool hasMoreThanOneD = oneD != -1 && text.IndexOf('d', oneD + 1) != -1;
                if (hasMoreThanOneD)
                {
                    diceNotation = false;
                }
            }
            else
            {
                diceNotation = false;
            }

            // Is there any text at all?
            if (text == "")
            {
                diceNotation = false;
            }

            return diceNotation;
        }

        // Method for calculating total number of dice rolls
        static int Auxiliary(string diceNotation)
        {
            // Seperating the number that tells ous the number of dice rolls
            string[] diceRolls = diceNotation.Split('d');

            // Puting the rigth values into the rigth strings
            string numberOfRollsString = diceRolls[0];

            // If the number of rolls is not specidied we assume its 1
            if (numberOfRollsString == "")
            {
                numberOfRollsString = "1";
            }

            // Making the string into ints
            int numberOfRolls = Int32.Parse(numberOfRollsString);

            return numberOfRolls;
        }

        static void Main(string[] args)
        {
            // Input
            string text = "To use the magic potion of dragon breath, first roll d8. If you roll 2 or higher, you manage to open the potion. Now roll 5d4+5 to see how many seconds the spell will last. Finally, the damage of the flames will be 2d6 per second.";

            // Making the text into an array of words
            string[] words = text.Split(' ', ',', '.', '!', '?');
            int diceNotationCounter = 0;
            int totalDiceRolls = 0;

            // Checking if a word is in standar dice notation, counting the notations
            // calculating the total rolls
            foreach (string word in words)
            {
                if (IsStandardDiceNotation(word))
                {
                    totalDiceRolls += Auxiliary(word);
                    diceNotationCounter++;
                }
            }

            // Output the result
            Console.WriteLine($"{diceNotationCounter} standard dice notations present.");
            Console.WriteLine($"The player will have to perform {totalDiceRolls} rolls.");
        }
    }
}