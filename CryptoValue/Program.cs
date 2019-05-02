using System;
using System.Threading;

namespace CryptoValue
{
    class Program
    {
        static void Main(string[] args)
        {
            BestValue bestValue = new BestValue();
            while (true)
            {
                bestValue.SmallestHighest();
                Console.WriteLine($"Maximal value is in {bestValue._maxUrl} and it's {bestValue._maxValue}");
                Console.WriteLine($"Minimal value is in {bestValue._minUrl} and it's {bestValue._minValue}");
                Thread.Sleep(2000);
            }
        }
    }
}
