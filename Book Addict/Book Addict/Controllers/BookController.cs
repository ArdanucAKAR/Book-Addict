using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book_Addict.Controllers
{
    public class BookController : Controller
    {
        public ActionResult Detail(string id)
        {
            if (id != null)
            {
                Book book = new Book { ID = id };
                book = DataService.GetBook(book);
                if (book != null)
                    return View(book);
                else
                    return Redirect("Error/404");
            }
            else
            {
                if (Request.UrlReferrer != null)
                    return Redirect(Request.UrlReferrer.ToString());
                else
                    return RedirectToAction("Index");
            }
        }
    }
}