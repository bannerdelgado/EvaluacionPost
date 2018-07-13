using ExampleWebApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {


            string content = Task.Run(GetData).Result;


            List<City> cities = JsonConvert.DeserializeObject<List<City>>(content);

            foreach (var city in cities)
            {
                Console.WriteLine("------------------");
                

            }
            Console.ReadKey();
        }


        private static async Task<string> GetData()
        {
            string url = "https://jsonplaceholder.typicode.com/posts";

            HttpClient Client = new HttpClient();

            string content = await Client.GetStringAsync(url);

            return content;

        }
    }
}
