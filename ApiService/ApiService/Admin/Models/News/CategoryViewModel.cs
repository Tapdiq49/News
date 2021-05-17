using System.ComponentModel.DataAnnotations;

namespace Admin.Models.News
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required]
        public bool SoftDeleted { get; set; }

        [Required(ErrorMessage = "Kategoriya adı vacibdir")]
        [MaxLength(50, ErrorMessage = "Kategoriya adı maximum 50 xarakter ola bilər")]
        public string Name { get; set; }
    }
}
