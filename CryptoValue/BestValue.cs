using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoValue
{
    class BestValue
    {
        public decimal MaxValue { get; set; }
        public decimal MinValue { get; set; }

        public BestValue()
        {
            MinValue = 0;
            MaxValue = 0;
        }

        public async Task<List<decimal>> CallMethods(string cases)
        {
            var values = new List<decimal>();
            Price price = new Price();
            values.Add(await price.ValueBinance());
            values.Add(await price.ValueBitfinex(cases));
            values.Add(await price.ValueBitforex(cases));
            //values.Add(await price.ValueCoinEX(cases));
            //values.Add(await price.ValueCEX(cases));

            //if (cases == "bid")
            //{
            //    values.Add(await price.ValueHuobi());
            //}
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
                        MinValue = i;
                    }
                    MinValue = Math.Min(MinValue, i);
                }
            }
            if (cases == "bid")
            {
                foreach (var i in values.Result)
                {
                    MaxValue = Math.Max(MaxValue, i);
                }
            }
        }

    }
}
