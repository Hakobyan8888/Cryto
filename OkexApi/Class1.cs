using RestEase;
using System;

namespace OkexApi
{
    public class Class1
    {
        public static void Main()
        {
            var api = RestClient.For<IOkexAPI>("https://www.okex.com");
            api.GetUserAsync("asdasd");
        }

    }
}
