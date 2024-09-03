﻿using LibraryWithMVC.Models.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web.Mvc;

namespace LibraryWithMVC.Controllers
{
    public class BookController : Controller
    {
        DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities();
        // GET: Book
        public ActionResult Index()
        {
            return View(db.tbl_book.ToList());
        }

        // GET:AddBook
        [HttpGet]
        public ActionResult AddBook()
        {
            //SelectList books = db.tbl_book.Select(x => x.tbl_category.ctg_id == x.bk_ctg,);

            return View();
        }

        [HttpPost]
        public ActionResult AddBook(tbl_book book)
        {
            return View();
        }
    }
}