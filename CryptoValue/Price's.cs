using System;
using System.Threading.Tasks;
using Binance;
using BitfinexApi;
using BitforexAPI;
using BitmaxAPI;

namespace CryptoValue
{
    class Price
    {
        public async Task<decimal> ValueBinance()
        {
            var api = new BinanceApi();
            var answer = await api.GetExchangeRateAsync(Asset.ETH, Asset.BTC);
            Console.WriteLine($"Binance is {answer}");
            return answer;
        }

        public async Task<decimal> ValueBitfinex(string AskOrBid)
        {
            BitfinexApi.Assets assets = new BitfinexApi.Assets();
            Tickers bitfinexClient = new Tickers();

            decimal answer = bitfinexClient.Market(assets.ETH, assets.BTC, AskOrBid);
            Console.WriteLine($"Bitfinex is {AskOrBid} {answer}");
            return answer;
        }

        public async Task<decimal> ValueBitforex(string AskOrBid)
        {
            BitforexAPI.Assets assets = new BitforexAPI.Assets();
            BitforexClient bitforexClient = new BitforexClient();

            decimal answer = bitforexClient.Market(assets.ETH, assets.BTC, AskOrBid);
            Console.WriteLine($"Bitforex is {AskOrBid} {answer}");
            return answer;
        }

    }
}