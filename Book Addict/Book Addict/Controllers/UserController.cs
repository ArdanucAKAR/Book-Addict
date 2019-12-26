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
                    return RedirectToAction("Index");
            }
            else
                return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            UserService.Login(user);
            return RedirectToAction("Index");
        }

        public ActionResult Register()
        {
            if (UserService.CheckToken() != null)
            {
                if (Request.UrlReferrer != null)
                    return Redirect(Request.UrlReferrer.ToString());
                else
                    return RedirectToAction("Index");
            }
            else
                return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            UserService.Register(user);
            return RedirectToAction("Index");
        }
    }
}