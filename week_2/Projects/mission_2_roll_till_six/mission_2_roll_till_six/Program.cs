using System;

namespace mission_2_roll_till_six
{
    class Program
    {
        static void Main(string[] args)
        {
            // use do...while

            var random = new Random();
            int roll = 0;
            int sum = 0;

            do
            {
                roll = random.Next(1, 7);
                Console.WriteLine($"The player rolls: {roll}");
                sum = sum + roll;

            } while (roll < 6);

            Console.WriteLine($"Total score: {sum}");

        }
    }
}
