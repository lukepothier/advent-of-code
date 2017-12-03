using System;
using System.IO;
using System.Linq;

namespace Day2
{
    // Puzzle @ https://adventofcode.com/2017/day/2

    static class Program
    {
        static void Main()
        {
            Console.WriteLine(Solve2a(File.ReadAllText(@"Inputs\2.txt")));
            Console.WriteLine(Solve2b(File.ReadAllText(@"Inputs\2.txt")));

            Console.Read();
        }

        static int Solve2a(string inputString)
        {
            var sum = 0;
            string[] rows = inputString.Split('\n');

            foreach (var row in rows)
            {
                string[] values = row.Replace("\n", "").Split('\t');
                int[] input = Array.ConvertAll(values, c => int.Parse(c));

                var max = input.Max();
                var min = input.Min();

                sum += max - min;
            }

            return sum;
        }

        static int Solve2b(string inputString)
        {
            var sum = 0;
            string[] rows = inputString.Split('\n');

            foreach (var row in rows)
            {
                string[] values = row.Replace("\n", "").Split('\t');
                int[] input = Array.ConvertAll(values, c => int.Parse(c));

                var rowComplete = false;

                for (var i = 0; i < input.Length; i++)
                {
                    if (!rowComplete)
                    {
                        int[] others = input.Except(new int[] { input[i] }).ToArray();

                        foreach (var item in others)
                            if (input[i] % item == 0)
                            {
                                sum += input[i] / item;
                                rowComplete = true;
                                break;
                            }
                    }
                }
            }

            return sum;
        }
    }
}
