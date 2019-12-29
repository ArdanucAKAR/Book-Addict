using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Book_Addict.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            if (UserService.CheckToken() != null)
                return View();
            else
                return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            user.Login();
            return RedirectToAction("Index", "Home", null);
        }

        public ActionResult Logout(User user)
        {
            UserService.Logout();
            return RedirectToAction("Index", "Home", null);
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            user.Add();
            return RedirectToAction("Index", "Home", null);
        }

        [HttpPost]
        public void AddFavouriteAuthor(Author author)
        {
            Singleton.GetInstance().User.AddFavouriteAuthor(author);
        }

        [HttpPost]
        public void AddFavouriteBook() { }

        [HttpPost]
        public void AddFavouriteBookCategory() { }

        public ActionResult Detail(string id)
        {
            if (id != null)
            {
                User user = new User { ID = id };
                user = UserService.GetUser(user);
                if (user != null)
                    return View(user);
                else
                    return Redirect("Error/404");
            }
            else
            {
                if (Request.UrlReferrer != null)
                    return Redirect(Request.UrlReferrer.ToString());
                else
                    return RedirectToAction("Index", "Home");
            }
        }
    }
}