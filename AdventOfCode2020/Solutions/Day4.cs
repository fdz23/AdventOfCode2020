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

        public long Part2()
        {
            var validPassports = _passports.Where(p => p.Fields.Count >= 7).ToList();
            validPassports.RemoveAll(p => p.Fields.Count == 7 && p.Fields.ContainsKey("cid"));

            return validPassports.Where(passport => FieldsAreValid(passport.Fields)).Count();
        }

        private bool FieldsAreValid(Dictionary<string, string> fields)
        {
            if (fields.TryGetValue("byr", out var birthYear))
            {
                if (!(birthYear.Length == 4 && Convert.ToInt32(birthYear).IsBetween(1920, 2002)))
                {
                    return false;
                }
            }

            if (fields.TryGetValue("iyr", out var issueYear))
            {
                if (!(issueYear.Length == 4 && Convert.ToInt32(issueYear).IsBetween(2010, 2020)))
                {
                    return false;
                }
            }

            if (fields.TryGetValue("eyr", out var expirationYear))
            {
                if (!(expirationYear.Length == 4 && Convert.ToInt32(expirationYear).IsBetween(2020, 2030)))
                {
                    return false;
                }
            }

            if (fields.TryGetValue("hgt", out var height))
            {
                if (height.Contains("cm"))
                {
                    if (!Convert.ToInt32(height.Split("cm")[0]).IsBetween(150, 193))
                    {
                        return false;
                    }
                }
                else
                {
                    if (height.Contains("in"))
                    {
                        if (!Convert.ToInt32(height.Split("in")[0]).IsBetween(59, 76))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            if (fields.TryGetValue("hcl", out var hairColor))
            {
                if (!Regex.IsMatch(hairColor, @"^#([0-9]|[a-f]){6}$"))
                {
                    return false;
                }
            }

            if (fields.TryGetValue("ecl", out var eyeColor))
            {
                if (!Regex.IsMatch(eyeColor, @"^(amb|blu|brn|gry|grn|hzl|oth)$"))
                {
                    return false;
                }
            }

            if (fields.TryGetValue("pid", out var passportId))
            {
                if (!Regex.IsMatch(passportId, @"^[0-9]{9}$"))
                {
                    return false;
                }
            }

            return true;
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
