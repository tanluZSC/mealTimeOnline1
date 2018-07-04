using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MealTimeOnline.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            FormsAuthenticationTicket token = new FormsAuthenticationTicket(0, "LiuACG", DateTime.Now, DateTime.Now.AddHours(1), true, "LiuACG", FormsAuthentication.FormsCookiePath);
            var token_ = FormsAuthentication.Encrypt(token);
            return Content(token_);
        }
    }
}