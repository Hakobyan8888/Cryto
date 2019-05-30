using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoValue
{
    class BestValue
    {
        public decimal MaxValue { get; set; }
        public decimal MinValue { get; set; }
        public string MaxUrl { get; set; }
        public string MinUrl { get; set; }

        public BestValue()
        {
            MinValue = 0;
            MaxValue = 0;
        }

        public async Task<List<Tuple<decimal, string>>> CallMethods(string cases)
        {
            var values = new List<Tuple<decimal, string>>();
            Price price = new Price();
            values.Add(Tuple.Create(await price.ValueBinance(), "Binance"));
            values.Add(Tuple.Create(await price.ValueBitfinex(cases), "Bitfinex"));
            values.Add(Tuple.Create(await price.ValueBitforex(cases), "Bitforex"));

            return values;
        }

        public void SmallestHighest(string cases)
        {
            var values = CallMethods(cases);
            if (cases == "ask")
            {
                foreach (var i in values.Result)
                {
                    if (MinValue == 0)
                    {
                        MinValue = i.Item1;
                        MinUrl = i.Item2;
                    }
                    if (MinValue > i.Item1)
                    {
                        MinValue = i.Item1;
                        MinUrl = i.Item2;
                    }
                }
            }
            if (cases == "bid")
            {
                foreach (var i in values.Result)
                {
                    if (MaxValue < i.Item1)
                    {
                        MaxValue = i.Item1;
                        MaxUrl = i.Item2;
                    }
                }
            }
        }

    }
}
