﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolioMvc.Models.Post
{
    public class PostUpdateViewModel
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public string Meta { get; set; }

        public string UrlSlug { get; set; }

        public bool IsPublish { get; set; }

        [Display(Name = "Created Date")]
        [Required]
        public DateTime CreatedDate { get; set; }

        public DateTime? PostedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public DateTime? DeletedDate { get; set; }

        // TODO: deleted field
        public decimal Price { get; set; }

        // TODO: deleted field
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$"), StringLength(5)]
        public string Rating { get; set; }
    }
}
