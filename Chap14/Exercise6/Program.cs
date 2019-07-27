using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise6 {
    class Program {
        static void Main(string[] args) {

            // ローカル時刻(日本の時刻)を得る
            var local = new DateTime(2020, 8, 10, 16, 32, 20, DateTimeKind.Local);
            // DateTimeOffsetに変換する
            var date = new DateTimeOffset(local);

            var utc = date.ToUniversalTime();
            Console.WriteLine(utc);
            // "Singapore Standard Time"の時刻に変換する
            DateTimeOffset sst = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(date, "Singapore Standard Time");
            Console.WriteLine(sst);
        }
    }
}
