using System.ComponentModel.DataAnnotations;

namespace Admin.Models.Account
{
    public class ChangePasswordViewModel
    {
        [Required]
        public string ForgetToken { get; set; }

        [Required(ErrorMessage = "Xana bosh ola bilməz")]
        [MaxLength(50, ErrorMessage = "Parolunuz maximum 50 simvol olmalıdır")]
        [MinLength(6, ErrorMessage = "Parolunuz minimum 6 simvol olmalıdır")]
        public string Password { get; set; }
    }
}
