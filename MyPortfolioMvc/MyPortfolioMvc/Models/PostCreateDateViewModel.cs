using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolioMvc.Models
{
    public class PostCreateDateViewModel
    {
        public List<Post> Posts { get; set; }
        public SelectList CreateDates { get; set; }
        public string PostCreateDate { get; set; }
        public string SearchString { get; set; }
    }
}
