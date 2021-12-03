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
            //Console.WriteLine(Diagnostic(lines));
            Console.WriteLine( DiagnosticOxygen(lines.ToList()));
        }

        private static List<string> Something(List<string> lines, List<string> listOfOnes, List<string> listOfZeros)
        {
            if ((lines.Count > listOfZeros.Count) || (listOfOnes.Count == listOfZeros.Count))
            {
                GettingLines(lines, 1, listOfZeros, listOfOnes);
                return listOfOnes;
            }
            GettingLines(lines, 1, listOfZeros, listOfOnes);
            return listOfZeros;
        }
        
        private static int DiagnosticOxygen(List<string> lines)
        {
            var listOfZeros = new List<string>();
            var listOfOnes = new List<string>();
            if (listOfOnes.Count > listOfZeros.Count || listOfOnes.Count == listOfZeros.Count)
            {
                GettingLines(lines, 0, listOfZeros, listOfOnes);
            }
            
            var listOfZeros1 = new List<string>();
            var listOfOnes1 = new List<string>();
            if ((listOfOnes.Count > listOfZeros.Count) || (listOfOnes.Count == listOfZeros.Count))
            {
                GettingLines(listOfOnes, 1, listOfZeros1, listOfOnes1);
            }
            else
            {
                GettingLines(listOfZeros, 1, listOfZeros1, listOfOnes1);
            }
            
            var listOfZeros2 = new List<string>();
            var listOfOnes2 = new List<string>();
            if ((listOfOnes1.Count > listOfZeros1.Count) || (listOfOnes1.Count == listOfZeros1.Count))
            {
                GettingLines(listOfOnes1, 2, listOfZeros2, listOfOnes2);
            }
            else
            {
                GettingLines(listOfZeros1, 2, listOfZeros2, listOfOnes2);
            }
            
            var listOfZeros3 = new List<string>();
            var listOfOnes3 = new List<string>();
            if ((listOfOnes2.Count > listOfZeros2.Count) || (listOfOnes2.Count == listOfZeros2.Count))
            {
                GettingLines(listOfOnes2, 3, listOfZeros3, listOfOnes3);
            }
            else
            {
                GettingLines(listOfZeros2, 3, listOfZeros3, listOfOnes3);
            }
          
            
            var listOfZeros4 = new List<string>();
            var listOfOnes4= new List<string>();
            if ((listOfOnes3.Count > listOfZeros3.Count) || (listOfOnes2.Count == listOfZeros2.Count))
            {
                GettingLines(listOfOnes3, 4, listOfZeros4, listOfOnes4);
            }
            else
            {
                GettingLines(listOfZeros3, 4, listOfZeros4, listOfOnes4);
            }

            return Convert(listOfOnes4[0]);
        }

        private static void GettingLines(IReadOnlyList<string> lines,  int j, List<string>? listOfZeros, List<string>? listOfOnes)
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
                    var parseNumber = int.Parse(t.Substring(j,1));
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
        
    private static int Convert(string str1) {
            if (str1 == "")
                throw new Exception("Invalid input");
            var res = 0;
            for (var i = 0; i < str1.Length; i++) {
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
                } catch {
                    throw new Exception("Invalid!");
                }
            }
            return res;
        }
    }
}
