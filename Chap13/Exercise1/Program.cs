using Exercise1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1 {
    class Program {
        static void Main(string[] args) {
            // 次の３行で、書籍本文と同じデータを挿入する。
            // 実行すると、次の２つのファイルが作成される。
            // "C:\Users\<ユーザ名>\Exercise1.Models.BooksDbContext.mdf"
            // "C:\Users\<ユーザ名>\Exercise1.Models.BooksDbContext.ldf"

            InsertBooks();
            AddAuthors();
            AddBooks();

            // ここからが問題の解答
            Console.WriteLine("# 1.1");
            Exercise1_1();

            Console.WriteLine("# 1.2");
            Exercise1_2();

            Console.WriteLine("# 1.3");
            Exercise1_3();

            Console.WriteLine("# 1.4");
            Exercise1_4();

            Console.WriteLine("# 1.5");
            Exercise1_5();

            Console.ReadLine();
        }

        private static void Exercise1_1() {
            using (var db = new BooksDbContext()) {
                var natsume = db.Authors.Single(a => a.Name == "夏目漱石");
                var book1 = new Book {
                    Title = "こころ",
                    PublshedYear = 1991,
                    Author = natsume,
                };
                db.Books.Add(book1);
                var author2 = db.Authors.Single(a => a.Name == "宮沢賢治");
                var book2 = new Book {
                    Title = "注文の多い料理店",
                    PublshedYear = 2000,
                    Author = author2,
                };
                db.Books.Add(book2);
                db.SaveChanges();
            }
            using (var db = new BooksDbContext()) {
                var kikuchi = new Author {
                    Birthday = new DateTime(1888, 12, 26),
                    Gender = "M",
                    Name = "菊池寛"
                };
                var book1 = new Book {
                    Title = "真珠夫人",
                    PublshedYear = 2003,
                    Author = kikuchi
                };
                db.Books.Add(book1);

                var kawabata = new Author {
                    Birthday = new DateTime(1899, 6, 14),
                    Gender = "M",
                    Name = "川端康成"
                };
                var book2 = new Book {
                    Title = "伊豆の踊子",
                    PublshedYear = 2003,
                    Author = kawabata
                };
                db.Books.Add(book2);
                db.SaveChanges();
            }
        }

        private static void Exercise1_2() {
            using (var db = new BooksDbContext()) {
                foreach (var book in db.Books.OrderBy(b => b.Author.Id)) {
                    Console.WriteLine("{0} {1} {2}({3:yyyy/MM/dd})",
                        book.Title, book.PublshedYear,
                        book.Author.Name, book.Author.Birthday
                    );
                }
            }
        }

        private static void Exercise1_3() {
            using (var db = new BooksDbContext()) {
                var books = db.Books
                              .Where(b => b.Title.Length == db.Books.Max(x => x.Title.Length));
                foreach (var book in books) {
                    Console.WriteLine("{0} {1} {2}({3:yyyy/MM/dd})",
                        book.Title, book.PublshedYear,
                        book.Author.Name, book.Author.Birthday
                    );
                }
            }
        }

        private static void Exercise1_4() {
            using (var db = new BooksDbContext()) {
                var books = db.Books
                              .OrderBy(b => b.PublshedYear)
                              .Take(3);
                foreach (var book in books) {
                    Console.WriteLine("{0} {1} {2}({3:yyyy/MM/dd})",
                        book.Title, book.PublshedYear,
                        book.Author.Name, book.Author.Birthday
                    );
                }
            }
        }

        private static void Exercise1_5() {
            using (var db = new BooksDbContext()) {
                var authors = db.Authors
                              .OrderByDescending(a => a.Birthday);
                foreach (var author in authors) {
                    Console.WriteLine("{0} {1:yyyy/MM}", author.Name, author.Birthday);
                    foreach (var book in author.Books)
                        Console.WriteLine("  {0} {1}",
                            book.Title, book.PublshedYear,
                            book.Author.Name, book.Author.Birthday
                    );
                    Console.WriteLine();
                }
            }
        }

        static IEnumerable<Book> GetBooks() {
            using (var db = new BooksDbContext()) {
                return db.Books
                         .Where(book => book.Author.Name.StartsWith("夏目"))
                         .ToList();
            }
        }

        static void InsertBooks() {
            using (var db = new BooksDbContext()) {
                var book1 = new Book {
                    Title = "坊ちゃん",
                    PublshedYear = 2003,
                    Author = new Author {
                        Birthday = new DateTime(1867, 2, 9),
                        Gender = "M",
                        Name = "夏目漱石"
                    }
                };
                db.Books.Add(book1);
                var book2 = new Book {
                    Title = "人間失格",
                    PublshedYear = 1990,
                    Author = new Author {
                        Birthday = new DateTime(1909, 6, 19),
                        Gender = "M",
                        Name = "太宰治"
                    }
                };
                db.Books.Add(book2);
                db.SaveChanges();
            }
        }

        private static void AddAuthors() {
            using (var db = new BooksDbContext()) {
                var author1 = new Author {
                    Birthday = new DateTime(1878, 12, 7),
                    Gender = "F",
                    Name = "与謝野晶子"
                };
                db.Authors.Add(author1);
                var author2 = new Author {
                    Birthday = new DateTime(1896, 8, 7),
                    Gender = "M",
                    Name = "宮沢賢治"
                };
                db.Authors.Add(author2);
                db.SaveChanges();
            }
        }

        private static void AddBooks() {
            using (var db = new BooksDbContext()) {
                var author1 = db.Authors.Single(a => a.Name == "与謝野晶子");
                var book1 = new Book {
                    Title = "みだれ髪",
                    PublshedYear = 2000,
                    Author = author1,
                };
                db.Books.Add(book1);
                var author2 = db.Authors.Single(a => a.Name == "宮沢賢治");
                var book2 = new Book {
                    Title = "銀河鉄道の夜",
                    PublshedYear = 1989,
                    Author = author2,
                };
                db.Books.Add(book2);
                db.SaveChanges();
            }
        }

    }
}
