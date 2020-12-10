using AdventOfCode2020.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Utils
{
    public static class Extensions
    {
        public static Day2Part1DTO ConvertDay2Part1DTO(this string line)
        {
            var lineSplit = line.Split(" ");
            var numbers = lineSplit[0].Split("-");

            return new Day2Part1DTO
            {
                Character = lineSplit[1].Split(":")[0],
                Min = Convert.ToInt32(numbers[0]),
                Max = Convert.ToInt32(numbers[1]),
                Password = lineSplit[2]
            };
        }

        public static bool IsBetween(this int number, int min, int max)
        {
            return number >= min && number <= max;
        }
    }
}
