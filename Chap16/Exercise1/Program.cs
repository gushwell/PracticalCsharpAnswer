using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// コンソールアプリケーションとして作成しています。

namespace Exercise1 {
    class Program {
        static  void Main(string[] args) {
            RunAsync();
            // 非同期で動作しているので、ここでキー入力待ちにして、プログラムが終わらないようにしている。
            // Mainメソッドには、async は使えない。
            Console.ReadLine();
        }

        private static async void RunAsync() {
            var text = await TextReaderSample.ReadTextAsync("oop.md");
            Console.WriteLine(text);
        }
    }

    static class TextReaderSample {
        public static async Task<string> ReadTextAsync(string filePath) {
            var sb = new StringBuilder();
            var sr = new StreamReader(filePath);
            while (!sr.EndOfStream) {
                var line = await sr.ReadLineAsync();
                sb.AppendLine(line);
            }
            return sb.ToString();
        }
    }
}
