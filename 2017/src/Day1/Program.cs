using System;
using System.IO;

namespace Day1
{
    // Puzzle @ https://adventofcode.com/2017/day/1

    static class Program
    {
        static void Main()
        {
            Console.WriteLine(Solve1a(File.ReadAllText(@"Inputs\1.txt")));
            Console.WriteLine(Solve1b(File.ReadAllText(@"Inputs\1.txt")));

            Console.Read();
        }

        static int Solve1a(string inputString)
        {
            inputString = inputString.Replace("\r\n", "").Replace("\n", "").Replace("\r", "");

            char[] characters = inputString.ToCharArray();

            int[] input = Array.ConvertAll(characters, c => (int)char.GetNumericValue(c));

            var inputLength = input.Length;

            if (inputLength == 0)
                return 0;

            var sum = 0;

            for (var i = 0; i < inputLength; i++)
            {
                if (i == inputLength - 1)
                {
                    if (inputLength > 1 && input[i] == input[0])
                        sum += input[i];
                }
                else
                {
                    if (input[i] == input[i + 1])
                        sum += input[i];
                }
            }

            return sum;
        }

        static int Solve1b(string inputString)
        {
            inputString = inputString.Replace("\r\n", "").Replace("\n", "").Replace("\r", "");

            char[] characters = inputString.ToCharArray();

            int[] input = Array.ConvertAll(characters, c => (int)char.GetNumericValue(c));

            var inputLength = input.Length;

            if (inputLength == 0)
                return 0;

            var skip = inputLength / 2;

            var sum = 0;

            for (var i = 0; i < inputLength; i++)
            {
                if (i + skip > inputLength - 1)
                {
                    var wrap = i + skip - inputLength;
                    if (input[i] == input[wrap])
                        sum += input[i];
                }
                else
                    if (input[i] == input[i + skip])
                        sum += input[i];
            }

            return sum;
        }
    }
}
