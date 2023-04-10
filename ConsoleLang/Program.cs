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
            MyPrinter myPrinter = null;
            string clazz = typeof(JsonPrinter).Name;
            switch (clazz)
            {
                case "StringPrinter":
                    myPrinter = new StringPrinter();
                    break;
                case "NumberPrinter":
                    myPrinter = new NumberPrinter();
                    break;
                case "LoopPrinter":
                    myPrinter = new LoopPrinter();
                    break;
                case "ListPrinter":
                    myPrinter = new ListPrinter();
                    break;
                case "ObjectPrinter":
                    myPrinter = new ObjectPrinter();
                    break;
                case "JsonPrinter":
                    myPrinter = new JsonPrinter();
                    break;
                case "HttpClientPrinter":
                    myPrinter = new HttpClientPrinter();
                    break;
                case "FilePrinter":
                    myPrinter = new FilePrinter();
                    break;
                default:
                    Console.WriteLine("Error: Not found!");
                    break;
            }

            if (null != myPrinter)
            {
                myPrinter.print();
            }

            // exit
            //Console.ReadKey();
        }
    }
}