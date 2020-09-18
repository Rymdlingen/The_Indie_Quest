using System;

namespace branches_tutorial
{
    class Program
    {
        static void ExploreIf()
        {
            int a = 3;
            int b = 3;
            if (a + b > 10)
            {
                Console.WriteLine("The answer is greater than 10.");
            }
            else
            {
                Console.WriteLine("The answer is not greater than 10.");
            }

            int c = 2;
            if ((a + b + c > 10) && (a == b))
            {
                Console.WriteLine("True, The answer is greater than 10");
                Console.WriteLine("And the first number is equal to the second");
            }
            else
            {
                Console.WriteLine("False, The answer is not greater than 10");
                Console.WriteLine("Or the first number is not equal to the second");
            }

            if ((a + b + c > 10) || (a == b))
            {
                Console.WriteLine("True, The answer is greater than 10");
                Console.WriteLine("Or the first number is equal to the second");
            }
            else
            {
                Console.WriteLine("False, The answer is not greater than 10");
                Console.WriteLine("And the first number is not equal to the second");
            }

        }

        static void ExploreWhileFor()

        {
            int counter = 0;
            do
            {
                Console.WriteLine($"Hello World! The counter is {counter}");
                counter++;
            } while (counter < 10);

            for (int index = 8; index < 15; index++)
            {
                Console.WriteLine($"Hello World! The index is {index}");
            }
        }

        static void Challange()
        {
            int b = 0;

            for (int a = 1; a < 21; a++)
            {
                if (a % 3 == 0)
                {
                    b = b + a;
                }

            }

            Console.WriteLine($"The sum is {b}.");
        }


        static void Main(string[] args)
        {
            //ExploreIf();

            //ExploreWhileFor();

            Challange();


        }
    }
}
