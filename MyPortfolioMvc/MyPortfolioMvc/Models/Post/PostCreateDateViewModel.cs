using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MyPortfolioMvc.Models.Post
{
    public class PostCreateDateViewModel
    {
        public List<PostFilterViewModel> Posts { get; set; }
        public SelectList CreateDates { get; set; }
        public string PostCreateDate { get; set; }
        public string SearchString { get; set; }
    }
}
