using System;
using System.Collections.Generic;

namespace AdventOfCode.Day1
{
    class Problem1
    {
        static void OldMain()
        {
            var increases = GetNumberOfIncreases(PuzzleInput.Data);
            Console.WriteLine($"Number of increases: {increases}");
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