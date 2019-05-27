using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CryptoValue
{
    class RunProgram
    {
        BestValue bestValue = new BestValue();
        Best best = new Best();
        Bank1 bank1 = new Bank1();
        Bank2 bank2 = new Bank2();
        Exchanges exchanges = new Exchanges();

        public void Start()
        {
            while (true)
            {
                bestValue.SmallestHighest("ask");
                bestValue.SmallestHighest("bid");
                best.MaxBid = bestValue.MaxValue;
                best.MinAsk = bestValue.MinValue;
                best.MaxUrl = bestValue.MaxUrl;
                best.MinUrl = bestValue.MinUrl;
                
                decimal suspectedProfit = (best.MaxBid - best.MinAsk) / best.MinAsk;
                bestValue.MaxValue = 0;
                bestValue.MinValue = 0;

                Print(suspectedProfit);

                if (exchanges.Checker(suspectedProfit) > 0)
                {
                    bank1.BuyBTC(best.MaxBid);
                    bank2.BuyETH(best.MinAsk);
                    bank1.SendMoney(bank2);
                    bank2.SendMoney(bank1);
                }
                Print(suspectedProfit);
                Thread.Sleep(1500);
            }
        }
        public void Print(decimal suspectedProfit)
        {
            Console.WriteLine($"Maximal value is in {best.MaxUrl} and it's {best.MaxBid}");
            Console.WriteLine($"Minimal value is in {best.MinUrl} and it's {best.MinAsk}");
            Console.WriteLine();
            Console.WriteLine($"Difference is {(best.MaxBid - best.MinAsk) * 100 / best.MinAsk}%");
            Console.WriteLine();
            Console.WriteLine($"The expected Profit is {exchanges.Checker(suspectedProfit)}");
            Console.WriteLine($"The full Balance transaction {bank1.BTCBalance + bank2.BTCBalance + (bank1.ETHBalance + bank2.ETHBalance) * 0.0315m}");
            Console.WriteLine();
        } 
    }
}
