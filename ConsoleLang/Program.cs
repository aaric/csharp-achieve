using System;
using ConsoleLang.Lang;

namespace ConsoleLang
{
    internal class Program
    {
        /**
         * https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/
         */
        public static void Main(string[] args)
        {
            string clazz = typeof(LoopPrinter).Name;
            switch (clazz)
            {
                case "StringPrinter":
                    StringPrinter.print();
                    break;
                case "NumberPrinter":
                    NumberPrinter.print();
                    break;
                case "LoopPrinter":
                    LoopPrinter.print();
                    break;
                default:
                    Console.WriteLine("Error: No class found!");
                    break;
            }

            // exit
            //Console.ReadKey();
        }
    }
}