using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IdentityServerMvc.Models.AccountViewModel
{
    public class LoginViewModel
    {
        [Required]
        [DisplayName("邮箱")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DisplayName("密码")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("记住我?")]
        public bool RememberMe { get; set; }
    }
}