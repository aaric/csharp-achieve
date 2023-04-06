using System;

namespace ConsoleLang.Lang
{
    public class StringPrinter : MyPrinter
    {
        public void print()
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
        }
    }
}