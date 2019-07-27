using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpPhrase.TextFileProcessor.Framework;


/*

  最後の演習問題では、ちょと意地悪な仕掛けを入れてあります。
  本書の「17.2 Template Methodパター」で示したコードでは、TextFileProcessorは名前空間の名前でしたが、
  この問題では、TextFileProcessor をクラス名にしています。
  そのため、書籍の「リスト17.8」などを参考に、この問題のコードを書いた場合、TextFileProcessor は、
  クラス名と名前空間の両方で使われる名前になってしまいます。
  しかし、この状態では、文法エラーとなってしまい、ビルドが通りません。

  なぜなら、C#では、名前空間をドットで区切った名前とクラス名が同じだと、単独のクラス名は、名前空間名
  だとみなされてしまうからです。

  これを回避するには、オブジェクトを生成する際などのクラス名は、必ず名前空間で修飾したクラス名を指定
  しなければなりません。以下のコードがその箇所です。

     var processor = new Framework.TextFileProcessor(new ToHankakuService());

  しかし、一般的には、このようなことが起こらないような名前空間名にするのが普通です。
  例えば、この例だと、名前空間名を CSharpPhrase.TextFileProcessor  から、CSharpPhrase.TextFileProsessing に
  変更するなどの対応が考えられます。

  ...

  ところで、、この問題は、依存性の注入(DI)と言われるパターンの簡単な例です。
  TextFileProcessor クラスは、ToHankakuService クラスと依存関係にあるわけですが、この依存関係を、
  以下のインスタンス生成時に確立させていることになります。

    new Framework.TextFileProcessor(new ToHankakuService());

  これは手動で、依存性の注入を行っていますが、DIコンテナと呼ばれるものを使うと、コード上に直接記述せず、
  自動的に依存性の注入を行うことが可能です。
  .NET Frameworkにも、Managed Extensibility Framework と呼ばれる DIコンテナの機能を持ったクラス群が提供
  されています。また、外部のDIコンテナとしては、Unity(Gameエンジンとは別のもの), Spring.NET などが有名です。
  
*/


namespace CSharpPhrase.TextFileProcessor {
    class Program {
        static void Main(string[] args) {
            var processor = new Framework.TextFileProcessor(new ToHankakuService());
            processor.Run(args[0]);

            // 以下は、LineCounterServiceのインスタンスを渡した例。
            // TextFileProcessorのコンストラクタに、ITextFileService を実装したクラスのインスタンスを
            // 渡すことで、TextFileProcessorクラスは、いろいろな動作が可能になる。

            //    var processor = new Framework.TextFileProcessor(new LineCounterService());
            //    processor.Run(args[0]);
        }
    }
}
