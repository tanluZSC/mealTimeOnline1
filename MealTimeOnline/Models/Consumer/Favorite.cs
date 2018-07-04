using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MealTimeOnline.Models.Commodity;
using MealTimeOnline.Models.Dealer;

namespace MealTimeOnline.Models.Consumer
{
    public class Favorite
    {
        [Key]
        public int CollectionId { set; get; }

        [ForeignKey("Canteen")]
        [Required(ErrorMessage = "餐厅信息不能为空")]
        public int RestaurantId { set; get; } // 收藏餐厅（食堂）编号
        public virtual Canteen Canteen { get; set; } //  一个收藏对应一个餐厅

        [ForeignKey("Food")]
        [Required(ErrorMessage = "商品信息不能为空")]
        public long FoodId { set; get; } // 收藏菜品编号
        public virtual Food Food { get; set; } //  一个收藏对应一个商品

        [ForeignKey("User")]
        [Required(ErrorMessage = "用户信息不能为空")]
        public int UserId { get; set; }
        public virtual User User { get; set; } // 一个收藏对应一个用户
    }
}