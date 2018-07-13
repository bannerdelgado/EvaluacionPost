using ExampleWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleWebApi.ViewModel
{
    public class BookingViewModel
    {
        public User User { get; set; }
        public List <City> City { get; set; }
    }
}
