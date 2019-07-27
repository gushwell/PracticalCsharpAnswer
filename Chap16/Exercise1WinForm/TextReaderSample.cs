using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1WinForm {
    static class TextReaderSample {

        // IProgressインターフェースを使い、読み込んだ行を1行ずつ、呼び出し元に通知しています。
        // ReadTextAsyncを呼び出した時と、表示のされかたが異なる点に注目してください。
        public static async Task ReadLinesAsync(string filePath, IProgress<string> progress) {
            var sr = new StreamReader(filePath);
            while (!sr.EndOfStream) {
                var line = await sr.ReadLineAsync();
                progress.Report(line);
            }
        }

        // StringBuilderを使い、読み込んだ行をため込んでいき、最後にテキスト全部を返します。 
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
