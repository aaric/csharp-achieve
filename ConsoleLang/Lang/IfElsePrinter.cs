using System;

namespace ConsoleLang.Lang
{
    public class IfElsePrinter
    {
        public static void print()
        {
            // if else
            string greeting = $"hello world";
            if (greeting.Contains("hello") && greeting.Length > 10)
            {
                Console.WriteLine("You are right!");
            }
            else
            {
                Console.WriteLine("You are wrong!");
            }
        }
    }
}