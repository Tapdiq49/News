using System.ComponentModel.DataAnnotations;

namespace Admin.Models.Contact
{
    public class ContactViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Nomrə məcburidir")]
        [MaxLength(50, ErrorMessage = "Nomrə maksimum 50 xarakter ola bilər")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Ünvan məcburidir")]
        [MaxLength(50, ErrorMessage = "Ünvan maksimum 50 xarakter ola bilər")]
        public string Address { get; set; }

        [Required(ErrorMessage = "E-poçt məcburidir")]
        [MaxLength(50, ErrorMessage = "E-poçt maksimum 50 xarakter ola bilər")]
        public string Email { get; set; }
    }
}
