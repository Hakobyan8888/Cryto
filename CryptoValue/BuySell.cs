using System;
using Binance;
using System.Threading.Tasks;

namespace CryptoValue
{
    class BuySell
    {
        public async Task Binance(string buy)
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
                                Side = OrderSide.Buy,
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
                                Side = OrderSide.Sell,
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
        public void Bitbank()
        {

        }
        public void Bitforex()
        {

        }
        public void Bitmax()
        {

        }
    }
}
