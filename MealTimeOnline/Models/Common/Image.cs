using System.ComponentModel.DataAnnotations;

namespace MealTimeOnline.Models.Common
{
    public enum ImageCategory
    {
        [Display(Name = "未分类")]
        None,

        [Display(Name = "食物")]
        Food,

        [Display(Name = "食堂")]
        Canteen
    }

    public class Image
    {
        [Key]
        public int ImageId { get; set; }

        [Required(ErrorMessage = "分类不能为空")]
        public ImageCategory Category { get; set; }

        [Required(ErrorMessage = "图片路径不能为空")]
        [DataType(DataType.ImageUrl)]
        public string ImagePath { get; set; }
    }
}