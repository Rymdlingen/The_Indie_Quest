using System;
using System.Collections.Generic;

namespace W2D4_mission_1_characters
{
    class Program
    {
        static void Main(string[] args)
        {

            var dice = new List<int> { };
            var resultDice6 = new Random();
            int rolls;
            var stats = new List<int> { };
            int totals;

            for (int scores = 0; scores < 6; scores++)
            {

                for (int numberOfRolls = 0; numberOfRolls < 4; numberOfRolls++)
                {
                    rolls = resultDice6.Next(1, 7);

                    dice.Add(rolls);

                }
                string allRolls = String.Join(", ", dice);
                Console.Write($"You roll {allRolls}.");

                dice.Sort();
                dice.Remove(dice[0]);

                totals = 0;

                for (int i = 0; i < 3; i++)
                {
                    totals += dice[i];
                }

                stats.Add(totals);

                Console.WriteLine($" Your ability score is {totals}.");

                dice.Clear();

            }
            stats.Sort();

            string allStats = String.Join(", ", stats);
            Console.WriteLine($"Your available ability scores are {allStats}.");

        }
    }
}
