using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealTimeOnline.Models.Dealer
{
    public enum RegisterState
    {
        [Display(Name = "审核中")]
        Padding,

        [Display(Name = "申请成功")]
        Accept,
       
        [Display(Name = "申请失败")]
        Deny
    }

    public class EnterRegister
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        [Display(Name = "申请时间")]
        public DateTime RegisterDate { get; set; }

        [Required]
        [StringLength(32768)]
        [Display(Name = "申请理由")]
        public string Context { get; set; }

        [Required]
        [Display(Name = "状态")]
        public RegisterState State { get; set; }
    }
}