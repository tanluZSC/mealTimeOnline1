using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MealTimeOnline.Models.Common;
using MealTimeOnline.Models.Consumer;
using MealTimeOnline.Models.Dealer;

namespace MealTimeOnline.Models.Commodity
{
    public class Food
    {
        [Key]
        public long FoodId { get; set; } // 菜品id

        [Display(Name = "菜品分类表")]
        public int? FoodCategoryId { get; set; } // 菜品分类
        public virtual FoodCategory FoodCategory { get; set; }

        [Display(Name = "适合人群")]
        public int? PeopleCategoryId { get; set; } // 适合人群//最好做成选择列表
        public virtual PeopleCategory PeopleCategory { get; set; }

        [Display(Name = "名称")]
        [Required(ErrorMessage = "名称不能为空")]
        [StringLength(128)]
        public string FoodName { get; set; } // 名称

        [Required(ErrorMessage = "价格不能为空")]
        [Display(Name = "价格")]
        [Range(typeof(decimal), "0", "99999999", ErrorMessage = "价格范围[0, 99999999]")]
        public decimal Price { get; set; } // 价格

        [Display(Name = "折扣")]
        [Range(typeof(decimal), "0", "1", ErrorMessage = "折扣范围[0.00, 1.00]")]
        public decimal? Discount { get; set; } // 折扣

        [Display(Name = "成分")]
        [Required(ErrorMessage = "成分不能为空")]
        [StringLength(512, ErrorMessage = "长度不能超过512位")]
        public string FoodElement { get; set; } // 成分

        [Display(Name = "营养价值")]
        [StringLength(512, ErrorMessage = "长度不能超过512位")]
        public string FoodNutrition { get; set; } // 营养价值

        [Required(ErrorMessage = "食堂不能为空")]
        [ForeignKey("Canteen")]
        public int CanteenId { get; set; }
        public virtual Canteen Canteen { get; set; } // 一个菜对应一个食堂

        [Display(Name = "图片")]
        public string Images { get; set; } // 一个菜对应多个图, 用Json数组保存图片地址

        public virtual ICollection<Evaluate> Evaluates { get; set; } // 一个菜对应多个评价
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
    }
}