using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exercise2 {
    class Program {
        static void Main(string[] args) {
            var file = "sample.xml";
            var outfile = "output.xml";
            ChangeXmlFormat(file, outfile);

            // これは確認用
            var text = File.ReadAllText(outfile);
            Console.WriteLine(text);
        }

        private static void ChangeXmlFormat(string file, string outfile) {
            var xdoc = XDocument.Load(file);
            var words = xdoc.Root.Elements()
                             .Select(x =>
                                new XElement("word",
                                    new XAttribute("kanji", x.Element("kanji").Value),
                                    new XAttribute("yomi", x.Element("yomi").Value)
                                )
                             );
            var root = new XElement("difficultkanji", words);
            root.Save(outfile);
        }
    }
}
