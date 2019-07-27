# 第1章 オブジェクト指向プログラミングの基礎

　C#でプログラムを書くということは必然的に、クラスを定義し利用することになります。本書を読んでいるあなたは、すでにクラスについての学習が済んでいると思いますが、まだ十分にクラスというものに馴染んでいないかもしれません。そのため、本書の本題である「C#プログラミングの定石、パターン」の説明に入る前に、まずは、クラスを定義、利用する上で必ず理解しておいて欲しい点や落とし穴になりそうなところを復習しておきましょう．

## 1-1:クラス

### 1-1-1:クラスを定義する

　「クラス」は、C#でプログラミングする上で最も重要な概念のひとつです。C#でオブジェクト指向プログラミングをする上での基礎となるものであり、クラスを正しく理解し使えるようになることが大切です。まずは、クラスの定義についてざっと概観していきます。

    // 商品クラス
    public 【class】 Product {
       // 商品コード
       public int Code { get; set; }
       // 商品名
       public string Name { get; set; }
       // 商品価格(税抜き)
       public int Price { get; set; }
    }

　上のコードは、商品を表すProductクラスの定義例です。Productクラスには、Code、Name、Priceの3つのプロパティが存在しています。このProductクラスに2つのメソッドを追加してみます。

    public class Product {
       public int Code { get; set; }
       public string Name { get; set; }
       public int Price { get; set; }

       // 消費税額を求める (消費税率は8%)
       public int GetTax() {                       〈←追加したメソッド〉
          return (int)(Price * 0.08); 
       }
      
       // 税込価格を求める
       public int GetTaxIncludedPrice() {          〈←追加したメソッド〉
          return Price + GetTax();
       }
    }

　クラスには、データの他に振る舞いを表すメソッドを定義することができるのでしたね。GetTaxはその商品の消費税額を求めるメソッド、GetTaxIncludedPriceはその商品の税込価格を求めるメソッドです。

　GetTaxメソッドでは、税抜き価格に消費税8%を掛け、消費税額を求めています。この時、計算結果はdouble型になりますので、int型にキャスト(型変換)しています。

　GetTaxIncludedPriceメソッドでは、1.08を掛けるのではなく、GetTaxメソッドで求めた消費税額をPriceに加えることで税込価格を求めています。

　それでは次に、Productクラスにコンストラクタを定義しましょう。

##### リスト1-1:Productクラス

    public class Product {
       public int Code { get; 【private】 set; }         〈←setは、privateに変更〉
       public string Name { get; 【private】 set; }      〈←setは、privateに変更〉
       public int Price { get; 【private】 set; }        〈←setは、privateに変更〉

       // コンストラクタ
       public 【Product】(int code, string name, int price) {  〈←追加したコンストラクタ〉
          this.Code = code;
          this.Name = name;
          this.Price = price;
       }

       // 消費税額を求める
       public int GetTax() {
          return (int)(Price * 0.08);
       }

       // 税込価格を求める
       public int GetTaxIncludedPrice() {
          return Price + GetTax();
       }
    }

　コンストラクタは、クラス名と同じ名前をもった特殊なメソッドです。商品コード、商品名、商品価格(税抜き)の3つの引数を持つコンストラクタを定義しました。コンストラクタの定義に合わせ、Code、Name、Priceのプロパティのsetアクセサのアクセスレベルをprivate(非公開)に変更しています。これでProductクラスの利用者は、コンストラクタ以外でプロパティの値を設定できなくしています。

