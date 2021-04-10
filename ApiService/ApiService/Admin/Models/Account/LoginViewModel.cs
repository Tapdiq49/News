using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Control.Models.Account
{
    public class LoginViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "E-poçt vacibdir")]
        [EmailAddress(ErrorMessage = "Düzgün e-poçt daxil edin")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Şifrə vacibdir")]
        [MinLength(6, ErrorMessage = "Şifrə ən azı 6 xarakter ola bilər")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        public bool RememberMe { get; set; }
    }
}
