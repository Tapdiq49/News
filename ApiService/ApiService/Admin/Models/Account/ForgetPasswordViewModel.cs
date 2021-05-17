using System.ComponentModel.DataAnnotations;

namespace Admin.Models.Account
{
    public class ForgetPasswordViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "E-poçt vacibdir")]
        [EmailAddress(ErrorMessage = "Düzgün e-poçt daxil edin")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
