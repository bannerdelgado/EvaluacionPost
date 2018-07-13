using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ExampleWebApi.Models
{
    public class BookingContext:DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Weather> Weather { get; set; }
    }
}