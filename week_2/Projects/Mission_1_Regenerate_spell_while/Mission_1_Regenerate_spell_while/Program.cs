using System;

namespace Mission_1_Regenerate_spell_while
{
    class Program
    {
        static void Main(string[] args)
        {
            // use while

            var random = new Random();

            int HP = random.Next(1, 101);

            Console.WriteLine($"Warrior HP: {HP}");
            Console.WriteLine("Regenerate spell is cast!");

            while (HP < 50)
            {
                HP = HP + 10;
                Console.WriteLine($"Warrior HP: {HP}");

            }

            Console.WriteLine("Regenerate spell is complete.");

        }
    }
}
