using System;
using System.Collections.Generic;
using System.IO;

namespace WindowSlide
{
    internal static class Program
    {
        private static void Main()
        {
            var lines = File.ReadAllLines(@"input.txt");
            var result = CalculateIncrease(lines);
            Console.WriteLine(result);
        }

        private static int CalculateIncrease(IReadOnlyList<string> lines)
        {
            
            var topIndex = 0;
            var lowIndex =  2;
            var count = 0;
            int[] partialArray = { int.Parse(lines[topIndex]), int.Parse(lines[1]), int.Parse(lines[lowIndex])};
            var previousMeasure = SumElementsFrom(partialArray);
            while (lowIndex < lines.Count - 1)
            {
                topIndex = topIndex + 1;
                lowIndex = topIndex + 2; 
                partialArray = new [] { int.Parse(lines[topIndex]), int.Parse(lines[topIndex + 1]), int.Parse(lines[lowIndex])};
                var measure = SumElementsFrom(partialArray);
                if (previousMeasure >= measure)
                {
                    previousMeasure = measure;
                }
                else
                {
                    previousMeasure = measure;
                    Console.WriteLine($"{measure} Increased");
                    count++; 
                }
            }
           
            
            return count;
        }

        private static int SumElementsFrom(int[] partialArray)
        {
            var accumulate = 0;
            for (var i = 0; i <= 2; i++)
            {
                accumulate = accumulate + partialArray[i];
            }

            return accumulate;
        }
    }
}