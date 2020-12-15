using AdventOfCode2020.Data;
using AdventOfCode2020.DTOs;
using AdventOfCode2020.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Solutions
{
    public class Day5
    {
        private readonly FileParser _fileParser = new FileParser();
        private readonly List<string> _input;
        private readonly List<Seat> _seats;
        private Seat _mySeat;

        public Day5()
        {
            _input = _fileParser.ParseFile("Day5.txt");
            _seats = new List<Seat>();
        }

        public long Part1()
        {
            var maxSeatId = new Seat
            {
                MaxCol = 0
            };

            foreach (var line in _input)
            {
                var seat = new Seat();

                seat.CalculateSeatId(line);
                _seats.Add(seat);

                if (seat.Id > maxSeatId.Id)
                {
                    maxSeatId = seat;
                }
            }

            _mySeat = maxSeatId;
            return maxSeatId.Id;
        }

        public long Part2()
        {
            var seat = _seats
                .OrderBy(s => s.Id)
                .FirstOrDefault(seat => _seats.FirstOrDefault(s => s.Id == seat.Id + 1) == null
                            && _seats.FirstOrDefault(s => s.Id == seat.Id + 2) != null);

            return seat.Id + 1;
        }
    }
}
