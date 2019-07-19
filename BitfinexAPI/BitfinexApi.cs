using System;
using System.Text;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace BitfinexApi
{
    public class BitfinexApiV1
    {
        private DateTime epoch = new DateTime(1970, 1, 1);

        private HMACSHA384 hashMaker; 
        private string Key;
        private int nonce = 0;
        private string Nonce
        {
            get
            {
                if (nonce == 0)
                {
                    nonce = (int)(DateTime.UtcNow - epoch).TotalSeconds;
                }
                return (nonce++).ToString();
            }
        }
        public BitfinexApiV1(string key, string secret)
        {
            hashMaker = new HMACSHA384(Encoding.UTF8.GetBytes(secret));
            this.Key = key;
        }

        public BitfinexApiV1()
        {
        }

        private String GetHexString(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes)
            {
                sb.Append(String.Format("{0:x2}", b));
            }
            return sb.ToString();
        }
        public async Task<BalancesResponse> GetBalancesAsync()
        {
            BalancesRequest req = new BalancesRequest(Nonce);
            string response = await SendRequestAsync(req,"GET");
            BalancesResponse resp = BalancesResponse.FromJSON(response);

            return resp;
        }
        public async Task<CancelOrderResponse> CancelOrderAsync(int order_id)
        {
            CancelOrderRequest req = new CancelOrderRequest(Nonce, order_id);
            string response = await SendRequestAsync(req,"POST");
            CancelOrderResponse resp = CancelOrderResponse.FromJSON(response);
            return resp;
        }
        public async Task<CancelAllOrdersResponse> CancelAllOrdersAsync()
        {
            CancelAllOrdersRequest req = new CancelAllOrdersRequest(Nonce);
            string response = await SendRequestAsync(req,"GET");
            return new CancelAllOrdersResponse(response);
        }
        public async Task<OrderStatusResponse> GetOrderStatusAsync(int order_id)
        {
            OrderStatusRequest req = new OrderStatusRequest(Nonce, order_id);
            string response = await SendRequestAsync(req, "POST");
            return OrderStatusResponse.FromJSON(response);
        }
        public async Task<ActiveOrdersResponse> GetActiveOrdersAsync()
        {
            ActiveOrdersRequest req = new ActiveOrdersRequest(Nonce);
            string response = await SendRequestAsync(req, "POST");
            return ActiveOrdersResponse.FromJSON(response);
        }
        public async Task<ActivePositionsResponse> GetActivePositionsAsync()
        {
            ActivePositionsRequest req = new ActivePositionsRequest(Nonce);
            string response = await SendRequestAsync(req, "POST");
            return ActivePositionsResponse.FromJSON(response);
        }

        public async Task<NewOrderResponse> ExecuteBuyOrderAsync(decimal amount, decimal price, OrderExchange exchange, OrderSymbol symbol, OrderType type)
        {
            return await ExecuteOrder(amount, price, exchange, symbol, OrderSide.Buy, type);
        }
        public async Task<NewOrderResponse> ExecuteSellOrderAsync(decimal amount, decimal price, OrderExchange exchange, OrderSymbol symbol, OrderType type)
        {
            return await ExecuteOrder(amount, price, exchange, symbol, OrderSide.Sell, type);
        }
        public async Task<NewOrderResponse> ExecuteOrder(decimal amount, decimal price, OrderExchange exchange, OrderSymbol symbol, OrderSide side, OrderType type)
        {
            NewOrderRequest req = new NewOrderRequest(Nonce, symbol, amount, price, exchange, side, type);
            string response = await SendRequestAsync(req,"POST");
            NewOrderResponse resp = NewOrderResponse.FromJSON(response);
            return resp;
        }

        private async Task<string> SendRequestAsync(GenericRequest request,string httpMethod)
        {
            string json = JsonConvert.SerializeObject(request);
            string json64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));
            byte[] data = Encoding.UTF8.GetBytes(json64);
            byte[] hash = hashMaker.ComputeHash(data);
            string signature = GetHexString(hash);

            HttpWebRequest wr = WebRequest.Create("https://api.bitfinex.com"+request.request) as HttpWebRequest;
            wr.Headers.Add("X-BFX-APIKEY", Key);
            wr.Headers.Add("X-BFX-PAYLOAD", json64);
            wr.Headers.Add("X-BFX-SIGNATURE", signature);
            wr.Method = httpMethod;
            
            string response = null;
            try
            {
                HttpWebResponse resp = wr.GetResponse() as HttpWebResponse;
                StreamReader sr = new StreamReader(resp.GetResponseStream());
                response = await sr.ReadToEndAsync();
                sr.Close();
            }
            catch (WebException ex)
            {
                StreamReader sr = new StreamReader(ex.Response.GetResponseStream());
                response = sr.ReadToEnd();
                sr.Close();
                throw new BitfinexException(ex, response);
            }
            return response;
        }
    }
}
