using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Uppgift_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var jsonString = GetJson("https://jsonplaceholder.typicode.com/posts/1").Result;

            Console.WriteLine(jsonString);

            var result = JsonConvert.DeserializeObject<JsonObject>(jsonString);

            Console.WriteLine(result.UserId);
            Console.WriteLine(result.Id);
            Console.WriteLine(result.Title);
            Console.WriteLine(result.Body);

            Console.ReadLine();
        }

        static Task<string> GetJson(string url)
        {
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync(url);
            var result = response.Result.Content.ReadAsStringAsync();
            
            return result;
        }

        public class JsonObject
        {
            public int UserId { get; set; }
            public int Id { get; set; }
            public string Title { get; set; }
            public string Body { get; set; }
        }
    }
}
