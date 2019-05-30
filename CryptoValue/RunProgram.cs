using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using BitfinexApi;

namespace CryptoValue
{
    class RunProgram
    {
        BestValue bestValue = new BestValue();
        Best best = new Best();
        Bank1 bank1 = new Bank1();
        Bank2 bank2 = new Bank2();
        Exchanges exchanges = new Exchanges();
        BitfinexApiV1 bitfinexApiV1 = new BitfinexApiV1("qGG4G9RNeqKx56s0J5bSjl3EYUwGsIBa3to6hKiVCtj", "AYICh3OUrI0Pry9QeplPC7zZWPS0UUlEQP4MSUKYmac");
        BuySell buySell = new BuySell();

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
                    switch (best.MinUrl)
                    {
                        case "Binance":
                            buySell.Binance("buy").Wait();
                            break;
                        case "Bitfinex":
                            Console.WriteLine(bitfinexApiV1.ExecuteBuyOrder(0.01m, 100, OrderExchange.Bitfinex, OrderSymbol.ETHBTC, OrderType.MarginMarket));
                            break;
                        case "Bitforex":
                            buySell.Bitforex("buy");
                            break;
                    }
                    switch (best.MaxUrl)
                    {
                        case "Binance":
                            buySell.Binance("sell").Wait();
                            break;
                        case "Bitfinex":
                            Console.WriteLine(bitfinexApiV1.ExecuteSellOrder(0.01m, 100, OrderExchange.Bitfinex, OrderSymbol.ETHBTC, OrderType.MarginMarket));
                            break;
                        case "Bitforex":
                            buySell.Bitforex("sell");
                            break;
                    }
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
