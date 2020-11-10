using System;

namespace Arrays_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            // Part 1
            // Assignment 1

            // Creating an array with the days of a week.
            string[] daysOfTheWeek = new string[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };

            // Displaying the days of a week.
            Console.WriteLine($"The days of the week are: {String.Join(", ", daysOfTheWeek)}");
            Console.WriteLine();



            // Assignment 2

            // Creating an array with the length of how many days there is in november.
            string[] daysOfNovember = new string[30];

            // The number of the first day of november.
            int currentDayIndex = 6;

            // Adding all the days and dates to the array.
            for (int day = 0; day < 30; day++)
            {
                daysOfNovember[day] = $"{day + 1}: {daysOfTheWeek[currentDayIndex]}";
                currentDayIndex++;

                if (currentDayIndex > 6)
                {
                    currentDayIndex = 0;
                }
            }

            // Displaying days and dates of november.
            Console.WriteLine($"Days this month are: {String.Join(", ", daysOfNovember)}");
            Console.WriteLine();



            // Assignment 3

            // Creating an array of doubles with random length.
            var random = new Random();
            double[] arrayOfDoubles = new double[random.Next(5, 11)];

            // Adding random numbers to the array.
            for (int numbers = 0; numbers < arrayOfDoubles.Length; numbers++)
            {
                arrayOfDoubles[numbers] = random.Next(1, 11);
            }

            // Displaying array.
            Console.WriteLine($"{arrayOfDoubles.Length} random numbers are: {String.Join(", ", arrayOfDoubles)}");
            Console.WriteLine();



            // Assignment 4

            // Creating two arrays, one with a random length, for random numbers, and one with double that length minus one for interpolated numbers.
            int randomArrayLength = random.Next(5, 6);
            double[] randomNumbers = new double[randomArrayLength];
            double[] interpolatedNumbers = new double[randomArrayLength * 2 - 1];

            // Adding random numbers to the array.
            for (int numbers = 0; numbers < randomNumbers.Length; numbers++)
            {
                randomNumbers[numbers] = random.Next(1, 11);
            }

            // Calculating interpolated numbers and adding them to another array.
            for (int numbers = 0; numbers < randomNumbers.Length; numbers++)
            {
                interpolatedNumbers[numbers * 2] = randomNumbers[numbers];
                if (numbers < randomNumbers.Length - 1)
                {
                    interpolatedNumbers[numbers * 2 + 1] = (randomNumbers[numbers] + randomNumbers[numbers + 1]) / 2;
                }
            }

            // Displaying both arrays.
            Console.WriteLine($"{randomNumbers.Length} random numbers are: {String.Join(", ", randomNumbers)}");
            Console.WriteLine($"Interpolated numbers are: {String.Join(", ", interpolatedNumbers)}");
            Console.WriteLine();



            // Part 2
            // Assignment 1

            // Creating a 2 dimensional array with random size.
            int[,] twoDimensionalArray = new int[random.Next(2, 6), random.Next(2, 5)];
            // Getting the size of the two dimensions.
            int dimension1Length = twoDimensionalArray.GetLength(0);
            int dimension2Length = twoDimensionalArray.GetLength(1);

            // Adding and displaying a random number for each of the spots in the array.
            for (int dimension1 = 0; dimension1 < dimension1Length; dimension1++)
            {
                for (int dimension2 = 0; dimension2 < dimension2Length; dimension2++)
                {
                    twoDimensionalArray[dimension1, dimension2] = random.Next(0, 10);
                    Console.Write(twoDimensionalArray[dimension1, dimension2]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();



            // Assignment 2

            // Creating an new 2D array using the dimensions from earlier but in oposit positions.
            int[,] twoDimensionalArrayTransposed = new int[dimension2Length, dimension1Length];

            // Adding the old numbers to new spots in the new array.
            for (int dimension1 = 0; dimension1 < dimension2Length; dimension1++)
            {
                for (int dimension2 = 0; dimension2 < dimension1Length; dimension2++)
                {
                    twoDimensionalArrayTransposed[dimension1, dimension2] = twoDimensionalArray[dimension2, dimension1];
                    Console.Write(twoDimensionalArrayTransposed[dimension1, dimension2]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();



            // Assignment 3

            // Creating an 2D array of size 10 by 10.
            int[,] multiplication = new int[10, 10];

            for (int dimension1 = 0; dimension1 < 10; dimension1++)
            {
                // First number of the multiplication.
                int firstNumber = dimension1 + 1;

                for (int dimension2 = 0; dimension2 < 10; dimension2++)
                {
                    // Second number of the multipliction.
                    int secondNumber = dimension2 + 1;

                    // Add sum of multiplication to array, and display the number.
                    multiplication[dimension1, dimension2] = firstNumber * secondNumber;
                    Console.Write(multiplication[dimension1, dimension2].ToString().PadRight(3, ' '));
                }
                Console.WriteLine();
            }
            Console.WriteLine();



            // Assignment 4

            // Creating an 2D array with the size of a chessboard.
            int[,] chessboard = new int[8, 8];

            // Choose a random spot for the knight
            int knightDimension1 = random.Next(0, chessboard.GetLength(0));
            int knightDimension2 = random.Next(0, chessboard.GetLength(1));

            // Set knights position
            chessboard[knightDimension1, knightDimension2] = 0;

            /*for (int dimension1 = 0; dimension1 < 10; dimension1++)
            {

                for (int dimension2 = 0; dimension2 < 10; dimension2++)
                {
                    if (chessboard[dimension1, dimension2] == chessboard[knightDimension1, knightDimension2])
                    {

                    }
                }
            }*/
        }

        /*static int CalculateKnightMovement(int[,] chessboard, int dimension1, int dimension2, int turns = 0)
        {
            if (chessboard[dimension1, dimension2] != 0)
            {
                dimension1 += 2;
                dimension2 += 1;
                CalculateKnightMovement(chessboard, dimension1, dimension2);
            }
            return turns;
        }*/
    }
}
