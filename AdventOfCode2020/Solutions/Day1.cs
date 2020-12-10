using AOC2020.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2020.Solutions
{
    public class Day1
    {
        private readonly FileParser _fileParser = new FileParser();

        public int Part1()
        {
            var input = _fileParser.ParseFile($"Day1.txt");
            var solution = 0;

            foreach (var number in input)
            {
                solution = number;
                var otherNumber = input.Find(n => n + number == 2020);

                if (otherNumber != 0)
                {
                    return solution * otherNumber;
                }
            }

            return solution;
        }
    }
}
