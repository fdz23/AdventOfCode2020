using AdventOfCode2020.Data;
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
        private readonly List<string> _input;
        private List<Group> _groups;

        public Day6()
        {
            _input = _fileParser.ParseFile("Day6.txt");
            _groups = CreateGroups();
        }

        public long Part1()
        {
            long sum = 0;

            _groups.ForEach(g =>
            {
                var allAnswers = new List<Answer>();

                g.Persons.ForEach(p =>
                {
                    allAnswers.AddRange(p.Answers);
                });

                sum += allAnswers.Select(a => a.Character).Distinct().Count();
            });

            return sum;
        }

        public long Part2()
        {
            long sum = 0;

            _groups.ForEach(g =>
            {
                var allCharacters = new List<string>();

                g.Persons.ForEach(p =>
                {
                    p.Answers.ForEach(a =>
                    {
                        if (g.Persons.All(person => person.Answers.Select(answer => answer.Character).Contains(a.Character)))
                        {
                            if (!allCharacters.Contains(a.Character))
                            {
                                allCharacters.Add(a.Character);
                            }
                        }
                    });
                });

                sum += allCharacters.Count();
            });

            return sum;
        }

        private List<Group> CreateGroups()
        {
            var groups = new List<Group>();
            var persons = new List<Person>();

            foreach (var input in _input)
            {
                if (input.Equals(""))
                {
                    var personsToAdd = new List<Person>();
                    personsToAdd.AddRange(persons);

                    groups.Add(new Group() { Persons = personsToAdd });
                    persons.Clear();
                }
                else
                {
                    var answers = new List<Answer>();

                    for (int i = 0; i < input.Length; i++)
                    {
                        answers.Add(new Answer { Character = input.CharacterAt(i) });
                    }

                    persons.Add(new Person { Answers = answers });
                }
            }

            groups.Add(new Group() { Persons = persons });

            return groups;
        }
    }
}
