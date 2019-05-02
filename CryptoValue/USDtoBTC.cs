using System;
using System.Threading.Tasks;
using Binance;
using Bittrex.Net;
using Coinbase;
using CoinEx.Net;
using LiquidQuoine.Net;
using Nextmethod.Cex;
using Alex75.Cryptocurrencies;
using Alex75.BitstampApiClient;
using HuobiLibrary;

namespace CryptoValue
{
    class USDtoBTC
    {

        public async Task<decimal> ValueBinance()
        {
            var api = new BinanceApi();
            var answer = await api.GetExchangeRateAsync(Asset.BTC, Asset.USDC);
            Console.WriteLine($"Binance is {answer}");
            return answer;
        }

        public async Task<decimal> ValueCoinbase()
        {
            var client = new CoinbaseClient();
            var value = await client.Data.GetSpotPriceAsync("BTC-USD");
            decimal answer = value.Data.Amount;
            Console.WriteLine($"Coinbase is {answer}");
            return answer;
        }

        public async Task<decimal> ValueBittrex()
        {
            var client = new BittrexClient();
            var priceResult = await client.GetTickerAsync("USD-BTC");
            decimal answer = priceResult.Data.Last;
            Console.WriteLine($"Bittrex is {answer}");
            return answer;
        }

        public async Task<decimal> ValueCoinEX()
        {
            var client = new CoinExClient();
            var result = await client.GetMarketStateAsync("BTCTUSD");
            var answer = result.Data.Ticker.Last;
            Console.WriteLine($"CoinEX is {answer}");
            return answer;
        }

        public async Task<decimal> ValueLiquid()
        {
            var client = new LiquidQuoineClient();
            var orderBookByProductId = await client.GetOrderBookAsync(1);
            var answer = orderBookByProductId.Data.BuyPriceLevels[0].Price;
            Console.WriteLine($"Liquid is {answer}");
            return answer;
        }

        public async Task<decimal> ValueCEX()
        {
            CexApi cexClient = new CexApi();
            var ticker = await cexClient.Ticker(SymbolPair.BTC_USD);
            var answer = ticker.Last;
            Console.WriteLine($"CEX is {answer}");
            return answer;
        }

        public async Task<decimal> ValueHuobi()
        {
            Assets assets = new Assets();
            HuobiClient huobiClient = new HuobiClient();

            decimal answer = huobiClient.Market(assets.BTC, assets.USD);
            Console.WriteLine($"Huobi is {answer}");
            return answer;
        }

    }
}
