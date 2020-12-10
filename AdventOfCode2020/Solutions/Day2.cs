using AdventOfCode2020.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Solutions
{
    public class Day2
    {
        private readonly FileParser _fileParser = new FileParser();
        private readonly List<string> _input;

        public Day2()
        {
            _input = _fileParser.ParseFile($"Day2.txt");
        }

        public int Part1()
        {
            var amountOfValidPasswords = 0;

            foreach (var line in _input)
            {
                var dto = line.ConvertDay2Part1DTO();
                var matches = Regex.Matches(dto.Password, dto.Character);

                if (matches.Count.IsBetween(dto.Min, dto.Max))
                {
                    amountOfValidPasswords++;
                }
            }

            return amountOfValidPasswords;
        }

        public int Part2()
        {
            var amountOfValidPasswords = 0;

            foreach (var line in _input)
            {
                var dto = line.ConvertDay2Part1DTO();
                var matches = Regex.Matches(dto.Password, dto.Character);
                var match = matches.Where(match => match.Index == dto.Min - 1 || match.Index == dto.Max - 1);

                if (match.Count() == 1)
                {
                    amountOfValidPasswords++;
                }
            }

            return amountOfValidPasswords;
        }
    }
}
