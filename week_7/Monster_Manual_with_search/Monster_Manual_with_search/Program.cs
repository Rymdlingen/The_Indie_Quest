﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Monster_Manual_with_search
{
    // For storing information about individual monsters.
    class MonsterEntry
    {
        public string Name;
        public string Description;
        public string Alignment;
        public string HitPoints;
        public ArmorInformation Armor = new ArmorInformation();
    }

    // For storing information about armor.
    class ArmorInformation
    {
        public int Class;
        public string Description;
        public ArmorType Type;
    }

    // For storing information about armor type.
    class ArmorTypeEntry
    {
        public string Name;
        public ArmorTypeCategory Category;
        public int Weight;
    }

    // All armor types.
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

    // Armor type categorys.
    enum ArmorTypeCategory
    {
        Light,
        Medium,
        Heavy
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Title of the tool.
            Console.WriteLine("MONSTER MANUAL\n");

            // A string with what the user inputs in the search.
            string monsterSearch = "";

            // Path to armor types.
            string pathArmorTypes = "ArmorTypes.txt";

            // Putting all the armor types in an array.
            string[] armorTypesFile = File.ReadAllLines(pathArmorTypes);

            // A dictionary of armor types.
            var armorTypeEntries = new Dictionary<ArmorType, ArmorTypeEntry> { };

            foreach (string line in armorTypesFile)
            {
                var values = new List<string> { };
                for (int value = 0; value < line.Split(',').Length; value++)
                {
                    values.Add(line.Split(',')[value]);
                }

                var armorTypeEntry = new ArmorTypeEntry();

                ArmorType armorType = (ArmorType)Enum.Parse(typeof(ArmorType), values[0]);

                // Storing the name of the armor.
                armorTypeEntry.Name = values[1];

                // Storing the category of the armor.
                ArmorTypeCategory armorTypeCategory = (ArmorTypeCategory)Enum.Parse(typeof(ArmorTypeCategory), values[2]);
                armorTypeEntry.Category = armorTypeCategory;

                // Storing the weight of the armor
                armorTypeEntry.Weight = Int32.Parse(values[3]);

                armorTypeEntries.Add(armorType, armorTypeEntry);
            }

            // Path to the manual.
            string pathMonsterManual = "MonsterManual.txt";

            // Putting all the lines in the manual in an array.
            string[] monsterManual = File.ReadAllLines(pathMonsterManual);

            // A list of all monster names and a list with information about every monster.
            var monsterNames = new List<string>();
            var monsterEntries = new List<MonsterEntry>();

            // Sorting all monsters by armor type.
            string[] armorTypesNames = Enum.GetNames(typeof(ArmorType));
            string[] armorTypesNamesFormatted = Enum.GetNames(typeof(ArmorType));
            ArmorType[] armorTypes = (ArmorType[])Enum.GetValues(typeof(ArmorType));
            var monstersSortedByArmorType = new Dictionary<ArmorType, List<string>>();

            // Formatting the armor types.
            for (int armorType = 0; armorType < armorTypesNamesFormatted.Length; armorType++)
            {
                string armorTypeWithTwoWordsPattern = "([A-Z].*)([A-Z].*)";
                if (Regex.IsMatch(armorTypesNamesFormatted[armorType], armorTypeWithTwoWordsPattern))
                {
                    Match armorTypeMatch = Regex.Match(armorTypesNamesFormatted[armorType], armorTypeWithTwoWordsPattern);
                    GroupCollection armorTypeGroups = armorTypeMatch.Groups;
                    armorTypesNamesFormatted[armorType] = $"{armorTypeGroups[1]} {armorTypeGroups[2]}";
                }
            }

            // Creating as many new nested lists as there is armor types to sort all monsters into.
            foreach (ArmorType type in armorTypes)
            {
                monstersSortedByArmorType.Add(type, new List<string> { });
            }

            // Getting information about each monster and putting it in the right list, array and/or object.
            for (int manualLines = 0; manualLines < monsterManual.Length; manualLines++)
            {
                var monsterEntry = new MonsterEntry();

                // Each monsters information contians 6 lines.
                for (int block = 0; block < 6; block++)
                {
                    // The first line of a block has the name of the monster.
                    if (block == 0)
                    {
                        // Add name to the list.
                        monsterEntry.Name = monsterManual[manualLines + block];
                        monsterNames.Add(monsterManual[manualLines + block]);
                    }
                    else if (block == 1)
                    {
                        // Add description and alignment to list
                        string[] descriptionAndAlignment = monsterManual[manualLines + block].Split(',');
                        // Some of the lines with thedescription and alignment contains more than on ',' this if else makes sure those lines are stored correctly.
                        if (descriptionAndAlignment.Length > 2)
                        {
                            monsterEntry.Description = $"{descriptionAndAlignment[0]}, {descriptionAndAlignment[1].TrimStart()}";
                            monsterEntry.Alignment = descriptionAndAlignment[2].TrimStart();
                        }
                        else
                        {
                            monsterEntry.Description = descriptionAndAlignment[0];
                            monsterEntry.Alignment = descriptionAndAlignment[1].TrimStart();
                        }
                    }
                    else if (block == 2)
                    {
                        // Search for and add hit points (dice notation) to list.
                        string pattern = @"\d*d\d*[-+]?\d*";
                        Match diceNotation = Regex.Match(monsterManual[manualLines + block], pattern);
                        if (diceNotation.Value == "")
                        {
                            // If no standard dicenotation was find, add the number instead.
                            Match number = Regex.Match(monsterManual[manualLines + block], @"\d+");
                            monsterEntry.HitPoints = $"{number.Value} (no standard dice notation found)";
                        }
                        else
                        {
                            // Add the dice notation.
                            monsterEntry.HitPoints = diceNotation.Value;
                        }
                    }
                    else if (block == 3)
                    {
                        // Search for the monsters armor type and class.
                        string pattern = @"(\d+) (\((.*)\))?";
                        Match match = Regex.Match(monsterManual[manualLines + block], pattern);
                        GroupCollection group = match.Groups;
                        monsterEntry.Armor.Class = Int32.Parse(group[1].Value);
                        monsterEntry.Armor.Description = group[3].Value;

                        // If the armor type is not specified.
                        if (group[3].Value == "")
                        {
                            monsterEntry.Armor.Type = ArmorType.Unspecified;
                        }
                        else
                        {
                            // Search for a matching armor type.
                            foreach (ArmorType type in armorTypes)
                            {
                                if (group[3].Value.ToLower().Contains(armorTypesNamesFormatted[(int)type].ToLower()))
                                {
                                    // Makes sure Leather and Studded Leather is not counted as the same.
                                    if (group[3].Value.ToLower().Contains("studded"))
                                    {
                                        monsterEntry.Armor.Type = ArmorType.StuddedLeather;
                                    }
                                    else
                                    {
                                        monsterEntry.Armor.Type = type;
                                    }
                                    break;
                                }
                                else if (type == ArmorType.Other)
                                {
                                    monsterEntry.Armor.Type = ArmorType.Other;
                                    break;
                                }
                            }
                        }

                        monstersSortedByArmorType[monsterEntry.Armor.Type].Add(monsterManual[manualLines]);
                    }
                }
                // Adding the monster to the list of monsters.
                monsterEntries.Add(monsterEntry);

                // Skipping to the next block (one extra + is added in the forloop, thats for the blank line between blocks).
                manualLines += 6;
            }

            // Asking user if they want to search by name or armor type.
            string typeOfSearch = "";
            while (typeOfSearch != "n" && typeOfSearch != "name" && typeOfSearch != "a" && typeOfSearch != "armor" && typeOfSearch != "armor class")
            {
                Console.WriteLine("Do you want to search by monster (n)ame or (a)rmor class?");
                typeOfSearch = Console.ReadLine();
                Console.WriteLine();
            }

            bool searchByName = false;
            bool searchByArmorType = false;
            ArmorType selectedArmorType = ArmorType.Unspecified;

            // Continuing with different searches for different choises.
            if (typeOfSearch.ToLower() == "n" || typeOfSearch.ToLower() == "name")
            {
                searchByName = true;

                // Asking for user to enter a search and storing the search in a string.
                Console.WriteLine("Enter a quary to search monsters by name:");
                monsterSearch = Console.ReadLine();
                Console.WriteLine();
            }
            else if (typeOfSearch.ToLower() == "a" || typeOfSearch.ToLower() == "armor" || typeOfSearch.ToLower() == "armor class")
            {
                searchByArmorType = true;

                // Asking the user what type of armor they are searching for.
                Console.WriteLine("Which armor type do you want to display?");
                for (int armorTypesIndex = 0; armorTypesIndex < armorTypesNamesFormatted.Length; armorTypesIndex++)
                {
                    Console.WriteLine($"{armorTypesIndex + 1}. {armorTypesNamesFormatted[armorTypesIndex]}");
                }
                Console.WriteLine();

                // Asking for number of monster.
                Console.WriteLine("Enter a number:");
                string armorTypeNumberString = Console.ReadLine();
                Console.WriteLine();

                // Checking if input is an integer.
                bool isANumber = false;
                while (!isANumber)
                {
                    // If the input is an integer, parse the number.
                    if (Regex.IsMatch(armorTypeNumberString, @"^\d+$"))
                    {
                        int selectedArmorTypeNumber = Int32.Parse(armorTypeNumberString);

                        // If the number is on the list, continue.
                        if (selectedArmorTypeNumber <= armorTypesNames.Length && selectedArmorTypeNumber > 0)
                        {
                            isANumber = true;
                            int selectedArmorTypeIndex = selectedArmorTypeNumber - 1;
                            selectedArmorType = (ArmorType)selectedArmorTypeIndex;
                            Console.WriteLine($"These are the monsters with {armorTypesNamesFormatted[selectedArmorTypeIndex].ToLower()} armor.");
                            continue;
                        }
                    }

                    // If it isn't ask for a new input.
                    Console.WriteLine("You have to enter a number from the list. Try again:");
                    armorTypeNumberString = Console.ReadLine();
                    Console.WriteLine();
                }
            }


            // List with search result.
            var searchResult = new List<string> { };
            bool matchesFound = false;

            // If the user is searching by name.
            if (searchByName)
            {
                // Searching for matches, if no matches ask the user again.
                while (!matchesFound)
                {
                    // Pattern for searching for a monsters name.
                    string monsterSearchPattern = $".*{monsterSearch}.*";

                    // Adding matching names to the list.
                    foreach (string name in monsterNames)
                    {
                        if (Regex.IsMatch(name, monsterSearchPattern, RegexOptions.IgnoreCase))
                        {
                            searchResult.Add(name);
                        }
                    }

                    // Checking if there was any matches.
                    if (searchResult.Count == 0)
                    {
                        // Asking to try again if there were no matches.
                        Console.WriteLine("No monsters were found. Try again:");
                        monsterSearch = Console.ReadLine();
                        Console.WriteLine();
                    }
                    else
                    {
                        // If there was any matches this loop ends.
                        matchesFound = true;
                    }
                }
            }

            // If the user is searching by armor type.
            if (searchByArmorType)
            {
                foreach (string monster in monstersSortedByArmorType[selectedArmorType])
                {
                    searchResult.Add(monster);
                }
            }

            // Displaying the list with numbers.
            int selectedMonsterNumber = 1;
            // If there was only one match the tool will skip displaying a list and show information about the monster it found.
            if (searchResult.Count == 1)
            {

            }// Asking the user to choose if there was multiple matches.
            else
            {
                // Displaying a list of matches.
                Console.WriteLine("Which monster did you want to look up?");
                for (int results = 0; results < searchResult.Count; results++)
                {
                    Console.WriteLine($"{results + 1}: {searchResult[results]}");
                }
                Console.WriteLine();

                // Asking for number of monster.
                Console.WriteLine("Enter a number:");
                string monsterNumberString = Console.ReadLine();
                Console.WriteLine();

                // Checking if input is an integer.
                bool isANumber = false;
                while (!isANumber)
                {
                    // If the input is an integer, parse the number.
                    if (Regex.IsMatch(monsterNumberString, @"^\d+$"))
                    {
                        selectedMonsterNumber = Int32.Parse(monsterNumberString);

                        // If the number is on the list, continue.
                        if (selectedMonsterNumber <= searchResult.Count && selectedMonsterNumber > 0)
                        {
                            isANumber = true;
                            continue;
                        }
                    }

                    // If it isn't ask for a new input.
                    Console.WriteLine("You have to enter a number from the list. Try again:");
                    monsterNumberString = Console.ReadLine();
                    Console.WriteLine();
                }
            }

            // Variable with the name of the selected monster.
            string selectedMonsterName = searchResult[selectedMonsterNumber - 1];

            // Confirming choice.
            Console.WriteLine($"Displaying information for {selectedMonsterName}.\n");

            // Finding the index of the monster.
            int selectedMonsterIndex = monsterNames.IndexOf(selectedMonsterName);

            // Displaying information about the selected monster.
            MonsterEntry selectedMonster = monsterEntries[selectedMonsterIndex];
            Console.WriteLine($"Name: {selectedMonster.Name}");
            Console.WriteLine($"Description: {selectedMonster.Description}");
            Console.WriteLine($"Alignment: {selectedMonster.Alignment}");
            Console.WriteLine($"Hit points: {selectedMonster.HitPoints}");
            Console.WriteLine($"Armor class: {selectedMonster.Armor.Class}");

            if (selectedMonster.Armor.Description != "")
            {
                Console.WriteLine($"Armor type: {selectedMonster.Armor.Description}");
            }

            if (armorTypeEntries.ContainsKey(selectedMonster.Armor.Type))
            {
                ArmorTypeEntry selectedMonsterArmor = armorTypeEntries[selectedMonster.Armor.Type];
                Console.WriteLine($"Armor category: {selectedMonsterArmor.Category}");
                Console.WriteLine($"Armor weight: {selectedMonsterArmor.Weight} lb.");
            }
            Console.WriteLine();
        }
    }
}
