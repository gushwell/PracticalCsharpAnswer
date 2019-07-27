using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise1.Model;  // 1.1.3

namespace Exercise1 {
    class Program {
        static void Main(string[] args) {
            // 1.1.1
            var dorayaki = new Product(98, "どら焼き", 210);
            // 1.1.2
            var tax = dorayaki.GetTax();
            Console.WriteLine($"{tax}円");
        }
    }

}
