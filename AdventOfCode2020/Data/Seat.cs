using AdventOfCode2020.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Data
{
    public class Seat
    {
        public Seat()
        {
            MinRow = 0;
            MaxRow = 127;
            MinCol = 0;
            MaxCol = 7;
        }

        public int MinRow { get; set; }

        public int MaxRow { get; set; }

        public int MinCol { get; set; }

        public int MaxCol { get; set; }

        public long Id => MinRow * 8 + MaxCol;

        public void CalculateSeatId(string line)
        {
            for (int i = 0; i < line.Length; i++)
            {
                switch (line.CharacterAt(i))
                {
                    case "B":
                        GetUpperHalfRow();
                        break;
                    case "F":
                        GetLowerHalfRow();
                        break;
                    case "R":
                        GetUpperHalfCol();
                        break;
                    case "L":
                        GetLowerHalfCol();
                        break;
                }
            }
        }

        private void GetUpperHalfRow()
        {
            MinRow += (MaxRow - MinRow) / 2 + 1;
        }

        private void GetLowerHalfRow()
        {
            MaxRow = MinRow + (MaxRow - MinRow) / 2;
        }

        private void GetUpperHalfCol()
        {
            MinCol += (MaxCol - MinCol) / 2 + 1;
        }

        private void GetLowerHalfCol()
        {
            MaxCol = MinCol + (MaxCol - MinCol) / 2;
        }
    }
}
