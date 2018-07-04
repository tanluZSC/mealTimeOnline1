using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MealTimeOnline.ViewModels.Order;
using MealTimeOnline.Models.Consumer;

namespace MealTimeOnline.ViewModels.Order
{
    public class CheckOutViewModel
    {
        public CartViewModel cartVm { get; set; } //购物车
        public decimal ServicePrice { get; set; } //配送费
        public decimal TotalPrice { get; set; } //总价
        //收货地址,付款方式. 未完成
    }
}