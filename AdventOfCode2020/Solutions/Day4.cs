using AdventOfCode2020.DTOs;
using AdventOfCode2020.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Solutions
{
    public class Day4
    {
        private readonly FileParser _fileParser = new FileParser();
        private readonly List<string> _input;
        private readonly List<PassportDTO> _passports = new List<PassportDTO>();
        public Day4()
        {
            _input = _fileParser.ParseFile("Day4.txt");
            ParsePassports();
        }

        public long Part1()
        {
            var validPassports = _passports.Where(p => p.Fields.Count >= 7).ToList();
            validPassports.RemoveAll(p => p.Fields.Count == 7 && p.Fields.ContainsKey("cid"));

            return validPassports.Count();
        }

        private void ParsePassports()
        {
            var newInputs = new List<string>();
            newInputs.Add("");
            var index = 0;

            foreach (var input in _input)
            {
                if (input.Equals(""))
                {
                    newInputs.Add("");
                    index++;
                }
                else
                {
                    if (!newInputs[index].Equals(""))
                    {
                        newInputs[index] += $" {input}";
                    }
                    else
                    {
                        newInputs[index] += input;
                    }
                }
            }

            foreach (var input in newInputs)
            {
                var fields = input.Split(" ");
                var passport = new PassportDTO();
                passport.Fields = new Dictionary<string, string>();

                foreach (var field in fields)
                {
                    var keyValue = field.Split(":");

                    passport.Fields.Add(keyValue[0], keyValue[1]);
                }

                _passports.Add(passport);
            }
        }
    }
}
