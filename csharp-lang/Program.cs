using System;

namespace csharp_lang
{
    internal class Program
    {
        /**
         * https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/
         */
        public static void Main(string[] args)
        {
            // string
            string aFriend = "aaric";
            int aFriendAge = 18;
            string greeting = $"     hello {aFriend}     ";
            //Console.Write("hello " + aFriend);
            Console.WriteLine($"My friend is {aFriend} and he is {aFriendAge} years old.");
            Console.WriteLine($"The name {aFriend} has {aFriend.Length} letters.");
            Console.WriteLine($"{greeting.TrimStart().ToUpper()}");
            Console.WriteLine($"{greeting.TrimEnd().ToLower()}");
            Console.WriteLine($"{greeting.Trim().Contains("hello")}");
            Console.WriteLine($"{greeting.Replace("hello", "goodbye")}");

            // number
            int a = 3, b = 4, c = 5;
            int intMin = int.MinValue;
            int intMax = int.MaxValue;
            double doubleMin = double.MinValue;
            double doubleMax = double.MaxValue;
            Console.WriteLine($"(a + b) * c = {(a + b) * c}");
            Console.WriteLine($"intMin={intMin}, intMax={intMax}");
            Console.WriteLine($"doubleMin={doubleMin}, doubleMax={doubleMax}");
            decimal e = 1.0M, f = 3.0M;
            decimal decimalMin = decimal.MinValue;
            decimal decimalMax = decimal.MaxValue;
            Console.WriteLine($"e / f = {e / f}");
            Console.WriteLine($"decimalMin={decimalMin}, decimalMax={decimalMax}");
            double radius = 2.50D, PI = Math.PI;
            Console.WriteLine($"PI * radius * radius = {PI * radius * radius}");

            // exit
            //Console.ReadKey();
        }
    }
}