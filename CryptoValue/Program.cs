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
            while (true)
            {
                bestValue.SmallestHighest("ask");
                bestValue.SmallestHighest("bid");
                best.MaxBid = bestValue.MaxValue;
                best.MinAsk = bestValue.MinValue;
                Console.WriteLine($"Maximal value is in {bestValue.MaxUrl} and it's {best.MaxBid}");
                Console.WriteLine($"Minimal value is in {bestValue.MinUrl} and it's {best.MinAsk}");
                Console.WriteLine($"Difference is {(best.MaxBid - best.MinAsk) * 8177}");
                Thread.Sleep(10000);
            }
        }
    }
}
