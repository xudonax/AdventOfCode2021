using System;
using System.Collections.Generic;

namespace AdventOfCode.Day1
{
    class Problem2
    {
        static void OldMain()
        {
            var sums = GetSums(PuzzleInput.Data);
            var increases = GetNumberOfIncreases(sums);
            Console.WriteLine($"Number of increases: {increases}");
        }

        static IList<int> GetSums(IList<int> items)
        {
            var sums = new List<int>();

            for (int i = 0; i <= items.Count - 3; i++)
            {
                sums.Add(items[i] + items[i + 1] + items[i + 2]);
            }

            return sums;
        }

        static int GetNumberOfIncreases(IEnumerable<int> items)
        {
            var increases = 0;
            var last = int.MinValue;

            foreach (var item in items)
            {
                if (last == int.MinValue) last = item;
                if (item > last) increases++;
                last = item;
            }

            return increases;
        }
    }
}