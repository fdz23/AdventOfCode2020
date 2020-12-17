using AdventOfCode2020.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Solutions
{
    public class Day8
    {
        private readonly FileParser _fileParser = new FileParser();
        private readonly List<string> _input;
        private readonly List<int> _linesVisited;

        public Day8()
        {
            _input = _fileParser.ParseFile("Day8.txt");
            _linesVisited = new List<int>();
        }

        public long Part1()
        {
            long accumulator = 0;

            for (int i = 0; i < _input.Count;)
            {
                if (_linesVisited.Contains(i))
                {
                    return accumulator;
                }
                else
                {
                    var lineSplit = _input[i].Split(" ");
                    var command = lineSplit[0];
                    var amount = lineSplit[1].ToInt().Value;
                    _linesVisited.Add(i);

                    if (command.Equals("nop"))
                    {
                        i++;
                        continue;
                    }

                    if (command.Equals("acc"))
                    {
                        accumulator += amount;
                        i++;
                        continue;
                    }
                        
                    i += amount;
                }
            }

            return accumulator;
        }
    }
}
