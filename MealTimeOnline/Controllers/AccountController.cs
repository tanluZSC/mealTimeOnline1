using System.Linq;
using System.Web.Mvc;
using MealTimeOnline.ViewModels.Auth;
using MealTimeOnline.ViewModels.Account;
using MealTimeOnline.DataAccessLayer;
using System.Web.Security;
using MealTimeOnline.Models;
using MealTimeOnline.Models.Consumer;

namespace MealTimeOnline.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        MtoDataContext db = new MtoDataContext();
        // GET: Account/Index
        public ActionResult Index()
        {
            return View();
        }

        // GET: Account/Info
        public ActionResult Info()
        {
            return View();
        }

        // GET: Accoutn/Security
        public ActionResult Security()
        {
            return View();
        }

        // GET: Account/Modifypassword
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Modifypassword()
        {
            return View();
        }

        // Post: Account/Modifypassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Modifypassword(ModifypwViewModel model)
        {
            var usr = db.Users.SingleOrDefault(c => c.Username == model.Username && c.Password == model.oldPassword);
            if (usr == null)
            {
                ModelState.AddModelError("", "密码错误");
            }
            else
            {
                db.Users.SingleOrDefault(c => c.Username == model.Username && c.Password == model.oldPassword).Password = model.NewPassword;
                db.SaveChanges();
                return RedirectToAction("Index", "Account");
            }
            return View();
        }

        // GET: Accoutn/Evaluated
        public ActionResult Evaluated()
        {
            return View();
        }

        // GET: Accoutn/AccountBalance
        public ActionResult AccountBalance()
        {
            return View();
        }

        // GET: Accoutn/Addresses
        public ActionResult Addresses()
        {
            return View();
        }
        // Post: Account/Addresses
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Addresses(AdderssesViewModel model)
        {
            var tmpId = int.Parse(System.Web.HttpContext.Current.User.Identity.Name.Trim());
            var usr = db.Users.SingleOrDefault(c => c.Id == tmpId);
            string tmpstr = model.rIndex + model.rLongIndex;

            var usrAddr = db.Addresses.Where(c => c.UserId == usr.Id && c.AddressInfo.Equals(tmpstr));
            if(usrAddr.Count() == 0)
            {
                var usrNewAddr = new Address();
                usrNewAddr.AddressInfo = tmpstr;
                usrNewAddr.UserId = usr.Id;
                usr.RoomNum = model.rLongIndex;
                usr.School = model.rIndex;

                db.Addresses.Add(usrNewAddr);
                db.SaveChanges();
                return RedirectToAction("Addresses", "Account");
            }
            return RedirectToAction("Addresses", "Account");
        }

        // GET: Accoutn/RecentOrder
        public ActionResult RecentOrder()
        {
            return View();
        }

        // GET: Accoutn/RedPacket
        public ActionResult RedPacket()
        {
            return View();
        }
    }
}