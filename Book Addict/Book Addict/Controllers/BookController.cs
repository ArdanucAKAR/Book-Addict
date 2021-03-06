﻿using System;
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
                book = BookService.GetBook(book);
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

        public ActionResult Category(string id)
        {
            if (id != null)
            {
                Category category = new Category { ID = id };
                List<Book> books = BookService.GetBooksByCategory(category);
                if (category != null)
                    return View(books);
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