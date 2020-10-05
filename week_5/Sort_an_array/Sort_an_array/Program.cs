using System;
using System.Threading;

namespace Sort_an_array
{
    class Program
    {
        static void DisplayData(int[] data)
        {
            Console.Clear();

            for (int y = 20; y >= 0; y--)
            {
                if (y % 5 == 0)
                {
                    Console.Write($"{y,3} |");
                }
                else
                {
                    Console.Write("    |");
                }

                for (int x = 0; x < data.Length; x++)
                {
                    if (y == 0)
                    {
                        Console.Write("-");
                        continue;
                    }

                    Console.Write(y <= data[x] ? "\u2592" : " ");
                }

                Console.WriteLine();
            }

            Thread.Sleep(10);
        }

        static void InsertionSort()
        {
            var random = new Random();
            int[] data = new int[70];
            for (int i = 0; i < 70; i++)
            {
                data[i] = random.Next(20);
            }

            // Insertion sort

            // Split the list between sorted numbers on the left and unsorted on the right.
            // At the start, only the first number is sorted, the rest are unsorted.
            // Then take the first unsorted number and move it to the left until it is in the correct place in the sorted list.
            // Repeat this with all unsorted numbers until all the numbers are in the sorted list.
            int sortedCount = 1;

            do
            {
                // If the list is empty skip the sorting
                if (data.Length == 0)
                {
                    break;
                }

                // Find the first unsorted number.
                int indexOfFirstUnsortedNumber = sortedCount;
                int firstUnsortedNumber = data[indexOfFirstUnsortedNumber];

                // Test the sorted number to the left of it and see if it is bigger.
                int testIndex = indexOfFirstUnsortedNumber - 1;

                while (data[testIndex] > firstUnsortedNumber)
                {
                    // The sorted number is bigger!
                    // Move the sorted number to the right since it is bigger than the unsorted number.
                    // (Bigger numbers must be on the right of the smaller ones.)
                    data[testIndex + 1] = data[testIndex];

                    // Continue testing the next number on the left.
                    testIndex--;

                    // This will stop comparing numbers at the first place of the list.
                    if (testIndex < 0)
                    {
                        break;
                    }

                    // Display data for diagnostic purposes.
                    DisplayData(data);
                }

                // The unsorted number should now be placed into the spot where the last tested number was shifted away from.
                int insertionIndex = testIndex + 1;
                data[insertionIndex] = firstUnsortedNumber;

                // We've successfully sorted a new number.
                sortedCount++;

                // Display data for diagnostic purposes.
                DisplayData(data);

            } while (sortedCount < data.Length);

            Console.WriteLine($"The sorted numbers are: {string.Join(", ", data)}");
        }

        static void BubbleSort()
        {
            int[] data = new int[70];
            var random = new Random();

            for (int i = 0; i < 70; i++)
            {
                data[i] = (random.Next(20));
                DisplayData(data);
            }

            // Bubble sort

            // Go through the list number by number and compare it to its next neighbor.
            // If the next neighbor is smaller than the previous one, swap them!
            // Continue until we reach the end.
            // Each time we go through the list, the highest neighbor will 'bubble' to the end.
            // This means we have to sort a smaller and smaller part of the list as we go on.
            // We'll decrease our sorting range one by one until the whole list is sorted.
            for (int sortingRange = data.Length - 1; sortingRange > 0; sortingRange--)
            {
                // Now we go from the start of the list to the end of the sorting range.
                for (int i = 0; i < sortingRange; i++)
                {
                    // Look at the next neighbor and see if it's smaller.
                    if (data[i + 1] < data[i])
                    {
                        // It is smaller! We need to switch them.
                        (data[i], data[i + 1]) = (data[i + 1], data[i]);

                        /*int a=0, b=1;
                        (a, b) = (b, a);
                        var info = (1984, "Matej");
                        int year;
                        string name;
                        (year, name) = info;*/
                    }

                    // Display data for diagnostic purposes.
                    DisplayData(data);
                }
            }
        }

        static void MergeSort()
        {
            int[] data = new int[70];
            var random = new Random();

            for (int i = 0; i < 70; i++)
            {
                data[i] = (random.Next(20));
                DisplayData(data);
            }


            // Merge sort

            // Divide a list into two halves. First, sort each half separately.
            // Merge the sorted halves together by choosing the smallest number from one of the two lists.
            // Continue choosing until you've used all numbers from both lists.
            // We start the sort by simply trying to sort the full list.
            SortSublist(data, 0, data.Length - 1);

            // Display data for diagnostic purposes.
            DisplayData(data);
        }

        static void SortSublist(int[] data, int startIndex, int endIndex)
        {
            // If our list has one element or less, the sublist is already sorted.
            if (startIndex >= endIndex)
                return;

            // Split the list in half.
            int middleIndex = (startIndex + endIndex) / 2;

            // Sort left half.
            SortSublist(data, startIndex, middleIndex);

            // Sort right half.
            SortSublist(data, middleIndex + 1, endIndex);

            // Merge both lists together into a temporary list.
            int leftSublistIndex = startIndex;
            int rightSublistIndex = middleIndex + 1;
            int[] mergedList = new int[endIndex * 2];
            int index = 0;

            while (leftSublistIndex <= middleIndex || rightSublistIndex <= endIndex)
            {
                // See if the number from the left side is smaller, or if there are no numbers left on the right.
                if (rightSublistIndex > endIndex || leftSublistIndex <= middleIndex && data[leftSublistIndex] < data[rightSublistIndex])
                {
                    // Add the left number to the merged list.
                    mergedList[index] = data[leftSublistIndex];
                    leftSublistIndex++;
                    index++;
                }
                else
                {
                    // Add the right number to the merged list.
                    mergedList[index] = data[rightSublistIndex];
                    rightSublistIndex++;
                    index++;
                }

                // Display data for diagnostic purposes.
                DisplayData(data);
            }

            // Place numbers from the temporary list back into the main list.
            for (int i = 0; i < mergedList.Length; i++)
            {
                data[startIndex + i] = mergedList[i];

                // Display data for diagnostic purposes.
                DisplayData(data);
            }
        }

        static void Main(string[] args)
        {
            //InsertionSort();
            //BubbleSort();

            // Can't get the merge sort to work :(
            //MergeSort();
        }


    }
}
