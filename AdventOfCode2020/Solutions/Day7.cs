using AdventOfCode2020.Data;
using AdventOfCode2020.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Solutions
{
    public class Day7
    {
        private readonly FileParser _fileParser = new FileParser();
        private readonly List<string> _input;
        private readonly List<Bag> _bags = new List<Bag>();

        public Day7()
        {
            _input = _fileParser.ParseFile("Day7.txt");
            CreateBags();
        }

        public long Part1()
        {
            long bagCount = 0;

            foreach (var bag in _bags.Where(b => !b.Color.Equals("shiny gold")))
            {
                bagCount += GetSingleBagCount(bag, "shiny gold");
            }

            return bagCount;
        }

        public long Part2()
        {
            var bag = _bags.FirstOrDefault(b => b.Color.Equals("shiny gold"));
            
            return GetBagCount(bag, "shiny gold") - 1;
        }

        private void CreateBags()
        {
            CreateBagsWithoutReference();
            CreateReferenceForBags();
        }

        private void CreateBagsWithoutReference()
        {
            _bags.AddRange(_input.Select(GetBagFromLine));
        }

        private void CreateReferenceForBags()
        {
            foreach (var bag in _bags)
            {
                foreach (var line in _input.Where(l => !l.Contains("no other bags") && l.StartsWith(bag.Color)))
                {
                    var contained = line.Split("contain ")[1];
                    var differentBags = contained.Split(", ");

                    foreach (var differentBag in differentBags)
                    {
                        var containedBag = GetBagFromLine(differentBag);
                        bag.Bags.Add(_bags.FirstOrDefault(b => b.Equals(containedBag)), differentBag.Split(" ")[0].ToInt().Value);
                    }
                }
            }
        }

        private Bag GetBagFromLine(string line)
        {
            var words = line.Split(" ");
            var color = words[0].ToInt() == null ? $"{words[0]} {words[1]}" : $"{words[1]} {words[2]}";

            return new Bag
            {
                Color = color
            };
        }

        private long GetSingleBagCount(Bag obj, string colorToFind)
        {
            long bagCount = 0;

            if (obj.Color.Equals(colorToFind))
            {
                return 1;
            }
            else
            {
                foreach (var bag in obj.Bags.Keys)
                {
                    if (GetSingleBagCount(bag, colorToFind) > 0)
                    {
                        return 1;
                    }
                }
            }

            return bagCount;
        }

        private long GetBagCount(Bag obj, string colorToFind)
        {
            long bagCount = 0;
            bagCount++;

            foreach (var bag in obj.Bags)
            {
                bagCount += GetBagCount(bag.Key, colorToFind) * bag.Value;
            }

            return bagCount;
        }
    }
}
