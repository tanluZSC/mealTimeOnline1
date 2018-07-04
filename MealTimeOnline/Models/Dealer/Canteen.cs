using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MealTimeOnline.Models.Commodity;
using MealTimeOnline.Models.Common;
using MealTimeOnline.Models.Consumer;

namespace MealTimeOnline.Models.Dealer
{
    // 主要用于展示给顾客，用于选择
    public class Canteen
    {
        // 商家基础信息
        [Key]
        public int CanteenId { get; set; } // 食堂编号（唯一）

        [Display(Name = "名称")]
        [StringLength(128)]
        public string CanteenName { get; set; } // 食堂名称

        [Display(Name = "地址")]
        [StringLength(1024)]
        public string CanteenAddress { get; set; } // 食堂地址

        [Display(Name = "分类")]
        public int? CanteenCategoryId { get; set; } // 食堂分类
        public virtual CanteenCategory CanteenCategory { get; set; }

        [Display(Name = "配送价格")]
        public decimal ServicePrice { get; set; } // 食堂配送价格

        [Display(Name = "介绍")]
        [StringLength(2048)]
        public string CanteenInfo { get; set; } // 食堂介绍

        [Display(Name = "配送方式")]
        [StringLength(256)]
        public string SendWay { get; set; } // 食堂配送方式

        [Display(Name = "营业时间")]
        [StringLength(256)]
        public string ShopHours { get; set; } // 形如：12：00-13：00 // 营业时间

        [Display(Name = "商家公告")]
        [StringLength(2048)]
        public string Notice { get; set; } // 商家公告

        // 基于用户评价的商家信息
        [Display(Name = "平均配餐时间")]
        public TimeSpan UseTime { get; set; } // 食堂平均配餐时间（分钟）

        [Display(Name = "平均打分")]
        [Range(typeof(decimal), "0", "5")]
        public decimal EvaluateNum { get; set; } // 食堂平均打分

        [Display(Name = "月销售量")]
        public int SellNum { get; set; } // 食堂月销售量

        [Display(Name = "图片")]
        public string Images { get; set; } // 一个食堂对应多个图片, 用Json数组保存图片地址

        public virtual List<Food> Foods { get; set; } // 一个食堂对应多个菜
        public virtual ICollection<Order> Orders { get; set; } // 一个食堂对应多个订单
        public virtual ICollection<Evaluate> Evaluates { get; set; } // 一个食堂对应多个评价
    }
}