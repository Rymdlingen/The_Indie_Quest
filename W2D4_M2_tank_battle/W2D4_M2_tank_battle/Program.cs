using System;

namespace W2D4_M2_tank_battle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("DANGER! Die Franzosen kommen!!!");
            Console.WriteLine();
            Console.Write("Whats your name commander? \n");
            string name = Console.ReadLine();

            Console.Clear();

            Console.Write($"Welcome to the battlefield commander {name}");

            var random = new Random();

            int tankDistance = random.Next(40, 71);

            while (tankDistance > 0)
            {
                Console.WriteLine();

                Console.Write("_/");

                for (var i = 0; i < tankDistance; i++)
                {
                    Console.Write("_");
                }

                Console.Write("T");

                int distanceTo80 = 80 - tankDistance - 3;

                for (var i = 0; i < distanceTo80; i++)
                {
                    Console.Write("_");
                }

                Console.WriteLine();
                Console.WriteLine();


                Console.Write($"How far will you fire {name}? \n");
                string fireDistanceInput = Console.ReadLine();

                int fireDistance = Int32.Parse(fireDistanceInput);

                Console.Write("  ");

                for (int shotGroundDistance = 0; shotGroundDistance < fireDistance - 1; shotGroundDistance++)
                {
                    Console.Write(" ");
                }

                Console.Write("BOOM!");
                Console.WriteLine();
                Console.WriteLine();

                if (fireDistance < tankDistance + 1)
                {
                    Console.WriteLine("NOOO! Too short!");
                }
                else if (fireDistance > tankDistance + 1)
                {
                    Console.WriteLine("Das war ubers Ziel geschossen!");
                }
                else
                {
                    Console.WriteLine("BOOOOM!");
                    break;
                }

                Console.WriteLine();
                Console.WriteLine();
                //Console.Write($"{fireDistance}, {tankDistance + 1}");

                int tankMovingForward = random.Next(1, 16);
                tankDistance -= tankMovingForward;

                Console.WriteLine("Drücken Sie die Eingabetaste, um fortzufahren...");
                Console.ReadLine();

                Console.Clear();

            }

            if (tankDistance <= 0)
            {
                Console.WriteLine("                                    GAME OVER");
            }
        }
    }
}
