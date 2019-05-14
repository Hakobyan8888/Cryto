using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoValue
{
    class BestValue
    {
        public string MaxUrl { get; set; }
        public string MinUrl { get; set; }
        public decimal MaxValue { get; set; }
        public decimal MinValue { get; set; }

        public BestValue()
        {
            MinValue = 0;
            MaxValue = 0;
        }

        public async Task<Dictionary<decimal, string>> CallMethods(string cases)
        {
            var values = new Dictionary<decimal, string>();
            Price price = new Price();
            try
            {
                values.Add(await price.ValueBinance(), "binance.com");
                values.Add(await price.ValueCoinEX(cases), "coinex.com");
                values.Add(await price.ValueCEX(cases), "cex.io");

                if (cases == "bid")
                {
                    values.Add(await price.ValueHuobi(), "huobi.com");
                }
            }
            catch(Exception ex)
            {
                
            }
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
                        MinValue = i.Key;
                        MinUrl = i.Value;
                    }
                    if (MinValue > i.Key)
                    {
                        MinValue = i.Key;
                        MinUrl = i.Value;
                    }
                }
            }
            if (cases == "bid")
            {
                foreach (var i in values.Result)
                {
                    if (MaxValue < i.Key)
                    {
                        MaxValue = i.Key;
                        MaxUrl = i.Value;
                    }
                }
            }
        }

        public void

    }
}
