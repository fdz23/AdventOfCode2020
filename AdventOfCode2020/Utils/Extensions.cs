using AdventOfCode2020.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Utils
{
    public static class Extensions
    {
        public static Card ConvertToCard(this string line)
        {
            var lineSplit = line.Split(" ");
            var numbers = lineSplit[0].Split("-");

            return new Card
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

        public static string CharacterAt(this string msg, int index)
        {
            return msg.Substring(index, 1);
        }

        public static string ConcatTimes(this string msg, int times)
        {
            for (var i = 0; i < times; i++)
            {
                msg += msg;
            }

            return msg;
        }
    }
}
