using System;

namespace W3D1_M3_ordinal_numbers
{
    class Program
    {
        static string OrdinalNumber(int number)
        {

            //Get the last digit of an integer by modding it with 10.
            //If the number is bigger than 10, also get the second to last digit by dividing the integer by 10 and then modding the result with 10.
            //If the second to last digit is 1, return the integer plus "th"
            //If the last digit is 1, return the integer plus "st".
            //If the last digit is 2, return the integer plus "nd".
            //If the last digit is 3, return the integer plus "rd".
            //Otherwise return integer plus "th".

            int lastDigit = number % 10;
            int secondDigit = 0;

            if (number > 10)
            {
                secondDigit = (number / 10) % 10;
            }

            if (secondDigit == 1)
            {
                return number + "th";
            }
            else if (lastDigit == 1)
            {
                return number + "st";
            }
            else if (lastDigit == 2)
            {
                return number + "nd";
            }
            else if (lastDigit == 3)
            {
                return number + "rd";
            }
            else
            {
                return number + "th";
            }

        }

        static void Main(string[] args)
        {
            Console.WriteLine(OrdinalNumber(1));
            Console.WriteLine(OrdinalNumber(2));
            Console.WriteLine(OrdinalNumber(3));
            Console.WriteLine(OrdinalNumber(4));
            Console.WriteLine(OrdinalNumber(10));
            Console.WriteLine(OrdinalNumber(11));
            Console.WriteLine(OrdinalNumber(12));
            Console.WriteLine(OrdinalNumber(13));
            Console.WriteLine(OrdinalNumber(21));
            Console.WriteLine(OrdinalNumber(101));
            Console.WriteLine(OrdinalNumber(111));
            Console.WriteLine(OrdinalNumber(121));
        }
    }
}
