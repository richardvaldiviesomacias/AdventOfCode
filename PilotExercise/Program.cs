using System;
using System.IO;

namespace PilotExercise
{
    internal static class Program
    {
        private static void Main()
        {
            var lines = File.ReadAllLines(@"input2.txt");
            Console.WriteLine(Position(lines));
        }

        private static int Position(string[] lines)
        {
            var forward = 0;
            var depth = 0;
            var aim = 0;
            foreach (var line in lines)
            {
                var linePieces = line.Trim().Split(" ");
                var value = int.Parse(linePieces[1]);
                if (linePieces[0].ToLower() == "forward")
                {
                    forward += value;
                    depth += aim * value;
                }
                else
                {
                    aim = linePieces[0].ToLower() switch
                    {
                        "up" =>
                            aim - value,
                        "down" =>
                            aim + value,
                        _ => aim
                    };
                }
            }

            return forward * depth;
        }
    }
}