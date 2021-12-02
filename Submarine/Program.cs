﻿using System;
using System.IO;

namespace Submarine
{
    internal static class Program
    {
        private static void Main()
        {
            var lines = File.ReadAllLines(@"input.txt");
            Console.WriteLine(TheNumberOfTimesDepthMeasurementIncreases(lines));
            
        }

        private static int TheNumberOfTimesDepthMeasurementIncreases(string[]  file)
        {
            var initialNumber = int.Parse(file[0]);
            var count = 0;
            for (var line = 1; line <= file.Length - 1; line++)
            {
               
              var nextNUmber = int.Parse(file[line]);
              if (initialNumber > nextNUmber)
              {
                  initialNumber = nextNUmber;
              }
              else
              {
                  initialNumber = nextNUmber;
                  Console.WriteLine($"{nextNUmber} Increased");
                  count++; 
              }
            }

            return count;
        }
        
      
    }
}