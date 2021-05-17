using System.ComponentModel.DataAnnotations;

namespace Admin.Models.About
{
    public class AboutViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Başlıq məcburidir")]
        [MaxLength(150, ErrorMessage = "Başlıq maximum 150 xarakter ola bilər!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Mətn məcburidir")]
        public string Text { get; set; }
    }
}
