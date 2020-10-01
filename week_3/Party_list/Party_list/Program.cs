using System;
using System.Collections.Generic;

namespace Party_list
{
    class Program
    {
        static int Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }

        static string WriteAllPermutations(List<string> items)
        {
            int countUp = 1;
            var listOfAllPermutations = new List<string> { };
            string latestShuffle;
            var random = new Random();

            for (int differentCombinations = Factorial(items.Count); differentCombinations > 0; differentCombinations--)
            {
                for (int shufflesLeft = items.Count; shufflesLeft > 0; shufflesLeft--)
                {
                    int randomParticipant = random.Next(0, items.Count);
                    items.Add(items[randomParticipant]);
                    items[randomParticipant] = items[items.Count - 2];
                    items.RemoveAt(items.Count - 2);
                }

                latestShuffle = string.Join(", ", items);

                if (listOfAllPermutations.Contains(latestShuffle))
                {
                    differentCombinations++;
                }
                else
                {
                    listOfAllPermutations.Add(latestShuffle);
                }
            }

            var numberedList = new List<string> { };

            foreach (var permutation in listOfAllPermutations)
            {
                numberedList.Add($"{countUp}. {listOfAllPermutations[countUp - 1]}");
                countUp++;
            }

            return string.Join("\n", numberedList);
        }

        static void Main(string[] args)
        {
            var participants = new List<string> { "Johanna", "Anni", "Matej", "Yoshi" };

            Console.WriteLine(WriteAllPermutations(participants));
        }
    }
}
