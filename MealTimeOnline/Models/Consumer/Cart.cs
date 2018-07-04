using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MealTimeOnline.Models.Dealer;

namespace MealTimeOnline.Models.Consumer
{
    public class Cart
    {
        [Key]
        public long CarId { get; set; }

        //一个购物车产品对应一个用户
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Canteen")]
        public int CanteenId { get; set; }
        public virtual Canteen Canteen { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}