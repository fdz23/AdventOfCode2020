using AdventOfCode2020.DTOs;
using AdventOfCode2020.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Solutions
{
    public class Day5
    {
        private readonly FileParser _fileParser = new FileParser();
        private readonly List<string> _input;
        private readonly List<long> _idList;

        public Day5()
        {
            _input = _fileParser.ParseFile("Day5.txt");
            _idList = new List<long>();
        }

        public long Part1()
        {
            long maxSeatId = 0;

            foreach (var line in _input)
            {
                var seatId = DiscoverSeatId(line);
                _idList.Add(seatId);

                if (seatId > maxSeatId)
                {
                    maxSeatId = seatId;
                }
            }

            return maxSeatId;
        }

        public long DiscoverSeatId(string line)
        {
            int minCol = 0;
            int maxCol = 7;
            int maxRow = 127;
            int minRow = 0;

            for (int i = 0; i < line.Length; i++)
            {
                if (line.CharacterAt(i).Equals("B"))
                {
                    minRow += GetUpperHalf(minRow, maxRow);
                }
                if (line.CharacterAt(i).Equals("F"))
                {
                    maxRow = GetLowerHalf(minRow, maxRow);
                }
                if (line.CharacterAt(i).Equals("R"))
                {
                    minCol += GetUpperHalf(minCol, maxCol);
                }
                if (line.CharacterAt(i).Equals("L"))
                {
                    maxCol = GetLowerHalf(minCol, maxCol);
                }
            }

            return minRow * 8 + maxCol;
        }

        private int GetUpperHalf(int min, int max)
        {
            return (max - min) / 2 + 1;
        }

        private int GetLowerHalf(int min, int max)
        {
            return min + (max - min) / 2;
        }
    }
}
