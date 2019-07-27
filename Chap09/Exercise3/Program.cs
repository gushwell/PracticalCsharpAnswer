using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3 {
    class Program {
        static void Main(string[] args) {
            if (args.Length <= 1)
                return;
            var file1 = args[0];
            var file2 = args[1];
            Concat(file1, file2);

            Display(file1);
        }

        // これが一番簡潔なコード。
        // 調べれば、きっと簡単な方法が見つかる！
        private static void Concat(string file1, string file2) {
            File.AppendAllLines(file1, File.ReadLines(file2));
        }

        // こんな書き方もできる
        private static void Concat2(string file1, string file2) {
            using (var dest = new StreamWriter(file1, append:true, encoding:Encoding.UTF8)) {
                var lines = File.ReadLines(file2);
                foreach (var line in lines)
                    dest.WriteLine(line);
            }
        }

        // 確認用コード
        private static void Display(string outputPath) {
            var text = File.ReadAllText(outputPath);
            Console.WriteLine(text);
        }
    }
}

