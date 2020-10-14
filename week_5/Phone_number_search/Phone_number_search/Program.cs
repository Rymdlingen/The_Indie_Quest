using System;
using System.Collections.Generic;
using System.IO;

namespace test
{
    class Program
    {
        static bool IsPhoneNumber(string word)
        {
            bool isPhoneNumber = true;

            // Creating a list of valid symbols for a phone number
            var validSymbols = new List<int> { };
            // Adding numbers 0 - 9
            for (int code = 48; code < 58; code++)
            {
                validSymbols.Add(code);
            }
            // Adding - to valid chars
            validSymbols.Add(45);

            // If the word string is empty return false
            if (word == "")
            {
                return false;
            }

            // Is there only valid symbols int the word?
            for (int allChars = 0; allChars < word.Length; allChars++)
            {
                char checkThisChar = word[allChars];

                // If the symbols in the word is not in the valid symbols list then return false
                if (!validSymbols.Contains(checkThisChar))
                {
                    isPhoneNumber = false;
                    break;
                }
            }

            return isPhoneNumber;
        }
        static void Main(string[] args)
        {
            string path = @"message.txt";

            // Open the file to read from
            string readText = File.ReadAllText(path);

            // Split the text from the file into a list of words
            string[] words = readText.Split(' ', ',', '.');

            // A list to store phone numbers in
            var phoneNumbers = new List<string> { };

            // Check if every word is a phone number and if they are, add them to the phone number list
            foreach (string word in words)
            {
                if (IsPhoneNumber(word))
                {
                    phoneNumbers.Add(word);
                }
            }

            // Display the found phone numbers
            Console.Write($"The phone numbers present in the file are:\n{string.Join("\n", phoneNumbers)}");
        }
    }
}
