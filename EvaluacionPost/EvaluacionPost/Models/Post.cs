using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvaluacionPost.Models
{
    public class Post
    {
        public int id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public DateTime date { get; set; }
        public Category category{ get; set; }
    }
}