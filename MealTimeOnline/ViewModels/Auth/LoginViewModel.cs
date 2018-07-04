using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MealTimeOnline.ViewModels.Auth
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "用户名不能为空")]
        [DataType(DataType.Text)]
        [MaxLength(length: 100, ErrorMessage = "用户名长度不能超过100")]
        [DisplayName("用户名")]
        public string Username { get; set; }

        [Required(ErrorMessage = "密码不能为空")]
        [DataType(DataType.Password)]
        [MaxLength(length: 20, ErrorMessage = "密码长度不能超过20")]
        [DisplayName("密码")]
        public string Password { get; set; }

        [DisplayName("Remenber me")]
        public bool Remenber { get; set; }
    }
}