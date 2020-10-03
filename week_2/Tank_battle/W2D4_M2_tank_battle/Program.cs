using System;

namespace W2D4_M2_tank_battle
{
    class Program
    {
        static void Main(string[] args)
        {
            //Intro, asking for name
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("DANGER! Die Franzosen kommen!!!\n\nWhats your name commander?");
            Console.ForegroundColor = ConsoleColor.Red;
            string name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            //if any of these names output extra message
            if (name == "Mikael")
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"\nHej Mikael! Kul att du också testar mitt spel :D\n\nTryck enter för att börja skjuta!");
                Console.ReadLine();
                Console.Clear();
            }

            if (name == "Matej" || name == "Retro")
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine($"\nHi Matej! I hope you have some fun with the game!\n\nPress enter to start shooting!");
                Console.ReadLine();
                Console.Clear();
            }

            //Battle starts
            Console.Write($"Welcome to the battlefield commander ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(".\n");

            //random distance from artillery to tank and counting the rounds
            var random = new Random();
            int tankDistance = random.Next(40, 71);
            int rounds = 1;

            //loop for drawing battlefield, shooting and displaying result
            while (tankDistance > 11)
            {
                //text for second shot and forward
                if (rounds != 1)
                {
                    Console.WriteLine("You can do better than that! Try again.\n");
                }

                //drawing battlefield
                Console.Write("    ");
                for (var air = 0; air < tankDistance; air++)
                {
                    Console.Write(" ");
                }
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("-=_^_");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("_");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("&");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("/|");

                for (var groundBeforeTank = 0; groundBeforeTank < tankDistance; groundBeforeTank++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("_");
                }
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("_");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("‰………)");

                int distanceTo80 = 80 - tankDistance - 10;

                for (var groundAfterTank = 0; groundAfterTank < distanceTo80; groundAfterTank++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("_");
                }

                //asking for a number (aiming)
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"\n\nHow far will you fire ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(name);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("?");
                string fireDistanceInput = Console.ReadLine();

                //if ypu just press enter
                while (fireDistanceInput == "")
                {
                    Console.WriteLine("You have to write a number, try again!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"How far will you fire ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(name);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("?");
                    fireDistanceInput = Console.ReadLine();
                }

                //drawing shot
                int fireDistance = Int32.Parse(fireDistanceInput);
                if (fireDistance < 77)
                {
                    Console.Write("    ");

                    for (int shotGroundDistance = 0; shotGroundDistance < fireDistance - 1; shotGroundDistance++)
                    {
                        Console.Write(" ");
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("*\n");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nYour shot hit outside of the battlefield, aim better next time!");
                }

                //result of shot
                Console.ForegroundColor = ConsoleColor.White;
                if (fireDistance == 0)
                {
                    Console.WriteLine("HEY!! Watch out! You almost shot yourself.");
                }
                else if (fireDistance < tankDistance + 1)
                {
                    Console.WriteLine("NOOO! Too short!");
                }
                else if (fireDistance > tankDistance + 1 && fireDistance < 77)
                {
                    Console.WriteLine("Das war ubers Ziel geschossen!");
                }
                else if (fireDistance == tankDistance + 1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    if (rounds == 1)
                    {
                        Console.WriteLine($"BOOOOM! You won the war!\nAnd it only took you {rounds} shot to hit the tank. Impressive!\n\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }
                    Console.WriteLine($"BOOOOM! You won the war! It took you {rounds} shots to hit the tank.\n\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }

                //calculating tanks movement, press enter to continue
                int tankMovingForward = random.Next(1, 13);
                tankDistance -= tankMovingForward;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\nDrücken Sie die Eingabetaste, um fortzufahren... (Press enter to continue...)");
                Console.ReadLine();
                rounds++;
                Console.Clear();
            }

            //if tanks get to close, GAME OVER
            if (tankDistance < 12)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n                                    GAME OVER");

                //drawing battlefield
                Console.Write("    ");

                for (var tankShots = 0; tankShots < tankDistance; tankShots += 2)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("* ");
                }
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("-=_^_");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("_");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("&");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("/|");

                for (var groundBeforeTank = 0; groundBeforeTank < tankDistance; groundBeforeTank++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("_");
                }
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("_");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("‰………)");

                int distanceTo80again = 80 - tankDistance - 10;

                for (var groundAfterTank = 0; groundAfterTank < distanceTo80again; groundAfterTank++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("_");
                }

                //Outro if game over
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"\n\nYou took {rounds - 1} shots, but you missed all of them.");
                Console.WriteLine("The tank came so close it could shoot you. You lost the war and you died.\n\n");
            }
        }
    }
}