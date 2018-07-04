using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MealTimeOnline.Models.Commodity;
using MealTimeOnline.Models.Dealer;

namespace MealTimeOnline.Models.Common
{
    public enum EvaluateCategory
    {
        [Display(Name = "服务")]
        Service,

        [Display(Name = "菜品")]
        Goods,

        [Display(Name = "综合")]
        Comprehensive
    }

    public class Evaluate
    {
        [Key]
        public int EvaluateId { set; get; }

        [Display(Name = "评价分类")]
        [Required(ErrorMessage = "评价分类不能为空")]
        public EvaluateCategory Category { set; get; } // 1、服务 2、菜品 3、综合评价

        [Display(Name = "分数")]
        [Required(ErrorMessage = "分数不能为空")]
        [Range(0, 5, ErrorMessage = "分数应在[0, 5]之间")]
        public int Star { get; set; }

        [Display(Name = "点评")]
        [StringLength(140, ErrorMessage = "点评长度不能超过140位")]
        public string EvaluateContent { set; get; }

        [Display(Name = "用户")]
        [Required(ErrorMessage = "用户不能为空")]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; } // 一个评价对应一个用户

        [Display(Name = "餐厅")]
        [Required(ErrorMessage = "餐厅不能为空")]
        [ForeignKey("Canteen")]
        public int CanteenId { set; get; }
        public virtual Canteen Canteen { get; set; } // 一个评价对应一个食堂 

        public long? FoodId { get; set; } // 仅在 分类为 菜品 时有效
        public virtual Food Food { get; set; }
    }
}