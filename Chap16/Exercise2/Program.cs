using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Exercise2 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(Path.GetFullPath(args[0]));

            var obj = new AsyncWaitSample();
            obj.Execute(args[0]);

            // 2回目は、ファイルの内容がバッファーにたまっているために、必然的に速度が速くなる
            // そのため、非同期版は、最後にもう一回呼び出して、公平な速度比較とする。
            // ただし、実行環境によっては、並列版のほうが遅くなる場合もある。

            Console.WriteLine("並列版を実行します。Enterキーを押してください");
            Console.ReadLine();
            obj.ExecuteAsync(args[0]);

            Console.WriteLine("非並列版を実行します。Enterキーを押してください");
            Console.ReadLine();
            obj.Execute(args[0]);
        }
    }

    class AsyncWaitSample {
        public async void  ExecuteAsync(string dir) {
            // 同時実行数が多すぎるとかえって遅くなる場合がある。（実行環境に依存する）
            // 以下の4行で同時に実行するスレッド数を制限する。
            int workMin;
            int ioMin;
            ThreadPool.GetMinThreads(out workMin, out ioMin);
            ThreadPool.SetMinThreads(8, ioMin);
            var start = DateTime.Now;
            var files = Directory.EnumerateFiles(dir, "*.cs", SearchOption.AllDirectories);
            var tasks = new List<Task>();
            foreach (var file in files) {
                var task = Task.Run(() => {
                    if (Find(file))
                        Console.WriteLine(Path.GetFullPath(file));
                });
                tasks.Add(task);
            }
            await Task.WhenAll(tasks);
            
            Console.WriteLine("並列版 {0}", (DateTime.Now - start).TotalSeconds);
        }

        public void Execute(string dir) {
            var start = DateTime.Now;
            var files = Directory.EnumerateFiles(dir, "*.cs", SearchOption.AllDirectories);
            foreach (var file in files) {
                if (Find(file))
                    Console.WriteLine(Path.GetFullPath(file));
            }
            Console.WriteLine("非並列版 {0}", (DateTime.Now - start).TotalSeconds);
        }

        private bool Find(string file) {
            bool useAsync = false;
            bool useAwait = false;
            foreach (var line in File.ReadAllLines(file)) {
                if (Regex.IsMatch(line, @"\basync\b"))
                    useAsync = true;
                if (Regex.IsMatch(line, @"\bawait\b"))
                    useAwait = true;
                if (useAsync && useAwait)
                    return true;
            }
            return false;
        }
    }
}
