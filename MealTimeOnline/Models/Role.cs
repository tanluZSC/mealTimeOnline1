using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MealTimeOnline.Models
{
    // 角色不提供删除
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required]
        [StringLength(128)]
        [Display(Name = "Role")]
        public string Name { get; set; } // 角色名

        [Display(Name = "Slug")]
        [Required]
        [StringLength(128)]
        [RegularExpression(@"^(\w+)$", ErrorMessage = "缩略名只能用由英文组成")]
        public string Slug { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Privilege> Privileges { get; set; }
    }
}
