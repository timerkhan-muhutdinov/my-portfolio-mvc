using System;
using System.Collections.Generic;
using System.Text;

namespace MyPortfolioMvc.BLL.DTO.Post
{
    public class PostUpdateDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public string Meta { get; set; }

        public string UrlSlug { get; set; }

        public bool IsPublish { get; set; }
        public DateTime CreatedDate { get; set; }

        public DateTime? PostedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public DateTime? DeletedDate { get; set; }

        public decimal Price { get; set; }

        public string Rating { get; set; }
    }
}
