using System;
using System.Threading.Tasks;
using Binance;
using BitforexAPI;

namespace CryptoValue
{
    class BuySell
    {
        public async Task BinanceBuySell(string buy)
        {
            var api = new BinanceApi();
            if (await api.PingAsync())
            {
                Console.WriteLine("Successfull");
                switch (buy)
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
                        }
                        break;
                    case "sell":
                        using (var user = new BinanceApiUser("yIruCEm5k2TkExflzSf183xBp4HUt66G2BDx6WJqlL7HATRyJmcgp5UAiqYl0XsF", "BEqWhtDUPDIpNmaHFxA5ZhXLElcS74oal6yHLEx5sbE5gu46EsYLAfWAx1veyUr0"))
                        {
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
                        }
                        break;
                }
            }
        }

        public void Bitforex(string BuySell)
        {
            Assets assets = new Assets();
            var user = new BitforexClient("yIruCEm5k2TkExflzSf183xBp4HUt66G2BDx6WJqlL7HATRyJmcgp5UAiqYl0XsF", "BEqWhtDUPDIpNmaHFxA5ZhXLElcS74oal6yHLEx5sbE5gu46EsYLAfWAx1veyUr0");
            Console.WriteLine("Successfull");
            switch (BuySell)
            {
                case "buy":
                    user.ExecuteOrder(assets.ETH, assets.BTC, "ask", 1000, 1, 1);
                    break;
                case "sell":
                    user.ExecuteOrder(assets.ETH, assets.BTC, "ask", 1000, 1, 2);
                    break;
            }
        }

        public void Bitfinex(string BuySell)
        {
            
        }
    }
}
