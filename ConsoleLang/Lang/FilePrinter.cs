using System;
using System.IO;
using System.Text;

namespace ConsoleLang.Lang
{
    public class FilePrinter : MyPrinter
    {
        public void print()
        {
            string path = @"E:\test_file\mytext.txt";

            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine("hello world");
                    sw.WriteLine("hello microsoft");
                    sw.WriteLine("hello c");
                    sw.WriteLine("hello cpp");
                    sw.WriteLine("hello csharp");
                }

                string content = File.ReadAllText(path, Encoding.UTF8);
                Console.WriteLine($"{content}");

                int index = 0;
                using (StreamReader sr = new StreamReader(path))
                {
                    while (sr.Peek() >= 0)
                    {
                        index++;
                        Console.WriteLine($"{index}: {sr.ReadLine()}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e);
            }
        }
    }
}