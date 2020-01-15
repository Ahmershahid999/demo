using AuthenticationPart_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AuthenticationPart_1.Models;

namespace AuthenticationPart_1.Controllers
{
   [AllowAnonymous]
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            AuthenticationDBEntities db = new AuthenticationDBEntities();
            var data = db.Users.Where(x => x.Username == user.Username && x.Password == user.Password).Count();
            if (data == 0)
            {
                ViewBag.msg = "Invalid User";
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(user.Username, false);
                return RedirectToAction("Index","Home");
            }
            //return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }

}
