using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventOfCode2020.Utils;

namespace AdventOfCode2020.Solutions
{
    public class Day3
    {
        private readonly FileParser _fileParser = new FileParser();
        private readonly List<string> _input;

        public Day3()
        {
            _input = _fileParser.ParseFile($"Day3.txt").Select(line => line.ConcatTimes(7)).ToList();
        }

        public long Part1()
        {
            return ObtainNumberOfTrees(3, 1);
        }

        public long Part2()
        {
            return ObtainNumberOfTrees(1, 1) *
                   ObtainNumberOfTrees(3, 1) *
                   ObtainNumberOfTrees(5, 1) *
                   ObtainNumberOfTrees(7, 1) *
                   ObtainNumberOfTrees(1, 2);
        }

        public long ObtainNumberOfTrees(int right, int down)
        {
            var amountOfTrees = 0;
            var row = 0;
            var column = 0;
            var maxRow = _input.Count;
            var maxColumn = _input[row].Length;

            while (row < maxRow && column < maxColumn)
            {
                if (_input[row].CharacterAt(column).Equals("#"))
                {
                    amountOfTrees++;
                }

                column += right;
                row += down;
            }

            return amountOfTrees;
        }
    }
}
