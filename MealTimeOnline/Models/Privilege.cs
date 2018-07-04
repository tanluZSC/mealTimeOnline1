using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealTimeOnline.Models
{
    public class Privilege
    {
        [Key]
        public int PrivilegeId { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

        [StringLength(64)]
        public string PrivilegeKey { get; set; }
    }
}