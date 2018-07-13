using AutoMapper;
using ExampleWebApi.Models;
using ExampleWebApi.TransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExampleWebApi.Controllers
{
    public class WeatherController : ApiController
    {
        private BookingContext context;

        public WeatherController()
        {
            context = new BookingContext();
        }


        [HttpGet]
        public IEnumerable<WeatherDTO> GetAll()
        {
            var weather = context.Weather;

            var weatherDTO = Mapper.Map<IEnumerable<Weather>, IEnumerable<WeatherDTO>>(weather);

            return weatherDTO;

        }


        [HttpGet]
        public IHttpActionResult GetWeather(int id)
        {
            var weather = context.Weather.Find(id);

            if (weather == null)
                NotFound();

            return Ok(Mapper.Map<Weather, WeatherDTO>(weather));
        }

        [HttpPost]
        public IHttpActionResult Create(WeatherDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var weather = Mapper.Map<WeatherDTO, Weather>(dto);

            context.Weather.Add(weather);
            context.SaveChanges();

            dto.id = weather.id;

            return Created(new Uri($"{Request.RequestUri}/{weather.id}"), dto);
        }
    }
}
