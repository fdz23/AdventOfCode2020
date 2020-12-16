using AdventOfCode2020.Solutions;
using System;

namespace AdventOfCode2020
{
    class Program
    {
        static void Main(string[] args)
        {
            var day1 = new Day1();
            var day2 = new Day2();
            var day3 = new Day3();
            var day4 = new Day4();
            var day5 = new Day5();
            var day6 = new Day6();

            ExecuteAndShowTime(day1.Part1, 1, 1);
            ExecuteAndShowTime(day1.Part2, 1, 2);
            ExecuteAndShowTime(day2.Part1, 2, 1);
            ExecuteAndShowTime(day2.Part2, 2, 2);
            ExecuteAndShowTime(day3.Part1, 3, 1);
            ExecuteAndShowTime(day3.Part2, 3, 2);
            ExecuteAndShowTime(day4.Part1, 4, 1);
            ExecuteAndShowTime(day4.Part2, 4, 2);
            ExecuteAndShowTime(day5.Part1, 5, 1);
            ExecuteAndShowTime(day5.Part2, 5, 2);
            ExecuteAndShowTime(day6.Part1, 6, 1);
            ExecuteAndShowTime(day6.Part2, 6, 2);
        }

        public static void ExecuteAndShowTime(Func<long> function, int day, int part)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var solution = function();
            watch.Stop();
            Console.WriteLine($"Day {day} Part {part}'s solution: {solution}");
            Console.WriteLine($"Executed on {watch.ElapsedTicks * 100} ns\n");
        }
    }
}