using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MealTimeOnline.Models.Consumer;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MealTimeOnline.ViewModels.Account
{
    #region 订单视图模型
    public class OrderViewModel
    {
        public List<OrderItem> Orders { get; set; } //订单列表
    }
    #endregion
}