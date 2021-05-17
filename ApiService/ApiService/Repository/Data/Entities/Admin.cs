using Repository.Enums;
using System.ComponentModel.DataAnnotations;

namespace Repository.Data.Entities
{
    public class Admin : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Fullname { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string Password { get; set; }

        [MaxLength(50)]
        public string Token { get; set; }

        [MaxLength(50)]
        public string ForgetToken { get; set; }

        [Required]
        public ManagerType Type { get; set; }
    }
}
