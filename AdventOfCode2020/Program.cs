using AdventOfCode2020.Solutions;
using System;

namespace AdventOfCode2020
{
    class Program
    {
        static void Main(string[] args)
        {
            ExecuteAndShowTime(new Day1().Part1, 1, 1);
            ExecuteAndShowTime(new Day1().Part2, 1, 2);
            ExecuteAndShowTime(new Day2().Part1, 2, 1);
            ExecuteAndShowTime(new Day2().Part2, 2, 2);
            ExecuteAndShowTime(new Day3().Part1, 3, 1);
            ExecuteAndShowTime(new Day3().Part2, 3, 2);
        }

        public static void ExecuteAndShowTime(Func<long> function, int day, int part)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var solution = function();
            watch.Stop();
            Console.WriteLine($"Day {day} Part {part}'s solution: {solution}");
            Console.WriteLine($"Executed on {watch.ElapsedTicks / 100} ns\n");
        }
    }
}
