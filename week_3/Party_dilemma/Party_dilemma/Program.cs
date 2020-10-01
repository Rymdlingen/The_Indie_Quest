using System;

namespace Party_dilemma
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

        static void Main(string[] args)
        {
            for (int factorial = 0; factorial < 11; factorial++)
            {
                Console.WriteLine($"{factorial}! = {Factorial(factorial)}");
            }
        }
    }
}
