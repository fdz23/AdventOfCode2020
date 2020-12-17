using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Data
{
    public class Bag
    {
        public Bag()
        {
            Bags = new Dictionary<Bag, int>();
        }

        public string Color { get; set; }

        public Dictionary<Bag, int> Bags { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Bag bag && Equals(Color, bag.Color);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Color, Bags);
        }
    }
}
