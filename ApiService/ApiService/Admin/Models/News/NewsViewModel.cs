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

        [Required(ErrorMessage = "Başlığ vacibdir")]
        [MaxLength(50, ErrorMessage = "Başlığ maximum 50 xarakter ola bilər")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Mətn vacibdir")]
        [MinLength(1, ErrorMessage = "Başlığ maximum 50 xarakter ola bilər")]
        public string Text { get; set; }

        [Required]
        public bool Comment { get; set; }
        public bool SoftDeleted { get; set; }

        [Required(ErrorMessage = "Kategoriya vacibdir")]
        public int CategoryId { get; set; }
        public string VideoLink { get; set; }

        [Required(ErrorMessage = "Şəkil vacibdir")]
        public IList<NewsPhotoViewModel> Photos { get; set; }
        public Category Category { get; set; }
    }
}
