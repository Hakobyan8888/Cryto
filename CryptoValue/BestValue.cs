using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<Dictionary<decimal, string>> CallMethods()
        {
            var values = new Dictionary<decimal, string>();
            USDtoBTC UsdToBtc = new USDtoBTC();
            
            values.Add(await UsdToBtc.ValueBinance(), "binance.com");
            values.Add(await UsdToBtc.ValueCoinbase(), "coinbase.com");
            values.Add(await UsdToBtc.ValueBittrex(), "bittrex.com");
            values.Add(await UsdToBtc.ValueCoinEX(), "coinex.com");
            values.Add(await UsdToBtc.ValueLiquid(), "app.liquid.com");
            values.Add(await UsdToBtc.ValueCEX(), "cex.io");
            values.Add(await UsdToBtc.ValueHuobi(), "huobi.com");
            return values;
        }

        public void SmallestHighest()
        {
            var values = CallMethods();
            foreach (var i in values.Result)
            {
                if (_minValue == 0)
                {
                    _minValue = i.Key;
                    _minUrl = i.Value;
                }
                if (_maxValue < i.Key)
                {
                    _maxValue = i.Key;
                    _maxUrl = i.Value;
                }
                if (_minValue > i.Key)
                {
                    _minValue = i.Key;
                    _minUrl = i.Value;
                }
            }
        }
    }
}
