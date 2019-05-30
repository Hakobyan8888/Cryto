using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace BitforexAPI
{
    public class BitforexClient
    {
        internal string AccessKey { get; set; }
        internal string SecretKey { get; set; }
        NewOrder newOrder = new NewOrder();

        public BitforexClient() { }


        public BitforexClient(string accessKey, string secretKey)
        {
            this.AccessKey = accessKey;
            this.SecretKey = secretKey;
        }

        public decimal Market(string FirstCrypto, string SecondCrypto, string AskOrBid)
        {
            decimal value = 0;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.bitforex.com/api/v1/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync($"market/ticker?symbol=coin-{SecondCrypto}-{FirstCrypto}").Result;
            if (response.IsSuccessStatusCode && AskOrBid == "ask")
            {
                var products = response.Content.ReadAsStringAsync().Result;
                JObject jObject = JObject.Parse(products);
                value = (decimal)jObject["data"]["sell"];
            }
            else if (response.IsSuccessStatusCode && AskOrBid == "bid")
            {
                var products = response.Content.ReadAsStringAsync().Result;
                JObject jObject = JObject.Parse(products);
                value = (decimal)jObject["data"]["buy"];
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return value;
        }

        public void ExecuteOrder(string FirstCrypto, string SecondCrypto, string AskOrBid, decimal price, decimal amount, int tradeType)
        {
            newOrder.Buy(FirstCrypto, SecondCrypto, AskOrBid, price, amount, tradeType, AccessKey, SecretKey);
        }

    }

}
