﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exercise4 {
    class Program {
        static void Main(string[] args) {
            if (args.Length == 0) {
                Console.WriteLine("パラメータが指定されていません");
                return;
            }
            var file = args[0];
            var lines = File.ReadAllLines(file);
            var newlines = lines.Select(s => Regex.Replace(s, @"\bversion=""v4\.0""", @"version=""v5.0"""));
            File.WriteAllLines(file, newlines);

            // これ以降は確認用
            var text = File.ReadAllText(file);
            Console.WriteLine(text);
        }
    }
}
