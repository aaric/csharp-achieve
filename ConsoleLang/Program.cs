using System;
using System.IO;
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
            string clazz = typeof(ObjectPrinter).Name;
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
                case "ListPrinter":
                    ListPrinter.print();
                    break;
                case "ObjectPrinter":
                    ObjectPrinter.print();
                    break;
                default:
                    Console.WriteLine("Error: Not found!");
                    break;
            }

            // exit
            //Console.ReadKey();
        }
    }
}