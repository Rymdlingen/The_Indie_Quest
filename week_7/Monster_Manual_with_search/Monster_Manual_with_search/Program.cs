using System;
using System.Collections.Generic;
using System.IO;

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

            // Asking for player to enter a seach and storing the search in a string
            Console.WriteLine("Enter a quary to search monsters by name:");
            monsterSearch = Console.ReadLine();
        }
    }
}
