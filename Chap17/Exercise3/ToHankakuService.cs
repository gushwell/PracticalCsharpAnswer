using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CSharpPhrase.TextFileProcessor.Framework;

namespace CSharpPhrase.TextFileProcessor {
    class ToHankakuService : ITextFileService {
        private static Dictionary<char, char> _dictionary;

        public ToHankakuService() {
            // _dictionaryの初期化は、問題17.1とは異なった方法で初期化している。
            var zenkaku = "０１２３４５６７８９";
            var hankaku = "0123456789";
            _dictionary = zenkaku.Zip(hankaku, (zen, han) => new { zen, han })
                                 .ToDictionary(x => x.zen, x => x.han);
        }
        public void Execute(string line) {
            var s = Regex.Replace(line, "[０-９]", c => _dictionary[c.Value[0]].ToString());
            Console.WriteLine(s);
        }

        public void Initialize(string fname) {
        }

        public void Terminate() {
        }

    }
}
