using LibraryWithMVC.Models.Entity;
using System.Collections.Generic;
using System.Linq;
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
            List<SelectListItem> authors = (from x in db.tbl_author.ToList()
                                            select new SelectListItem
                                            {
                                                Text = (x.ath_name + " " + x.ath_surname),
                                                Value = x.ath_id.ToString()
                                            }).ToList();
            ViewBag.Authors = authors;

            List<SelectListItem> categories = (from x in db.tbl_category
                                               select new SelectListItem
                                               {
                                                   Text = x.ctg_name,
                                                   Value = x.ctg_id.ToString()
                                               }).ToList();
            ViewBag.Categories = categories;

            return View();
        }

        [HttpPost]
        public ActionResult AddBook(tbl_book book)
        {
            db.tbl_book.Add(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}