using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Monster_Manual_with_search
{
    class MonsterEntry
    {
        public string Name;
        public string Description;
        public string Alignment;
        public string HitPoints;
        public ArmorInformation Armor = new ArmorInformation();
    }

    class ArmorInformation
    {
        public int Class;
        public string Type;
    }

    enum ArmorType
    {
        Unspecified,
        Natural,
        Leather,
        StuddedLeather,
        Hide,
        ChainShirt,
        ChainMail,
        ScaleMail,
        Plate,
        Other
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Title of the tool
            Console.WriteLine("MONSTER MANUAL\n");

            // A string with what the user inputs in the search
            string monsterSearch = "";

            // Path to the manual
            string path = "MonsterManual.txt";

            // Putting all the lines in the manual in an array
            string[] monsterManual = File.ReadAllLines(path);

            // A list of all monster names and array with information about every monster
            var monsterNames = new List<string> { };
            var monsterEntries = new List<MonsterEntry> { };
            string[] armorTypesNames = Enum.GetNames(typeof(ArmorType));
            var monstersSortedByArmorType = new List<List<string>> { };
            for (int manualLines = 0; manualLines < monsterManual.Length; manualLines++)
            {
                var monsterEntry = new MonsterEntry();

                // Each monsters information contians 6 lines
                for (int block = 0; block < 6; block++)
                {
                    // The first line of a block has the name of the monster
                    if (block == 0)
                    {
                        // Add name to the list
                        monsterEntry.Name = monsterManual[manualLines + block];
                        monsterNames.Add(monsterManual[manualLines + block]);
                    }
                    else if (block == 1)
                    {
                        // Add description and alignment to list
                        string[] descriptionAndAlignment = monsterManual[manualLines + block].Split(',');
                        monsterEntry.Description = descriptionAndAlignment[0];
                        monsterEntry.Alignment = descriptionAndAlignment[1].TrimStart();
                    }
                    else if (block == 2)
                    {
                        // Search for and add hit points (dice notation) to list
                        string pattern = @"\d*d\d*[-+]?\d*";
                        Match diceNotation = Regex.Match(monsterManual[manualLines + block], pattern);
                        if (diceNotation.Value == "")
                        {
                            Match number = Regex.Match(monsterManual[manualLines + block], @"\d+");
                            monsterEntry.HitPoints = $"{number.Value} (no standard dice notation found)";
                        }
                        else
                        {
                            monsterEntry.HitPoints = diceNotation.Value;
                        }
                    }
                    else if (block == 3)
                    {
                        string pattern = @"(\d+) (\((.*)\))?";
                        Match match = Regex.Match(monsterManual[manualLines + block], pattern);
                        GroupCollection group = match.Groups;
                        monsterEntry.Armor.Class = Int32.Parse(group[1].Value);
                        monsterEntry.Armor.Type = group[3].Value;

                        if (group[3].Value == "")
                        {
                            monstersSortedByArmorType[0].Add(monsterManual[manualLines]);
                        }
                        else if (group[3].Value.Contains("Natural"))
                        {
                            monstersSortedByArmorType[1].Add(monsterManual[manualLines]);
                        }
                    }
                }
                // Adding the monster to the list of monsters
                monsterEntries.Add(monsterEntry);

                // Skipping to the next block (one extra + is added in the forloop, thats for the blank line between blocks)
                manualLines += 6;
            }

            // Asking user if they want to search by name or armor type
            Console.WriteLine("Do you want to search by monster (n)ame or (a)rmor class?");
            string typeOfSearch = Console.ReadLine();
            bool searchByName = false;
            bool searchByArmorType = false;
            int selectedArmorTypeNumber = 1;
            string selectedArmorType = "";

            // Continuing with different searches for different choises
            if (typeOfSearch.ToLower() == "n" || typeOfSearch.ToLower() == "name")
            {
                searchByName = true;

                // Asking for user to enter a search and storing the search in a string
                Console.WriteLine("Enter a quary to search monsters by name:");
                monsterSearch = Console.ReadLine();
                Console.WriteLine();
            }
            else if (typeOfSearch.ToLower() == "a" || typeOfSearch.ToLower() == "armor" || typeOfSearch.ToLower() == "armor class")
            {
                searchByArmorType = true;

                // Asking the user what type of armor they are searching for
                Console.WriteLine("Which armor type do you want to display?");
                for (int armorTypes = 0; armorTypes < armorTypesNames.Length; armorTypes++)
                {
                    Console.WriteLine($"{armorTypes + 1}. {armorTypesNames[armorTypes]}");
                }
                Console.WriteLine();

                // Asking for number of monster
                Console.WriteLine("Enter a number:");
                string armorTypeNumberString = Console.ReadLine();
                Console.WriteLine();

                // Checking if input is an integer
                bool isANumber = false;
                while (!isANumber)
                {
                    // if the input is an integer, parse the number
                    if (Regex.IsMatch(armorTypeNumberString, @"^\d+$"))
                    {
                        selectedArmorTypeNumber = Int32.Parse(armorTypeNumberString);

                        // if the number is on the list, continue
                        if (selectedArmorTypeNumber <= armorTypesNames.Length && selectedArmorTypeNumber > 0)
                        {
                            isANumber = true;
                            selectedArmorType = armorTypesNames[selectedArmorTypeNumber - 1];
                            continue;
                        }
                    }

                    // if it isn't ask for a new input
                    Console.WriteLine("You have to enter a number from the list. Try again:");
                    armorTypeNumberString = Console.ReadLine();
                    Console.WriteLine();
                }
            }
            else
            {

            }

            // List with search result
            var searchResult = new List<string> { };
            bool matchesFound = false;

            // If the user is searching by name
            if (searchByName)
            {
                // Searching for matches, if no matches ask the user again
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
            }

            // If the user is searching by armor type
            if (searchByArmorType)
            {
                // Pattern for searching for a monsters armor type
                string monsterSearchPattern = $".*{monsterSearch}.*";
                string armorTypePattern = $"{selectedArmorType}";

                // Adding matching names to the list
                foreach (string name in monsterNames)
                {
                    if (Regex.IsMatch(name, monsterSearchPattern, RegexOptions.IgnoreCase))
                    {
                        searchResult.Add(name);
                    }
                }
            }

            // Sorting the list
            //searchResult.Sort();

            // Displaying the list with numbers
            int selectedMonsterNumber = 1;
            // If there was only one match the tool will skip displaying a list and show information about the monster it found
            if (searchResult.Count == 1)
            {

            }// Asking the user to choose if there was multiple matches
            else
            {
                // Displaying a list of matches
                Console.WriteLine("Which monster did you want to look up?");
                for (int results = 0; results < searchResult.Count; results++)
                {
                    Console.WriteLine($"{results + 1}: {searchResult[results]}");
                }
                Console.WriteLine();

                // Asking for number of monster
                Console.WriteLine("Enter a number:");
                string monsterNumberString = Console.ReadLine();
                Console.WriteLine();

                // Checking if input is an integer
                bool isANumber = false;
                while (!isANumber)
                {
                    // if the input is an integer, parse the number
                    if (Regex.IsMatch(monsterNumberString, @"^\d+$"))
                    {
                        selectedMonsterNumber = Int32.Parse(monsterNumberString);

                        // if the number is on the list, continue
                        if (selectedMonsterNumber <= searchResult.Count && selectedMonsterNumber > 0)
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
            }

            // Variable with the name of the selected monster
            string selectedMonster = searchResult[selectedMonsterNumber - 1];

            // Confirming choice
            Console.WriteLine($"Displaying information for {selectedMonster}.\n");

            // Finding the index of the monster
            int selectedMonsterIndex = monsterNames.IndexOf(selectedMonster);

            // Displaying information about the selected monster
            Console.WriteLine($"Name: {monsterEntries[selectedMonsterIndex].Name}");
            Console.WriteLine($"Description: {monsterEntries[selectedMonsterIndex].Description}");
            Console.WriteLine($"Alignment: {monsterEntries[selectedMonsterIndex].Alignment}");
            Console.WriteLine($"Hit points: {monsterEntries[selectedMonsterIndex].HitPoints}");
            Console.WriteLine($"Armor class: {monsterEntries[selectedMonsterIndex].Armor.Class}");
            if (monsterEntries[selectedMonsterIndex].Armor.Type != "")
            {
                Console.WriteLine($"Armor type: {monsterEntries[selectedMonsterIndex].Armor.Type}");
            }
            Console.WriteLine();
        }
    }
}
