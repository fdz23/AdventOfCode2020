﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.DTOs
{
    public class Passport
    {
        public Dictionary<string, string> Fields { get; set; }

        public bool IsValid { get; set; }
    }
}
