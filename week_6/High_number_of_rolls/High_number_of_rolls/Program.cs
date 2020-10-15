using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace High_number_of_rolls
{
    class Program
    {
        static void Main(string[] args)
        {
            // This is the document with all the monsters
            string path = @"MonsterManual.txt";

            // This is an array of all the lines in the document
            string[] monsterFileText = File.ReadAllLines(path);

            // Adding the first line to the list of monster names,
            // because I know its a monster name
            var listOfMonsterNames = new List<string> { monsterFileText[0] };

            // List for storing true or false for needing 10 rolls or more to calculate monster HP
            var listOf10OrMoreRolls = new List<bool> { };

            string tenOrMoreRolls = "\\d\\dd";

            // Checking for specific parts of the text
            for (int index = 1; index < monsterFileText.Length; index++)
            {
                // Checking if there is an empty line of text, if there is the line after
                // is a monster name and the monster names is added to the list of monster names
                if (monsterFileText[index - 1] == "")
                {
                    listOfMonsterNames.Add(monsterFileText[index]);
                }

                // Checking if calculating a monsters hit points requires to roll
                //the dice 10 or more times
                if (monsterFileText[index - 1].Contains("Hit Points"))
                {
                    if (Regex.IsMatch(monsterFileText[index - 1], tenOrMoreRolls))
                    {
                        listOf10OrMoreRolls.Add(true);
                    }
                    else
                    {
                        listOf10OrMoreRolls.Add(false);
                    }
                }
            }

            // Writing the full list of monster names and their ability to fly
            Console.WriteLine("Monsters in the manual are:");

            for (int index = 0; index < listOfMonsterNames.Count; index++)
            {
                Console.WriteLine($"{listOfMonsterNames[index]} - 10+ dice rolls: {listOf10OrMoreRolls[index]}");
            }

            //Console.WriteLine(listOfMonsterNames.Count);
            //Console.WriteLine(listOf10OrMoreRolls.Count);
        }

    }
}
