using AutoMapper;
using ExampleWebApi.Models;
using ExampleWebApi.TransferObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ExampleWebApi.Controllers
{
    public class CityController : ApiController
    {
        private BookingContext context;

        public CityController()
        {

            context = new BookingContext();
        }

        [HttpGet]
        public IEnumerable<City> GetAll()
        {
            string content = Task.Run(GetCities).Result;

            List<City> cities = JsonConvert.DeserializeObject<List<City>>(content);

            return cities;
        }

        [HttpPost]
        public City Create(City city)
        {
            var cities = context.City.Add(city);
            context.SaveChanges();
            return cities;
        }

        public static async Task<string> GetCities()
        {
            string url = "http://middleware-neoris.s3-website-us-west-1.amazonaws.com/";

            HttpClient Client = new HttpClient();

            string content = await Client.GetStringAsync(url);

            return content;

        }


        

    }
}
