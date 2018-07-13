using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExampleWebApi.Models
{
    public class City
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [JsonProperty(PropertyName ="id")]
        public string CityId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Country { get; set; }
    }
}