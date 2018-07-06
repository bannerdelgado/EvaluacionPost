using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvaluacionPost.Models
{
    public class Comment
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime date { get; set; }
        public string text { get; set; }
    }
}