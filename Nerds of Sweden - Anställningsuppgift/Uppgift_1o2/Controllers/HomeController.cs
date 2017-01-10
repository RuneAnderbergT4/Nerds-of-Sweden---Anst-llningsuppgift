using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Uppgift_1o2.Models;

namespace Uppgift_1o2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var jsonString = GetJson("https://jsonplaceholder.typicode.com/posts/1").Result;
            
            var result = JsonConvert.DeserializeObject<JSONPlaceholderObject>(jsonString);

            ViewBag.JSONString = jsonString;
            
            ViewBag.Result = result;

            ViewBag.Title = "JSON";

            return View();
        }

        public Task<string> GetJson(string url)
        {
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync(url);
            var result = response.Result.Content.ReadAsStringAsync();

            return result;
        }
    }
}