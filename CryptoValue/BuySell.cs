using System;
using System.Threading.Tasks;
using Binance;
using BitforexAPI;
using BitfinexApi;

namespace CryptoValue
{
    class BuySell
    {
        public async Task BinanceBuySell(string BuyOrSell)
        {
            var api = new BinanceApi();
            if (await api.PingAsync())
            {
                Console.WriteLine("Successfull");
                switch (BuyOrSell)
                {
                    case "buy":
                        using (var user = new BinanceApiUser("yIruCEm5k2TkExflzSf183xBp4HUt66G2BDx6WJqlL7HATRyJmcgp5UAiqYl0XsF", "BEqWhtDUPDIpNmaHFxA5ZhXLElcS74oal6yHLEx5sbE5gu46EsYLAfWAx1veyUr0"))
                        {
                            // Create a client (MARKET) order.
                            var clientOrder = new MarketOrder(user)
                            {
                                Symbol = Symbol.ETH_BTC,
                                Side = Binance.OrderSide.Buy,
                                Quantity = 1m
                            };

                            try
                            {
                                // Send the TEST order.
                                await api.PlaceAsync(clientOrder);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"TEST Order Failed: \"{e.Message}\"");
                            }
                            WithdrawRequest withdrawRequest = new WithdrawRequest(user)
                            {
                                Address = "",
                                Amount = 2,
                                Asset = Asset.ETH,
                            };
                            await api.WithdrawAsync(withdrawRequest);

                        }
                        break;
                    case "sell":
                        using (var user = new BinanceApiUser("yIruCEm5k2TkExflzSf183xBp4HUt66G2BDx6WJqlL7HATRyJmcgp5UAiqYl0XsF", "BEqWhtDUPDIpNmaHFxA5ZhXLElcS74oal6yHLEx5sbE5gu46EsYLAfWAx1veyUr0"))
                        {
                            WithdrawRequest withdrawRequest = new WithdrawRequest(user)
                            {
                                Address = "",
                                Amount = 2,
                                Asset = Asset.BTC,
                            };
                            // Create a client (MARKET) order.
                            var clientOrder = new MarketOrder(user)
                            {
                                Symbol = Symbol.ETH_BTC,
                                Side = Binance.OrderSide.Sell,
                                Quantity = 1m
                            };

                            try
                            {
                                // Send the TEST order.
                                await api.PlaceAsync(clientOrder);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"TEST Order Failed: \"{e.Message}\"");
                            }
                            await api.WithdrawAsync(withdrawRequest);
                        }
                        break;
                }
            }
        }

        public async Task Bitforex(string BuyOrSell)
        {
            Assets assets = new Assets();
            var user = new BitforexClient("yIruCEm5k2TkExflzSf183xBp4HUt66G2BDx6WJqlL7HATRyJmcgp5UAiqYl0XsF", "BEqWhtDUPDIpNmaHFxA5ZhXLElcS74oal6yHLEx5sbE5gu46EsYLAfWAx1veyUr0");
            Console.WriteLine("Successfull");
            switch (BuyOrSell)
            {
                case "buy":
                    await user.ExecuteOrder(assets.ETH, assets.BTC, "ask", 1000, 1, 2);
                    break;
                case "sell":
                    await user.ExecuteOrder(assets.ETH, assets.BTC, "sell", 1000, 1, 2);
                    break;
            }
        }

        public async Task Bitfinex(string BuyOrSell)
        {
            BitfinexAssets assets = new BitfinexAssets();
            var user = new BitfinexApiV1("yIruCEm5k2TkExflzSf183xBp4HUt66G2BDx6WJqlL7HATRyJmcgp5UAiqYl0XsF", "BEqWhtDUPDIpNmaHFxA5ZhXLElcS74oal6yHLEx5sbE5gu46EsYLAfWAx1veyUr0");
            Console.WriteLine("Successfull");
            switch (BuyOrSell)
            {
                case "buy":
                    await user.ExecuteBuyOrderAsync(1000, 1, OrderExchange.Bitfinex, OrderSymbol.ETHBTC, BitfinexApi.OrderType.MarginMarket);
                    break;
                case "sell":
                    await user.ExecuteSellOrderAsync(1000, 1, OrderExchange.Bitfinex, OrderSymbol.ETHBTC, BitfinexApi.OrderType.MarginMarket);
                    break;
            }
        }
    }
}
