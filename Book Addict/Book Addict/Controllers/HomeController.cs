using Book_Addict.Models;
using Book_Addict.Models.Services;
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
            return RedirectToAction("SavingRegisterData");
        }
        public ActionResult SavingRegisterData()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.Books = DataService.GetBooks();
            mymodel.Categories = DataService.GetCategories();
            mymodel.Authors = DataService.GetAuthors();

            return View(mymodel);
        }
    }
}