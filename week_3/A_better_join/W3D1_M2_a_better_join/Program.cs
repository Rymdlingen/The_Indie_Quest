using System;
using System.Collections.Generic;

namespace W3D1_M1_a_better_join
{
    class Program
    {

        static string JoinWithAnd(List<string> items, bool useSerialComma = true)
        {
            int count = items.Count;
            string stringItems;

            if (count == 0)
            {
                return "";
            }

            if (count == 1)
            {
                return items[0];
            }

            if (count == 2)
            {
                return stringItems = string.Join(" and ", items);
            }

            var itemsCopy = new List<string>(items);

            if (useSerialComma)
            {
                itemsCopy.RemoveAt(itemsCopy.Count - 1);
                itemsCopy.Add("and " + items[items.Count - 1]);
            }
            else
            {
                itemsCopy[itemsCopy.Count - 2] = $"{itemsCopy[itemsCopy.Count - 2]} and {itemsCopy[itemsCopy.Count - 1]}";

                itemsCopy.RemoveAt(itemsCopy.Count - 1);
            }

            return stringItems = string.Join(", ", itemsCopy);

        }

        static void Main(string[] args)
        {
            var items = new List<string> { "Johanna", "Sandra", "Linn", "Sallie" };

            Console.WriteLine($"The heroes in the party are: {JoinWithAnd(items, false)}");
        }
    }
}
