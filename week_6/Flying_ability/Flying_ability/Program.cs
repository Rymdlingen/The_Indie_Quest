using System;
using System.IO;
using System.Collections.Generic;

namespace Flying_ability
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

            var listOfFlyingAbility = new List<bool> { };

            // Checking for specific parts of the text
            for (int index = 1; index < monsterFileText.Length; index++)
            {
                // Checking if there is an empty line of text, if there is the line after
                // is a monster name and the monster names is added to the list of monster names
                if (monsterFileText[index - 1] == "")
                {
                    listOfMonsterNames.Add(monsterFileText[index]);
                }

                // Checking if a line conatins the word fly and if it does add true to the list
                // else add false
                if (monsterFileText[index - 1].Contains("Speed"))
                {
                    if (monsterFileText[index - 1].Contains("fly"))
                    {
                        listOfFlyingAbility.Add(true);
                    }
                    else
                    {
                        listOfFlyingAbility.Add(false);
                    }
                }
            }

            // Writing the full list of monster names and their ability to fly
            Console.WriteLine("Monsters in the manual are:");

            for (int index = 0; index < listOfMonsterNames.Count; index++)
            {
                Console.WriteLine($"{listOfMonsterNames[index]} - Can fly: {listOfFlyingAbility[index]}");
            }

            //Console.WriteLine(listOfMonsterNames.Count);
            //Console.WriteLine(listOfFlyingAbility.Count);
        }
    }
}
