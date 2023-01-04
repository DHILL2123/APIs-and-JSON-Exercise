using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace APIsAndJSON
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            var kanyeURL = "https://api.kanye.rest";

            var kanyeResponse = client.GetStringAsync(kanyeURL).Result;
            var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();

            Console.WriteLine(kanyeQuote);
            Console.WriteLine();


            var ronUrl = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";

            for (int i = 0; i < 5; i++)
            {

                var ronResponse = client.GetStringAsync(ronUrl).Result;
                var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();

                kanyeResponse = client.GetStringAsync(kanyeURL).Result;
                kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();

                
                Console.WriteLine($"Ron: {ronQuote}");
                Console.WriteLine($"Kanye: {kanyeQuote}");
                Console.WriteLine($"---------------------");

            }
        }
            
    }


}
   
   


