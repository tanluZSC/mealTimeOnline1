using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MealTimeOnline.ViewModels.Auth
{
    public class SignUpViewModel
    {
        [DisplayName("用户名")]
        [Required(ErrorMessage = "用户名不能为空")]
        [MinLength(4, ErrorMessage = "用户名长度不能小于4位")]
        [MaxLength(32, ErrorMessage = "用户名长度不能大于32位")]
        [DataType(DataType.Text)]
        public string Username { get; set; }

        [DisplayName("密码")]
        [Required(ErrorMessage = "新密码不能为空")]
        [MinLength(6, ErrorMessage = "密码长度不能小于6位")]
        [MaxLength(32, ErrorMessage = "密码长度不能大于32位")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("确认密码")]
        [Required(ErrorMessage = "请再次输入密码")]
        [Compare("Password", ErrorMessage = "两次输入的密码不一致")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [DisplayName("联系电话")]
        [Required(ErrorMessage = "Phone Number不能为空")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [DisplayName("电子邮箱")]
        [Required(ErrorMessage = "Email 不能为空")]
        [EmailAddress(ErrorMessage = "Email 格式错误")]
        public string Email { get; set; }
    }
}