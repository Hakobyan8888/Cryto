using System;
using System.Threading.Tasks;
using Binance;
using BitbankAPI;
using BitfinexAPI;
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
            BitfinexAPI.Assets assets = new BitfinexAPI.Assets();
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

        public async Task<decimal> ValueBitmax(string AskOrBid)
        {
            BitmaxAPI.Assets assets = new BitmaxAPI.Assets();
            BitmaxClient bitmaxClient = new BitmaxClient();

            decimal answer = bitmaxClient.Market(assets.ETH, assets.BTC, AskOrBid);
            Console.WriteLine($"Bitmax is {AskOrBid} {answer}");
            return answer;
        }

        public async Task<decimal> ValueBitbank(string AskOrBid)
        {
            BitbankAPI.Assets assets = new BitbankAPI.Assets();
            BitbankClient bitbankClient = new BitbankClient();

            decimal answer = bitbankClient.Market(assets.ETH, assets.BTC, AskOrBid);
            Console.WriteLine($"Bitbank is {AskOrBid} {answer}");
            return answer;
        }

    }
}
