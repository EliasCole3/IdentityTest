using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdentityTest.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Web;


namespace IdentityTest.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            string temp = user.Password;
            var userStore = new UserStore<IdentityUser>();
            var manager = new UserManager<IdentityUser>(userStore);

            var user2 = new IdentityUser() { UserName = user.Username };
            IdentityResult result = manager.Create(user2, user.Password);

            if (result.Succeeded)
            {
                TempData["message"] = "Identity user create worked";

                //var temp2 =  this.ControllerContext.HttpContext;
                var authenticationManager = HttpContext.GetOwinContext().Authentication;
                //var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = manager.CreateIdentity(user2, DefaultAuthenticationTypes.ApplicationCookie);
                authenticationManager.SignIn(new AuthenticationProperties() { }, userIdentity);
                //Response.Redirect("~/Login.aspx");
                //return View("Login");
                return View("Index");
            }
            else
            {
                TempData["message"] = "Failed: " + result.Errors.FirstOrDefault();
            }
            return View("Index");
        }

    }
}
