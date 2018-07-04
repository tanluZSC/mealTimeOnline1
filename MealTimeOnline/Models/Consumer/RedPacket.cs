using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealTimeOnline.Models.Consumer
{
    public class RedPacket
    {
        [Key]
        public long RedPacketId { get; set; }

        [Display(Name = "使用期限")]
        [DataType(DataType.Date)]
        [DisplayFormat(NullDisplayText = "不限期", DataFormatString = "{0:截至日期 yyyy-MM-dd}")]
        public DateTime? Deadline { get; set; }

        [Required(ErrorMessage = "必须设置金额")]
        [Display(Name = "金额")]
        public decimal Money { get; set; }

        [ForeignKey("User")]
        [Display(Name = "用户名")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}