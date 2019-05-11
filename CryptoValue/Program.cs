using System;
using System.Threading;

namespace CryptoValue
{
    class Program
    {
        static void Main(string[] args)
        {
            BestValue bestValue = new BestValue();
            Best best = new Best();
            bestValue.SmallestHighest("ask");
            bestValue.SmallestHighest("bid");
            best.MaxBid = bestValue._maxValue;
            best.MinAsk = bestValue._minValue;
            Console.WriteLine($"Maximal value is in {bestValue._maxUrl} and it's {best.MaxBid}");
            Console.WriteLine($"Minimal value is in {bestValue._minUrl} and it's {best.MinAsk}");
            Thread.Sleep(2000);
        }
    }
}
