using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Monsters_with_alignment_the_regex_way
{
    class Program
    {
        static void Main(string[] args)
        {
            // This is the document with all the monsters
            string path = @"MonsterManual.txt";

            // This is an array of all the lines in the document
            string[] monsterFileText = File.ReadAllLines(path);

            // Lists to cover all combinations of alignments
            var alignment1 = new List<string> { "lawful", "chaotic", "neutral" };
            var alignment2 = new List<string> { "good", "neutral", "evil" };

            // List of different types of monsters
            var namesByAlignment = new List<string>[3, 3];
            var namesOfUnaligned = new List<string>();
            var namesOfAnyAlignment = new List<string>();
            var namesOfSpecialCases = new List<string>();

            // Adding lists to the list of all alignment combinations
            for (int axis1 = 0; axis1 < 3; axis1++)
                for (int axis2 = 0; axis2 < 3; axis2++)
                    namesByAlignment[axis1, axis2] = new List<string>();

            // List to add monsters name to (used to count all the monsters)
            var listOfMonsterNames = new List<string> { };

            // Every monster block is 6 lines with the name of the monster on the first line
            // and the monsters alignment on the second line
            int blockLine = 0;

            // Pattern for detecting if a monster has an alignment
            string alignmentPattern = "(lawful|neutral|chaotic) (good|neutral|evil)$";

            // Searching in every block of monster information
            for (int index = 0; index < monsterFileText.Length; index++)
            {
                // First line of each block has the monsters name
                if (blockLine == 0)
                {
                    // Add every monsters name to the list of monster names
                    listOfMonsterNames.Add(monsterFileText[index]);
                }

                // The second line of the block ha alignment information
                if (blockLine == 1)
                {
                    // Adding an unaligned monsters name to the list of unaligned monsters
                    if (monsterFileText[index].Contains("unaligned"))
                    {
                        namesOfUnaligned.Add(monsterFileText[index - 1]);
                    }
                    // Adding the name of a monster that can have any alignment to the correct list
                    else if (monsterFileText[index].Contains("any alignment"))
                    {
                        namesOfAnyAlignment.Add(monsterFileText[index - 1]);
                    }
                    // Adding monsters with specified alignments to different lists
                    else if (Regex.IsMatch(monsterFileText[index], alignmentPattern))
                    {
                        for (int axis1 = 0; axis1 < 3; axis1++)
                        {
                            if (monsterFileText[index].Contains(alignment1[axis1]))
                            {
                                for (int axis2 = 0; axis2 < 3; axis2++)
                                {
                                    // Add monster name to list of lawful-good (0, 0)
                                    // Add monster name to list of lawful-neutral (0, 1)
                                    // Add monster name to list of lawful-evil (0, 2)
                                    // Add monster name to list of chaotic-good (1, 0)
                                    // Add monster name to list of chaotic-neutral (1, 1)
                                    // Add monster name to list of chaotic-evil (1, 2)
                                    // Add monster name to list of neutral-good (2, 0)
                                    // Add monster name to list of neutral-evil (2, 2)
                                    if (monsterFileText[index].Contains($"{alignment1[axis1]} {alignment2[axis2]}"))
                                    {
                                        namesByAlignment[axis1, axis2].Add(monsterFileText[index - 1]);
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                    } // Add monster name to list of true-neutral (2, 1)
                    else if (!Regex.IsMatch(monsterFileText[index], alignmentPattern) && Regex.IsMatch(monsterFileText[index], @"neutral$"))
                    {
                        namesByAlignment[2, 1].Add(monsterFileText[index - 1]);
                    } // Adding all the other monsters to list of special cases (with the special case in parentheses)
                    else
                    {
                        string[] specialCase = monsterFileText[index].Split(", ");
                        namesOfSpecialCases.Add($"{monsterFileText[index - 1]} ({specialCase[1]})");
                    }
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

            // Count for checking that my lists have all the names
            /*Console.WriteLine(listOfMonsterNames.Count);
            int namesByAlignmentCount = 0;
            for (int axis1 = 0; axis1 < 3; axis1++)
            {
                for (int axis2 = 0; axis2 < 3; axis2++)
                {
                    namesByAlignmentCount += namesByAlignment[axis1, axis2].Count;
                }
            }
            Console.WriteLine(namesByAlignmentCount + namesOfAnyAlignment.Count + namesOfSpecialCases.Count + namesOfUnaligned.Count);
            */

            // Writing all different lists of different monsters
            // First all lists and names for monsters with specified alignments
            for (int axis1 = 0; axis1 < 3; axis1++)
            {
                for (int axis2 = 0; axis2 < 3; axis2++)
                {
                    if (alignment1[axis1] == "neutral" && alignment2[axis2] == "neutral")
                    {
                        Console.WriteLine($"Monsters with alignment true {alignment2[axis2]} are:\n{string.Join("\n", namesByAlignment[axis1, axis2])}");
                    }
                    else
                    {
                        Console.WriteLine($"Monsters with alignment {alignment1[axis1]} {alignment2[axis2]} are:\n{string.Join("\n", namesByAlignment[axis1, axis2])}");
                    }
                    Console.WriteLine();
                }
            }

            // All unaligned monsters
            Console.WriteLine($"Unaligned monsters are:\n{string.Join("\n", namesOfUnaligned)}");
            Console.WriteLine();
            // All monster that can be of any alignment
            Console.WriteLine($"Monsters which can be of any alignment are:\n{string.Join("\n", namesOfAnyAlignment)}");
            Console.WriteLine();
            // All monsters with special alignments (and their special alignments)
            Console.WriteLine($"Monsters with special cases are:\n{string.Join("\n", namesOfSpecialCases)}");
        }
    }
}
