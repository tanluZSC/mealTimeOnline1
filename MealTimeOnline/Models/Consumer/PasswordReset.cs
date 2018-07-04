using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MealTimeOnline.Models.Consumer
{
    public class PasswordReset
    {
        [Key, ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [EmailAddress]
        [StringLength(256)]
        [Display(Name = "密码找回邮箱")]
        [Required(ErrorMessage = "邮箱地址不能为空")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Token 不能为空")]
        [StringLength(512)]
        public string Token { get; set; }

        [Required(ErrorMessage = "创建时间不能为空")]
        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }
    }
}
