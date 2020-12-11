using AdventOfCode2020.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Solutions
{
    public class Day1
    {
        private readonly FileParser _fileParser = new FileParser();
        private readonly List<int> _input;

        public Day1()
        {
            _input = _fileParser.ParseFile($"Day1.txt").Select(line => Convert.ToInt32(line)).ToList();
        }

        public long Part1()
        {
            var solution = 0;

            foreach (var number in _input)
            {
                solution = number;
                var otherNumber = _input.Find(n => n + number == 2020);

                if (otherNumber != 0)
                {
                    return solution * otherNumber;
                }
            }

            return solution;
        }
        public long Part2()
        {
            var solution = 0;

            foreach (var numberOne in _input)
            {
                foreach (var numberTwo in _input)
                {
                    solution = numberOne * numberTwo;

                    var numberThree = _input.Find(n => n + numberOne + numberTwo == 2020);

                    if (numberThree != 0)
                    {
                        return solution * numberThree;
                    }
                }
            }

            return solution;
        }
    }
}
