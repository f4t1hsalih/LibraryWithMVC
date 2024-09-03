using LibraryWithMVC.Models.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LibraryWithMVC.Controllers
{
    public class BookController : Controller
    {
        DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities();

        public void DropDownValues()
        {
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
        }

        // GET: Book
        public ActionResult Index(string p)
        {
            var books = from k in db.tbl_book select k;
            if (!string.IsNullOrEmpty(p))
            {
                books = books.Where(m => m.bk_name.Contains(p));
            }
            return View(books.ToList());
        }

        // GET:AddBook
        [HttpGet]
        public ActionResult AddBook()
        {
            DropDownValues();

            return View();
        }

        [HttpPost]
        public ActionResult AddBook(tbl_book book)
        {
            book.bk_status = true;
            db.tbl_book.Add(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET: DeleteBook
        public ActionResult DeleteBook(int id)
        {
            var book = db.tbl_book.Find(id);
            db.tbl_book.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET :EditBook
        [HttpGet]
        public ActionResult EditBook(int id)
        {
            DropDownValues();

            var values = db.tbl_book.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult EditBook(tbl_book book)
        {
            db.Entry(book).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}