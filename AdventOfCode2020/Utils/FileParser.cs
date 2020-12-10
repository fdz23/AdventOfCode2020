using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AOC2020.Utils
{
    public class FileParser
    {
        private readonly string _defaultPath = "E:\\Prog\\AOC2020\\AdventOfCode2020\\Inputs\\";

        public List<int> ParseFile(string path)
        {
            var reader = File.OpenText(_defaultPath + path);
            var line = reader.ReadLine();
            var lines = new List<int>();

            while (line != null)
            {
                lines.Add(Convert.ToInt32(line));
                line = reader.ReadLine();
            }

            return lines;
        }
    }
}
