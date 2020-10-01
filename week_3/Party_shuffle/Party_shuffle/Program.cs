using System;
using System.Collections.Generic;

namespace Party_shuffle
{
    class Program
    {
        static string ShuffleList(List<string> items)
        {
            var random = new Random();

            for (int shufflesLeft = items.Count; shufflesLeft > 0; shufflesLeft--)
            {
                int randomParticipant = random.Next(0, shufflesLeft + 1);
                items.Add(items[randomParticipant]);
                items[randomParticipant] = items[items.Count - 2];
                items.RemoveAt(items.Count - 2);
            }

            return string.Join(", ", items);
        }

        static void Main(string[] args)
        {
            var participants = new List<string> { "Johanna", "Anni", "Matej", "Gabriel", "Hilda", "Chris" };

            Console.WriteLine($"Signed-up participants: {string.Join(", ", participants)}\n");
            Console.WriteLine("Generating starting order...\n");
            Console.WriteLine($"Starting order: {ShuffleList(participants)}");
        }
    }
}
