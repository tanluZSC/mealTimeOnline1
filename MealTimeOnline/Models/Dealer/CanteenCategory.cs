using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MealTimeOnline.Models.Dealer
{
    public class CanteenCategory
    {
        [Key]
        public int CanteenCategoryId { get; set; }

        [Display(Name = "分类名称")]
        [Required(ErrorMessage = "分类不能为空")]
        [StringLength(64, ErrorMessage = "分类名称长度不能超过64位")]
        public string Value { get; set; }

        public ICollection<Canteen> Canteens { get; set; }
    }
}