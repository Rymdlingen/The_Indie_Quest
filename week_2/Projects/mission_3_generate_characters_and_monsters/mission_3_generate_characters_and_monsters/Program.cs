using System;

namespace mission_3_generate_characters_and_monsters
{
    class Program
    {
        static void Main(string[] args)
        {
            // use loop

            var random = new Random();

            for (var diceRolls = 0; rolls = 3; rolls++)
            {
                var strenght = 0;
                var roll = random.Next(1, 7);

                strenght = strenght + roll;
            }

            Console.WriteLine(strenght);

        }
    }
}
