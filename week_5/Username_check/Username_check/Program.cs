using System;
using System.Collections.Generic;

namespace Username_check
{
    class Program
    {
        static bool IsValidUsername(string username)
        {
            // 48 - 57 numbers 0 - 9
            // 97 - 122 lowercase alphabet
            // Creating a list of all approved symbols ASCIIcodes (numbers and lowercase English alphabet)
            var symbolsCode = new List<int> { };
            // Adding numbers
            for (int code = 48; code < 58; code++)
            {
                symbolsCode.Add(code);
            }
            // Adding letters
            for (int code = 97; code < 123; code++)
            {
                symbolsCode.Add(code);
            }

            bool approvedSymbol = true;

            // If no symbols were in the username then it is not valid
            if (username == "")
            {
                approvedSymbol = false;
            }

            // Checking if all symbols in the username is in the approved symbols list
            for (int allSymbols = 0; allSymbols < username.Length; allSymbols++)
            {
                char checkThisChar = (char)username[allSymbols];

                // if the symbols in the username is not in the symbols list then return false
                if (symbolsCode.Contains(checkThisChar))
                {

                }
                else
                {
                    approvedSymbol = false;
                    break;
                }
            }

            return approvedSymbol;
        }

        static void Main(string[] args)
        {
            // Instructions
            Console.WriteLine("Input a username that only contains \nlowercase letters from a - z and/or numbers 0 - 9.\n");
            int cursorPosition = 3;

            // Check all the names!
            while (true)
            {
                string username = Console.ReadLine();
                Console.CursorTop = cursorPosition;
                Console.WriteLine($"{username} = {IsValidUsername(username)}");
                cursorPosition++;
            }
        }
    }
}
