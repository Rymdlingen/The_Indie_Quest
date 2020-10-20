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
            // A bunch of games I like and random games with different rankings
            string[] htmlCode = new string[] { httpClient.GetStringAsync(@"https://store.steampowered.com/app/413150/Stardew_Valley/").Result,
                                               httpClient.GetStringAsync(@"https://store.steampowered.com/app/232790/Broken_Age/").Result,
                                               httpClient.GetStringAsync(@"https://store.steampowered.com/app/224760/FEZ/").Result,
                                               httpClient.GetStringAsync(@"https://store.steampowered.com/app/609490/Minit/").Result,
                                               httpClient.GetStringAsync(@"https://store.steampowered.com/app/233470/Evoland/").Result,
                                               httpClient.GetStringAsync(@"https://store.steampowered.com/app/339240/10_Years_After/").Result,
                                               httpClient.GetStringAsync(@"https://store.steampowered.com/app/223598/The_Sims_3_Island_Paradise/").Result,
                                               httpClient.GetStringAsync(@"https://store.steampowered.com/app/606860/Nephise/?curator_clanid=11846936").Result,
                                               httpClient.GetStringAsync(@"https://store.steampowered.com/app/47400/Stronghold_3_Gold/").Result,
                                               httpClient.GetStringAsync(@"https://store.steampowered.com/app/1235722/The_Sims_4_Discover_University/").Result,
                                               httpClient.GetStringAsync(@"https://store.steampowered.com/app/513710/SCUM/").Result,
            };

            // Pattern for extracting the name of the game
            string namePattern = @"<b>Title:</b> (.*)<br>";
            // Pattern for extracting all the ratings (0-2)
            string ratingPattern = @"<.*game_review_summary.*data.*>([\D].*)<\/span>";
            //old pattern <.*game_review_summary.*>(.*)<\/span>

            // Putting the extracted names and ratings in an array
            string[][] namesAndRatings = new string[htmlCode.Length][];
            for (int length = 0; length < namesAndRatings.Length; length++)
            {
                namesAndRatings[length] = new string[3];
            }

            // Checking one link at the time
            for (int code = 0; code < htmlCode.Length; code++)
            {
                Match name = Regex.Match(htmlCode[code], namePattern);
                MatchCollection ratings = Regex.Matches(htmlCode[code], ratingPattern);
                GroupCollection groups;

                // Adding the name to the first spot in the array
                groups = name.Groups;
                namesAndRatings[code][0] = groups[1].Value;

                // Adding the second group (only the text) of every match to the array
                for (int rating = 0; rating < ratings.Count; rating++)
                {
                    groups = ratings[rating].Groups;
                    namesAndRatings[code][rating + 1] = groups[1].Value;
                }
            }

            // Output
            for (int game = 0; game < namesAndRatings.Length; game++)
            {
                Console.WriteLine(namesAndRatings[game][0].ToUpper());
                if (namesAndRatings[game][2] != null)
                {
                    Console.WriteLine($"Recent reviews: {namesAndRatings[game][2]}");
                    Console.WriteLine($"All reviews: {namesAndRatings[game][1]}");
                }
                else if (namesAndRatings[game][1] != null)
                {
                    Console.WriteLine($"All reviews: {namesAndRatings[game][1]}");
                }
                else
                {
                    Console.WriteLine("This game has no rating.");
                }
                Console.WriteLine();
            }
        }
    }
}
