using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book_Addict.Controllers
{
    public class AuthorController : Controller
    {
        public ActionResult Detail(string id)
        {
            if (id != null)
            {
                Author author = new Author { ID = id };
                author = AuthorService.GetAuthor(author);
                if (author != null)
                    return View(author);
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