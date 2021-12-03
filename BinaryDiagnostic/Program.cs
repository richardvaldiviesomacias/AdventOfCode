using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BinaryDiagnostic
{
    internal static class Program
    {
        private const int LengthOfBinaryElement = 5;

        private static void Main()
        {
            var lines = File.ReadAllLines(@"input.txt");
            Console.WriteLine(Diagnostic(lines));
            Console.WriteLine(DiagnosticOxygen(lines.ToList()));
            Console.WriteLine(DiagnosticCO2(lines.ToList()));
            Console.WriteLine(DiagnosticOxygen(lines.ToList()) * DiagnosticCO2(lines.ToList()));
        }

        private static int DiagnosticOxygen(List<string> lines)
        {
            for (int j = 0; j < lines[0].Length; j++)
            {
                var listOfZeros = new List<string>();
                var listOfOnes = new List<string>();
                lines = (List<string>)GettingLines(lines, j, listOfZeros, listOfOnes, true);
                if (lines.Count == 1) break;
            }

            return Convert(lines[0]);
        }

        private static int DiagnosticCO2(List<string> lines)
        {
            for (int j = 0; j < lines[0].Length; j++)
            {
                var listOfZeros = new List<string>();
                var listOfOnes = new List<string>();
                lines = (List<string>)GettingLines(lines, j, listOfZeros, listOfOnes, false);
                if (lines.Count == 1) break;
            }

            return Convert(lines[0]);
        }

        private static ICollection<string> GettingLines(IEnumerable<string> lines, int j,
            ICollection<string> listOfZeros,
            ICollection<string> listOfOnes, bool higher)
        {
            foreach (var t in lines)
            {
                var parseNumber = int.Parse(t.Substring(j, 1));
                if (parseNumber == 0)
                {
                    listOfZeros.Add(t);
                }
                else
                {
                    listOfOnes.Add(t);
                }
            }

            if (higher)
            {
                if (listOfOnes.Count > listOfZeros.Count || listOfOnes.Count == listOfZeros.Count)
                {
                    return listOfOnes;
                }

                return listOfZeros;
            }

            if (listOfOnes.Count > listOfZeros.Count || listOfOnes.Count == listOfZeros.Count)
            {
                return listOfZeros;
            }

            return listOfOnes;
        }

        private static int Diagnostic(IReadOnlyList<string> lines)
        {
            string numberGamma = "";
            string numberEpsilon = "";
            var countOnes = 0;
            var countZeros = 0;
            for (var j = 0; j < LengthOfBinaryElement; j++)
            {
                foreach (var t in lines)
                {
                    var parseNumber = int.Parse(t.Substring(j, 1));
                    if (parseNumber == 0)
                    {
                        countZeros++;
                    }
                    else
                    {
                        countOnes++;
                    }
                }

                if (countOnes > countZeros)
                {
                    numberGamma += "1";
                    numberEpsilon += "0";
                }
                else
                {
                    numberGamma += "0";
                    numberEpsilon += "1";
                }

                countOnes = 0;
                countZeros = 0;
            }

            return Convert(numberGamma) * Convert(numberEpsilon);
        }

        private static int Convert(string str1)
        {
            if (str1 == "")
                throw new Exception("Invalid input");
            var res = 0;
            for (var i = 0; i < str1.Length; i++)
            {
                try
                {
                    var val = int.Parse(str1[i].ToString());
                    switch (val)
                    {
                        case 1:
                            res += (int)Math.Pow(2, str1.Length - 1 - i);
                            break;
                        case > 1:
                            throw new Exception("Invalid!");
                    }
                }
                catch
                {
                    throw new Exception("Invalid!");
                }
            }

            return res;
        }
    }
}