using Repository.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Admin.Models.News
{
    public class NewsViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public bool Comment { get; set; }
        public bool SoftDeleted { get; set; }
        public int CategoryId { get; set; }
        public string VideoLink { get; set; }

        public ICollection<NewsPhotoViewModel> Photos { get; set; }
        public Category Category { get; set; }
    }
}
