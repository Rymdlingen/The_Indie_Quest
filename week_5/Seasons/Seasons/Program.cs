using System;

namespace Seasons
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

        static string CreateDayDescription(int day, int season, int year)
        {
            string[] seasons = { "Spring", "Summer", "Fall", "Winter" };
            return $"{OrdinalNumber(day)} day of {seasons[season]} in the year {year}";
        }

        static void Main(string[] args)
        {
            Console.WriteLine(CreateDayDescription(7, 1, 134));
            Console.WriteLine(CreateDayDescription(41, 3, 22));
            Console.WriteLine(CreateDayDescription(3, 2, 1601));
            Console.WriteLine(CreateDayDescription(22, 0, 1992));
        }
    }
}
