using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Monster_Manual_with_search
{
    class Program
    {
        static void Main(string[] args)
        {
            // Title of the tool
            Console.WriteLine("MONSTER MANUAL\n");

            // A string with what the user inputs in the search
            string monsterSearch;

            // Path to the manual
            string path = "MonsterManual.txt";

            // Putting all the lines in the manual in an array
            string[] monsterManual = File.ReadAllLines(path);

            // A list of all monster names
            var monsterNames = new List<string> { };
            for (int manualLines = 0; manualLines < monsterManual.Length; manualLines++)
            {
                // Each monsters information contians 6 lines
                for (int block = 0; block < 6; block++)
                {
                    // The first line of a block has the name of the monster
                    if (block == 0)
                    {
                        // Add name to list of names
                        monsterNames.Add(monsterManual[manualLines]);
                    }
                }
                // Skipping to the next block (one extra + is added in the forloop, thats for the blank line between blocks)
                manualLines += 6;
            }

            // Asking for player to enter a seach and storing the search in a string
            Console.WriteLine("Enter a quary to search monsters by name:");
            monsterSearch = Console.ReadLine();
            Console.WriteLine();

            // List with search result
            var searchResult = new List<string> { };
            bool matchesFound = false;
            // Earching for matches, if no matches ask the user again
            while (!matchesFound)
            {
                // Pattern for searching for a monsters name
                string monsterSearchPattern = $".*{monsterSearch}.*";

                // Adding matching names to the list
                foreach (string name in monsterNames)
                {
                    if (Regex.IsMatch(name, monsterSearchPattern, RegexOptions.IgnoreCase))
                    {
                        searchResult.Add(name);
                    }
                }

                // Checking if there was any matches
                if (searchResult.Count == 0)
                {
                    // Asking to try again if there were no matches
                    Console.WriteLine("No monsters were found. Try again:");
                    monsterSearch = Console.ReadLine();
                    Console.WriteLine();
                }
                else
                {
                    // If there was any matches this loop ends
                    matchesFound = true;
                }
            }

            // Sorting the list
            //searchResult.Sort();

            // Displaying the list with numbers
            // If there was only one match
            if (searchResult.Count == 1)
            {
                Console.WriteLine($"Displaying information for {searchResult[0]}");
                Console.WriteLine();
            }// Asking the user to choose if there was multiple matches
            else
            {
                for (int results = 0; results < searchResult.Count; results++)
                {
                    Console.WriteLine($"{results + 1}: {searchResult[results]}");
                }
                Console.WriteLine();

                // Asking for number of monster
                Console.WriteLine("Which monster are you searching for? Enter a number:");
                string monsterNumberString = Console.ReadLine();
                Console.WriteLine();

                // Checking if input is an integer
                bool isANumber = false;
                int monsterNumber = 1;
                while (!isANumber)
                {
                    // if the input is an integer, parse the number
                    if (Regex.IsMatch(monsterNumberString, @"^\d+$"))
                    {
                        monsterNumber = Int32.Parse(monsterNumberString);

                        // if the number is on the list, continue
                        if (monsterNumber < searchResult.Count)
                        {
                            isANumber = true;
                            continue;
                        }
                    }

                    // if it isn't ask for a new input
                    Console.WriteLine("You have to enter a number from the list. Try again:");
                    monsterNumberString = Console.ReadLine();
                    Console.WriteLine();
                }

                // Confirming choice
                Console.WriteLine($"Displaying information for {searchResult[monsterNumber - 1]}");
                Console.WriteLine();
            }
        }
    }
}
