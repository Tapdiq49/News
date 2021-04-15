using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
