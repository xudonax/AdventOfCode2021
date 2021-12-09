using System;
using System.Collections.Generic;

namespace AdventOfCode.Day3
{
    class Problem1
    {
        static void Main()
        {
            var status = ParseStatus(PuzzleInput.Data);

            Console.WriteLine($"Final position: {status.Gamma}, {status.Epsilon}. Power usage: {status.Gamma * status.Epsilon}.");
        }

        static (ulong Gamma, ulong Epsilon) ParseStatus(IList<string> diagnosticData)
        {
            var dataLength = diagnosticData[0].Length;
            var countInPosition = new int[2, dataLength];
            var gammaChars = new char[dataLength];
            var epsilonChars = new char[dataLength];

            foreach (var data in diagnosticData)
            {
                for (int i = 0; i < dataLength; i++)
                {
                    if (data[i] == '0') countInPosition[0, i] += 1;
                    if (data[i] == '1') countInPosition[1, i] += 1;
                    
                }
            }

            for (int i = 0; i < dataLength; i++)
            {
                if (countInPosition[0, i] > countInPosition[1, i])
                {
                    gammaChars[i] = '0';
                    epsilonChars[i] = '1';
                }
                else if (countInPosition[0, i] < countInPosition[1, i])
                {
                    gammaChars[i] = '1';
                    epsilonChars[i] = '0';
                }
            }

            var gammaString = new String(gammaChars);
            var epsilonString = new String(epsilonChars);

            var gamma = Convert.ToUInt64(gammaString.PadLeft(64 - dataLength, '0'), 2);
            var epsilon = Convert.ToUInt64(epsilonString.PadLeft(64 - dataLength, '0'), 2);

            return (gamma, epsilon);
        }
    }
}