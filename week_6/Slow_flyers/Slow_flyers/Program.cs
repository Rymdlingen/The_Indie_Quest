using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Slow_flyers
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
            var listOfMonsterNames = new List<string> { };

            // Patterns for detecting fly speeds between 10 and 40
            string flySpeed = "fly [1-3][0-9][^\\d]";
            string flySpeed40 = "fly 40[^\\d]";

            // Checking for specific parts of the text
            for (int index = 0; index < monsterFileText.Length; index++)
            {
                // Checking if a line conatins the word Speed and then if it contains a fly speed between 10 and 40
                if (monsterFileText[index].Contains("Speed"))
                {
                    if (Regex.IsMatch(monsterFileText[index], flySpeed) || Regex.IsMatch(monsterFileText[index], flySpeed40))
                    {
                        listOfMonsterNames.Add(monsterFileText[index - 4]);
                    }
                }
            }

            // Writing the full list of monster names and their ability to fly
            Console.WriteLine("Monsters that can fly 10-40 feet per turn:");

            for (int index = 0; index < listOfMonsterNames.Count; index++)
            {
                Console.WriteLine($"{listOfMonsterNames[index]}");
            }

            Console.WriteLine(listOfMonsterNames.Count);
            //Console.WriteLine(listOfFlyingAbility.Count);
        }
    }
}
