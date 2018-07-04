using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MealTimeOnline.Models.Common;
using MealTimeOnline.Models.Dealer;

namespace MealTimeOnline.Models.Consumer
{
    public enum Satisfaction
    {
        [Display(Name = "好评")]
        Positive,

        [Display(Name = "中评")]
        Moderate,

        [Display(Name = "差评")]
        Negative
    }

    public enum OrderStatus
    {
        [Display(Name = "待处理")]
        Pending,

        [Display(Name = "处理中")]
        Processing,

        [Display(Name = "订单完成")]
        Complete,

        [Display(Name = "取消订单")]
        Cancel
    }

    public enum PayStatus
    {
        [Display(Name = "待支付")]
        Pending,

        [Display(Name = "已支付")]
        Completed
    }

    public class Order
    {
        [Key]
        public long OrderId { get; set; } // 定单号

        [Display(Name = "订单号")]
        public string OrderIdentificationCode // 订单唯一表示符
            => $"{OrderTime:yyyyMMddHHmmssFFFFFF}{UserId%10000:D4}{CanteenId%10000:D4}{OrderId%10000:D4}";

        [Required(ErrorMessage = "下单时间不能为空")]
        [Display(Name = "下单时间")]
        public DateTime OrderTime { get; set; } // 下单时间

        [Display(Name = "订单完成时间")]
        public DateTime? ComplateTime { get; set; } // 订单完成时间

        [Display(Name = "订单状态")]
        [Required(ErrorMessage = "订单状态不能为空")]
        public OrderStatus OrderStatus { set; get; } // 订单状态（待处理、完成、退单）

        [Display(Name = "订单支付状态")]
        [Required(ErrorMessage = "支付状态不能为空")]
        public PayStatus PayStatus { get; set; } // 订单支付状态（完成支付、待支付）

        [Required(ErrorMessage = "支付方式不能为空")]
        public int PaymentId { set; get; } // 订单支付方式（微信、支付宝、校园卡，//（线上财富值））
        public virtual Payment Payment { get; set; }

        [Display(Name = "满意度")]
        public Satisfaction? Satisfaction { set; get; } // 满意度（好评、差评）

        [Display(Name = "评价")]
        public virtual ICollection<Evaluate> Evaluates { get; set; } // 评价(有的存具体评价，没有自动填充“待评价”)

        [Display(Name = "订单数量")]
        [Required(ErrorMessage = "订单数量不能为空")]
        public int OrderNum { set; get; } // 订单数量

        [Display(Name = "总价")]
        [Required(ErrorMessage = "订单总价不能为空")]
        public decimal SumPrice { get; set; } // 总价

        [Display(Name = "用户")]
        [ForeignKey("User")]
        [Required(ErrorMessage = "用户不能为空")]
        public int UserId { get; set; }
        public virtual User User { get; set; } // 一个订单对应一个用户

        [Display(Name = "食堂")]
        [ForeignKey("Canteen")]
        [Required(ErrorMessage = "食堂不能为空")]
        public int CanteenId { get; set; }
        public virtual Canteen Canteen { get; set; } // 一个订单对应一个食堂

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}