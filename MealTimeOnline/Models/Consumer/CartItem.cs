using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MealTimeOnline.Models.Commodity;
using MealTimeOnline.Models.Dealer;

namespace MealTimeOnline.Models.Consumer
{
    public class CartItem
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

        [Display(Name = "商品数量")]
        public int Count { get; set; }

        public virtual Cart Cart { get; set; }
    }
}