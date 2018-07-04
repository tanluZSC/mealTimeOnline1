using System.Linq;
using System.Web.Mvc;
using MealTimeOnline.ViewModels.Auth;
using MealTimeOnline.DataAccessLayer;
using System.Web.Security;
using MealTimeOnline.Models;

namespace MealTimeOnline.Controllers
{
    [Authorize]
    public class AuthController : Controller
    {
        MtoDataContext db = new MtoDataContext();

        // GET: Auth/Login
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        // POST: Auth/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel login, string returnUrl) // [Bind(Include = "Username,Password,Remenber")]
        {
            if (ModelState.IsValid)
            {
                var usr = db.Users.SingleOrDefault(c => c.Username == login.Username && c.Password == login.Password);
                var tmpchar = "Admin";
                if (usr != null && login.Username.Equals(tmpchar) == true)
                {
                    FormsAuthentication.SetAuthCookie(usr.Id.ToString(), true);
                    return RedirectToAction("Home", "Admin");
                }
                else if (usr == null)
                {
                    ModelState.AddModelError("", "用户名或密码错误");
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(usr.Id.ToString(), true);
                    return Redirect(returnUrl ?? Url.Action("Index", "Home"));
                }
            }
            return View();
        }

        // GET: Auth/Logout
        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        // GET: Auth/SignUp
        [HttpGet]
        [AllowAnonymous]
        public ActionResult SignUp()
        {
            return View();
        }

        // Post: Auth/SignUp
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult SignUp(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (db.Users.Where(c => c.Username == model.Username).Count() > 0)
                {
                    ModelState.AddModelError("", "用户已存在");
                }
                else if (db.Users.Where(c => c.Email == model.Email).Count() > 0)
                {
                    ModelState.AddModelError("", "该邮箱已被注册");
                }
                else
                {
                    var usr = new User();
                    usr.Username = model.Username;
                    usr.Password = model.Password;
                    usr.PhoneNumber = model.Phone;
                    usr.Email = model.Email;
                    usr.Age = 0;
                    usr.RoleId = db.Roles.First(c => c.Slug == "User").RoleId;
                    usr.Sex = Sex.None;
                    usr.Money = 0;
                    usr.Credits = 0;

                    db.Users.Add(usr);
                    db.SaveChanges();
                    FormsAuthentication.SetAuthCookie(usr.Id.ToString(), true);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}