using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter15 {
    public class Category {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString() {
            return $"Id:{Id}, カテゴリ名:{Name}";
        }
    }

    public class Book {

        public string Title { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public int PublishedYear { get; set; }

        public override string ToString() {
            return $"発行年:{PublishedYear}, カテゴリ:{CategoryId}, 価格:{Price}, タイトル:{Title}";
        }
    }

    public static class Library {
        // Categoriesプロパティで上記のカテゴリの一覧を得ることができる。
        public static IEnumerable<Category> Categories { get; private set; }

        // Booksプロパティで上記の書籍情報の一覧を得ることができる。
        public static IEnumerable<Book> Books { get; private set; }

        static Library() {
            // CategoriesとBooksにデータを設定。実装詳細は省略
            Categories = new List<Category> {
                new Category { Id = 1, Name = "Development"  },
                new Category { Id = 2, Name = "Serever"  },
                new Category { Id = 3, Name = "Web Design"  },
                new Category { Id = 4, Name = "Windows"  },
                new Category { Id = 5, Name = "Application"  },
            };

            Books = new List<Book> {
                new Book { Title = "Writing C# Solid Code", CategoryId = 1, Price = 2500, PublishedYear = 2016 },
                new Book { Title = "C#開発指南", CategoryId = 1, Price = 3800, PublishedYear = 2014 },
                new Book { Title = "Visual C#再入門", CategoryId = 1, Price = 2780, PublishedYear = 2016 },
                new Book { Title = "フレーズで学ぶC# Book", CategoryId = 1, Price = 2400, PublishedYear = 2016 },
                new Book { Title = "TypeScript初級講座", CategoryId = 1, Price = 2500, PublishedYear = 2015 },
                new Book { Title = "PowerShell 実践レシピ", CategoryId = 2, Price = 4200, PublishedYear = 2013 },
                new Book { Title = "SQL Server 完全入門", CategoryId = 2, Price = 3800, PublishedYear = 2014 },
                new Book { Title = "IIS Webサーバー運用ガイド", CategoryId = 2, Price = 3180, PublishedYear = 2015 },
                new Book { Title = "Microsoft Azureサーバー構築", CategoryId = 2, Price = 4800, PublishedYear = 2016 },
                new Book { Title = "Webデザイン講座 HTML5＆CSS", CategoryId = 3, Price = 2800, PublishedYear = 2013 },
                new Book { Title = "HTML5 Web大百科", CategoryId = 3, Price = 3800, PublishedYear = 2015 },
                new Book { Title = "CSSデザイン 逆引き辞典", CategoryId = 3, Price = 3550, PublishedYear = 2015 },
                new Book { Title = "Windows10で楽しくお仕事", CategoryId = 4, Price = 2280, PublishedYear = 2016 },
                new Book { Title = "Windows10使いこなし術", CategoryId = 4, Price = 1890, PublishedYear = 2015 },
                new Book { Title = "続Windows10使いこなし術", CategoryId = 4, Price = 2080, PublishedYear = 2016 },
                new Book { Title = "Windows10 やさしい操作入門", CategoryId = 4, Price = 2300, PublishedYear = 2015 },
                new Book { Title = "まるわかりMicrosoft Office入門", CategoryId = 5, Price = 1890, PublishedYear = 2015 },
                new Book { Title = "Word・Excel実践テンプレート集", CategoryId = 5, Price = 2600, PublishedYear = 2016 },
                new Book { Title = "たのしく学ぶExcel初級編", CategoryId = 5, Price = 2800, PublishedYear = 2015 },
            };
        }
    }
}
