using System;
using System.Collections.Generic;
using System.Text;
using Binance;

namespace CryptoValue
{
    public class Withdraw
    {
        public void SendMoney(string WalletToSend)
        {
            switch (WalletToSend)
            {
                case "Binance":
                    BinanceApi binanceApi = new BinanceApi();
                    break;
                case "Bitfinex":
                    break;
                case "Bitforex":
                    break;
            }
        }
    }
}
