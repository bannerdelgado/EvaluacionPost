using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvaluacionPost.Models
{
    public class EditViewModel
    {
        public Post post { get; set; }
        public List<Category> category {get;set;}
    }
}