using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MealTimeOnline.Models.Commodity;
using MealTimeOnline.Models.Dealer;

namespace MealTimeOnline.Models.Consumer
{
    public class OrderItem
    {
        [Key, ForeignKey("User"), Column(Order = 1)]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Key, ForeignKey("Canteen"), Column(Order = 2)]
        public int CanteenId { get; set; }
        public virtual Canteen Canteen { get; set; }

        [Key, ForeignKey("Food"), Column(Order = 3)]
        public long FoodId { get; set; }
        public virtual Food Food { get; set; }

        [Key, ForeignKey("Order"), Column(Order = 4)]
        public long OrderId { get; set; }
        public virtual Order Order { get; set; }

        [Display(Name = "单价")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Display(Name = "商品数量")]
        public int Count { get; set; }
    }
}