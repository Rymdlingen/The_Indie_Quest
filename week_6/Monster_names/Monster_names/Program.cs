using System;
using System.IO;
using System.Collections.Generic;

namespace Monster_names
{
    class Program
    {
        static void Main(string[] args)
        {
            // This is the document with all the monsters
            string path = @"MonsterManual.txt";

            // This is an array of all the lines in the document
            string[] monsterNames = File.ReadAllLines(path);

            // Adding the first line to the list of monster names,
            // because I know its a monster name
            var listOfMonsterNames = new List<string> { monsterNames[0] };

            // Checking if all the other lines have a blank space after them,
            // if they do I know that line is a monster name
            for (int index = 1; index < monsterNames.Length; index++)
            {
                if (monsterNames[index - 1] == "")
                {
                    listOfMonsterNames.Add(monsterNames[index]);
                }
            }

            // Writing the full list of monster names
            Console.WriteLine($"Monsters in the manual are:\n{string.Join("\n", listOfMonsterNames)}");
        }
    }
}
