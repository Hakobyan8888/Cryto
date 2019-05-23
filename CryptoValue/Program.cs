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
            Bank1 bank1 = new Bank1();
            Bank2 bank2 = new Bank2();
            while (true)
            {
                bestValue.SmallestHighest("ask");
                bestValue.SmallestHighest("bid");
                best.MaxBid = bestValue.MaxValue;
                best.MinAsk = bestValue.MinValue;
                Console.WriteLine($"Maximal value is in and it's {best.MaxBid}");
                Console.WriteLine($"Minimal value is in and it's {best.MinAsk}");
                Console.WriteLine($"Difference is {(best.MaxBid - best.MinAsk) * 100 / best.MinAsk}%");
                decimal suspectedProfit = (best.MaxBid - best.MinAsk) / best.MinAsk;
                bestValue.MaxValue = 0;
                bestValue.MinValue = 0;
                Exchanges exchanges = new Exchanges();
                Console.WriteLine($"The balance in First Bank before switching {bank1.BTCBalance} && {bank1.ETHBalance}");
                Console.WriteLine($"The balance in Second Bank before switching {bank2.BTCBalance} && {bank2.ETHBalance}");
                Console.WriteLine($"The expected Profit is {exchanges.Checker(suspectedProfit)}");
                Console.WriteLine($"The full Balance before next transaction {bank1.BTCBalance + bank2.BTCBalance + (bank1.ETHBalance + bank2.ETHBalance) * 0.0315m}");
                if (exchanges.Checker(suspectedProfit) > 0)
                {
                    bank1.BuyBTC(best.MaxBid);
                    bank2.BuyETH(best.MinAsk);
                    bank1.SendMoney(bank2);
                    bank2.SendMoney(bank1);
                }
                Console.WriteLine($"The balance in First Bank after switching {bank1.BTCBalance} && {bank1.ETHBalance}");
                Console.WriteLine($"The balance in Second Bank after switching {bank2.BTCBalance} && {bank2.ETHBalance}");
                Console.WriteLine($"The full balance after transaction {bank1.BTCBalance + bank2.BTCBalance + (bank1.ETHBalance + bank2.ETHBalance) * 0.0315m}");
                Thread.Sleep(1500);
            }
        }
    }
}
