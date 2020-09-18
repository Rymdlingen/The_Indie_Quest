using System;

namespace mission_3_generate_characters_and_monsters
{
    class Program
    {
        static void Main(string[] args)
        {
            // use for loop

            var random = new Random();
            int strength = 0;
            int dice6 = 0;

            for (int dice3Rolls = 0; dice3Rolls < 3; dice3Rolls++)
            {
                dice6 = random.Next(1, 7);
                strength = strength + dice6;
            }

            Console.WriteLine($"A character with strength {strength} was created.");

            int dice10 = 0;
            int cubeHP = 40;


            for (int dice8Rolls = 0; dice8Rolls < 8; dice8Rolls++)
            {
                dice10 = random.Next(1, 11);
                cubeHP = cubeHP + dice10;
            }

            Console.WriteLine($"A Gelatinous cube with {cubeHP} HP appears!");

            int totalHP = cubeHP;
            int cubeHP2 = 40;


            for (int monster = 0; monster < 100; monster++)
            {

                for (int dice8Rolls = 0; dice8Rolls < 8; dice8Rolls++)
                {
                    dice10 = random.Next(1, 11);
                    cubeHP2 = cubeHP2 + dice10;
                }

                totalHP = totalHP + cubeHP2;
                cubeHP2 = 40;

            }

            Console.WriteLine($"Dear gods, an army of 100 cubes descends upon us with a total of {totalHP} HP. We are doomed!");

        }
    }
}
