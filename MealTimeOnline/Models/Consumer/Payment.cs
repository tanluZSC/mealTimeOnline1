using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MealTimeOnline.Models.Consumer
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        [Display(Name = "支付类型名称")]
        [Required(ErrorMessage = "支付类型名称不能为空")]
        [StringLength(128, ErrorMessage = "支付类型名称长度不能超过128位")]
        public string Name { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}