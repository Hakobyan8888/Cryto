using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HuobiLibrary;

namespace CryptoValue
{
    class BestValue
    {
        public string _maxUrl { get; set; }
        public string _minUrl { get; set; }
        public decimal _maxValue { get; set; }
        public decimal _minValue { get; set; }
                
                
        public BestValue()
        {
            _minValue = 0;
            _maxValue = 0;
        }



        public async Task<Dictionary<decimal, string>> CallMethods(string cases)
        {
            var values = new Dictionary<decimal, string>();
            Price price = new Price();

            values.Add(await price.ValueBinance(), "binance.com");
            values.Add(await price.ValueCoinEX(cases), "coinex.com");
            values.Add(await price.ValueCEX(cases), "cex.io");
            if (cases == "bid")
            {
                values.Add(await price.ValueHuobi(), "huobi.com");
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
                    if (_minValue == 0)
                    {
                        _minValue = i.Key;
                        _minUrl = i.Value;
                    }
                    if (_minValue > i.Key)
                    {
                        _minValue = i.Key;
                        _minUrl = i.Value;
                    }
                }
            }
            if (cases == "bid")
            {
                foreach (var i in values.Result)
                {
                    if (_maxValue < i.Key)
                    {
                        _maxValue = i.Key;
                        _maxUrl = i.Value;
                    }
                }
            }
        }
    }
}
