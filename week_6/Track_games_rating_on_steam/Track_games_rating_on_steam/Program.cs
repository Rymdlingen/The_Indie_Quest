using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Track_games_rating_on_steam
{
    class Program
    {
        static void Main(string[] args)
        {
            // Getting the HTML code from the website
            var httpClient = new HttpClient();
            string htmlCode = httpClient.GetStringAsync(@"https://store.steampowered.com/app/413150/Stardew_Valley/").Result;

            // Pattern for extracting the rating
            string ratingPattern = @"<.*game_review_summary.*description.*>(.*)<\/span>";
            //string ratingPattern = @"<.*description.*>(.*)<.*>";
            // The pattern above also works

            // Putting the extracted rating in a string
            Match match = Regex.Match(htmlCode, ratingPattern);
            GroupCollection groups = match.Groups;
            string rating = groups[1].Value;

            // Output
            Console.WriteLine($"The rating ofthe game Stardew Valley is {rating}.");
        }
    }
}
