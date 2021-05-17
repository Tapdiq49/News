using Repository.Enums;
using System.ComponentModel.DataAnnotations;

namespace Admin.Models.Manager
{
    public class AdminViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad və soyad vacibdir")]
        [MaxLength(50,ErrorMessage = "Ad və soyad maximum 50 xarakter ola bilər")]
        public string Fullname { get; set; }

        [Required(ErrorMessage = "E-poçt ünvan vacibdir")]
        [MaxLength(50, ErrorMessage = "E-poçt ünvan maximum 50 xarakter ola bilər")]
        [EmailAddress(ErrorMessage = "Düzgün e-poçt ünvan daxil edin")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Şifrə vacibdir")]
        [MaxLength(100, ErrorMessage = "Şifrə maximum 100 xarakter ola bilər")]
        [MinLength(6, ErrorMessage = "Şifrə minimum 6 xarakter ola bilər")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Rolunu seçmək vacibdir")]
        public ManagerType Type { get; set; }
    }
}
