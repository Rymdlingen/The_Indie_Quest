using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Monsters_with_alignmnet
{
    class Program
    {
        static void Main(string[] args)
        {
            // This is the document with all the monsters
            string path = @"MonsterManual.txt";

            // This is an array of all the lines in the document
            string[] monsterFileText = File.ReadAllLines(path);

            // List to add monsters name to
            var listOfMonsterNames = new List<string> { };

            // Every monster block is 6 lines with the name of the monster on the first line
            int blockLine = 0;

            // Pattern for detecting if a monster has an alignment
            string alignmentPattern = "(lawful|neutral|chaotic) (good|neutral|evil)";

            // A list of monsters names and alignments if the have a specified alignment
            var monstersWithSpecifiedAlignments = new List<string> { };

            // Checking if all the other lines have a blank space after them,
            // if they do I know that line is a monster name
            for (int index = 0; index < monsterFileText.Length; index++)
            {
                if (blockLine == 0)
                {
                    listOfMonsterNames.Add(monsterFileText[index]);
                }

                if (blockLine == 1 && Regex.IsMatch(monsterFileText[index], alignmentPattern))
                {
                    // Adding the name of the monster to the list
                    monstersWithSpecifiedAlignments.Add(monsterFileText[index - 1]);

                    // Adding and formatting the monsters alignments to the list
                    string[] takeTheTwoLastWords = Regex.Split(monsterFileText[index], " ");
                    string twoLastWords = $"({takeTheTwoLastWords[takeTheTwoLastWords.Length - 2]} {takeTheTwoLastWords[takeTheTwoLastWords.Length - 1]})";
                    monstersWithSpecifiedAlignments.Add(twoLastWords);
                }

                // Resetting the line count if the block ends
                if (monsterFileText[index] == "")
                {
                    blockLine = 0;
                }
                else
                {
                    blockLine++;
                }
            }

            // Writing the list of names and alignments for monster that have specified alignments
            Console.WriteLine("Monsters with a specific alignment:");

            for (int index = 0; index < monstersWithSpecifiedAlignments.Count; index++)
            {
                Console.WriteLine($"{monstersWithSpecifiedAlignments[index]} {monstersWithSpecifiedAlignments[index + 1]}");
                index++;
            }

            //Console.WriteLine(listOfMonsterNames.Count);
            //Console.WriteLine(monstersWithSpecifiedAlignments.Count);
        }
    }
}
