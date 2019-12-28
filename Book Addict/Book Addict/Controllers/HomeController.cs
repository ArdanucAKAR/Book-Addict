using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book_Addict.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (UserService.CheckToken() != null)
                return View(BookService.GetBooks());
            else
                return RedirectToAction("Login");
        }

        public ActionResult SavingRegisterData()
        {
            NewUserFavourite nuf = new NewUserFavourite();
            nuf.Books = BookService.GetBooks();
            nuf.Categories = DataService.GetCategories();
            nuf.Authors = AuthorService.GetAuthors();
            ViewData["check"] = false;
            return View(nuf);
        }

        public ActionResult ShowData(List<string> categoryId)
        {
            return View();
        }
    }
}