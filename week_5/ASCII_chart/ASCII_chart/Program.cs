using System;
using System.Collections.Generic;

namespace ASCII_chart
{
    class Program
    {
        static void Main(string[] args)
        {
            var asciiChart = new List<char> { };

            for (int i = 0; i <= 255; i++)
            {
                asciiChart.Add((char)i);
            }

            foreach (char symbol in asciiChart)
            {
                Console.Write($"{asciiChart.IndexOf(symbol)}: {symbol}.\n");
            }

            // 0 - 31 do not output a character, they are control characters, like starting over at the start of the line, tab, ending lines and a lot of things.
            // 32 is space
            // 33 - 47 are symbols or punctation
            // 48 - 57 are numbers
            // 58 - 64 are symbols or punctation
            // 65 - 90 are uppercase letters
            // 91 - 96 are symbols ot punctation
            // 97 - 122 are lower case letters
            // 123 - 126 are symbols
            // 127 is delete

            // 128 - 159 I dont know what these numbers are
            // 160 looks like space
            // 161 - 255 looks like more symbols and variations of letters

            // I googled it!
            // 128 - 255 is the extended ASCII codes but it doesn't seem to be the same all the time, the charts from google does not look like my list.
        }
    }
}
