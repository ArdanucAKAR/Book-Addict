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

        public ActionResult Login()
        {
            if (UserService.CheckToken() != null)
            {
                if (Request.UrlReferrer != null)
                    return Redirect(Request.UrlReferrer.ToString());
                else
                    return RedirectToAction("Index", "Home");
            }
            else
                return View();
        }

        [HttpPost]
        public JavaScriptResult Login(User user)
        {
            if (user.Login() != null)
            {
                return JavaScript("window.location = '" + Url.Action("Index", "Home") + "'");
            }
            return JavaScript("document.getElementById('result').innerHTML = 'Kullanıcı Adı veya Şifre Yanlış'");
        }

        public ActionResult Register()
        {
            if (UserService.CheckToken() != null)
            {
                if (Request.UrlReferrer != null)
                    return Redirect(Request.UrlReferrer.ToString());
                else
                    return RedirectToAction("Index", "Home");
            }
            else
                return View();
        }

        [HttpPost]
        public JavaScriptResult Register(User user)
        {
            if (user.Register() != null)
            {
                return JavaScript("window.location = '" + Url.Action("SavingRegisterData", "Home") + "'");
            }
            return JavaScript("alert('hata')");
        }

        [HttpPost]
        public void AddFavouriteAuthor(Author author)
        {
            Singleton.Instance.User.AddFavouriteAuthor(author);
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