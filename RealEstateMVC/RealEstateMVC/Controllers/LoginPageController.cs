using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using RealEstateMVC.Models;
namespace RealEstateMVC.Controllers
{
    public class LoginPageController : Controller
    {
        private RealEstateEntities db = new RealEstateEntities();
        // GET: LoginPage

        
        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Login(User user)
        {
            var nuser = db.Users.FirstOrDefault(x => x.username == user.username && x.password == user.password);
            if (nuser != null)
            {
                FormsAuthentication.SetAuthCookie(nuser.username,false);
                return RedirectToAction("Index","Admin");
            }
            else
            {
                ViewBag.message = "Wrong username or password.";
               
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }

     
    }
}