﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace BitfinexApi
{
    public enum OrderType
    {
        MarginMarket,
        MarginLimit,
        MarginStop,
        MarginTrailingStop
    }
    public enum OrderSide
    {
        Buy,
        Sell
    }
    public enum OrderExchange
    {
        Bitfinex,
        Bitstamp,
        All
    }
    public enum OrderSymbol
    {
        ETHBTC,
        BTCETH,
    }
    public class NewOrderRequest:GenericRequest
    {
        public string symbol;
        public string amount;
        public string price;
        public string exchange;
        public string side;
        public string type;

        public NewOrderRequest(string nonce, OrderSymbol symbol, decimal amount, decimal price, OrderExchange exchange, OrderSide side, OrderType type)
        {
            this.symbol = EnumHelper.EnumToStr(symbol);
            this.amount = amount.ToString(CultureInfo.InvariantCulture);
            this.price = price.ToString(CultureInfo.InvariantCulture);
            this.exchange = EnumHelper.EnumToStr(exchange);
            this.side = EnumHelper.EnumToStr(side);
            this.type = EnumHelper.EnumToStr(type);
            this.nonce = nonce;
            this.request = "/v1/order/new";
        }
    }
    public class EnumHelper
    {
        private static Dictionary<object, string> enumStr = null;
        private static Dictionary<object, string> Get()
        {
            if (enumStr == null)
            {
                enumStr = new Dictionary<object, string>();
                enumStr.Add(OrderSymbol.BTCETH, "btceth");
                enumStr.Add(OrderSymbol.ETHBTC, "ethbtc");

                enumStr.Add(OrderExchange.All, "all");
                enumStr.Add(OrderExchange.Bitfinex, "bitfinex");
                enumStr.Add(OrderExchange.Bitstamp, "bitstamp");

                enumStr.Add(OrderSide.Buy, "buy");
                enumStr.Add(OrderSide.Sell, "sell");

                enumStr.Add(OrderType.MarginLimit, "exchange limit");
                enumStr.Add(OrderType.MarginMarket, "exchange market");
                enumStr.Add(OrderType.MarginStop, "exchange stop");
                enumStr.Add(OrderType.MarginTrailingStop, "exchange trailing-stop");
            }
            return enumStr;
        }

        public static string EnumToStr(object enumItem)
        {
            return Get()[enumItem];
        }
    }
}
