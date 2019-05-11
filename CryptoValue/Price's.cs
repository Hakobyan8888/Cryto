using System;
using System.Threading.Tasks;
using Binance;
using CoinEx.Net;
using HuobiLibrary;
using CEXLibrary;

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
        
        public async Task<decimal> ValueCoinEX(string AskOrBid)
        {
            var client = new CoinExClient();
            var result = await client.GetMarketStateAsync("ETHBTC");
            if (AskOrBid == "ask")
            {
                var answer = result.Data.Ticker.BestBuyPrice;
                Console.WriteLine($"CoinEX is ask {answer}");
                return answer;
            }
            else if(AskOrBid == "bid")
            {
                var answer = result.Data.Ticker.BestSellPrice;
                Console.WriteLine($"CoinEX is bid {answer}");
                return answer;
            }
            else
            {
                return 0;
            }
            
        }
        
        public async Task<decimal> ValueCEX(string AskOrBid)
        {
            CEXLibrary.Assets assets = new CEXLibrary.Assets();
            CEXClient CexClient = new CEXClient();

            decimal answer = CexClient.Market(assets.ETH, assets.BTC, AskOrBid);
            Console.WriteLine($"CEX is {AskOrBid} {answer}");
            return answer;
        }

        public async Task<decimal> ValueHuobi()
        {
            HuobiLibrary.Assets asset = new HuobiLibrary.Assets();
            HuobiClient huobiClient = new HuobiClient();

            decimal answer = huobiClient.Market(asset.ETH, asset.BTC);
            Console.WriteLine($"Huobi is {answer}");
            return answer;
        }

    }
}
