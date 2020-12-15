using AdventOfCode2020.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Solutions
{
    public class Day6
    {
        private readonly FileParser _fileParser = new FileParser();
        private List<string> _input;

        public Day6()
        {
            _input = _fileParser.ParseFile("Day6.txt");
            ParseInput();
        }

        public long Part1()
        {
            long sumOfAnswers = 0;

            foreach (var input in _input)
            {
                var letters = new Dictionary<string, bool>();

                for (int i = 0; i < input.Length; i++)
                {
                    var character = input.CharacterAt(i);

                    if (!letters.ContainsKey(character))
                    {
                        letters.Add(character, true);
                    }
                }

                sumOfAnswers += letters.Count;
            }

            return sumOfAnswers;
        }

        private void ParseInput() 
        {
            var newInput = new List<string>();
            newInput.Add("");

            foreach (var input in _input)
            {
                if (input.Equals(""))
                {
                    newInput.Add("");
                }
                else
                {
                    newInput[^1] += input;
                }
            }

            _input = newInput;
        }
    }
}
