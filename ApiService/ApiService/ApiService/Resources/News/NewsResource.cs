﻿using Repository.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Resources.News
{
    public class NewsResource
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public bool Comment { get; set; }
        public int CategoryId { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }
        public ICollection<NewsPhoto> Photos { get; set; }
        public int View { get; set; }
        public string VideoLink { get; set; }
        public Category Category { get; set; }

    }
}
