using System;

namespace ConsoleLang.Lang
{
    public class LoopPrinter : MyPrinter
    {
        public void print()
        {
            // loop
            int i = 10;
            do
            {
                Console.WriteLine($"i = {i}");
                i--;
            } while (i > 0);

            for (int j = 0; j < 10; j++)
            {
                if (j % 3 == 0)
                {
                    Console.WriteLine($"j = {j}");
                }
            }
        }
    }
}