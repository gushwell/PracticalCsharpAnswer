using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4 {
    class Program {
        static void Main(string[] args) {
            if (args.Length <= 1)
                return;

            // これは確認用
            Console.WriteLine($"source: {Path.GetFullPath(args[0])}");
            Console.WriteLine($"dest:   {Path.GetFullPath(args[1])}\n");
            // ここまで

            var sourceDir = args[0];
            var destDir = args[1];
            CopyFiles(sourceDir, destDir);
        }

        private static void CopyFiles(string sourceDir, string destDir) {
            var files = Directory.EnumerateFiles(sourceDir, "*.*");
            if (!Directory.Exists(destDir))
                Directory.CreateDirectory(destDir);
            foreach (var file in files) {
                var dest = GetBakFilePath(destDir, file);
                Console.WriteLine(dest);
                File.Copy(file, dest, overwrite:true);
            }
        }

        private static string GetBakFilePath(string destDir, string file) {
            var name = Path.GetFileNameWithoutExtension(file) + "_bak";
            var ext = Path.GetExtension(file);
            // 拡張子がないファイルの場合、extは"" なので、無条件にextを追加してもうまくいく
            return Path.Combine(destDir, name + ext);
        }
    }
}
