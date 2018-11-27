using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IdentityServerMvc.Models.AccountViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [DisplayName("邮箱")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DisplayName("密码")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DisplayName("确认密码")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}