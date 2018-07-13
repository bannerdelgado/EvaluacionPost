using ExampleWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleWebApi.ViewModel
{
    public class ResultViewModel
    {
        public User User { get; set; }
        public City City { get; set; }
        public List<Weather> Weather { get; set; }
    }
}