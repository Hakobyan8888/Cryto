using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace BitforexAPI
{
    public class NewOrder
    {
        HttpResponseMessage response = null;

        internal void Buy(string FirstCrypto, string SecondCrypto, string AskOrBid,decimal price, decimal amount, int tradeType, string accessKey, string secretKey)
        {
            long nonce = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            string signedKey = ComputeSha256Hash(secretKey);
            HttpClient client = new HttpClient();
            
            client.BaseAddress = new Uri("https://api.bitforex.com/api/v1/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            response.EnsureSuccessStatusCode();
            response = client.GetAsync($"trade/placeOrder?accessKey={accessKey}&amount={amount}&nonce={nonce}&price={price}&symbol=coin-{SecondCrypto}-{FirstCrypto}&tradeType={tradeType}&signData={signedKey}").Result;
            Console.WriteLine(response);
        }

        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
