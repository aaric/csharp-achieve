using System;

namespace ConsoleLang.Lang
{
    public class NumberPrinter
    {
        public static void print()
        {
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
        }
    }
}