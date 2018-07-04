using System.ComponentModel.DataAnnotations;

namespace MealTimeOnline.Models.Consumer
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }

        [Required(ErrorMessage = "地址信息不能为空")]
        [StringLength(256, ErrorMessage = "地址长度不能超过256")]
        public string AddressInfo { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}