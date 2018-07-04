using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MealTimeOnline.DataAccessLayer;
using MealTimeOnline.Models.Consumer;
using MealTimeOnline.Models.Dealer;
using MealTimeOnline.ViewModels.Order;
using MealTimeOnline.Models.Commodity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MealTimeOnline.Controllers
{
    #region 餐厅展示，下单控制器
    [Authorize]
    public class OrderController : Controller
    {
        MtoDataContext db = new MtoDataContext();
        public static CartViewModel cartVm = new CartViewModel();

        #region 餐厅展示
        // GET: Order/Canteen
        [HttpGet]
        public ActionResult Canteen()
        {
            cartVm.orders = new List<OrderViewModel>();
            CanteenViewModel canteenVm = new CanteenViewModel();
            canteenVm.canteen = db.Canteens.ToList(); //从数据库中获取餐厅数据，并初始化视图模型
            return View("Canteen", canteenVm);
        }
        #endregion

        //[HttpPost]
        //public void Canteen(string BtnSubmit)
        //{
        //    if (BtnSubmit == "CheckOut")
        //    {
        //        CheckOut(cartVm);
        //    }
        //}

        #region 点餐触发事件
        // POST: Order/Modify
        [HttpPost]
        public void Modify(string id, string cnt)//所点食物的id和数量cnt
        {
            cartVm.canteenId = db.Foods.Find(int.Parse(id)).CanteenId;
            if (id != string.Empty && cnt != string.Empty)
            {
                bool flag = false;
                for (int i = 0; i < cartVm.orders.Count; i++)
                {
                    if (int.Parse(id) == cartVm.orders[i].FoodId)
                    {
                        if (int.Parse(cnt) == 0)
                        {
                            cartVm.orders.RemoveAt(i);
                        }
                        else
                        {
                            cartVm.orders[i].cnt = int.Parse(cnt);
                        }
                        flag = true;
                        break;
                    }
                }
                if (flag == false)
                {
                    OrderViewModel item = new OrderViewModel();
                    item.FoodId = int.Parse(id); item.cnt = int.Parse(cnt);
                    cartVm.orders.Add(item);
                }
            }
        }
        #endregion

        #region 结算Action
        // POST: Order/CheckOut
        [HttpPost]
        public ActionResult CheckOut()
        {
            CheckOutViewModel checkVm = new CheckOutViewModel();
            checkVm.cartVm = cartVm;
            checkVm.TotalPrice = 0;
            checkVm.ServicePrice = db.Canteens.Find(cartVm.canteenId).ServicePrice;
            foreach (OrderViewModel item in cartVm.orders) //总计每个顶点的总计
            {
                checkVm.TotalPrice += item.cnt * db.Foods.Find(item.FoodId).Price;
            }
            checkVm.TotalPrice += checkVm.ServicePrice; //总计加上配送费
            return View("CheckOut", checkVm);
        }
        #endregion

        #region 结算提交
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Submit(string orders)
        {
            CheckOutViewModel data = System.Web.Helpers.Json.Decode<CheckOutViewModel>(orders);

            int canteenId = data.cartVm.canteenId;
            int userId = int.Parse(HttpContext.User.Identity.Name);

            // Create order
            Order order = new Order
            {
                CanteenId = canteenId,
                OrderNum = data.cartVm.orders.Count,
                OrderTime = DateTime.Now,
                PaymentId = db.Payments.First().PaymentId,
                OrderStatus = OrderStatus.Pending,
                SumPrice = data.TotalPrice,
                UserId = userId
            };
            db.Orders.Add(order);
            db.SaveChanges();

            // Create order items
            foreach (var item in data.cartVm.orders)
            {
                OrderItem oi = new OrderItem
                {
                    CanteenId = canteenId,
                    UserId = userId,
                    Count = item.cnt,
                    FoodId = item.FoodId,
                    OrderId = order.OrderId,
                    Price = db.Foods.Find(item.FoodId).Price * item.cnt
                };
                db.OrderItems.Add(oi);
            }
            db.SaveChanges();

            return RedirectToAction("Index", "Account");
        }
        #endregion
    }
    #endregion
}