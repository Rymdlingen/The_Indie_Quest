using System;
using System.Collections.Generic;
using System.Threading;

namespace W3D1_M4_the_matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var streams = new List<int> { };
            var random = new Random();

            string symbols = @"!@#$%^&*()_+-=[];',.\/~{}:|<>?";

            for (var i = 0; i < 10; i++)
            {
                streams.Add(random.Next(0, 80));
            }

            Console.ForegroundColor = ConsoleColor.DarkGreen;

            while (true)
            {
                for (var x = 0; x < 80; x++)
                {

                    Console.Write(streams.Contains(x) ? symbols[random.Next(symbols.Length)] : ' ');

                }

                Console.WriteLine();
                Thread.Sleep(100);


                if (random.Next(3) == 0)
                {
                    streams.RemoveAt(random.Next(streams.Count));
                }

                if (random.Next(3) == 0)
                {
                    streams.Add(random.Next(0, 80));
                }

            }
        }
    }
}
