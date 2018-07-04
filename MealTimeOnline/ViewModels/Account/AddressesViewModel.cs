using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MealTimeOnline.Models.Consumer;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MealTimeOnline.ViewModels.Account
{
    #region 地址视图模型
    public class AdderssesViewModel
    {
        [DisplayName("位置")]
        public string rIndex { get; set; }

        [DisplayName("详细地址")]
        public string rLongIndex { get; set; }
    }
    #endregion
}