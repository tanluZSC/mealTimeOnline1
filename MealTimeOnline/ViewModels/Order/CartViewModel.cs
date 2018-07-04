using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MealTimeOnline.ViewModels.Order
{
    #region 订单视图模型
    public class OrderViewModel
    {
        public int FoodId { get; set; } //食物id
        public int cnt { get; set; } //食物数量
    }
    #endregion

    #region 购物车视图模型
    public class CartViewModel
    {
        public int canteenId { get; set; } //餐厅id
        public List<OrderViewModel> orders { get; set; } //订单列表
    }
    #endregion
}