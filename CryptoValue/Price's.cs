using System;
using System.Threading.Tasks;
using Binance;
using CoinEx.Net;
using BitforexLibrary;
using CEXLibrary;
using BitfinexLibrary;

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
            BitfinexLibrary.Assets assets = new BitfinexLibrary.Assets();
            BitfinexClient bitfinexClient = new BitfinexClient();

            decimal answer = bitfinexClient.Market(assets.ETH, assets.BTC, AskOrBid);
            Console.WriteLine($"Bitfinex is {AskOrBid} {answer}");
            return answer;
        }

        public async Task<decimal> ValueBitforex(string AskOrBid)
        {
            BitforexLibrary.Assets assets = new BitforexLibrary.Assets();
            BitforexClient bitforexClient = new BitforexClient();

            decimal answer = bitforexClient.Market(assets.ETH, assets.BTC, AskOrBid);
            Console.WriteLine($"Bitforex is {AskOrBid} {answer}");
            return answer;
        }

    }
}
