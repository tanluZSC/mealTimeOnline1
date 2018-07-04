using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MealTimeOnline.ViewModels.Auth
{
    public class ModifypwViewModel
    {
        [Required(ErrorMessage = "用户名不能为空")]
        [DataType(DataType.Text)]
        [MaxLength(length: 100, ErrorMessage = "用户名长度不能超过100")]
        [DisplayName("用户名")]
        public string Username { get; set; }

        [DisplayName("旧的密码")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "密码不能为空")]
        public string oldPassword { get; set; }

        [DisplayName("新的密码")]
        [Required(ErrorMessage = "新密码不能为空")]
        [MinLength(6, ErrorMessage = "密码长度不能小于6位")]
        [MaxLength(32, ErrorMessage = "密码长度不能大于32位")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DisplayName("确认密码")]
        [Required(ErrorMessage = "请再次输入密码")]
        [Compare("NewPassword", ErrorMessage = "两次输入的密码不一致")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}