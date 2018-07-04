using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MealTimeOnline.Models.Common;
using MealTimeOnline.Models.Consumer;
using MealTimeOnline.Models.Dealer;

namespace MealTimeOnline.Models
{
    public enum Sex
    {
        [Display(Name = "保密")]
        None,

        [Display(Name = "男")]
        Male,

        [Display(Name = "女")]
        Female
    }

    public class User
    {
        [Key]
        public int Id { get; set; } // 用户编号

        [Required]
        [Index(IsUnique = true)]
        [StringLength(64, MinimumLength = 4)]
        public string Username { get; set; } // 用户名

        [Required]
        [DataType(DataType.Password)]
        [StringLength(64, MinimumLength = 4)]
        public string Password { get; set; } // 密码

        [Display(Name = "Banded")]
        [Required(ErrorMessage = "IsBanded不能为空")]
        public bool IsBanded { get; set; }

        [StringLength(512)]
        [DataType(DataType.ImageUrl)]
        public string Avatar { set; get; } // 头像

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { set; get; } // 电话

        [StringLength(256)]
        [EmailAddress]
        [Index(IsUnique = true)]
        public string Email { set; get; } // 邮箱

        [StringLength(256)]
        public string RoomNum { set; get; } // 房号.主要用于区分片区，方便进一步地推送菜品

        [StringLength(256)]
        public string School { set; get; } // 学校

        [StringLength(64)]
        public string Number { set; get; } // 学号

        [Required]
        public Sex Sex { set; get; } // 性别

        [Range(0, 200)]
        public int Age { set; get; } // 年龄

        [StringLength(1024)]
        public string FoodLike { set; get; } // (口味偏好，复选框, Json)

        #region 以下为财富值
        [StringLength(64)]
        public string CardNumber { get; set; } // 用户校园卡号

        [DataType(DataType.Currency)]
        public decimal Money { get; set; } // 在线余额

        public int Credits { get; set; } // 积分
        #endregion // 财富值

        [Display(Name = "Role")]
        [Required(ErrorMessage = "必须选择权限")]
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

        public virtual ICollection<Address> Addresses { get; set; } // 一个用户有多个地址
        public virtual ICollection<Favorite> Favorites { get; set; } // 一个用户有多个收藏
        public virtual ICollection<Order> Orders { get; set; } // 一个用户有多个订单
        public virtual ICollection<Cart> Carts { get; set; } // 一个用户有多个购物车(每个商家一个)
        public virtual ICollection<Evaluate> Evaluates { get; set; } // 一个用户有多个评价
        public virtual ICollection<RedPacket> RedPackets { get; set; } // 一个用户有多个红包

        public virtual PasswordReset PasswordReset { get; set; }

        public virtual ICollection<EnterRegister> Registers { get; set; } // 一个用户有多个申请
    }
}